namespace OrderProcessingLibrary.DataObjects
{
    using System;

    public class OrderItem
    {
        public OrderItem(OrderInfo objOrdInfo,Product objItem, int quantity )
        {
            OrderInfo = objOrdInfo;
            Item = objItem;
            Quantity = quantity;
        }

        public OrderInfo OrderInfo { get; private set; }

        public Product Item { get; private set; }

        public int Quantity { get; private set; }

        public string Key
        {
            get { return String.Format("{0}_{1}_{2}", Item.ItemNumber, OrderInfo.OrderNumber, OrderInfo.OrderItemId); }
        }
    }
}
