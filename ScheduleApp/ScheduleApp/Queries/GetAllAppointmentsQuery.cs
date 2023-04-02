using MediatR;
using ScheduleApp.Entities;
using ScheduleApp.Models;

namespace ScheduleApp.Queries
{
    public class GetAllAppointmentsQuery:IRequest<List<AppointmentsDto>>
    {
    }
}
