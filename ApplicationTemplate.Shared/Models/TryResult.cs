using System.Net;

namespace ApplicationTemplate.Shared.Models;

public record TryResult<T>(T? Result, bool Success, HttpStatusCode StatusCode, string? ErrorMessage = null);