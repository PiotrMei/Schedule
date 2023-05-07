using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Application.Queries;
using ScheduleCore.Exceptions;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Primitives;

namespace ScheduleCore.Application.QueryHandlers
{
    internal class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, ClientInformationDto>
    {
        private readonly ScheduleDbContext _context;
        private readonly IMapper _mapper;
        public GetClientByIdQueryHandler(ScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientInformationDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.Include(a => a.Adress)
                 .FirstOrDefaultAsync(c => c.Id == request.ClientId, cancellationToken);
            if (client == null) throw new NotFoundException("CLient not Found");
            var clientDto = _mapper.Map<ClientInformationDto>(client);
            return clientDto;
        }
    }
}
