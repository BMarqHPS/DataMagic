namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Xml;

    using Exceptions;
    using Utilities;
    using Logger = Utilities.LogFileListener;
    using Settings = Utilities.AppSettings;

    public class OrdersToPackages : XmlDocument
    {
        private readonly string pathFileName;
        private XmlNode root;


        public OrdersToPackages(byte style)
        {
            pathFileName = Settings.AppPath + @"\XRefOrders2Packages.xml";
            pathFileName = pathFileName.Replace("file:\\", "");
            if (style == NewStyle.Init)
            {
                InitializeDocument();
                Logger.Log("XRefOrders2Packages.xml has been initialized.", LogLevel.Verbose);
            }
            else
            {
                LoadDocument();
                Logger.Log("XRefOrders2Packages.xml has been loaded.", LogLevel.Verbose);
            }
        }


        private void LoadDocument()
        {
            try
            {
                Load(pathFileName);
                root = DocumentElement;
            }
            catch (Exception ex)
            {
                throw new XRefXmlException("Failed to load XRefOrders2Packages.xml!", ex);
            }
        }

        private void InitializeDocument()
        {
            try
            {
                CreateXmlDeclaration("1.0", "utf-8", null);
                AppendChild(CreateNode(XmlNodeType.Element, null, "Packages", null));
                Save(pathFileName);
                root = DocumentElement;
            }
            catch (Exception ex)
            {
                throw new XRefXmlException("Initialization of OrdersToPackages failed!", ex);
            }
        }

        private XmlAttribute CreateAttributeWithValue(string attrName, string attrValue)
        {
            var attr = CreateAttribute(attrName);
            attr.Value = attrValue;
            return attr;
        }


        public void AddOrderNode(XmlNode pkgNode, OrderInfo ordInfo, int quantity)
        {
            // Layout of Order node: <Order OrderNum="" OrderID="" OrderItemID="" />
            try
            {
                // ReSharper disable PossibleNullReferenceException
                var ordersNode = pkgNode.SelectSingleNode("Orders");
                var orderNode = CreateNode(XmlNodeType.Element, null, "Order", null);
                orderNode.Attributes.Append(CreateAttributeWithValue("OrderNum", ordInfo.OrderNumber));
                orderNode.Attributes.Append(CreateAttributeWithValue("OrderID", ordInfo.OrderId.ToString()));
                orderNode.Attributes.Append(CreateAttributeWithValue("OrderItemID", ordInfo.OrderItemId.ToString()));
                orderNode.Attributes.Append(CreateAttributeWithValue("Qty", quantity.ToString()));
                ordersNode.AppendChild(orderNode);
                // ReSharper restore PossibleNullReferenceException
            }
            catch (Exception ex)
            {
                throw new XRefXmlException("Failed to add order node to XRefOrders2Packages.xml", ex);
            }
        }

        public void AddPackageNode(XmlNode objNode)
        {
            try
            {
                root.AppendChild(objNode);
            }
            catch (Exception ex)
            {
                throw new XRefXmlException("Failed to add package node to XRefOrders2Packages.xml", ex);
            }
        }

        public XmlNode CreatePackageNode(int ID, OrderInfo objOrdInfo)
        {
            // Layout of Package node:   <Package ID="MDI00012345" Key="">
            //                                <Orders>
            //                                    <Order OrderNum="" OrderID="" OrderItemID="" />
            //                                </Orders>
            //                            </Package>

            var pkgID = "MDI" + ID.ToString().PadLeft(9, '0');

            try
            {

                // Construct the key for this package (this will correspond later with the key built
                // from the manifest lines).
                var key = String.Format("{0}_{1}", objOrdInfo.OrderNumber, objOrdInfo.OrderItemId);

                // ReSharper disable PossibleNullReferenceException
                var tempNode = CreateNode(XmlNodeType.Element, null, "Package", null);
                tempNode.Attributes.Append(CreateAttributeWithValue("ID", pkgID));
                tempNode.Attributes.Append(CreateAttributeWithValue("Key", key));

                // Create/append an Orders child node (this will contain the individual Order elements).
                tempNode.AppendChild(CreateNode(XmlNodeType.Element, null, "Orders", null));

                return tempNode;
                // ReSharper restore PossibleNullReferenceException
            }
            catch (Exception ex)
            {
                throw new XRefXmlException("Failed to create new package node for ID '" + pkgID + "'!", ex);
            }
        }

        public XmlNode GetPackage(string key)
        {
            try
            {
                // <Package ID="MDI00012345" Key="" ShipDate="">
                return root.SelectSingleNode(@"//Package[@Key='" + key + "']");
            }
            catch (Exception ex)
            {
                throw new XRefXmlException("Failed to get package node for Key '" + key + "'!", ex);
            }
        }

        public void SaveDocument()
        {
            Save(pathFileName);
        }

    }

    public class NewStyle
    {
        public const byte Init = 0;
        public const byte Load = 1;
    }
}
