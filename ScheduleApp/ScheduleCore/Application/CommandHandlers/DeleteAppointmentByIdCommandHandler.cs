using MediatR;
using ScheduleCore.Command;
using ScheduleCore.Entities;
using ScheduleCore.Exceptions;
using ScheduleCore.Primitives;

namespace ScheduleCore.CommandHandler
{
    internal class DeleteAppointmentByIdCommandHandler : ICommandHandler<DeleteAppointmentByIdCommand, Unit>
    {
        private readonly ScheduleDbContext _context;
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
