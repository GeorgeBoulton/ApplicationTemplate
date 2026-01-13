namespace ApplicationTemplate.Api;

public static class Startup
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddMappers();
    }

    private static void AddMappers(this IServiceCollection services)
    {
        
    }

}
