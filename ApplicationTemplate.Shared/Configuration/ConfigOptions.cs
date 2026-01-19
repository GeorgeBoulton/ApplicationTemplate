namespace ApplicationTemplate.Shared.Configuration;

public sealed class ConfigOptions
{
    public const string SectionName = "Config";

    public BankSimulatorServiceOptions BankSimulatorService { get; init; } = new();
}

public sealed class BankSimulatorServiceOptions
{
    public string BaseUri { get; init; } = string.Empty;
    public string ClientName { get; init; } = string.Empty;
}