namespace ApplicationTemplate.Shared;

public record TryResult<T>(T? Result, bool Success, string? ErrorMessage = null);