using CavistaLaptopLifecycleManagement.Api.Database;
using CavistaLaptopLifecycleManagement.Api.Features.Ticket.Models;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CavistaLaptopLifecycleManagement.Api.Features.Ticket.Endpoints.Queries
{
    [Handler]
    [MapGet("{ticketId}")]
    [MapGroup<TicketMapGroup>]
    public sealed partial class GetTicket
    {
        public record Query([FromRoute]Guid ticketId);

        private async static ValueTask<Models.Ticket> HandleAsync(
            Query request,
            //UserService userService,
            CLMDbContext context,
            CancellationToken token)
        {
            var ticket =  await (context.Tickets.Where(x => x.Id == request.ticketId).Select(Models.Ticket.FromDatabaseEntity)).FirstOrDefaultAsync(token);

            return ticket;
            //return userService.GetUsers();
        }
    }
}
