namespace ApplicationTemplate.DAL.Clients;

public class BaseClientFactory(IHttpClientFactory factory) : IBaseClientFactory
{
    public IBaseClient CreateBaseClient(string clientName) 
        => new BaseClient(factory.CreateClient(clientName));
}