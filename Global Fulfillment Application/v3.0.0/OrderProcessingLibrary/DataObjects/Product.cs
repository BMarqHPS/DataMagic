namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class Product
    {
        public Product(string itemNo)
        {
            ItemNumber = itemNo;
        }

        public Product(XmlNode itemNode)
        {
            var weightNode = itemNode.SelectSingleNode("Weight");
            var subItemsNode = itemNode.SelectSingleNode("SubItems");

            SubItems = new List<string>();

            // ReSharper disable PossibleNullReferenceException
            ItemNumber = itemNode.Attributes["ItemNum"].Value;
            Description = itemNode.Attributes["Description"].Value;
            H = byte.Parse(itemNode.Attributes["H"].Value);
            L = byte.Parse(itemNode.Attributes["L"].Value);
            W = byte.Parse(itemNode.Attributes["W"].Value);
            SinglePack = bool.Parse(itemNode.Attributes["SinglePack"].Value);
            SignatureRequired = bool.Parse(itemNode.Attributes["SignReq"].Value);
            ShipUSMail = bool.Parse(itemNode.Attributes["USMail"].Value);
            PackingException = bool.Parse(itemNode.Attributes["PackingException"].Value);

            Weight = Single.Parse(weightNode.Attributes["WeightForOne"].Value);
            PackagingWeight = Single.Parse(weightNode.Attributes["PackagingWeight"].Value);

            if (subItemsNode.HasChildNodes)
            {
                foreach (XmlElement subItem in subItemsNode)
                {
                    SubItems.Add(subItem.InnerText);
                }
            }
            // ReSharper restore PossibleNullReferenceException
        }

        public IList<string> SubItems { get; set; }

        public Single PackagingWeight { get; set; }

        public Single Weight { get; set; }

        public bool PackingException { get; set; }

        public bool ShipUSMail { get; set; }

        public bool SignatureRequired { get; set; }

        public bool SinglePack { get; set; }

        public byte W { get; set; }

        public byte L { get; set; }

        public byte H { get; set; }

        public string Description { get; set; }

        public string ItemNumber { get; set; }

        public bool IsKit { get { return SubItems.Count > 0; } }

        public int CubicSize { get { return H * W * L; } }

        public bool HasDimensions { get { return H != 0 || L != 0 || W != 0; } }

        public Single GetWeightByQty(int quantity)
        {
            return ((Weight - PackagingWeight)*quantity) + PackagingWeight;
        }

        public string PropertyList()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("\t\t\t\tDesc: {0}, ", Description);
            sb.AppendFormat("H: {0}, ", H);
            sb.AppendFormat("W: {0}, ", W);
            sb.AppendFormat("L: {0}, ", L);
            sb.AppendFormat("Weight: {0}, ", Weight);
            sb.AppendFormat("PkgWeight: {0}", PackagingWeight);
            sb.AppendLine();
            sb.AppendFormat("\t\t\t\tSinglePack: {0}, ", SinglePack);
            sb.AppendFormat("ShipByMail: {0}, ", ShipUSMail);
            sb.AppendFormat("PackException: {0}, ", PackingException);
            sb.AppendFormat("SignRequired: {0}, ", SignatureRequired);
            sb.AppendFormat("IsKit: {0}", SubItems.Count == 0 ? "False" : "True");
            if (SubItems.Count != 0)
            {
                var items = String.Join(",", SubItems.ToArray());
                sb.AppendFormat("\t\t\t\tSubItems : {0}", items);
            }

            return sb.ToString();
        }
    }
}
