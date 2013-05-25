namespace OrderProcessingLib.DataAccess
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public static class SqlHelper
    {
        // Do not implement Try..Catch structures, the exceptions need to be caught and handled
        // in the application.

        private static readonly string connectString = ConfigurationManager.AppSettings["ConnectionString"];

        public static DataTable GetPendingOrders()
        {
            var ordersTable = new DataTable();

            using (var cn = new SqlConnection(connectString))
            {
                cn.Open();

                using (var cmd = new SqlCommand("usp_GetPendingOrders", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ordersTable);
                    }
                }
            }

            return ordersTable;
        }

        public static bool FlagPendingOrdersAsProcessing()
        {
            using (var cn = new SqlConnection(connectString))
            {
                cn.Open();
                using (var cmd = new SqlCommand("usp_FlagPendingOrdersAsProcessing", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public static DataTable GetProductIdsForPendingOrders(bool firstPass)
        {
            var productIdList = new DataTable();

            using (var cn = new SqlConnection(connectString))
            {
                cn.Open();

                using (var cmd = new SqlCommand("usp_GetProductIdsForPendingOrders", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add(new SqlParameter("@FirstPass", SqlDbType.Bit) {Value = firstPass ? 1 : 0});
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(productIdList);
                    }
                }
            }

            return productIdList;
        }
    }
}
