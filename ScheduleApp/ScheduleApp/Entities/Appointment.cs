namespace ScheduleApp.Entities
{
    public class Appointment : IAppointment
    {
        public int Id { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public string? Remarks { get; set; }
        public int ClientInformationsId { get; set; }
        public virtual ClientInformations ClientInformations { get; set; }
    }
}

