﻿namespace WebAgentProjectsApiContracts.V1.Requests;

public sealed class UpdateServiceRequest
{
    public string? ProjectName { get; set; }
    public string? EnvironmentName { get; set; }
    public string? ServiceName { get; set; }
    public string? ServiceUserName { get; set; }
    public string? AppSettingsFileName { get; set; }
    public string? ProgramArchiveDateMask { get; set; }
    public string? ProgramArchiveExtension { get; set; }
    public string? ParametersFileDateMask { get; set; }
    public string? ParametersFileExtension { get; set; }
    public string? ServiceDescriptionSignature { get; set; }
    public string? ProjectDescription { get; set; }
}