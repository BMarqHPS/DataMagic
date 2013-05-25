namespace ServiceLibrary.DataContracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class SubmitOrderResult
    {
        [DataMember]
        public List<LineItemStatus> OrderItems { get; set; }

        [DataMember]
        public bool HasException { get; set; }

        [DataMember]
        public ServiceException Exception { get; set; }
    }
}
