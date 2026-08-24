using CavistaLaptopLifecycleManagement.Api.Database;
using CavistaLaptopLifecycleManagement.Api.Database.Entities;
using CavistaLaptopLifecycleManagement.Api.Features.Laptop.Models;
using CavistaLaptopLifecycleManagement.Api.Features.Ticket.Models;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CavistaLaptopLifecycleManagement.Api.Features.Ticket.Endpoints.Commands
{
    [Handler]
    [MapPost("create")]
    [MapGroup<TicketMapGroup>]
    public sealed partial class CreateTicket
    {
        internal static Created<Response> TransformResult(Response response) =>
        TypedResults.Created($"/api/tickets/{response.TicketId}", response);

        public sealed record Body
        {
            public required string Description { get; init; }
            public required string Comment { get; init; }
        }

        public sealed record Command
        {
            //[FromRoute]
            //public required int Id { get; init; }

            [FromBody]
            public required Body Body { get; init; }
        }

        public sealed record Response
        {
            public required Guid TicketId { get; init; }
        }

        private async static ValueTask<Response> HandleAsync(
            Command request,
            //UserLaptopService userLaptopService,
            CLMDbContext context,
            CancellationToken token)
        {
            var userId = Guid.Parse("01a0310a-4365-77c5-b2fb-0ca9aff6a92a"); //Replace with logged in user

            var ticketToAdd = new Database.Entities.Ticket
            {
                Description = request.Body.Description,
                Comment = request.Body.Comment,
                UserId = userId, 
                Created_At = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
            };

            context.Tickets.Add(ticketToAdd);

            var userLaptop = await context.UserLaptops.Where(x => x.UserID == userId && x.Condition == UserLaptopCondition.Active && !x.IsDeprecated).FirstOrDefaultAsync(token);

            if (userLaptop == null)
            {
                return default;
            }

            var historyToAdd = new LaptopHistory
            {
                UserLaptopID = userLaptop.Id,
                TicketID = ticketToAdd.Id,
                LaptopHistoryStatus = LaptopHistoryStatus.None,
                Created_At = DateTime.UtcNow, 
                Modified = DateTime.UtcNow,
            };

            context.LaptopHistories.Add(historyToAdd);

            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new Response { TicketId = ticketToAdd.Id };
                }
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurred => {ex.Message}");
            }

            return new Response { TicketId = ticketToAdd.Id};
        }

    }
}
