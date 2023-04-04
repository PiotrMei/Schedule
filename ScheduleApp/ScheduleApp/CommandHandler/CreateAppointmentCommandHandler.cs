using MediatR;
using ScheduleApp.Command;
using ScheduleApp.Entities;
using ScheduleApp.Exceptions;

namespace ScheduleApp.CommandHandler
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Unit>
    {
        private readonly ScheduleDbContext _context;
        public CreateAppointmentCommandHandler(ScheduleDbContext context)
        {
            _context = context;
        }
        public Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Appointment appointment = new Appointment()
            {
                AppointmentStart = request.appointmentStart,
                AppointmentEnd = request.AppointmentEnd,
                Remarks = request.Remarks,
                ClientInformations = _context.Clients.FirstOrDefault(a => a.Id == request.clientInformationsId),
                Service = _context.Services.FirstOrDefault(a => a.Id == request.serviceId)
            };
            if (appointment.ClientInformations == null)
            {
                throw new NotFoundException("Client not found");
            }
            if (appointment.Service == null)
            {
                throw new NotFoundException("Service not found");
            }
            List<Appointment> appointments = _context.Appointments.ToList();
            var validationrResult = TermValidator.Validate(appointment, appointments);
            if (validationrResult == false) throw new FormatException("incorrect input");
            _context.Add(appointment);
            _context.SaveChanges();
            return Task.FromResult(Unit.Value);

        }


    }
}
