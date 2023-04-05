﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Command;
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
        public async Task<ActionResult<List<Appointment>>> GetAllAppointments(CancellationToken ct)
        {
            var request = new GetAllAppointmentsQuery();
            var response = await _mediator.Send(request, ct);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] CreateAppointmentCommand createAppointmentCommand, CancellationToken ct)
        {
            var request = new CreateAppointmentCommand(createAppointmentCommand.clientInformationsId,
                createAppointmentCommand.serviceId, createAppointmentCommand.appointmentStart,
                createAppointmentCommand.AppointmentEnd, createAppointmentCommand.Remarks);
            await _mediator.Send(request, ct);
            return Created("api/Appointment",null);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAppointment([FromQuery] int appointemtID, CancellationToken ct)
        {
            var request = new DeleteAppointmentByIdCommand(appointemtID);
            await _mediator.Send(request, ct);
            return NoContent();
        }

    }
}
