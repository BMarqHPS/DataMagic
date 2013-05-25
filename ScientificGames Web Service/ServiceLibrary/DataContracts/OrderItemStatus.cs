namespace ServiceLibrary.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class OrderItemStatus
    {
        [DataMember]
        public string OrderlineItemId { get; set; }

        [DataMember]
        public string ProductIdentifier { get; set; }

        [DataMember]
        public int QtyOrdered { get; set; }

        [DataMember]
        public int QtyShipped { get; set; }

        [DataMember]
        public int QtyCancelled { get; set; }

        [DataMember]
        public int QtyBackordered { get; set; }

        [DataMember]
        public List<ItemTracking> TrackingInformation { get; set; }
    }
}
