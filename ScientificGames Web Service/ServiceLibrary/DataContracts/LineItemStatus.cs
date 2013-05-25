namespace ServiceLibrary.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LineItemStatus
    {
        [DataMember]
        public string OrderLineItemId { get; set; }

        [DataMember]
        public string ProductIdentifier { get; set; }

        [DataMember]
        public int QtyReserved { get; set; }
    }
}
