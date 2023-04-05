using ScheduleApp.Entities;

namespace ScheduleApp.CommandHandler
{
    internal interface ITermsValidator
    {
        Task ValidateAsync(DateTime start, DateTime end, CancellationToken cancellationToken);
    }
}