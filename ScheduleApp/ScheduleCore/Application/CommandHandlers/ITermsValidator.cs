using ScheduleCore.Entities;

namespace ScheduleCore.CommandHandler
{
    internal interface ITermsValidator
    {
        Task ValidateAsync(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}