using MediatR;
using ScheduleApp.Primitives;

namespace ScheduleApp.Command
{
    public record DeleteAppointmentByIdCommand(int appointmentId) : ICommand<Unit>
    {
    }
}
