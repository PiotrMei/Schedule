//using MediatR;
//using ScheduleCore.Domain.Entities;
//using ScheduleCore.Queries;
//using ScheduleCore.QueryHandlers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ScheduleCore.Application
//{
//    public class MediatRSend : IMediatRSend
//    {
//        private readonly IMediator _mediator;
//        public MediatRSend(IMediator mediator)
//        {
//            _mediator = mediator;
//        }
//        public async Task<List<AppointmentsDto>> Send(CancellationToken ct)
//        {
//            var request = new GetAllAppointmentsQuery();
//            var result = await _mediator.Send(request, ct);
//            return result;
//        }
//    }
//}
