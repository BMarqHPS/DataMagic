
namespace OrderProcessingLibrary.Exceptions
{
    using System;

    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string itemNumber)
            : base(String.Format(
                "Item '{0}' already exists in the list.\n\nPlease change the Item Number, or Cancel adding this item.",
                itemNumber))
        { }
    }
}
