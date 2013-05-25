namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class ItemDataLoadException : Exception
    {
        public ItemDataLoadException(string message, Exception ex)
            :base(message, ex)
        { }
    }
}
