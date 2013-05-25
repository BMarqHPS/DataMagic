namespace ServiceLibrary.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using DataContracts;

    public class GetOrderStatusHandler
    {
        private readonly SqlConnection cn;

        private const int OrderIdOrdinal = 0;
        private const int OrderedDateOrdinal = 1;

        private const int OrderLineItemIdOrdinal = 0;
        private const int ProductIdentifierOrdinal = 1;
        private const int QtyOrderedOrdinal = 2;
        private const int QtyShippedOrdinal = 3;
        private const int QtyCancelledOrdinal = 4;
        private const int QtyBackorderedOrdinal = 5;
        private const int CarrierOrdinal = 6;
        private const int ShipDateOrdinal = 7;
        private const int TrackingNumberOrdinal = 8;
        private const int TrackingUrlOrdinal = 9;

        private int id;

        public GetOrderStatusHandler(string connectionString)
        {
            cn = new SqlConnection(connectionString);
            cn.Open();
        }


        public void DropHandler()
        {
            cn.Close();
            cn.Dispose();
        }

        public OrderStatusResult GetOrderStatus(OrderStatusRequest request)
        {
            var result = new OrderStatusResult();

            try
            {
                GetIdAndOrderDate(request, result);
                result.ItemStatuses = GetLineItemStatuses(id);
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

        private void GetIdAndOrderDate(OrderStatusRequest request, OrderStatusResult result)
        {
            using (var cmd = new SqlCommand("usp_GetOrderDateAndID", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 255) {Value = request.OrderNumber});
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    id = reader.GetInt32(OrderIdOrdinal);
                    result.OrderDate = reader.GetDateTime(OrderedDateOrdinal);
                }
                reader.Close();
            }
        }

        private IList<OrderItemStatus> GetLineItemStatuses(int orderId)
        {
            var lineItems = new List<OrderItemStatus>();

            using (var cmd = new SqlCommand("usp_GetLineItemStatuses", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.Int) {Value = orderId});
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var lineItem = new OrderItemStatus
                                           {
                                               OrderlineItemId = reader.GetString(OrderLineItemIdOrdinal),
                                               ProductIdentifier = reader.GetString(ProductIdentifierOrdinal),
                                               QtyOrdered = reader.GetInt32(QtyOrderedOrdinal),
                                               QtyShipped = reader.GetInt32(QtyShippedOrdinal),
                                               QtyCancelled = reader.GetInt32(QtyCancelledOrdinal),
                                               QtyBackordered = reader.GetInt32(QtyBackorderedOrdinal),
                                               TrackingInformation = new List<ItemTracking>()
                                           };
                        var tracking = new ItemTracking();
                        if (!reader.IsDBNull(CarrierOrdinal))
                            tracking.Carrier = reader.GetString(CarrierOrdinal);
                        if (!reader.IsDBNull(ShipDateOrdinal))
                            tracking.ShipDate = reader.GetDateTime(ShipDateOrdinal);
                        if (!reader.IsDBNull(TrackingNumberOrdinal))
                            tracking.TrackingNumber = reader.GetString(TrackingNumberOrdinal);
                        if (!reader.IsDBNull(TrackingUrlOrdinal))
                            tracking.TrackingUrl = reader.GetString(TrackingUrlOrdinal);

                        lineItem.TrackingInformation.Add(tracking);
                        lineItems.Add(lineItem);
                    }
                }
                else
                {
                    // TODO: Throw exception indicating no line items were returned.
                }

            }

            return lineItems;
        }
    }
}
