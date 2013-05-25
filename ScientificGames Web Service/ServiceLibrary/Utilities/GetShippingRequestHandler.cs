namespace ServiceLibrary.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using DataContracts;

    public class GetShippingRequestHandler
    {
        private readonly SqlConnection cn;


        private const int OrderLineItemIdOrdinal = 0;
        private const int CarrierOrdinal = 1;
        private const int ShipDateOrdinal = 2;
        private const int TrackingNumberOrdinal = 3;
        private const int TrackingUrlOrdinal = 4;

        public GetShippingRequestHandler(string connectString)
        {
            cn = new SqlConnection(connectString);
            cn.Open();
        }

        public void DropHandler()
        {
            cn.Close();
            cn.Dispose();
        }

        public ShippingInfoResult GetShippingInfo(ShippingInfoRequest request)
        {
            var result = new ShippingInfoResult();
            
            try
            {
                using (var cmd = new SqlCommand("usp_GetShippingInfoByDateRange", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) {Value = request.StartDate});
                    cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) {Value = request.EndDate});

                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result.Manifests = new List<ItemTracking>();
                        while (reader.Read())
                        {
                            var itemStatus = new ItemTracking
                                                 {
                                                     OrderLineItemId = reader.GetString(OrderLineItemIdOrdinal),
                                                     Carrier = reader.GetString(CarrierOrdinal),
                                                     ShipDate = reader.GetDateTime(ShipDateOrdinal),
                                                     TrackingNumber = reader.GetString(TrackingNumberOrdinal),
                                                     TrackingUrl = reader.GetString(TrackingUrlOrdinal)
                                                 };
                            result.Manifests.Add(itemStatus);
                        }
                    }
                    else
                    {
                        // TODO: Throw an exception indicating no rows were returned.
                    }

                }
            }
            catch (SqlException ex)
            {
                result.HasException = true;
                result.Exception = ExceptionFactory.BuildSqlException(ex);
            }
            catch (Exception ex)
            {
                result.HasException = true;
                result.Exception = ExceptionFactory.BuildSystemException(ex);
            }

            return result;
        }
    }
}
