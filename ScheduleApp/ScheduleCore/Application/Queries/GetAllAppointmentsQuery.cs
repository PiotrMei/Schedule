using MediatR;
using ScheduleUI.Models;
using ScheduleCore.Primitives;

namespace ScheduleCore.Queries
{
    public class GetAllAppointmentsQuery : IQuery<List<AppointmentsDto>>
    {
    }
}
