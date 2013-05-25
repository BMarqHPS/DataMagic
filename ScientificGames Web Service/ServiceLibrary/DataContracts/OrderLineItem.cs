namespace ServiceLibrary.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OrderLineItem
    {
        [DataMember]
        public string OrderLineItemId { get; set; }

        [DataMember]
        public string ProductIdentifier { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string ShippingMethod { get; set; }

        [DataMember]
        public string GiftMessage { get; set; }
    }
}
