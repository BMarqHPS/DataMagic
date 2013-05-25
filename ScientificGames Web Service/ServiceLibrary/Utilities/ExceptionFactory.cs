namespace ServiceLibrary.Utilities
{
    using System;
    using System.Data.SqlClient;
    using DataContracts;

    public static class ExceptionFactory
    {
        /*  Severity Levels

              0       Emergency: system is unusable
              1       Alert: action must be taken immediately
              2       Critical: critical conditions
              3       Error: error conditions
              4       Warning: warning conditions
              5       Notice: normal but significant condition
              6       Informational: informational messages
              7       Debug: debug-level messages

         */

        public static ServiceException BuildSqlException(SqlException ex)
        {
            return new ServiceException {Severity = "3", Code = ex.Number, Message = ex.Message};
        }

        public static ServiceException BuildSystemException(Exception ex)
        {
            return new ServiceException {Severity = "3", Code = 9999, Message = ex.Message};
        }

        public static ServiceException BuildInfoException(string infoMessage)
        {
            return new ServiceException {Severity = "6", Code = 0, Message = infoMessage};
        }

        public static ServiceException BuildNoItemException(NoLineItemsFoundException ex)
        {
            if (String.IsNullOrEmpty(ex.OrderNumber))
            {
                var message = String.Format("{0} {1:mm-dd-yyyy} to {2:mm-dd-yyyy}", ex.Message, ex.StartDate, ex.EndDate);
                return new ServiceException {Severity = "4", Code = 0, Message = message};
            }
            else
            {
                var message = String.Format("{0} {1}", ex.Message, ex.OrderNumber);
                return new ServiceException {Severity = "4", Code = 0, Message = message};
            }
        }
    }

    public class NoLineItemsFoundException : Exception
    {
        public string OrderNumber { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public NoLineItemsFoundException(string orderNumber)
            :base("No line items were found for order number :")
        {
            this.OrderNumber = orderNumber;
        }

        public NoLineItemsFoundException(DateTime startDate, DateTime endDate)
            : base("No line items were found for date range")
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}
