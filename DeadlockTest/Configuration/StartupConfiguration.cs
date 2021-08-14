using DeadlockTest.Business.Interfaces;
using DeadlockTest.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeadlockTest.Configuration
{
    public static class StartupConfiguration
    {
        public static void SetUpServices(this IServiceCollection service)
        {
            service.AddTransient<IItemService, ItemService>();
            service.AddTransient<IOrderService, OrderService>();
        }
    }
}
