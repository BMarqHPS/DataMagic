namespace OrderProcessingService
{
    using System.Configuration;

    using OrderProcessingInterface;
    using ServiceLibrary.DataContracts;
    using ServiceLibrary.Utilities;

    public class OrderProcessing : IOrderProcessing
    {

        private readonly string connectString;

        public OrderProcessing()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var connections = ConfigurationManager.ConnectionStrings;
            var dbAccess = appSettings["Access"];
            connectString = connections[dbAccess].ConnectionString;
        }

        public ShippingInfoResult GetShippingRequest(ShippingInfoRequest request)
        {
            var requestor = new GetShippingRequestHandler(connectString);
            return requestor.GetShippingInfo(request);
        }

        public SubmitOrderResult SubmitOrder(SubmitOrderRequest request)
        {
            var submitter = new SubmitOrderHandler(connectString);
            return submitter.SaveOrder(request);
        }

        public OrderStatusResult OrderStatusRequest(OrderStatusRequest request)
        {
            var requestor = new GetOrderStatusHandler(connectString);
            return requestor.GetOrderStatus(request);
        }
    }
}
