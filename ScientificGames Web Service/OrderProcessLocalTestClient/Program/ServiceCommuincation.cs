namespace OrderProcessingLocalTestClient.Program
{
    using System.ServiceModel;
    using ServiceLibrary.DataContracts;

    using OrderProcessing;

    public static class ServiceCommuincation
    {
        public static SubmitOrderResult SubmitOrder(SubmitOrderRequest orderRequest)
        {
            //var binding = new WSHttpBinding();
            //var address = new EndpointAddress(@"http://localhost:8080/OrderProcessingService");
            var binding = new NetTcpBinding(SecurityMode.None);
            var address = new EndpointAddress(@"net.tcp://localhost:8080/OrderProcessingService");

            var factory = new ChannelFactory<IOrderProcessing>(binding, address);
            var channel = factory.CreateChannel();

            var response = channel.SubmitOrder(orderRequest);
            return response;
        }

        public static OrderStatusResult RequestOrderStatus(OrderStatusRequest statusRequest)
        {
            //var binding = new WSHttpBinding();
            //var address = new EndpointAddress(@"http://localhost:8080/OrderProcessingService");
            var binding = new NetTcpBinding(SecurityMode.None);
            var address = new EndpointAddress(@"net.tcp://localhost:8080/OrderProcessingService");

            var factory = new ChannelFactory<IOrderProcessing>(binding, address);
            var channel = factory.CreateChannel();

            var result = channel.OrderStatusRequest(statusRequest);
            return result;
        }

        public static ShippingInfoResult RequestShippingInformation(ShippingInfoRequest infoRequest)
        {
            //var binding = new WSHttpBinding();
            //var address = new EndpointAddress(@"http://localhost:8080/OrderProcessingService");
            var binding = new NetTcpBinding(SecurityMode.None);
            var address = new EndpointAddress(@"net.tcp://localhost:8080/OrderProcessingService");

            var factory = new ChannelFactory<IOrderProcessing>(binding, address);
            var channel = factory.CreateChannel();

            var result = channel.GetShippingRequest(infoRequest);
            return result;
        }
    }




}
