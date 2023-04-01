namespace ScheduleApp.Entities
{
    public class ClientInformations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string? Remarks { get; set; }
        public virtual List<Appointment>? Appointments { get; set; }
    }

}