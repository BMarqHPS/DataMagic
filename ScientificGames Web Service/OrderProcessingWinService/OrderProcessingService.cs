namespace OrderProcessingWinService
{
    using System.ServiceModel;
    using System.ServiceProcess;
    using global::OrderProcessingService;

    public class OrderProcessingService : ServiceBase
    {
        public ServiceHost serviceHost;

        public OrderProcessingService()
        {
            ServiceName = "SG Order Processing Service";
        }

        public static void Main()
        {
            Run(new OrderProcessingService());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
                serviceHost.Close();

            serviceHost = new ServiceHost(typeof(OrderProcessing));
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost == null) return;

            serviceHost.Close();
            serviceHost = null;
        }
    }
}
