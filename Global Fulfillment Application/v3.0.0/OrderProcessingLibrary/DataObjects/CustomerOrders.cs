namespace OrderProcessingLibrary.DataObjects
{
    using System.Collections.Generic;

    public class CustomerOrders : List<string>
    {
        public CustomerOrders(string orderNumber, string key)
        {
            Key = key;
            Add(orderNumber);
        }

        public string Key { get; private set; }

        //public void UpdateKey(string newKey)
        //{
        //    Key = newKey;
        //}
    }
}
