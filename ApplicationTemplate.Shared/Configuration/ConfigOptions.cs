namespace ApplicationTemplate.Shared.Configuration;

public sealed class ConfigOptions
{
    public const string SectionName = "Config";

    public UpstreamServiceOptions UpstreamService { get; init; } = new();
}

public sealed class UpstreamServiceOptions
{
        
    public string BaseUri { get; init; } = string.Empty;
}