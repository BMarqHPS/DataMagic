namespace ServiceLibrary.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class OrderStatusRequest
    {
        [DataMember]
        public string OrderNumber { get; set; }
    }
}
