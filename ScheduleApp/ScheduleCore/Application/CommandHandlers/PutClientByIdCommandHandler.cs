using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Application.Commands;
using ScheduleCore.Exceptions;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Primitives;

namespace ScheduleCore.Application.CommandHandlers
{
    internal class PutClientByIdCommandHandler : ICommandHandler<PutClientByIdCommand, Unit>
    {
        private readonly ScheduleDbContext _context;
        public PutClientByIdCommandHandler(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PutClientByIdCommand request, CancellationToken cancellationToken)
        {
            var ClientToPut = await _context.Clients
                .Include(a => a.Adress)
                .FirstOrDefaultAsync(a => a.Id == request.ClientId, cancellationToken);

            if (ClientToPut == null) throw new NotFoundException("Client not found");

            if (request.Name != null) ClientToPut.Name = request.Name;
            if (request.LastName != null) ClientToPut.LastName = request.LastName;
            if (request.PhoneNumber != null) ClientToPut.PhoneNumber = request.PhoneNumber;
            if (request.Remarks != null) ClientToPut.Remarks = request.Remarks;
            if (request.PostalCode != null) ClientToPut.Adress.PostalCode = request.PostalCode;
            if (request.City != null) ClientToPut.Adress.City = request.City;
            if (request.Street != null) ClientToPut.Adress.Street = request.Street;
            if (request.Number != null) ClientToPut.Adress.Number = request.Number;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
