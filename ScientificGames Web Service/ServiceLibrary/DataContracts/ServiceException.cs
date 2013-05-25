namespace ServiceLibrary.DataContracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ServiceException
    {
        [DataMember]
        public string Severity { get; set; }

        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
