using ApplicationTemplate.Shared.Models;

namespace ApplicationTemplate.DAL.Clients;

public interface IBaseClient
{
    Task<TryResult<T>> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default);
    Task<TryResult<TResponse>> PostAsync<TRequest, TResponse>(
        Uri uri,
        TRequest request,
        CancellationToken cancellationToken = default);
    Task<TryResult<TResponse>> PutAsync<TRequest, TResponse>(
        Uri uri,
        TRequest request,
        CancellationToken cancellationToken = default);
    Task<TryResult<T>> DeleteAsync<T>(Uri uri, CancellationToken cancellationToken = default);
}