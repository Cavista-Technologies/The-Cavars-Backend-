using CavistaLaptopLifecycleManagement.Api.Features.Laptop.Models;
using CavistaLaptopLifecycleManagement.Api.Features.Laptop.Services;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Authorization;

namespace CavistaLaptopLifecycleManagement.Api.Features.Laptop.Endpoints
{
    [Handler]
    [MapGet("")]
    [MapGroup<LaptopMapGroup>]
    [AllowAnonymous]
    public sealed partial class GetUserLaptops
    {
        public record Query;

        private static ValueTask<IEnumerable<UserLaptop>> HandleAsync(
            Query _,
            UserLaptopService userLaptopService,
            CancellationToken token)
        {
            return userLaptopService.GetUserLaptop();
        }
    }
}
