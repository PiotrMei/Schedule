using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Entities;
using ScheduleApp.Queries;

namespace ScheduleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator medioator)
        {
            _mediator = medioator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointments()
        {
            var request = new GetAllAppointmentsQuery();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
