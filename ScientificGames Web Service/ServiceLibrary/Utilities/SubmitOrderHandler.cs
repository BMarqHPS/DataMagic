namespace ServiceLibrary.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using DataContracts;

    public class SubmitOrderHandler
    {
        private readonly SqlConnection cn;
        private SqlTransaction trans;

        private const int OrderLineItemIdOrdinal = 0;
        private const int ProductIdentifierOrdinal = 1;
        private const int QtyReservedOrdinal = 2;

        private int id;
        private string orderNumber;

        public SubmitOrderHandler(string connectString)
        {
            cn = new SqlConnection(connectString);
            cn.Open();
        }


        public void DropHandler()
        {
            cn.Close();
            cn.Dispose();
        }

        public SubmitOrderResult SaveOrder(SubmitOrderRequest request)
        {
            var result = new SubmitOrderResult();
            orderNumber = request.OrderNumber;

            try
            {
                trans = cn.BeginTransaction();

                var orderId = InsertOrderRecord(request);

                foreach (var orderLineItem in request.LineItems)
                {
                    InsertLineItems(orderId, orderLineItem);
                }

                trans.Commit();
                trans.Dispose();
                trans = null;

                result = GetOrderResults();
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
            finally
            {
                if (trans != null)
                {
                    trans.Rollback();
                    trans.Dispose();
                }
                cn.Close();
                cn.Dispose();
            }

            return result;
        }


        private SubmitOrderResult GetOrderResults()
        {
            var result = new SubmitOrderResult();
            var lineItems = new List<LineItemStatus>();

            try
            {
                using (var cmd = new SqlCommand("usp_GetOrderLineItems", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.Int) { Value = id });
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var lineItem = new LineItemStatus
                            {
                                OrderLineItemId = reader.GetString(OrderLineItemIdOrdinal),
                                ProductIdentifier = reader.GetString(ProductIdentifierOrdinal),
                                QtyReserved = reader.GetInt32(QtyReservedOrdinal)
                            };
                            lineItems.Add(lineItem);
                        }
                    }
                    else
                    {
                        throw new NoLineItemsFoundException(orderNumber);
                    }
                }
                result.HasException = false;
                result.Exception = null;
                result.OrderItems = lineItems;

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

        private void InsertLineItems(int orderId, OrderLineItem lineItem)
        {
            using (var cmd = new SqlCommand("usp_InsertOrderItem", cn, trans))
            {
                var parameters = new[]
                                     {
                                         new SqlParameter("@OrderID", SqlDbType.Int)
                                             {Value = orderId},
                                         new SqlParameter("@OrderLineItemId", SqlDbType.NVarChar, 50)
                                             {Value = lineItem.OrderLineItemId},
                                         new SqlParameter("@ProductIdentifier", SqlDbType.NVarChar, 50)
                                             {Value = lineItem.ProductIdentifier},
                                         new SqlParameter("@Quantity", SqlDbType.Int)
                                             {Value = lineItem.Quantity},
                                         new SqlParameter("@ShipMethod", SqlDbType.NVarChar, 25)
                                             {Value = lineItem.ShippingMethod},
                                         new SqlParameter("@GiftMessage", SqlDbType.NVarChar, 1000)
                                             {Value = lineItem.GiftMessage}
                                     };

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }

        private int InsertOrderRecord(SubmitOrderRequest request)
        {

            using (var cmd = new SqlCommand("usp_InsertOrder", cn, trans))
            {
                var parameters = new []
                                     {
                                         new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 255)
                                             {Value = request.OrderNumber},
                                         new SqlParameter("@Account", SqlDbType.NVarChar, 16)
                                             {Value = request.Account},
                                         new SqlParameter("@FirstName", SqlDbType.NVarChar, 64)
                                             {Value = request.FirstName},
                                         new SqlParameter("@LastName", SqlDbType.NVarChar, 64)
                                             {Value = request.LastName},
                                         new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 255)
                                             {Value = request.Address.Line1},
                                         new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 255)
                                             {Value = request.Address.Line2},
                                         new SqlParameter("@City", SqlDbType.NVarChar, 64)
                                             {Value = request.Address.City},
                                         new SqlParameter("@ST", SqlDbType.NVarChar, 2)
                                             {Value = request.Address.State},
                                         new SqlParameter("@ZipCode", SqlDbType.NVarChar, 16)
                                             {Value = request.Address.Zip},
                                         new SqlParameter("@Phone", SqlDbType.NVarChar, 16)
                                             {Value = request.Phone}
                                     };
                var prmId = new SqlParameter("@ID", SqlDbType.Int) {Direction = ParameterDirection.Output};

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                cmd.Parameters.Add(prmId);
                cmd.ExecuteNonQuery();

                id = Convert.ToInt32(prmId.Value);
            }

            return id;
        }
    }
}
