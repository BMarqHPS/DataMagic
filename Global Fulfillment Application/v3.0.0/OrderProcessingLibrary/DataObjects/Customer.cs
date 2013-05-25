namespace OrderProcessingLibrary.DataObjects
{
    using System;

    public class Customer
    {
        public Customer(OrderLine orderLine)
        {
            OrderNumber = orderLine.OrderNumber;
            FirstName = orderLine.FirstName;
            LastName = orderLine.LastName;
            Address = orderLine.Address;
            Address2 = orderLine.Address2;
            City = orderLine.City;
            State = orderLine.State;
            Zip = orderLine.Zip;
            Phone = orderLine.Phone;

            POBox = CheckForPoBox();
        }

        private bool CheckForPoBox()
        {
            return Address.Contains("PO Box") || Address.Contains("P O BOX") || Address.Contains("P.O.BOX") ||
                   Address.Contains("P.O. BOX") || Address.Contains("P. O. BOX") || Address.StartsWith("BOX ");
        }

        public string OrderNumber { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Zip { get; private set; }

        public string Phone { get; private set; }

        public bool POBox { get; private set; }

        public string Attention
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        public string Key
        {
            get { return String.Format("{0}_{1}_{2}", LastName, Zip, OrderNumber); }
        }

        public string MatchingKey
        {
            get { return String.Format("{0}_{1}_{2}_{3}_{4}", Zip, Address, LastName, FirstName, OrderNumber); }
        }

        public byte IsSameCustomer(Customer customer)
        {
            byte matchCount = 0;

            if (customer.FirstName==FirstName)
                matchCount++;

            if (customer.LastName == LastName)
                matchCount += 3;

            if (customer.Address == Address)
            {
                matchCount++;
            }
            else
            {
                var addressPart1 = customer.Address.Split(' ');
                int streetNumber;
                if (int.TryParse(addressPart1[0], out streetNumber))
                {
                    var addressPart2 = Address.Split(' ');
                    if (streetNumber.ToString() == addressPart2[0])
                        matchCount++;
                }
            }

            if (customer.Zip == Zip)
                matchCount += 3;

            return matchCount;
        }
    }
}
