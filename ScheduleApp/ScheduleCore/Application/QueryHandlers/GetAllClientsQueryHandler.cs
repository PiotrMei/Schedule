using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Application.Queries;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Application.QueryHandlers
{
    internal class GetAllClientsQueryHandler : IQueryHandler<GetAllClientsQuery, List<ClientInformationDto>>
    {
        private readonly ScheduleDbContext _context;
        private readonly IMapper _mapper;
        public GetAllClientsQueryHandler(ScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<List<ClientInformationDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var Clients = await _context.Clients
                .Include(a => a.Adress)
                .ToListAsync(cancellationToken);
           
            var ClientsDto = _mapper.Map<List<ClientInformationDto>>(Clients).ToList(); 
            return ClientsDto;
        }
    }
}
