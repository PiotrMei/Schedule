using MediatR;
using ScheduleCore.Primitives;

namespace ScheduleCore.Command
{
    public record CreateAppointmentCommand(int ClientInformationsId, int ServiceId,
                DateTime AppointmentStart, DateTime AppointmentEnd, string? Remarks) : ICommand<int>
    {
    }
}
