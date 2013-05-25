namespace OrderProcessingInterface
{
    using System.ServiceModel;
    using ServiceLibrary.DataContracts;


    [ServiceContract]
    public interface IOrderProcessing
    {
        [OperationContract]
        OrderStatusResult OrderStatusRequest(OrderStatusRequest request);

        [OperationContract]
        ShippingInfoResult GetShippingRequest(ShippingInfoRequest request);

        [OperationContract]
        SubmitOrderResult SubmitOrder(SubmitOrderRequest request);
    }
}
