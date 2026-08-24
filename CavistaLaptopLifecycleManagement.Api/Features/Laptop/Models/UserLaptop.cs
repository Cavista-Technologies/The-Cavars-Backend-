using Immediate.Apis.Shared;

namespace CavistaLaptopLifecycleManagement.Api.Features.Laptop.Models
{
    public class UserLaptop
    {
    }


    [RouteGroup("api/laptops")]
    public sealed partial class LaptopMapGroup
    {
        private static void CustomizeGroup(RouteGroupBuilder group)
            => group
                //.RequireAuthorization()
                .WithTags("Laptops");
    }
}
