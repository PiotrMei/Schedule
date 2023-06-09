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
        public async Task<IActionResult> Clients(GetAllClientsQuery getAllClientsQuery,CancellationToken ct)
        {
            //var request = new GetAllClientsQuery();
            var response = await _mediator.Send(getAllClientsQuery, ct);

            return View(response);
        }
        [HttpGet("/CreateClientView")]
        public IActionResult CreateClientView()
        {
            return View();
        }
        [HttpPost("/CreateClientPost")]
        public async Task<IActionResult> CreateClientPost(CreateClientCommand createClientCommand, CancellationToken ct)
        {
            int ClientId = await _mediator.Send(createClientCommand, ct);

            return View(ClientId);
        }

        [HttpGet("/DeleteClient/{ClientId}")]
        public IActionResult DeleteClient([FromRoute] int ClientId)
        {
            var deleteCLientByIdCommand = new DeleteCLientByIdCommand(ClientId);
            return View(deleteCLientByIdCommand);
        }


        [HttpPost("/DeleteClient/{ClientId}")]
        public async Task<IActionResult> DeleteClient([FromRoute]int ClientId, CancellationToken ct)
        {
            var deleteCLientByIdCommand = new DeleteCLientByIdCommand(ClientId);
            await _mediator.Send(deleteCLientByIdCommand, ct);
            return RedirectToAction("Clients");
        }

        [HttpGet("/GetClientById/{ClientId}")]
        public async Task<IActionResult> GetClientById([FromRoute] int ClientId, CancellationToken ct)
        {
            var request = new GetClientByIdQuery(ClientId);
            var response = await _mediator.Send(request, ct);
            return View(response);
        }

        [HttpGet("/PutClientView/{ClientId}")]
        public async Task<IActionResult> PutClientView([FromRoute] int clientId, CancellationToken ct)
        {
            var request = new GetClientByIdQuery(clientId);
            var response = await _mediator.Send(request, ct);
            var PutClientByIdCommand = new PutClientByIdCommand(clientId, response.Name ,response.LastName ,
                response.PhoneNumber , response.ClientRemarks, response.City,response.PostalCode ,
                response.Street ,response.Number );
            return View(PutClientByIdCommand);
        }
        [HttpPost("/PutClientById")]
        public async Task<IActionResult> PutClientById(PutClientByIdCommand putClientByIdCommand, CancellationToken ct)
        {
            
            await _mediator.Send(putClientByIdCommand, ct);
            string Id = "GetClientById/"+putClientByIdCommand.ClientId.ToString();
            return RedirectToAction("Clients");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}