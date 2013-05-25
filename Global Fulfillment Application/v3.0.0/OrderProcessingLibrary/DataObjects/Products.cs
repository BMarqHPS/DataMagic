namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Exceptions;
    using Logger = Utilities.LogFileListener;

    public class Products : XmlDocument
    {
        private XmlNode currentItemNode;
        private IList<string> itemNos;
        private string matchValue = "";
        private XmlNode root;
        private string xmlFileName;

        private XmlAttribute CreateAttributeWithValue(string attrName, string attrValue)
        {
            var attribute = CreateAttribute(attrName);
            attribute.Value = attrValue;
            return attribute;
        }

        private XmlNode CreateItemNode(Product objItem)
        {
            var newItem = CreateNode(XmlNodeType.Element, "Item", null);
            var weight = CreateNode(XmlNodeType.Element, "Weight", null);
            var subItems = CreateNode(XmlNodeType.Element, "SubItems", null);

            // ReSharper disable PossibleNullReferenceException
            newItem.Attributes.Append(CreateAttributeWithValue("ItemNum", objItem.ItemNumber));
            newItem.Attributes.Append(CreateAttributeWithValue("Description", objItem.Description));
            newItem.Attributes.Append(CreateAttributeWithValue("L", objItem.L.ToString()));
            newItem.Attributes.Append(CreateAttributeWithValue("W", objItem.W.ToString()));
            newItem.Attributes.Append(CreateAttributeWithValue("H", objItem.H.ToString()));
            newItem.Attributes.Append(CreateAttributeWithValue("SinglePack", objItem.SinglePack ? "true" : "false"));
            newItem.Attributes.Append(CreateAttributeWithValue("SignReq", objItem.SignatureRequired ? "true" : "false"));
            newItem.Attributes.Append(CreateAttributeWithValue("USMail", objItem.ShipUSMail ? "true" : "false"));
            newItem.Attributes.Append(CreateAttributeWithValue("PackingException",
                                                               objItem.PackingException ? "true" : "false"));

            weight.Attributes.Append(CreateAttributeWithValue("WeightForOne", objItem.Weight.ToString()));
            weight.Attributes.Append(CreateAttributeWithValue("PackagingWeight", objItem.PackagingWeight.ToString()));

            if (objItem.IsKit)
            {
                foreach (var subItemNum in objItem.SubItems)
                {
                    var subItem = CreateNode(XmlNodeType.Element, "SubItem", null);
                    subItem.InnerText = subItemNum;
                    subItems.AppendChild(subItem);
                }
            }

            newItem.AppendChild(weight);
            newItem.AppendChild(subItems);

            return newItem;
            // ReSharper restore PossibleNullReferenceException
        }

        private int GetLastIndex()
        {
            // ReSharper disable StringCompareIsCultureSpecific.1
            foreach (var itemNo in itemNos.Where(itemNo => String.Compare(itemNo, matchValue) > 0))
            {
                return itemNos.IndexOf(itemNo) - 1; // TODO: Verify the -1 works as expected.
            }
            return -1;
            // ReSharper restore StringCompareIsCultureSpecific.1
        }


        public bool AtFirstItem
        {
            get { return currentItemNode.Equals(root.FirstChild); }
        }

        public bool AtLastItem
        {
            get { return currentItemNode.Equals(root.LastChild); }
        }


        public bool ListLoaded { get; private set; }

        public void AddItem(Product objItem)
        {
            if (Exists(objItem.ItemNumber))
                throw new DuplicateItemException(objItem.ItemNumber);

            try
            {

                var newItem = CreateItemNode(objItem);

                matchValue = objItem.ItemNumber;
                var i = GetLastIndex();

                if (i == -1)
                {
                    root.AppendChild(newItem);
                }
                else
                {
                    var itemNum = itemNos[i];
                    currentItemNode = root.SelectSingleNode("//Item[@ItemNum='" + itemNum + "']");
                    root.InsertAfter(newItem, currentItemNode);
                }

                itemNos.Insert(i + 1, objItem.ItemNumber);

                Save(xmlFileName);

                Logger.Log(String.Format("Item '{0}' has been added to the list.", objItem.ItemNumber));
                Logger.Log(String.Format("\tValues -\n{0}", objItem.PropertyList()));

                currentItemNode = root.SelectSingleNode("//Item[@ItemNum='" + objItem.ItemNumber + "']");

            }
            catch (Exception ex)
            {
                throw new ItemMaintenanceException("Add item failed!", ex);
            }
        }

        public Product CurrentItem()
        {
            return new Product(currentItemNode);
        }

        public bool Exists(string itemNo)
        {
            return itemNos.Contains(itemNo);
        }

        public Product FirstItem()
        {
            currentItemNode = root.FirstChild;
            return new Product(currentItemNode);
        }

        public Product GetItem(string itemNo)
        {
            if (itemNos.Contains(itemNo))
            {
                currentItemNode = root.SelectSingleNode("//Item[@ItemNum='" + itemNo + "']");
                return new Product(currentItemNode);
            }

            return null;
        }

        public Product GetNextItem(string itemNo)
        {
            try
            {
                matchValue = itemNo;
                var i = GetLastIndex();
                var itemNum = itemNos[i];

                currentItemNode = root.SelectSingleNode("//Item[@ItemNum='" + itemNum + "']");
            }
            catch (Exception)
            {
                currentItemNode = root.LastChild;
            }

            return new Product(currentItemNode);
        }

        public Product NextItem()
        {
            currentItemNode = currentItemNode.NextSibling;
            return new Product(currentItemNode);
        }

        public Product PreviousItem()
        {
            currentItemNode = currentItemNode.PreviousSibling;
            return new Product(currentItemNode);
        }

        public void LoadItemList(string pathFileName)
        {
            xmlFileName = pathFileName;

            try
            {
                itemNos = new List<string>();

                Load(pathFileName);

                root = DocumentElement;

                if (root == null)
                    throw new Exception("A problem occurred while loading the item data; no root element was found.");

                if (!root.HasChildNodes)
                    throw new Exception(
                        "A problem occurred while loading the item data; root element contained no child nodes.");

                foreach (XmlNode node in root.ChildNodes)
                {
                    // ReSharper disable PossibleNullReferenceException
                    itemNos.Add(node.Attributes["ItemNum"].Value);
                    // ReSharper restore PossibleNullReferenceException
                }

                currentItemNode = root.FirstChild;
                ListLoaded = true;

                Logger.Log("Item list successfully loaded.");

            }
            catch (Exception ex)
            {
                throw new ItemDataLoadException("An exception occurred while loading the item data.", ex);
            }
        }

        public void RemoveItem(string itemNumber)
        {
            matchValue = itemNumber;

            try
            {
                var tempNode = currentItemNode;
                currentItemNode = tempNode.Equals(root.LastChild) ? currentItemNode.PreviousSibling : currentItemNode.NextSibling;

                root.RemoveChild(tempNode);
                Save(xmlFileName);

                var i = itemNos.IndexOf(itemNumber);
                itemNos.RemoveAt(i);

                Logger.Log(String.Format("Item '{0}' has been deleted.", itemNumber));
            }
            catch (Exception ex)
            {
                throw new ItemMaintenanceException("Unexpected exception occurred in RemoveItem.", ex);
            }
        }

        public void UpdateItem(Product item)
        {
            // ReSharper disable PossibleNullReferenceException

            if (currentItemNode.Attributes["ItemNum"].Value != item.ItemNumber)
                GetItem(item.ItemNumber);

            try
            {

                currentItemNode.Attributes["ItemNum"].Value = item.ItemNumber;
                currentItemNode.Attributes["Description"].Value = item.Description;
                currentItemNode.Attributes["L"].Value = item.L.ToString();
                currentItemNode.Attributes["W"].Value = item.W.ToString();
                currentItemNode.Attributes["H"].Value = item.H.ToString();
                currentItemNode.Attributes["SinglePack"].Value = item.SinglePack.ToString();
                currentItemNode.Attributes["SignReq"].Value = item.SignatureRequired.ToString();
                currentItemNode.Attributes["USMail"].Value = item.ShipUSMail.ToString();
                currentItemNode.Attributes["PackingException"].Value = item.PackingException.ToString();

                var weightNode = currentItemNode.SelectSingleNode("Weight");
                weightNode.Attributes["WeightForOne"].Value = item.Weight.ToString("0.00");
                weightNode.Attributes[""].Value = item.PackagingWeight.ToString();

                var newSubItemsNode = CreateNode(XmlNodeType.Element, "SubItems", null);
                if (item.IsKit)
                {
                    foreach (var itemNumber in item.SubItems)
                    {
                        var subItem = CreateNode(XmlNodeType.Element, "SubItem", null);
                        subItem.InnerText = itemNumber;
                        newSubItemsNode.AppendChild(subItem);
                    }
                }

                var oldSubItemsNode = currentItemNode.SelectSingleNode("SubItems");
                // ReSharper disable AssignNullToNotNullAttribute
                currentItemNode.ReplaceChild(newSubItemsNode, oldSubItemsNode);
                // ReSharper restore AssignNullToNotNullAttribute

                Logger.Log(String.Format("Item '{0}' has been updated.", item.ItemNumber));
                Logger.Log(String.Format("\tUpdated values - \n{0}", item.PropertyList()));

                Save(xmlFileName);

                // ReSharper restore PossibleNullReferenceException

            }
            catch (Exception ex)
            {
                throw new ItemMaintenanceException("An unexpected exception occurred during UpdateItem.", ex);
            }
        }
    }
}
