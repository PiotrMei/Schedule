using ScheduleCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Application.Commands
{
    public record CreateClientCommand(string Name, string LastName, string PhoneNumber, string? Remarks,
            string? City, string? PostalCode, string? Street, string? Number) : ICommand<int>
    {

    }
}
