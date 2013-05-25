namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class XRefXmlException : CustomBaseException
    {
        public XRefXmlException(string message, Exception ex)
            : base(message, ex)
        { }
    }
}
