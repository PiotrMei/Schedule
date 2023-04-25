using ScheduleCore.Queries;
using ScheduleCore.QueryHandlers;

namespace ScheduleCore.Application
{
    public interface IMediatRSend
    {
        Task<List<AppointmentsDto>> Send(CancellationToken ct);
    }
}