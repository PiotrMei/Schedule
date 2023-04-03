using MediatR;

namespace ScheduleApp.Command
{
    public record CreateAppointmentCommand(int clientInformationsId, int serviceId,
        DateTime appointmentStart, DateTime AppointmentEnd, string? Remarks) : IRequest<Unit>
    {
    }
}
