namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;

    using Exceptions;
    using Utilities;
    using Logger = Utilities.LogFileListener;
    using Setter = Utilities.AppSettings;

    public class Orders : SortedDictionary<string, Order>
    {
        public event Delegates.ProgressBar InitProgressBar;
        public event Delegates.ProgressBar IncrementProgressBar;
        public event Delegates.StatusBar UpdateStatusBar;


        public void ProcessOrderLines(OrderLines lines, Customers custList)
        {
            Order objOrder = null;
            Customer objCust = null;

            var previousOrderNum = "";

            InitProgressBar(this, new ProgressBarEventArgs(0, lines.Values.Count + 1));

            try
            {
                foreach (var objLine in lines.Values)
                {
                    IncrementProgressBar(this, new ProgressBarEventArgs());

                    var currentOrderNum = objLine.OrderNumber;

                    if (currentOrderNum == previousOrderNum)
                    {
                        // ReSharper disable PossibleNullReferenceException
                        objOrder.AddOrderItem(objLine);
                        Logger.Log("    Adding suborder " + objLine.OrderItemID + " to " + currentOrderNum + ".",
                                   LogLevel.Debug);
                        // ReSharper restore PossibleNullReferenceException
                    }
                    else
                    {
                        if (objOrder == null)
                        {
                            objOrder = new Order(objLine);
                            Logger.Log(
                                "Creating object for order number '" + currentOrderNum + "' (suborder " +
                                objLine.OrderItemID + ").", LogLevel.Debug);
                            objCust = new Customer(objLine);
                            Logger.Log("Created object for customer " + objLine.LastName + ", " + objLine.FirstName,
                                       LogLevel.Debug);
                        }
                        else
                        {
                            Add(objOrder.OrderNumber, objOrder);
                            custList.AddCustomer(objCust, objOrder);
                            Logger.Log("  Order '" + objOrder.OrderNumber + "' added to the base collection.",
                                       LogLevel.Debug);

                            objOrder = new Order(objLine);
                            Logger.Log(
                                "Creating object for order number '" + currentOrderNum + "' (suborder " +
                                objLine.OrderItemID + ").", LogLevel.Debug);
                            objCust = new Customer(objLine);
                            Logger.Log("Created object for customer " + objLine.LastName + ", " + objLine.FirstName,
                                       LogLevel.Debug);
                        }
                    }

                    previousOrderNum = currentOrderNum;
                }

                // ReSharper disable PossibleNullReferenceException
                Add(objOrder.OrderNumber, objOrder);
                custList.AddCustomer(objCust, objOrder);
                Logger.Log("  Order '" + objOrder.OrderNumber + "' added to the base collection.", LogLevel.Debug);
                // ReSharper restore PossibleNullReferenceException
            }
            catch (Exception ex)
            {
                throw new ProcessOrderException("An exception occurred while processing the order lines collection.", ex);
            }
        }
    }
}
