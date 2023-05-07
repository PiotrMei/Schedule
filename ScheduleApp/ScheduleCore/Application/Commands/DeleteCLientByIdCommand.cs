using MediatR;
using ScheduleCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Application.Commands
{
    public record DeleteCLientByIdCommand(int ClientId) :ICommand<Unit>
    {
    }
}
