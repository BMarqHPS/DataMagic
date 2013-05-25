namespace ServiceLibrary.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ShippingInfoResult
    {
        [DataMember]
        public List<ItemTracking> Manifests { get; set; }

        [DataMember]
        public bool HasException { get; set; }

        [DataMember]
        public ServiceException Exception { get; set; }
    }
}
