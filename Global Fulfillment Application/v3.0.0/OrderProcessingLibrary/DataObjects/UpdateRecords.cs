namespace OrderProcessingLibrary.DataObjects
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;

    using Utilities;
    using Logger = Utilities.LogFileListener;

    public class UpdateRecords
    {
        private readonly string connectionString;

        private readonly SortedDictionary<int, UpdateRecord> updateRecords = new SortedDictionary<int, UpdateRecord>();
        private readonly SortedDictionary<int, int> orderIds = new SortedDictionary<int, int>();
 
        public event Delegates.ProgressBar InitProgressBar;
        public event Delegates.ProgressBar IncrementProgressBar;
        public event Delegates.StatusBar UpdateStatusBar;

        public UpdateRecords(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public int UpdateCount { get { return orderIds.Count; } }


        public void AddUpdateRecord(ManifestRecord manifestRecord, XmlNode orderNode)
        {
            var updateRecord = new UpdateRecord(manifestRecord, orderNode);
            updateRecords.Add(updateRecord.OrderItemId, updateRecord);
            Logger.Log("Added UpdateRecord '" + updateRecord.Key + "'", LogLevel.Debug);
        }

        public void AddOrderID(int orderId)
        {
            orderIds.Add(orderId, orderId);
            Logger.Log("Added OrderID '" + orderId + "'", LogLevel.Debug);
        }

        public void ExecuteUpdate()
        {
            SqlTransaction trans = null;

            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    trans = cn.BeginTransaction();

                    UpdateOrderItems(trans, cn);
                    UpdateOrders(cn, trans);

                    trans.Commit();

                    Logger.Log("Orders updated successfully.");
                }
            }
            catch (SqlException)
            {
                if (trans != null)
                    trans.Rollback();
                
                throw;
            }
        }


        private void UpdateOrders(SqlConnection cn, SqlTransaction trans)
        {
            UpdateStatusBar(this,new StatusBarEventArgs("Updating order statuses..."));
            InitProgressBar(this, new ProgressBarEventArgs(0, orderIds.Count + 1));

            using (var cmd = new SqlCommand("usp_UpdateOrder", cn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                cmd.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.Int));

                foreach (var orderId in orderIds.Values)
                {
                    cmd.Parameters[0].Value = orderId;

                    cmd.ExecuteNonQuery();
                    IncrementProgressBar(this, null);
                }
            }
        }

        private void UpdateOrderItems(SqlTransaction trans, SqlConnection cn)
        {
            UpdateStatusBar(this, new StatusBarEventArgs("Updating order items..."));
            InitProgressBar(this, new ProgressBarEventArgs(0, updateRecords.Count + 1));

            using (var cmd = new SqlCommand("usp_UpdateOrderLine", cn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                var orderIdParam = new SqlParameter("@OrderID", SqlDbType.Int);
                var orderItemIdParam = new SqlParameter("@OrderItemID", SqlDbType.Int);
                var quantityShippedParam = new SqlParameter("@QtyShipped", SqlDbType.Int);
                var quantityCancelledParam = new SqlParameter("@QtyCancelled", SqlDbType.Int);
                var quantityBackorderedParam = new SqlParameter("@QtyBackOrdered", SqlDbType.Int);
                var carrierParam = new SqlParameter("@Carrier", SqlDbType.NVarChar, 10);
                var shipDateParam = new SqlParameter("@ShipDate", SqlDbType.SmallDateTime);
                var trackNumberParam = new SqlParameter("@TrackNumber", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add(orderIdParam);
                cmd.Parameters.Add(orderItemIdParam);
                cmd.Parameters.Add(quantityShippedParam);
                cmd.Parameters.Add(quantityCancelledParam);
                cmd.Parameters.Add(quantityBackorderedParam);
                cmd.Parameters.Add(carrierParam);
                cmd.Parameters.Add(shipDateParam);
                cmd.Parameters.Add(trackNumberParam);

                foreach (var update in updateRecords.Values)
                {
                    orderIdParam.Value = update.OrderId;
                    orderItemIdParam.Value = update.OrderItemId;
                    quantityShippedParam.Value = update.QuantityShipped;
                    quantityCancelledParam.Value = update.QuantityCancelled;
                    quantityBackorderedParam.Value = update.QuantityBackordered;
                    carrierParam.Value = update.Carrier;
                    shipDateParam.Value = update.ShipDate;
                    trackNumberParam.Value = update.TrackingNumber;

                    cmd.ExecuteNonQuery();
                    IncrementProgressBar(this, null);
                }
            }
        }
    }
}
