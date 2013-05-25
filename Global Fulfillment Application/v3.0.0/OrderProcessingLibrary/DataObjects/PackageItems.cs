namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;

    public class PackageItems
    {
        private readonly SortedList<string, int> items = new SortedList<string, int>();

        private int totalQty;
        private int cubicSize;

        public string Description { get; private set; }

        public byte H { get; private set; }

        public string ItemNumber { get; private set; }

        public byte L { get; private set; }

        public string MultipleItems { get { return (totalQty > 1 ? "M" : ""); } }

        public string ShipMethod { get; private set; }

        public bool SignatureRequired { get; private set; }

        public Single TotalWeight { get; private set; }

        public byte W { get; private set; }

        public void AddItem(Product objItem, int quantity)
        {
            int qty;

            if (items.TryGetValue(objItem.ItemNumber, out qty))
            {
                items[objItem.ItemNumber] = qty + quantity;
            }
            else
                items.Add(objItem.ItemNumber, quantity);

            if (!SignatureRequired)
                SignatureRequired = objItem.SignatureRequired;

            totalQty += quantity;
        }

        public void AddItem(OrderItem orderItem)
        {
            AddItem(orderItem.Item, orderItem.Quantity);

            if (String.IsNullOrEmpty(ShipMethod))
                ShipMethod = orderItem.OrderInfo.ShipMethod;
        }

        public void CalcWeightAndSize(Products itemList)
        {
            foreach (var kvpItem in items)
            {
                var tempItem = itemList.GetItem(kvpItem.Key);

                if (String.IsNullOrEmpty(ItemNumber))
                {
                    ItemNumber = tempItem.ItemNumber;
                    Description = tempItem.Description;
                }

                TotalWeight += tempItem.GetWeightByQty(kvpItem.Value);

                if (tempItem.CubicSize > cubicSize)
                {
                    H = tempItem.H;
                    L = tempItem.L;
                    W = tempItem.W;
                    cubicSize = tempItem.CubicSize;
                }
            }

        }
    }
}
