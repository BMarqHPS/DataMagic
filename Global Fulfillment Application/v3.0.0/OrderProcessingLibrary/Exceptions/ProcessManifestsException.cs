namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class ProcessManifestsException : CustomBaseException
    {
        public ProcessManifestsException(string message, Exception ex)
            : base(message, ex)
        { }
    }
}
