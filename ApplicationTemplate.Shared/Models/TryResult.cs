namespace ApplicationTemplate.Shared.Models;

public record TryResult<T>(T? Result, bool Success, string? ErrorMessage = null);