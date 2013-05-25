namespace OrderProcessingLibrary.DataObjects
{
    using System;

    public class ManifestRecord
    {
        public ManifestRecord(string lineIn, string carrier)
        {
            var fields = lineIn.Split(new [] {','});

            OrderId = Convert.ToInt32(fields[Ordinals.OrderId].Trim());
            OrderNumber = fields[Ordinals.OrderNum].Trim();
            OrderItemId = Convert.ToInt32(fields[Ordinals.OrderItemId].Trim());
            Carrier = carrier;
            TrackingNumber = fields[Ordinals.TrackingNumber].Trim();

            Key = String.Format("{0}_{1}", OrderNumber, OrderItemId);
        }

        public string OrderNumber { get; private set; }

        public int OrderId { get; private set; }

        public int OrderItemId { get; private set; }

        public string Carrier { get; private set; }

        public string Key { get; private set; }

        public string TrackingNumber { get; private set; }

    }


    public class Ordinals
    {
        // PackageReference,MANIFEST,SHIPCOST,WEIGHT,CARRIER,SERVICE,PACKAGEID,MULTISHIP,UPSTRACK,PackageReference3,ORDERNO
        public const int OrderNum = 0;          
        public const int Carrier = 4;           // 
        public const int TrackingNumber = 8;    // 
        public const int OrderItemId = 9;       // 
        public const int OrderId = 10;          // 
    }
}
