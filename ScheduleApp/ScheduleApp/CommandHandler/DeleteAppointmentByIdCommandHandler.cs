using MediatR;
using ScheduleApp.Command;
using ScheduleApp.Entities;
using ScheduleApp.Exceptions;

namespace ScheduleApp.CommandHandler
{
    public class DeleteAppointmentByIdCommandHandler : IRequestHandler<DeleteAppointmentByIdCommand, Unit>
    {
        ScheduleDbContext _context;
        public DeleteAppointmentByIdCommandHandler(ScheduleDbContext context)
        {
            _context = context;
        }
        public Task<Unit> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == request.appointmentId);
            if (appointment == null)
            {
                throw new NotFoundException("Appointment not found");
            }
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return Task.FromResult(Unit.Value);
        }
    }
}
