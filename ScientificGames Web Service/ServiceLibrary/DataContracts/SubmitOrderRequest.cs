namespace ServiceLibrary.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class SubmitOrderRequest
    {
        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public IList<OrderLineItem> LineItems { get; set; }

        [DataMember(Name = "ShipToFirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "ShipToLastName")]
        public string LastName { get; set; }

        [DataMember(Name = "ShipToAddress")]
        public Address Address { get; set; }

        [DataMember(Name = "ShipToPhone")]
        public string Phone { get; set; }
    }
}
