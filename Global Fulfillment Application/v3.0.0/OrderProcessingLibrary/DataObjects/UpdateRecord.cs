namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Xml;

    public class UpdateRecord
    {
        //  Sample of Package/Order node:
        //
        //  <Package ID="MDI000878779" Key="MA-0064NBA03d00400697_1010286">
        //    <Orders>
        //      <Order OrderNum="MA-0064NBA03d00400697" OrderID="418116" OrderItemID="1010286" Quantity="1"/>
        //      <Order OrderNum="MA-0064NBA03d00400408" OrderID="417827" OrderItemID="1010274" Quantity="2" />
        //      <Order OrderNum="MA-0064NBA03d00400569" OrderID="417988" OrderItemID="1010670" Quantity="1" />
        //    </Orders>
        //  </Package>

        public UpdateRecord (ManifestRecord manifestRecord, XmlNode orderNode)
        {
            // ReSharper disable PossibleNullReferenceException
            OrderId = Convert.ToInt32(orderNode.Attributes["OrderID"].Value);
            OrderItemId = Convert.ToInt32(orderNode.Attributes["OrderItemID"].Value);
            QuantityShipped = Convert.ToInt32(orderNode.Attributes["Qty"].Value);
            Carrier = manifestRecord.Carrier;
            TrackingNumber = manifestRecord.TrackingNumber;
            // ReSharper restore PossibleNullReferenceException
        }


        public int OrderId { get; private set; }

        public int OrderItemId { get; private set; }

        public int QuantityShipped { get; private set; }

        public int QuantityCancelled { get { return 0; } }

        public int QuantityBackordered { get { return 0; } }

        public string Carrier { get; private set; }

        public DateTime ShipDate { get { return DateTime.Today; } }

        public string TrackingNumber { get; private set; }

        public string Key { get { return String.Format("{0}/{1}", OrderId, OrderItemId); } }
    }
}
