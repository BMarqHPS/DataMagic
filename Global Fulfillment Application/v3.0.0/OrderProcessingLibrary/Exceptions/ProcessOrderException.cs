namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class ProcessOrderException : CustomBaseException
    {

        public ProcessOrderException(string message, Exception ex)
            :base(message, ex)
        { }
    }
}
