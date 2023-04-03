using MediatR;

namespace ScheduleApp.Command
{
    public record DeleteAppointmentByIdCommand(int appointmentId) : IRequest<Unit>
    {
    }
}
