using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScheduleCore.Application.Commands;
using ScheduleCore.Application.Queries;
using ScheduleCore.Entities;
using ScheduleCore.Queries;
using ScheduleUI.Models;
using System.Diagnostics;

namespace ScheduleUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TestViev()
        {

            var viewModel = new Address2
            {
                City = "Mikołów",
                PostalCode = "43-190"
            };


            return View(viewModel);
        }

        public async Task<IActionResult> Appointments(CancellationToken ct)
        {
            var request = new GetAllAppointmentsQuery();
            var response = await _mediator.Send(request, ct);

            return View(response);
        }
       
        public async Task<IActionResult> Clients(CancellationToken ct)
        {
            var request = new GetAllClientsQuery();
            var response = await _mediator.Send(request, ct);

            return View(response);
        }

        public IActionResult CreateClientView()
        {
            //var request = new CreateClientCommand();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateClientPost(CreateClientCommand createClientCommand, CancellationToken ct)
        {
            int ClientId = await _mediator.Send(createClientCommand, ct);
            
            return View(ClientId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}