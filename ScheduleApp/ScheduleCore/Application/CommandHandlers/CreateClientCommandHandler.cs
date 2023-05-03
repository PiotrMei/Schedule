using Microsoft.EntityFrameworkCore;
using ScheduleCore.Application.Commands;
using ScheduleCore.Entities;
using ScheduleCore.Exceptions;
using ScheduleCore.Infrastructure.EntityFramework.EntitiesConfiguration;
using ScheduleCore.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCore.Application.CommandHandlers
{
    internal class CreateClientCommandHandler : ICommandHandler<CreateClient.Command, int>
    {
        private readonly ScheduleDbContext _context;

        public CreateClientCommandHandler(ScheduleDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateClient.Command request, CancellationToken cancellationToken)
        {
            var NewAddress = new Address()
            {
                Street= request.Street,
                City= request.City,
                PostalCode= request.PostalCode,
                Number=request.Number
            };

            var NewClient = new ClientInformation()
            {
                Name=request.Name,
                LastName= request.LastName,
                AdressId= NewAddress.Id,
                PhoneNumber=request.PhoneNumber,
                Remarks= request.Remarks,
            };
            var Clients = _context.Clients;
            foreach (var item in Clients)
            {
                if (item.Equals(NewClient)) //Equals override in Clientinformation
                {
                    throw new ForbiddenException("Client Exists");
                }     
            }

            await _context.AddAsync(NewClient, cancellationToken);
            await _context.SaveChangesAsync();
            return NewClient.Id;

        }
    }
}
