using ApplicationTemplate.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationTemplate.Domain;

public static class Startup
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ITemplateService, TemplateService>();
    }
}