using MediatR;
using ScheduleCore.Primitives;

namespace ScheduleCore.Command
{
    public record DeleteAppointmentByIdCommand(int appointmentId) : ICommand<Unit>
    {
    }
}
