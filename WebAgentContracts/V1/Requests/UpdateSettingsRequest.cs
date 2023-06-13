namespace WebAgentContracts.V1.Requests;

public sealed class UpdateSettingsRequest
{
    //public string? ApiKey { get; set; }
    public string? ProjectName { get; set; }
    public string? ServiceName { get; set; }
    public string? AppSettingsFileName { get; set; }
    public string? ParametersFileDateMask { get; set; }
    public string? ParametersFileExtension { get; set; }
}