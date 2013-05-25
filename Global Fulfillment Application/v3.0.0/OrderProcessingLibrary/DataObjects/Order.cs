namespace OrderProcessingLibrary.DataObjects
{
    using System.Collections.Generic;

    public class Order
    {
        public Order(OrderLine orderLine)
        {
            Account = orderLine.Account;
            OrderNumber = orderLine.OrderNumber;
            FirstOrderItemId = orderLine.OrderItemID;
            OrderId = orderLine.OrderID;
            ShipMethod = orderLine.ShipMethod;
            Gift = orderLine.Gift;

            HasPackingExceptionItems = orderLine.Item.PackingException;

            OrderItems = new SortedList<string, OrderItem>();
            OrderItems.Add(orderLine.ProductId + "_" + orderLine.OrderItemID,
                           new OrderItem(new OrderInfo(orderLine), orderLine.Item, orderLine.Quantity));
        }


        public int OrderId { get; private set; }

        public int FirstOrderItemId { get; private set; }

        public bool HasPackingExceptionItems { get; private set; }

        public SortedList<string, OrderItem> OrderItems { get; private set; }

        public string OrderNumber { get; private set; }

        public string ShipMethod { get; private set; }

        public string Account { get; private set; }

        public string Gift { get; private set; }


        public void AddOrderItem(OrderLine objOrdLine)
        {
            if (!HasPackingExceptionItems)
                HasPackingExceptionItems = objOrdLine.Item.PackingException;

            OrderItems.Add(objOrdLine.ProductId + "_" + objOrdLine.OrderItemID,
                           new OrderItem(new OrderInfo(objOrdLine), objOrdLine.Item, objOrdLine.Quantity));
        }
        
        public bool CombinableOrder()
        {
            if (OrderItems.Count > 1)
                return false;

            //if (Account.EndsWith("X"))
            //    return false;

            return !OrderItems.Values[0].Item.SinglePack;
        }

    }
}
