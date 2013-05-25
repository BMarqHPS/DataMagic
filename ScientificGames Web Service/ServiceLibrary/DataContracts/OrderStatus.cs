namespace ServiceLibrary.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class OrderStatus
    {
        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public bool HasException { get; set; }

        [DataMember]
        public Exception Exception { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public IList<OrderItemStatus> ItemStatuses { get; set; }
    }
}
