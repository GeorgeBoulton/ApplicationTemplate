using System.Net;
using System.Net.Http.Json;
using ApplicationTemplate.Shared.Models;

namespace ApplicationTemplate.DAL.Clients;

public class BaseClient(HttpClient httpClient) : IBaseClient
{
    public async Task<TryResult<T>> GetAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        return await SendAsync<T>(HttpMethod.Get, uri, cancellationToken: cancellationToken);
    }
    
    public async Task<TryResult<TResponse>> PostAsync<TRequest, TResponse>(
        Uri uri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var content = JsonContent.Create(request);

        return await SendAsync<TResponse>(HttpMethod.Post, uri, content, cancellationToken);
    }
    
    public async Task<TryResult<TResponse>> PutAsync<TRequest, TResponse>(
        Uri uri,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        var content = JsonContent.Create(request);

        return await SendAsync<TResponse>(HttpMethod.Put, uri, content, cancellationToken);
    }

    
    public async Task<TryResult<T>> DeleteAsync<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        return await SendAsync<T>(HttpMethod.Delete, uri, cancellationToken: cancellationToken);
    }

    private async Task<TryResult<T>> SendAsync<T>(
        HttpMethod httpMethod,
        Uri uri,
        HttpContent? httpContent = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(httpMethod, uri);
        
        if (httpContent != null) request.Content = httpContent;

        try
        {
            using var response = await httpClient.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new TryResult<T>(default, true, response.StatusCode);
                }
                
                var content = await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
            
                return new TryResult<T>(content, true, response.StatusCode);

            }

            var errorResponse = await response.Content.ReadAsStringAsync(cancellationToken);
        
            return new TryResult<T>(default, false, response.StatusCode, errorResponse);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"Request to {uri} timed out.");
        }
        catch (HttpRequestException e)
        {
            // e.StatusCode can be null (DNS failure etc.)
            throw new HttpRequestException(
                $"Request to {uri} failed{(e.StatusCode is { } sc ? $" with status code {(int)sc} ({sc})" : "")}.",
                e,
                e.StatusCode);
        }
    }
}