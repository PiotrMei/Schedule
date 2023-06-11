using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Application.Queries;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Primitives;

namespace ScheduleCore.Application.QueryHandlers
{
    internal class GetAllClientsQueryHandler : IQueryHandler<GetAllClientsQuery, PageResult<ClientInformationDto>>
    {
        private readonly ScheduleDbContext _context;
        private readonly IMapper _mapper;
        public GetAllClientsQueryHandler(ScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PageResult<ClientInformationDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var BaseClients = _context.Clients
                .Include(a => a.Adress)
                .Include(a => a.Appointments)
                .Where(s => request.searchQuery == null || s.Name.ToLower() == request.searchQuery.ToLower()
                || s.LastName.ToLower() == request.searchQuery.ToLower());

            int pageNumber;
            int pageSize;
            if (request.pageNumber == 0)
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = request.pageNumber;
            }
            if (request.pagesize== 0)
            {
                pageSize = 5;
            }
            else
            {
                pageSize = request.pagesize;
            }


            BaseClients = request.sortDirection == SortDirection.Ascending ? BaseClients.OrderBy(o => o.Name) :
                     BaseClients.OrderByDescending(o => o.Name);
            var totalresults = BaseClients.Count();
            if (pageNumber * pageSize - totalresults >= pageSize)
            {
                pageNumber= (int)Math.Ceiling(totalresults / (double)pageSize);
            }
            var Clients = await BaseClients
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);


            var ClientsDto = _mapper.Map<List<ClientInformationDto>>(Clients);
            var ClientPageResult = new PageResult<ClientInformationDto>(ClientsDto,
                pageNumber, pageSize, totalresults);
            return ClientPageResult;
        }
    }
}
