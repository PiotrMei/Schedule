using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScheduleCore.Application.Commands;
using ScheduleCore.Application.Queries;
using ScheduleUI.Models;
using System.Diagnostics;

namespace ScheduleUI.Controllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IMediator _mediator;

        public ClientController(ILogger<ClientController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("/Clients")]
        public async Task<IActionResult> Clients(CancellationToken ct)
        {
            var request = new GetAllClientsQuery();
            var response = await _mediator.Send(request, ct);

            return View(response);
        }
        [HttpGet("/CreateClientView")]
        public IActionResult CreateClientView()
        {
            return View();
        }
        [HttpPost("CreateClientPost")]
        public async Task<IActionResult> CreateClientPost(CreateClientCommand createClientCommand, CancellationToken ct)
        {
            int ClientId = await _mediator.Send(createClientCommand, ct);

            return View(ClientId);
        }

        [HttpGet("DeleteClient/{ClientId}")]
        public IActionResult DeleteClient([FromRoute] int ClientId)
        {
            var deleteCLientByIdCommand = new DeleteCLientByIdCommand(ClientId);
            return View(deleteCLientByIdCommand);
        }


        [HttpPost("DeleteClient/{ClientId}")]
        public async Task<IActionResult> DeleteClient([FromRoute]int ClientId, CancellationToken ct)
        {
            var deleteCLientByIdCommand = new DeleteCLientByIdCommand(ClientId);
            await _mediator.Send(deleteCLientByIdCommand, ct);
            return RedirectToAction("Clients");
        }

        [HttpGet("GetClientById/{ClientId}")]
        public async Task<IActionResult> GetClientById([FromRoute] int ClientId, CancellationToken ct)
        {
            var request = new GetClientByIdQuery(ClientId);
            var response = await _mediator.Send(request, ct);
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}