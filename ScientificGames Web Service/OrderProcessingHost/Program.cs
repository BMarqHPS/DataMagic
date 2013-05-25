namespace OrderProcessingHost
{
    using System;
    using System.ServiceModel;

    using OrderProcessingService;

    public class Program
    {
        private static ServiceHost orderProcessing;


        static void Main(string[] args)
        {
            Console.WriteLine("ServiceHost");
            try
            {
                orderProcessing = new ServiceHost(typeof(OrderProcessing));
                orderProcessing.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            Console.WriteLine("Started");
            Console.ReadKey();
        }
    }
}
