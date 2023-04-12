using MediatR;
using ScheduleCore.Models;
using ScheduleCore.Primitives;

namespace ScheduleCore.Queries
{
    public class GetAllAppointmentsQuery : IQuery<List<AppointmentsDto>>
    {
    }
}
