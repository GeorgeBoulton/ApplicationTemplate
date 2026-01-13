namespace ApplicationTemplate.Api;

public static class Startup
{
    public static void AddServices(this IServiceCollection services)
    {
        Domain.Startup.AddServices(services);
        
        services.AddMappers();
    }

    private static void AddMappers(this IServiceCollection services)
    {
        
    }

}
