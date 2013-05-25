namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;

    using Utilities;
    using Logger = Utilities.LogFileListener;

    public class Customers : SortedDictionary<string, Customer>
    {
        public event Delegates.ProgressBar InitProgressBar;
        public event Delegates.ProgressBar IncrementProgressBar;
        public event Delegates.StatusBar UpdateStatusBar;


        private readonly SortedDictionary<string, Customer> rawCustomerList = 
            new SortedDictionary<string, Customer>();

        private readonly SortedDictionary<string, CustomerOrders> ordersByCustomer =
            new SortedDictionary<string, CustomerOrders>();


        public SortedDictionary<string, CustomerOrders> OrdersByCustomer { get { return ordersByCustomer; } } 

        public int RawCount { get { return rawCustomerList.Count; } }


        public void AddCustomer(Customer objCust, Order objOrder)
        {
            if (objOrder.CombinableOrder())
                rawCustomerList.Add(objCust.MatchingKey, objCust);
            else
            {
                Add(objCust.Key, objCust);
                ordersByCustomer.Add(objCust.Key, new CustomerOrders(objOrder.OrderNumber, objCust.Key));
            }
        }

        public void CustomerMatchup()
        {
            Customer prevCustomer = null;
            CustomerOrders custOrd = null;

            const byte IS_MATCH = 8;

            InitProgressBar(this, new ProgressBarEventArgs(0, Values.Count + 1));

            foreach (var currCustomer in rawCustomerList.Values)
            {
                if (prevCustomer == null)
                {
                    prevCustomer = currCustomer;
                    custOrd = new CustomerOrders(currCustomer.OrderNumber, currCustomer.Key);
                    Logger.Log(String.Format("Created CustomerOrder '{0}'", currCustomer.Key));
                    Add(currCustomer.Key, currCustomer);
                    Logger.Log(String.Format("Added customer '{0}' to base collection.", currCustomer.Key),
                               LogLevel.Debug);
                    continue;
                }

                byte matchTest = currCustomer.IsSameCustomer(prevCustomer);

                if (matchTest == IS_MATCH)
                {
                    custOrd.Add(currCustomer.OrderNumber);
                    Logger.Log(String.Format("\tAdded order '{0}' to CustomerOrder '{1}'", currCustomer.OrderNumber,
                                             currCustomer.Key));
                }
                else
                {
                    ordersByCustomer.Add(custOrd.Key, custOrd);
                    Logger.Log(String.Format("  CustomerOrder '{0}' added to the collection.", custOrd.Key),
                               LogLevel.Verbose);
                    Add(currCustomer.Key, currCustomer);
                    Logger.Log(String.Format("Added customer '{0}' to base collection.", currCustomer.Key));

                    custOrd = new CustomerOrders(currCustomer.OrderNumber, currCustomer.Key);
                    Logger.Log(String.Format("Created CustomerOrder '{0}'", currCustomer.Key));
                    prevCustomer = currCustomer;
                }

                IncrementProgressBar(this, new ProgressBarEventArgs());
            }

            // ReSharper disable PossibleNullReferenceException
            ordersByCustomer.Add(custOrd.Key, custOrd);
            // ReSharper restore PossibleNullReferenceException

            Logger.Log(String.Format("  CustomerOrder '{0}' added to the collection.", custOrd.Key), LogLevel.Verbose);

            rawCustomerList.Clear();
        }
    }
}
