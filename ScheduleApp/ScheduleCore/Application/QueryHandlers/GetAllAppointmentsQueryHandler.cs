using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Queries;

namespace ScheduleCore.QueryHandlers
{
    internal class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentsDto>>
    {
        private readonly ScheduleDbContext _context;
        private readonly IMapper _mapper;

        public GetAllAppointmentsQueryHandler(ScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AppointmentsDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _context.Appointments
                .Include(a => a.ClientInformation)
                .Include(a => a.Service)
                .Include(a => a.ClientInformation.Adress)
                .ToListAsync(cancellationToken);
            var appointmentsDto = _mapper.Map<List<AppointmentsDto>>(appointments).ToList();

            return appointmentsDto;
        }
    }
}
