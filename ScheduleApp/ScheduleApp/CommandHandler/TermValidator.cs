using ScheduleApp.Entities;
using ScheduleApp.Exceptions;

namespace ScheduleApp.CommandHandler
{
    public class TermValidator
    {
        public static void Validate(Appointment appointment, ScheduleDbContext _context)
        {
            foreach (var item in _context.Appointments)
            {
                if (appointment.AppointmentEnd >= item.AppointmentStart &&
                    appointment.AppointmentEnd <= item.AppointmentEnd)
                {
                    throw new ForbiddenException("Date not available");
                }
                else if (appointment.AppointmentStart >= item.AppointmentStart &&
                    appointment.AppointmentStart <= item.AppointmentEnd)
                {
                    throw new ForbiddenException("Date not available");
                }
                else if (appointment.AppointmentStart < item.AppointmentStart &&
                    appointment.AppointmentEnd > item.AppointmentEnd)
                {
                    throw new ForbiddenException("Date not available");
                }
            }
        }
    }
}
