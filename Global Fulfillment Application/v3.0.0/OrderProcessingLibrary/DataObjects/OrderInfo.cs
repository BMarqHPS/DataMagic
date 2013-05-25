namespace OrderProcessingLibrary.DataObjects
{
    public class OrderInfo
    {
        public OrderInfo(OrderLine ordLine)
        {
            OrderId = ordLine.OrderID;
            OrderItemId = ordLine.OrderItemID;
            OrderNumber = ordLine.OrderNumber;
            ShipMethod = ordLine.ShipMethod;
        }


        public int OrderId { get; private set; }

        public int OrderItemId { get; private set; }

        public string OrderNumber { get; private set; }

        public string ShipMethod { get; private set; }
    }
}
