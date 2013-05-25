namespace OrderProcessingLibrary.DataObjects
{
    using System.Collections.Generic;

    public class PrePackage : List<Order>
    {
        private readonly SortedList<string, SortedList<string, OrderItem>> allMultiPackItems =
            new SortedList<string, SortedList<string, OrderItem>>();

        private readonly SortedList<string, OrderItem> singlePackItems = new SortedList<string, OrderItem>();

        public PrePackage(string orderNumber, string custKey)
        {
            var stndShipItems = new SortedList<string, OrderItem>();
            var twoDayShipItems = new SortedList<string, OrderItem>();
            var overnightShipItems = new SortedList<string, OrderItem>();

            Key = orderNumber;
            CustomerKey = custKey;

            allMultiPackItems.Add("STND", stndShipItems);
            allMultiPackItems.Add("2DAY", twoDayShipItems);
            allMultiPackItems.Add("1DAY", overnightShipItems);
        }


        public string CustomerKey { get; private set; }

        public string Key { get; private set; }

        public SortedList<string, SortedList<string, OrderItem>> MultiPackItems { get { return allMultiPackItems; } }

        public SortedList<string, OrderItem> SinglePackItems { get { return singlePackItems; } }


        public void BuildItemLists(Products itemList)
        {
            for (var i = 0; i < Count; i++)
            {
                foreach (var objOrdItem in base[i].OrderItems.Values)
                {
                    if (objOrdItem.Item.SinglePack)
                    {
                        singlePackItems.Add(objOrdItem.Key, objOrdItem);
                    }
                    else
                    {
                        switch (objOrdItem.OrderInfo.ShipMethod)
                        {
                            case "2DAY":
                                allMultiPackItems["2DAY"].Add(objOrdItem.Key, objOrdItem);
                                break;
                            case "1DAY":
                                allMultiPackItems["1DAY"].Add(objOrdItem.Key, objOrdItem);
                                break;
                            default:
                                allMultiPackItems["STND"].Add(objOrdItem.Key, objOrdItem);
                                break;
                        }
                    }
                }
            }
        }
    }
}
