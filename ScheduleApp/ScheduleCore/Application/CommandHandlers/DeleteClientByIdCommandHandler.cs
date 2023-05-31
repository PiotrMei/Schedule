using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Application.Commands;
using ScheduleCore.Exceptions;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Primitives;

namespace ScheduleCore.Application.CommandHandlers
{
    internal class DeleteClientByIdCommandHandler : ICommandHandler<DeleteCLientByIdCommand, Unit>
    {
        private readonly ScheduleDbContext _context;
        public DeleteClientByIdCommandHandler(ScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCLientByIdCommand request, CancellationToken cancellationToken)
        {
            var ClientToRemove = await _context.Clients.Include(s => s.Adress)
                 .FirstOrDefaultAsync(c => c.Id == request.ClientId);
            if (ClientToRemove == null) throw new NotFoundException("Client Not Found");
           
            var AddressToRemove = ClientToRemove.Adress;
            if (AddressToRemove != null) _context.Remove(AddressToRemove);

            _context.Remove(ClientToRemove);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
