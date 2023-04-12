using Microsoft.EntityFrameworkCore;
using ScheduleApp.Entities;

namespace ScheduleApp.CommandHandler
{
    internal class TermValidator : ITermsValidator
    {
        private readonly ScheduleDbContext _context;

        public TermValidator(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task ValidateAsync(DateTime start, DateTime end, CancellationToken cancellationToken)
        {
            var appointments = await _context.Appointments.ToListAsync(cancellationToken);
            var validationrResult = Validate(start, end, appointments);
            if (validationrResult == false)
                throw new InvalidOperationException("incorrect input");
        }

        private static bool Validate(DateTime start, DateTime end, IEnumerable<IAppointment> appointments)
        {
            if (appointments == null || !appointments.Any()) return true;

            var validationResultStart = appointments.FirstOrDefault(appointments => start >= appointments.AppointmentStart &&
            start <= appointments.AppointmentEnd);
            if (validationResultStart != null) return false;

            var validationResultEnd = appointments.FirstOrDefault(appointments => end >= appointments.AppointmentStart &&
            end <= appointments.AppointmentEnd);
            if (validationResultEnd != null) return false;

            var validationResultOver = appointments.FirstOrDefault(appointments => start < appointments.AppointmentStart &&
            end > appointments.AppointmentEnd);
            if (validationResultOver != null) return false;

            return true;
        }
    }
}
