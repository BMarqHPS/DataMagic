namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class ItemMaintenanceException : Exception
    {
        public ItemMaintenanceException(string message, Exception ex)
            :base(message, ex)
        { }

        public ItemMaintenanceException(string message)
            : base(message)
        { }
    }
}
