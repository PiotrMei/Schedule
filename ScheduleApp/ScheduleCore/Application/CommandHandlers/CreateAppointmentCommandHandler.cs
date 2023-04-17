using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleCore.Command;
using ScheduleCore.Domain.Entities;
using ScheduleCore.Entities;
using ScheduleCore.Exceptions;
using ScheduleCore.Extension;
using ScheduleCore.Primitives;

namespace ScheduleCore.CommandHandler
{
    internal class CreateAppointmentCommandHandler : ICommandHandler<CreateAppointment.Command, int>
    {
      
        private readonly ScheduleDbContext _context;
        
        private readonly ITermsValidator _termsValidator;

        public CreateAppointmentCommandHandler(ScheduleDbContext context, ITermsValidator termsValidator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _termsValidator = termsValidator;
           
        }
        public async Task<int> Handle(CreateAppointment.Command request, CancellationToken cancellationToken)
        {
            
            var client = _context.Clients.FirstOrDefault(a => a.Id == request.ClientInformationsId);
            if (client is null)
                throw new NotFoundException("Client not found");

            var service = _context.Services.First(a => a.Id == request.ServiceId);
            if (service is null)
                throw new NotFoundException("Service not found");

            var appointment = await Appointment.Create(
                _termsValidator,
                request.AppointmentStart,
                request.AppointmentEnd,
                service.Id,
                request.Remarks,
                client.Id,
                cancellationToken);
            
            await _context.AddAsync(appointment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
           
            return appointment.Id;
        }
    }
}
