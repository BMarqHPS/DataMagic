namespace OrderProcessingLibrary.DataObjects
{
    using System;

    public class Package
    {
        private string multiItem;
        private string itemNum;
        private string itemDesc;
        private string signReq;


        public Package(int ID, Product objItem, Order objOrder, int orderItemId, Customer objCustInfo, string carrier)
        {
            BaseOrder = objOrder;
            CustInfo = objCustInfo;
            Carrier = carrier;
            PackageID = ID.ToString();
            PackageOrderNumber = objOrder.OrderNumber;
            PackageSubOrderNumber = orderItemId;

            itemNum = objItem.ItemNumber;
            itemDesc = objItem.Description;
            signReq = (objItem.SignatureRequired ? "Y" : "N");

            ShipMethod = objOrder.OrderItems[itemNum + "_" + orderItemId].OrderInfo.ShipMethod;
        }

        public Package(int ID, Order objOrder, Customer objCustInfo, OrderInfo objOrdInfo)
        {
            BaseOrder = objOrder;
            CustInfo = objCustInfo;
            PackageID = ID.ToString();
            PackageOrderNumber = objOrdInfo.OrderNumber;
            PackageSubOrderNumber = objOrdInfo.OrderItemId;
            ShipMethod = objOrdInfo.ShipMethod;
        }

        public Package(int ID, Package objPkg, Product objItem)
        {
            BaseOrder = objPkg.BaseOrder;
            CustInfo = objPkg.CustInfo;
            Carrier = objPkg.Carrier;
            PackageID = ID.ToString();
            PackageOrderNumber = objPkg.PackageOrderNumber;
            PackageSubOrderNumber = objPkg.PackageSubOrderNumber;

            itemNum = objItem.ItemNumber;
            itemDesc = objItem.Description;
            signReq = (objItem.SignatureRequired ? "Y" : "N");

            ShipMethod = objPkg.ShipMethod;
        }


        public Order BaseOrder { get; private set; }

        public Customer CustInfo { get; private set; }

        public string Carrier { get; private set; }

        public string PackageID { get; private set; }

        public string PackageOrderNumber { get; private set; }

        public int PackageSubOrderNumber { get; private set; }

        public string ShipMethod { get; private set; }

        public Single Weight { get; set; }

        public byte H { get; set; }

        public byte L { get; set; }

        public byte W { get; set; }


        public void AddItems(PackageItems pkgItems)
        {
            itemNum = pkgItems.ItemNumber;
            itemDesc = pkgItems.Description;

            H = pkgItems.H;
            L = pkgItems.L;
            W = pkgItems.W;

            Weight += pkgItems.TotalWeight;

            multiItem = pkgItems.MultipleItems;

            signReq = (pkgItems.SignatureRequired ? "Y" : "N");

            ShipMethod = pkgItems.ShipMethod;
        }

        public string OutputLine()
        {
            string lineOut;
            string service;
            var pkgID = "MDI" + PackageID.PadLeft(9, '0');

            if (Carrier == "UPS")
            {
                switch (ShipMethod)
                {
                    case "1DAY":
                        service = "Next Day Air";
                        break;
                    case "2DAY":
                        service = "2nd Day Air";
                        break;
                    default:
                        service = "Ground";
                        break;
                }

                // Format the output line for UPS package file.
                lineOut = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}," +
                                        "{11},{12},{13},{14},{15},{16},{17},{18},{19}," +
                                        "{20},{21},{22},{23},{24},{25},{26},{27},{28}," +
                                        "{29},{30},{31},{32},{33},{34},{35},{36},{37},{38}",
                                        BaseOrder.Account, PackageOrderNumber, "0", "", "0", itemNum, itemDesc,
                                        CustInfo.FirstName, "", CustInfo.LastName, CustInfo.Address, CustInfo.Address2,
                                        CustInfo.City, CustInfo.State, CustInfo.Zip, "USA", CustInfo.Phone,
                                        DateTime.Now.ToString("M/d/yyyy H:mm"), "S", "", "", "0",
                                        BaseOrder.Gift, pkgID, CustInfo.Attention, Weight, "PACKAGE", "PREPAID", "Y",
                                        service, "UPS", multiItem, signReq, signReq, L, W, H, PackageSubOrderNumber,
                                        BaseOrder.OrderId);

            }
            else
            {
                service = Weight <= 0.8125 ? "@@04" : "@@02";

                // Format the output line for USMail package file.
                lineOut = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}," +
                                        "{11},{12},{13},{14},{15},{16},{17},{18},{19}," +
                                        "{20},{21},{22},{23},{24},{25},{26},{27},{28}," +
                                        "{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39}",
                                        BaseOrder.Account, PackageOrderNumber, "0", "", "0", itemNum, itemDesc,
                                        CustInfo.FirstName, "", CustInfo.LastName, CustInfo.Address, CustInfo.Address2,
                                        CustInfo.City, CustInfo.State, CustInfo.Zip, "USA", CustInfo.Phone,
                                        DateTime.Now.ToString("M/d/yyyy H:mm"), "S", "", "", "0",
                                        BaseOrder.Gift, pkgID, CustInfo.Attention, Weight, "PACKAGE", "PREPAID", "Y",
                                        service, "UPS", multiItem, signReq, signReq, L, W, H, "USP",
                                        PackageSubOrderNumber,
                                        BaseOrder.OrderId);
            }

            return lineOut;
        }

        public void SetCarrier(Products itemList)
        {
            if (CustInfo.POBox)
            {
                // Must use US Mail for PO Box addresses.
                Carrier = "USPS";
                return;
            }

            if (multiItem == "M")
            {
                // Must use UPS for multiple item packages.
                Carrier = "UPS";
                return;
            }

            // Single item package carrier determined by flag on item.
            Carrier = (itemList.GetItem(itemNum).ShipUSMail ? "USPS" : "UPS");
        }

        public void SetDimensions(Product item)
        {
            H = item.H;
            W = item.W;
            L = item.L;
        }
    }
}
