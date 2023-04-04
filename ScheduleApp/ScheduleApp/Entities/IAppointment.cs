namespace ScheduleApp.Entities
{
    public interface IAppointment
    {
        DateTime AppointmentEnd { get; set; }
        DateTime AppointmentStart { get; set; }
    }
}