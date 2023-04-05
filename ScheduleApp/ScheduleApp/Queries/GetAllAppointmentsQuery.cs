using MediatR;
using ScheduleApp.Models;
using ScheduleApp.Primitives;

namespace ScheduleApp.Queries
{
    public class GetAllAppointmentsQuery : IQuery<List<AppointmentsDto>>
    {
    }
}
