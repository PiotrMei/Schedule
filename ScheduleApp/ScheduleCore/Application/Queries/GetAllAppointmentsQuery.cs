using MediatR;
using ScheduleCore.QueryHandlers;
using ScheduleCore.Primitives;

namespace ScheduleCore.Queries
{
    public class GetAllAppointmentsQuery : IQuery<List<AppointmentsDto>>
    {
    }
}
