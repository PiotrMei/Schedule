using MediatR;
using ScheduleCore.Primitives;

namespace ScheduleCore.Application.Commands
{
    public record PutClientByIdCommand(int ClientId, string Name, string LastName, string PhoneNumber, string? Remarks,
            string? City, string? PostalCode, string? Street, string? Number) : ICommand<Unit>
    {
    }
}
