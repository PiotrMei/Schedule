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
    public record GetAllClientsQuery(string searchQuery, SortDirection sortDirection,
        int pageNumber, int pagesize) :IQuery<PageResult<ClientInformationDto>>
    {
    }
}
