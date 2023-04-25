namespace ScheduleCore.Entities
{
    internal class Address2
    {
        public static Address2 ReturNewAddress()
        {
            return new Address2();
        }
        public Address2()
        { }

        public string City { get; set; }
        public string PostalCode { get; set; }

    }



}