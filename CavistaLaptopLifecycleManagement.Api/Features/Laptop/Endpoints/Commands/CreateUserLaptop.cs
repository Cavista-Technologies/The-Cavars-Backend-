using CavistaLaptopLifecycleManagement.Api.Features.Laptop.Models;
using CavistaLaptopLifecycleManagement.Api.Features.Laptop.Services;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CavistaLaptopLifecycleManagement.Api.Features.Laptop.Endpoints
{
    [Handler]
    [MapPost("create")]
    [MapGroup<LaptopMapGroup>]
    public sealed partial class CreateUserLaptop
    {
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

        private static ValueTask<IEnumerable<UserLaptop>> HandleAsync(
            Command request,
            UserLaptopService userLaptopService,
            CancellationToken token)
        {
            return userLaptopService.GetUserLaptop();
        }
    }
}
