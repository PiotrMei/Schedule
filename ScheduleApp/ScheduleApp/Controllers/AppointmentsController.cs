﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Command;
using ScheduleApp.Models;
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
        public async Task<ActionResult<List<AppointmentsDto>>> GetAllAppointments(CancellationToken cancellationToken)
        {
            var request = new GetAllAppointmentsQuery();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] CreateAppointment.Command createAppointmentCommand)
        {
            await _mediator.Send(createAppointmentCommand);
            return Created("api/Appointment", null);
        }

        [HttpDelete("{appointemtId}")]
        public async Task<ActionResult> DeleteAppointment([FromRoute] int appointemtId)
        {
            var request = new DeleteAppointmentByIdCommand(appointemtId);
            await _mediator.Send(request);
            return NoContent();
        }

    }
}
