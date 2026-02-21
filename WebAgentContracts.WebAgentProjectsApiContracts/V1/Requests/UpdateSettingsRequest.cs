namespace WebAgentContracts.WebAgentProjectsApiContracts.V1.Requests;

public sealed class UpdateSettingsRequest
{
    public string? ProjectName { get; set; }
    public string? EnvironmentName { get; set; }
    public string? AppSettingsFileName { get; set; }
    public string? ParametersFileDateMask { get; set; }
    public string? ParametersFileExtension { get; set; }
}
