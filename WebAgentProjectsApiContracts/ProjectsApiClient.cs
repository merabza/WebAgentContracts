using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiContracts;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneOf;
using StringMessagesApiContracts;
using SystemToolsShared.Errors;
using WebAgentProjectsApiContracts.V1.Requests;
using WebAgentProjectsApiContracts.V1.Routes;

namespace WebAgentProjectsApiContracts;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ProjectsApiClient : ApiClient
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectsApiClient(ILogger logger, IHttpClientFactory httpClientFactory, string server, string? apiKey,
        bool useConsole) : base(logger, httpClientFactory, server, apiKey, new StringMessageHubClient(server, apiKey),
        useConsole)
    {
    }

    public Task<OneOf<string, IEnumerable<Err>>> GetAppSettingsVersionByProxy(int serverSidePort, string apiVersionId,
        CancellationToken cancellationToken = default)
    {
        return GetAsyncAsString(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.GetAppSettingsVersionPrefix}/{serverSidePort}/{apiVersionId}",
            cancellationToken);
    }

    public Task<OneOf<string, IEnumerable<Err>>> GetVersionByProxy(int serverSidePort, string apiVersionId,
        CancellationToken cancellationToken = default)
    {
        return GetAsyncAsString(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.GetVersionPrefix}/{serverSidePort}/{apiVersionId}",
            cancellationToken);
    }

    public ValueTask<Option<IEnumerable<Err>>> RemoveProjectAndService(string projectName, string environmentName,
        bool isService, CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.RemoveProjectServicePrefix}/{projectName}/{environmentName}/{isService}",
            cancellationToken);
    }

    public ValueTask<Option<IEnumerable<Err>>> StartService(string projectName, string environmentName,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.StartServicePrefix}/{projectName}/{environmentName}",
            cancellationToken);
    }

    public ValueTask<Option<IEnumerable<Err>>> StopService(string projectName, string environmentName,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.StopServicePrefix}/{projectName}/{environmentName}",
            cancellationToken);
    }

    public ValueTask<OneOf<string, IEnumerable<Err>>> InstallProgram(string projectName, string environmentName,
        string programArchiveDateMask, string programArchiveExtension, string parametersFileDateMask,
        string parametersFileExtension, CancellationToken cancellationToken = default)
    {
        var body = new ProjectUpdateRequest
        {
            ProjectName = projectName,
            EnvironmentName = environmentName,
            ProgramArchiveDateMask = programArchiveDateMask,
            ProgramArchiveExtension = programArchiveExtension,
            ParametersFileDateMask = parametersFileDateMask,
            ParametersFileExtension = parametersFileExtension
        };

        var bodyJsonData = JsonConvert.SerializeObject(body);

        return PostAsyncReturnString(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.Update, true,
            bodyJsonData, cancellationToken);
    }

    public ValueTask<OneOf<string, IEnumerable<Err>>> InstallService(string projectName, string environmentName,
        string serviceUserName, string appSettingsFileName, string programArchiveDateMask,
        string programArchiveExtension, string parametersFileDateMask, string parametersFileExtension,
        string? serviceDescriptionSignature, string? projectDescription, CancellationToken cancellationToken = default)
    {
        var body = new UpdateServiceRequest
        {
            ProjectName = projectName,
            EnvironmentName = environmentName,
            ServiceUserName = serviceUserName,
            AppSettingsFileName = appSettingsFileName,
            ProgramArchiveDateMask = programArchiveDateMask,
            ProgramArchiveExtension = programArchiveExtension,
            ParametersFileDateMask = parametersFileDateMask,
            ParametersFileExtension = parametersFileExtension,
            ServiceDescriptionSignature = serviceDescriptionSignature,
            ProjectDescription = projectDescription
        };

        var bodyJsonData = JsonConvert.SerializeObject(body);

        return PostAsyncReturnString(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.UpdateService,
            true, bodyJsonData, cancellationToken);
    }

    public ValueTask<Option<IEnumerable<Err>>> UpdateAppParametersFile(string projectName, string environmentName,
        string appSettingsFileName, string parametersFileDateMask, string parametersFileExtension,
        CancellationToken cancellationToken = default)
    {
        var body = new UpdateSettingsRequest
        {
            ProjectName = projectName,
            EnvironmentName = environmentName,
            AppSettingsFileName = appSettingsFileName,
            ParametersFileDateMask = parametersFileDateMask,
            ParametersFileExtension = parametersFileExtension
        };
        var bodyJsonData = JsonConvert.SerializeObject(body);

        return PostAsync(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.UpdateSettings, true,
            bodyJsonData, cancellationToken);
    }
}