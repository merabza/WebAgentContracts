using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiContracts;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneOf;
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

    public async Task<OneOf<string, Err[]>> GetAppSettingsVersionByProxy(int serverSidePort, string apiVersionId,
        CancellationToken cancellationToken)
    {
        return await GetAsyncAsString(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.GetAppSettingsVersionPrefix}/{serverSidePort}/{apiVersionId}",
            cancellationToken);
    }

    public async Task<OneOf<string, Err[]>> GetVersionByProxy(int serverSidePort, string apiVersionId,
        CancellationToken cancellationToken)
    {
        return await GetAsyncAsString(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.GetVersionPrefix}/{serverSidePort}/{apiVersionId}",
            cancellationToken);
    }

    public async Task<Option<Err[]>> RemoveProjectAndService(string projectName, string environmentName, bool isService,
        CancellationToken cancellationToken)
    {
        return await DeleteAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.RemoveProjectServicePrefix}/{projectName}/{environmentName}/{isService}",
            cancellationToken);
    }

    public async Task<Option<Err[]>> StartService(string projectName, string environmentName,
        CancellationToken cancellationToken)
    {
        return await PostAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.StartServicePrefix}/{projectName}/{environmentName}",
            cancellationToken);
    }

    public async Task<Option<Err[]>> StopService(string projectName, string environmentName,
        CancellationToken cancellationToken)
    {
        return await PostAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.StopServicePrefix}/{projectName}/{environmentName}",
            cancellationToken);
    }

    public async Task<OneOf<string, Err[]>> InstallProgram(string projectName, string environmentName,
        string programArchiveDateMask, string programArchiveExtension, string parametersFileDateMask,
        string parametersFileExtension, CancellationToken cancellationToken)
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

        return await PostAsyncReturnString(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.Update,
            true, bodyJsonData, cancellationToken);
    }

    public async Task<OneOf<string, Err[]>> InstallService(string projectName, string environmentName,
        string serviceUserName, string appSettingsFileName, string programArchiveDateMask,
        string programArchiveExtension, string parametersFileDateMask, string parametersFileExtension,
        string? serviceDescriptionSignature, string? projectDescription, CancellationToken cancellationToken)
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

        return await PostAsyncReturnString(
            ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.UpdateService, true, bodyJsonData,
            cancellationToken);
    }

    public async Task<Option<Err[]>> UpdateAppParametersFile(string projectName, string environmentName,
        string appSettingsFileName, string parametersFileDateMask, string parametersFileExtension,
        CancellationToken cancellationToken)
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

        return await PostAsync(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.UpdateSettings, true,
            bodyJsonData, cancellationToken);
    }
}