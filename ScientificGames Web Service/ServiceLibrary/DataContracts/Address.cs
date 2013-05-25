namespace ServiceLibrary.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Address
    {
        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Zip { get; set; }
    }
}
