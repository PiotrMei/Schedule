using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Entities;
using ScheduleApp.Models;
using ScheduleApp.Primitives;
using ScheduleApp.Queries;

namespace ScheduleApp.QueryHandlers
{
    internal class GetAllAppointmentsQueryHandler : IQueryHandler<GetAllAppointmentsQuery, List<AppointmentsDto>>
    {
        private readonly ScheduleDbContext _context;
        private readonly IMapper _mapper;

        public GetAllAppointmentsQueryHandler(ScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<List<AppointmentsDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = _context.Appointments
                .Include(a => a.ClientInformations)
                .Include(a => a.Service)
                .Include(a => a.ClientInformations.Adress)
                .ToList();
            var appointmentsDto = _mapper.Map<List<AppointmentsDto>>(appointments).ToList();

            return Task.FromResult(appointmentsDto);
        }
    }
}
