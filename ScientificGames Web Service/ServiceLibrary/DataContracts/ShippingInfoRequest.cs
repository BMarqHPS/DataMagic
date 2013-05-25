namespace ServiceLibrary.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class ShippingInfoRequest
    {
        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }
    }
}
