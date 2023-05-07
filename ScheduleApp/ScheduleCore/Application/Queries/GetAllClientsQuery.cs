using MediatR;
using ScheduleCore.Application.QueryHandlers;
using ScheduleCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Application.Queries
{
    public class GetAllClientsQuery :IQuery<List<ClientInformationDto>>
    {
    }
}
