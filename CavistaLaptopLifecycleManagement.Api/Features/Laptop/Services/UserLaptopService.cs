using CavistaLaptopLifecycleManagement.Api.Features.Laptop.Models;
using Immediate.Injections.Shared;

namespace CavistaLaptopLifecycleManagement.Api.Features.Laptop.Services
{
    [RegisterScoped<UserLaptopService>]
    public class UserLaptopService
    {
        public async ValueTask<IEnumerable<UserLaptop>> GetUserLaptop()
        {
            return new List<UserLaptop>();
        }
    }
}
