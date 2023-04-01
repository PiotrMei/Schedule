namespace ScheduleApp.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        //public int ClientId { get; set; }
        public virtual ClientInformations ClientInformations { get; set; }
    }
}