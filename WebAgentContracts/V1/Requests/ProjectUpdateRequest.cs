namespace WebAgentContracts.V1.Requests;

public sealed class ProjectUpdateRequest
{
    public string? ProjectName { get; set; }
    public string? EnvironmentName { get; set; }
    public string? ProgramArchiveDateMask { get; set; }
    public string? ProgramArchiveExtension { get; set; }
    public string? ParametersFileDateMask { get; set; }
    public string? ParametersFileExtension { get; set; }
}