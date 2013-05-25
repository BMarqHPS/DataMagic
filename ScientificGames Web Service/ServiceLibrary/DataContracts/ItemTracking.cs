namespace ServiceLibrary.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ItemTracking
    {
        [DataMember]
        public string OrderLineItemId { get; set; }

        [DataMember]
        public string Carrier { get; set; }

        [DataMember]
        public DateTime ShipDate { get; set; }

        [DataMember]
        public DateTime RecvDate { get; set; }

        [DataMember]
        public string TrackingNumber { get; set; }

        [DataMember]
        public string TrackingUrl { get; set; }
    }
}
