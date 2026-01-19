using ApplicationTemplate.DAL.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTemplate.DAL;

public static class Startup
{
    private static void AddClients(IServiceCollection services)
    {
        services.AddHttpClient("BankSimulator", client =>
        {
            client.BaseAddress = new Uri("http://localhost:8080");
            client.Timeout = TimeSpan.FromSeconds(5);
            // Add headers/retry etc here
        });
        services.AddSingleton<IBaseClientFactory, BaseClientFactory>();
    }
}