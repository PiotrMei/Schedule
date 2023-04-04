using ScheduleApp.Entities;

namespace ScheduleApp.CommandHandler
{
    public class TermValidator
    {
        //public static void Validate(Appointment appointment, ScheduleDbContext _context)
        public static bool Validate(IAppointment inputappointment, List<Appointment> appointments)

        {
            if (inputappointment.AppointmentStart == null) return false;
            if (inputappointment.AppointmentEnd == null) return false;

            if (appointments == null || !appointments.Any()) return true;

            var validationResultStart = appointments.FirstOrDefault(appointments => inputappointment.AppointmentStart >= appointments.AppointmentStart &&
            inputappointment.AppointmentStart <= appointments.AppointmentEnd);
            if (validationResultStart != null) return false;

            var validationResultEnd = appointments.FirstOrDefault(appointments => inputappointment.AppointmentEnd >= appointments.AppointmentStart &&
            inputappointment.AppointmentEnd <= appointments.AppointmentEnd);
            if (validationResultEnd != null) return false;

            var validationResultOver = appointments.FirstOrDefault(appointments => inputappointment.AppointmentStart < appointments.AppointmentStart &&
            inputappointment.AppointmentEnd > appointments.AppointmentEnd);
            if (validationResultOver != null) return false;

            return true;
        }
    }
}
