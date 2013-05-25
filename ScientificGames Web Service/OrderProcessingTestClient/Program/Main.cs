namespace OrderProcessingRemoteTestClient.Program
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using ServiceLibrary.DataContracts;

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void buttonSubmitOrder_Click(object sender, EventArgs e)
        {
            SubmitOrderRequest orderRequest = null;

            if (DoSubmitOrderValidation())
            {
                orderRequest = BuildOrder();
            }

            if (orderRequest == null)
                MessageBox.Show(@"No order created/submitted.", @"Results", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            var result = ServiceCommuincation.SubmitOrder(orderRequest);
            DisplaySubmitOrderResults(result);

            tabSubmitOrderResults.Visible = true;
        }

        private void buttonRequestOrderStatus_Click(object sender, EventArgs e)
        {
            var statusRequest = new OrderStatusRequest {OrderNumber = textRequestStatusOrderNumber.Text};

            var result = ServiceCommuincation.RequestOrderStatus(statusRequest);
            DisplayRequestOrderStatusResults(result);
        }

        private void buttonRequestShippingInfo_Click(object sender, EventArgs e)
        {
            var startDate = dateTimeStartDate.Value;
            var endDate = dateTimeEndDate.Value;

            var shipInfoRequest = new ShippingInfoRequest {StartDate = startDate, EndDate = endDate};

            var result = ServiceCommuincation.RequestShippingInformation(shipInfoRequest);
            if (!result.HasException)
            {
                DisplayShippingInfoResults(result);
            }
        }

        private void DisplayShippingInfoResults(ShippingInfoResult result)
        {
            var stringType = Type.GetType("System.String");
            var dateTimeType = Type.GetType("System.DateTime");

            var displayTable = new DataTable();
            // ReSharper disable AssignNullToNotNullAttribute
            displayTable.Columns.Add(new DataColumn("OrderLineItemID", stringType));
            displayTable.Columns.Add(new DataColumn("Carrier", stringType));
            displayTable.Columns.Add(new DataColumn("ShipDate", dateTimeType));
            displayTable.Columns.Add(new DataColumn("TrackingNumber", stringType));
            displayTable.Columns.Add(new DataColumn("TrackingURL", stringType));
            // ReSharper restore AssignNullToNotNullAttribute

            foreach (var itemTracking in result.Manifests)
            {
                var newRow = displayTable.NewRow();
                newRow[0] = itemTracking.OrderLineItemId;
                newRow[1] = itemTracking.Carrier;
                newRow[2] = itemTracking.ShipDate;
                newRow[3] = itemTracking.TrackingNumber;
                newRow[4] = itemTracking.TrackingUrl;
                displayTable.Rows.Add(newRow);
            }

            dataGridViewShippingStatus.DataSource = displayTable;
        }

        private void DisplayRequestOrderStatusResults(OrderStatusResult result)
        {
            var itemStatuses = result.ItemStatuses;

            textOrderStatusLineItemId1.Text = itemStatuses[0].OrderlineItemId;
            textOrderStatusProductId1.Text = itemStatuses[0].ProductIdentifier;
            textOrderStatusQty1.Text = Convert.ToString(itemStatuses[0].QtyOrdered);

            if (itemStatuses.Count < 2) return;

            textOrderStatusLineItemId2.Text = itemStatuses[1].OrderlineItemId;
            textOrderStatusProductId2.Text = itemStatuses[1].ProductIdentifier;
            textOrderStatusQty2.Text = Convert.ToString(itemStatuses[1].QtyOrdered);

            if (itemStatuses.Count < 3) return;

            textOrderStatusLineItemId3.Text = itemStatuses[2].OrderlineItemId;
            textOrderStatusProductId3.Text = itemStatuses[2].ProductIdentifier;
            textOrderStatusQty3.Text = Convert.ToString(itemStatuses[2].QtyOrdered);
            
            if (itemStatuses.Count < 4) return;

            textOrderStatusLineItemId4.Text = itemStatuses[3].OrderlineItemId;
            textOrderStatusProductId4.Text = itemStatuses[3].ProductIdentifier;
            textOrderStatusQty4.Text = Convert.ToString(itemStatuses[3].QtyOrdered);

            if (itemStatuses.Count < 5) return;

            textOrderStatusLineItemId5.Text = itemStatuses[4].OrderlineItemId;
            textOrderStatusProductId5.Text = itemStatuses[4].ProductIdentifier;
            textOrderStatusQty5.Text = Convert.ToString(itemStatuses[4].QtyOrdered);
        }

        private void DisplaySubmitOrderResults(SubmitOrderResult result)
        {
            if (result.HasException)
            {
                // TODO: Display exception info.
                MessageBox.Show(@"Exception Occurred.");
                return;
            }

            var lineItems = result.OrderItems;

            textOrderResultOrderLineItemID1.Text = lineItems[0].OrderLineItemId;
            textOrderResultProductID1.Text = lineItems[0].ProductIdentifier;
            textOrderResultQty1.Text = Convert.ToString(lineItems[0].QtyReserved);

            if (lineItems.Count < 2) return;

            textOrderResultOrderLineItemID2.Text = lineItems[1].OrderLineItemId;
            textOrderResultProductID2.Text = lineItems[1].ProductIdentifier;
            textOrderResultQty2.Text = Convert.ToString(lineItems[1].QtyReserved);


            if (lineItems.Count < 3) return;
            
            textOrderResultOrderLineItemID3.Text = lineItems[2].OrderLineItemId;
            textOrderResultProductID3.Text = lineItems[2].ProductIdentifier;
            textOrderResultQty3.Text = Convert.ToString(lineItems[2].QtyReserved);

            if (lineItems.Count < 4) return;

            textOrderResultOrderLineItemID4.Text = lineItems[3].OrderLineItemId;
            textOrderResultProductID4.Text = lineItems[3].ProductIdentifier;
            textOrderResultQty4.Text = Convert.ToString(lineItems[3].QtyReserved);

            if (lineItems.Count < 5) return;

            textOrderResultOrderLineItemID5.Text = lineItems[4].OrderLineItemId;
            textOrderResultProductID5.Text = lineItems[4].ProductIdentifier;
            textOrderResultQty5.Text = Convert.ToString(lineItems[4].QtyReserved);
        }

        private SubmitOrderRequest BuildOrder()
        {
            var orderRequest = new SubmitOrderRequest
                            {
                                OrderNumber = textOrderNumber.Text,
                                Account = textAccount.Text,
                                FirstName = textFirstName.Text.Trim(),
                                LastName = textLastName.Text.Trim(),
                                Address = BuildShipToAddress(),
                                Phone = textPhone.Text.Trim()
                            };

            var lineItems = BuildOrderLineItemList();

            if (lineItems == null)
                return null;

            orderRequest.LineItems = lineItems;
            return orderRequest;
        }

        private Address BuildShipToAddress()
        {
            return new Address
                       {
                           Line1 = textAddressLine1.Text.Trim(),
                           Line2 = textAddressLine2.Text.Trim(),
                           City = textCity.Text.Trim(),
                           State = textState.Text.Trim(),
                           Zip = textZip.Text.Trim()
                       };
        }

        private IList<OrderLineItem> BuildOrderLineItemList()
        {
            var lineItems = new List<OrderLineItem>();

            if (!String.IsNullOrWhiteSpace(textProductId1.Text))
            {
                if (DoSubmitOrderLineItemValidation(1, textQty1, textShippingMethod1))
                    lineItems.Add(CreateOrderLineItem(textProductId1.Text, textQty1.Text, textShippingMethod1.Text, textGiftMessage1.Text));
                else
                    return null;
            }

            if (!String.IsNullOrWhiteSpace(textProductId2.Text))
            {
                if (DoSubmitOrderLineItemValidation(2, textQty2, textShippingMethod2)) 
                    lineItems.Add(CreateOrderLineItem(textProductId2.Text, textQty2.Text, textShippingMethod2.Text, textGiftMessage2.Text));
                else
                    return null;
            }

            if (!String.IsNullOrWhiteSpace(textProductId3.Text))
            {
                if (DoSubmitOrderLineItemValidation(3, textQty3, textShippingMethod3))
                    lineItems.Add(CreateOrderLineItem(textProductId3.Text, textQty3.Text, textShippingMethod3.Text,
                                                   textGiftMessage3.Text));
                else
                    return null;
            }

            if (!String.IsNullOrWhiteSpace(textProductId4.Text))
            {
                if (DoSubmitOrderLineItemValidation(4, textQty4, textShippingMethod4))
                    lineItems.Add(CreateOrderLineItem(textProductId4.Text, textQty4.Text, textShippingMethod4.Text,
                                                   textGiftMessage4.Text));
                else
                    return null;
            }

            if (!String.IsNullOrWhiteSpace(textProductId5.Text))
            {
                if (DoSubmitOrderLineItemValidation(5, textQty5, textShippingMethod5))
                    lineItems.Add(CreateOrderLineItem(textProductId5.Text, textQty5.Text, textShippingMethod5.Text,
                                                   textGiftMessage5.Text));
                else
                    return null;
            }

            return lineItems;
        }

        private OrderLineItem CreateOrderLineItem(string productId, string qty, string shipMethod, string giftMsg)
        {
            return new OrderLineItem
                       {
                           OrderLineItemId = Guid.NewGuid().ToString(),
                           ProductIdentifier = productId,
                           Quantity = Convert.ToInt32(qty),
                           ShippingMethod = shipMethod,
                           GiftMessage = giftMsg
                       };
        }

        private bool DoSubmitOrderValidation()
        {
            if (String.IsNullOrWhiteSpace(textOrderNumber.Text))
            {
                DisplayMissingInfo(textOrderNumber.Tag);
                return false;
            }
            return true;
        }

        private bool DoSubmitOrderLineItemValidation(int lineId, TextBox qty, TextBox shipMethod)
        {
            if (String.IsNullOrWhiteSpace(qty.Text))
            {
                DisplayMissingLineItemInfo(lineId, qty.Tag);
                return false;
            }
            if (String.IsNullOrWhiteSpace(shipMethod.Text))
            {
                DisplayMissingLineItemInfo(lineId, shipMethod.Tag);
            }
            return true;
        }

        private void DisplayMissingInfo(object tag)
        {
            MessageBox.Show(String.Format("{0} cannot be blank", tag), @"Missing Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void DisplayMissingLineItemInfo(int lineItemNum, object tag)
        {
            MessageBox.Show(String.Format("Line item {0} is missing {1}", lineItemNum, tag), @"Missing Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }


    }
}
