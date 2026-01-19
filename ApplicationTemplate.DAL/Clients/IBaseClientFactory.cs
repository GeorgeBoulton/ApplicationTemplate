namespace ApplicationTemplate.DAL.Clients;

public interface IBaseClientFactory
{
    IBaseClient CreateBaseClient(string clientName);
}