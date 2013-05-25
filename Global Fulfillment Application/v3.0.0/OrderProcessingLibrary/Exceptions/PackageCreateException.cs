namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class PackageCreateException : CustomBaseException
    {
        public PackageCreateException(string message, Exception ex)
            : base(message, ex)
        { }
    }
}
