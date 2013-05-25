namespace OrderProcessingRemoteTestClient.Program
{
    using System.ServiceModel;
    using ServiceLibrary.DataContracts;

    using OrderProcessing;

    public static class ServiceCommuincation
    {
        public static SubmitOrderResult SubmitOrder(SubmitOrderRequest orderRequest)
        {
            var channel = new ChannelFactory<IOrderProcessing>("*").CreateChannel();

            var response = channel.SubmitOrder(orderRequest);
            return response;
        }

        public static OrderStatusResult RequestOrderStatus(OrderStatusRequest statusRequest)
        {
            var channel = new ChannelFactory<IOrderProcessing>("*").CreateChannel();

            var result = channel.OrderStatusRequest(statusRequest);
            return result;
        }

        public static ShippingInfoResult RequestShippingInformation(ShippingInfoRequest infoRequest)
        {
            var channel = new ChannelFactory<IOrderProcessing>("*").CreateChannel();

            var result = channel.GetShippingRequest(infoRequest);
            return result;
        }
    }




}
