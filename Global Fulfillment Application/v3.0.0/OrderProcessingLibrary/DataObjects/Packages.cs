namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using Utilities;
    using Logger = Utilities.LogFileListener;
    using Settings = Utilities.AppSettings;

    public class Packages : Dictionary<string, Package>
    {
        public event Delegates.ProgressBar InitProgressBar;
        public event Delegates.ProgressBar IncrementProgressBar;
        public event Delegates.StatusBar UpdateStatusBar;


        private readonly Orders orderList;
        private readonly Customers custList;
        private readonly Products itemList;
        private int packageID;
        private readonly Dictionary<string, PrePackage> prePkgObjs = new Dictionary<string, PrePackage>();
        private readonly OrdersToPackages xrefList = new OrdersToPackages(NewStyle.Init);


        public Packages(Orders orderList, Customers custList, Products itemList)
        {
            this.orderList = orderList;
            this.custList = custList;
            this.itemList = itemList;
            packageID = AppSettings.PackageID;
        }


        public int UPSPackageCount { get; private set; }

        public int USMailPackageCount { get; private set; }


        public void CreatePackages()
        {
            Package shipPkg = null;

            InitProgressBar(this, new ProgressBarEventArgs(0, prePkgObjs.Values.Count + 1));

            foreach (var prePkg in prePkgObjs.Values)
            {
                IncrementProgressBar(this, new ProgressBarEventArgs());

                var objOrder = orderList[prePkg.Key];
                var objCustomer = custList[prePkg.CustomerKey];

                XmlNode pkgNode;
                if (prePkg.SinglePackItems.Count > 0)
                {
                    foreach (var objOrdItem in prePkg.SinglePackItems.Values)
                    {
                        pkgNode = xrefList.CreatePackageNode(packageID, objOrdItem.OrderInfo);
                        // ReSharper disable PossibleNullReferenceException
                        Logger.Log(String.Format("  Package node created, {0} - {1}",
                                                 pkgNode.Attributes["ID"].Value, pkgNode.Attributes["Key"].Value),
                                   LogLevel.Debug);
                        // ReSharper restore PossibleNullReferenceException

                        xrefList.AddOrderNode(pkgNode, objOrdItem.OrderInfo, objOrdItem.Quantity);
                        Logger.Log(String.Format("    Order line added, {0} - {1} - {2}",
                                                 objOrdItem.OrderInfo.OrderNumber, objOrdItem.OrderInfo.OrderItemId,
                                                 objOrdItem.OrderInfo.OrderId), LogLevel.Debug);

                        var objItem = objOrdItem.Item;
                        var shipUSMail = (objItem.ShipUSMail || objCustomer.POBox);
                        shipPkg = new Package(packageID, objItem, objOrder, objOrdItem.OrderInfo.OrderItemId,
                                              objCustomer, (shipUSMail ? "USPS" : "UPS"));

                        if (objItem.HasDimensions)
                            shipPkg.SetDimensions(objItem);

                        shipPkg.Weight = objItem.Weight;

                        Add(packageID.ToString(), shipPkg);
                        xrefList.AddPackageNode(pkgNode);

                        Logger.Log(String.Format("  Package node added, {0}", pkgNode.Attributes["ID"].Value),
                                   LogLevel.Debug);

                        packageID++;

                        if (objItem.IsKit)
                        {
                            {
                                for (int i = 0; i < objItem.SubItems.Count - 1; i++)
                                {
                                    var tempItem = itemList.GetItem(objItem.SubItems[i]);
                                    var newShipPkg = new Package(packageID, shipPkg, tempItem);

                                    if (tempItem.HasDimensions)
                                        newShipPkg.SetDimensions(tempItem);

                                    newShipPkg.Weight = tempItem.Weight;

                                    Add(packageID.ToString(), newShipPkg);

                                    packageID++;
                                }
                            }
                        }
                    }
                }

                pkgNode = null;

                foreach (var multiPackList in prePkg.MultiPackItems.Values)
                {
                    // ReSharper disable PossibleNullReferenceException
                    if (multiPackList.Count > 0)
                    {
                        var multiItemList = new PackageItems();
                        foreach (var objOrdItem in multiPackList.Values)
                        {
                            multiItemList.AddItem(objOrdItem);
                            if (pkgNode == null)
                            {
                                pkgNode = xrefList.CreatePackageNode(packageID, objOrdItem.OrderInfo);
                                shipPkg = new Package(packageID, objOrder, objCustomer, objOrdItem.OrderInfo);
                                Logger.Log(String.Format("  Package node created, {0} - {1}",
                                                         pkgNode.Attributes["ID"].Value, pkgNode.Attributes["Key"].Value),
                                           LogLevel.Debug);
                            }

                            xrefList.AddOrderNode(pkgNode, objOrdItem.OrderInfo, objOrdItem.Quantity);
                            Logger.Log(String.Format("    Order line added, {0} - {1} - {2}",
                                                     objOrdItem.OrderInfo.OrderNumber,
                                                     objOrdItem.OrderInfo.OrderItemId,
                                                     objOrdItem.OrderInfo.OrderId), LogLevel.Debug);
                        }

                        multiItemList.CalcWeightAndSize(itemList);
                        shipPkg.AddItems(multiItemList);
                        shipPkg.SetCarrier(itemList);
                        Add(packageID.ToString(), shipPkg);
                        xrefList.AddPackageNode(pkgNode);

                        Logger.Log(String.Format("  Package node added, {0}", pkgNode.Attributes["ID"].Value),
                                   LogLevel.Debug);

                        packageID++;
                    }

                    pkgNode = null;
                    // ReSharper restore PossibleNullReferenceException
                }
            }

            xrefList.SaveDocument();

            Settings.PackageID = packageID;
        }

        public void CreatePrePackages()
        {
            InitProgressBar(this, new ProgressBarEventArgs(0, custList.OrdersByCustomer.Values.Count));

            foreach (var objCustOrd in custList.OrdersByCustomer.Values)
            {
                PrePackage prePkg = null;

                foreach (var t in objCustOrd)
                {
                    IncrementProgressBar(this, new ProgressBarEventArgs());

                    if (orderList[t].HasPackingExceptionItems)
                    {
                        var preExceptPkg = new PrePackage(orderList[t].OrderNumber, objCustOrd.Key);
                        preExceptPkg.Add(orderList[t]);
                        preExceptPkg.BuildItemLists(itemList);
                        prePkgObjs.Add(preExceptPkg.Key, preExceptPkg);
                    }
                    else
                    {
                        if (prePkg == null)
                            prePkg = new PrePackage(orderList[t].OrderNumber, objCustOrd.Key);

                        prePkg.Add(orderList[t]);
                    }
                }
                if (prePkg != null)
                {
                    prePkg.BuildItemLists(itemList);
                    prePkgObjs.Add(prePkg.Key, prePkg);
                }
            }

        }

        public void WritePackageFiles(string upsPkgs, string usMailPkgs)
        {
            const string CarrierServiceHeader =
                "BPROJ,ORDERNO,BUORDERNO,SHIPDTE,BATCHNO,ITEM,ITMDESC,F_N,M_N,L_N,A,A_2,C,S,Z,COUNTRY,PH," +
                "EXPDATE,STATUS,CUSTNO,BINNO,VBINNO,GIFT,PACKAGEID,ATTN,WEIGHT,PackageType,BillingOption," +
                "Residential,Service,Shipping,MULTI,DELIVERYCONF,SIGN_REQ,Length,Width,Height,SubOrd,CertNo";

            var swUPS = new StreamWriter(upsPkgs);
            var swUSMail = new StreamWriter(usMailPkgs);

            swUPS.WriteLine(CarrierServiceHeader);

            //_pb.Maximum = Values.Count + 1;

            foreach (var pkg in Values)
            {
                //_pb.Increment(1);

                if (pkg.Carrier == "UPS")
                {
                    UPSPackageCount++;
                    swUPS.WriteLine(pkg.OutputLine());
                }
                else
                {
                    USMailPackageCount++;
                    swUSMail.WriteLine(pkg.OutputLine());
                }
            }

            swUPS.Flush();
            swUPS.Close();
            swUPS.Dispose();

            swUSMail.Flush();
            swUSMail.Close();
            swUSMail.Dispose();
        }
    }
}
