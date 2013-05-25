namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Data;

    public class OrderLine
    {
        private const int AccountOrdinal = 0;
        private const int OrderNumberOrdinal = 1;
        private const int OrderItemIdOrdinal = 2;
        private const int OrderIdOrdinal = 3;
        private const int ProductIdOrdinal = 4;
        private const int QuantityOrderedOrdinal = 5;
        private const int FirstNameOrdinal = 6;
        private const int LastNameOrdinal = 7;
        private const int AddressOrdinal = 8;
        private const int Address2Ordinal = 9;
        private const int CityOrdinal = 10;
        private const int StateOrdinal = 11;
        private const int ZipOrdinal = 12;
        private const int PhoneOrdinal = 13;
        private const int ShipMethodOrdinal = 14;
        private const int GiftOrdinal = 15;

        public string Account { get; private set; }
        public string OrderNumber { get; private set; }
        public int OrderItemID { get; private set; }     
        public int OrderID { get; private set; }         
        public string ProductId { get; private set; }
        public int Quantity { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string Address2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }
        public string Phone { get; private set; }
        public string ShipMethod { get; private set; }
        public string Gift { get; private set; }
        public string Key { get; private set; }

        public Product Item { get; set; }
        public string ItemDescrip { get; set; }


        public OrderLine(DataRow row)
        {
            Account = row[AccountOrdinal].ToString();                           // Formerly BPROJ
            OrderNumber = row[OrderNumberOrdinal].ToString();
            OrderItemID = Convert.ToInt32(row[OrderItemIdOrdinal].ToString());   // Formerly SubOrderNum
            OrderID = Convert.ToInt32(row[OrderIdOrdinal].ToString());          // Formerly CertNum              
            ProductId = row[ProductIdOrdinal].ToString();                       // Formerly ItemNum
            Quantity = Convert.ToInt32(row[QuantityOrderedOrdinal]);
            FirstName = row[FirstNameOrdinal].ToString();
            LastName = row[LastNameOrdinal].ToString();
            Address = row[AddressOrdinal].ToString();
            Address2 = Convert.IsDBNull(row[Address2Ordinal]) ? "" : row[Address2Ordinal].ToString();
            City = row[CityOrdinal].ToString();
            State = row[StateOrdinal].ToString();
            Zip = row[ZipOrdinal].ToString();
            Phone = row[PhoneOrdinal].ToString();
            ShipMethod = row[ShipMethodOrdinal].ToString();
            Gift = row[GiftOrdinal].ToString();

            Key = String.Format("{0}_{1}", OrderNumber, OrderItemID);
        }
    }
}
