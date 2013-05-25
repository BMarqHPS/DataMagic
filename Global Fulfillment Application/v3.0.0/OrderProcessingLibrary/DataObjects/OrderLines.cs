namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using OrderProcessingLib.DataAccess;
    using Utilities;
    using Logger = Utilities.LogFileListener;
    using Settings = Utilities.AppSettings;

    public class OrderLines : SortedDictionary<string, OrderLine>
    {
        public event Delegates.ProgressBar InitProgressBar;
        public event Delegates.ProgressBar IncrementProgressBar;
        public event Delegates.StatusBar UpdateStatusBar;


        private readonly SortedDictionary<string, Product> _cachedItems = new SortedDictionary<string, Product>(); 


        public int LoadOrders(Products itemList)
        {
            var orders = SqlHelper.GetPendingOrders();
            var lineCount = orders.Rows.Count;

            InitProgressBar(this, new ProgressBarEventArgs(0, lineCount));

            foreach (DataRow row in orders.Rows)
            {
                var objOrdLine = new OrderLine(row);

                IncrementProgressBar(this, new ProgressBarEventArgs());
                Logger.Log(
                    String.Format("  Loaded order line {0}, Item - {1}", objOrdLine.Key, objOrdLine.ProductId),
                    LogLevel.Debug);

                var itemNum = objOrdLine.ProductId;

                Product item;
                if (!_cachedItems.TryGetValue(itemNum, out item))
                {
                    item = itemList.GetItem(itemNum);
                    _cachedItems.Add(itemNum, item);
                }
                objOrdLine.Item = item;

                Add(objOrdLine.Key, objOrdLine);
            }

            return lineCount;
        }
    }

}
