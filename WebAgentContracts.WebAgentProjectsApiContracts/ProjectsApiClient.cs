using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SystemTools.ApiContracts;
using SystemTools.SharedKernel;
using SystemTools.StringMessagesApiContracts;
using WebAgentContracts.WebAgentProjectsApiContracts.V1.Requests;
using WebAgentContracts.WebAgentProjectsApiContracts.V1.Routes;

namespace WebAgentContracts.WebAgentProjectsApiContracts;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ProjectsApiClient : ApiClient
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public ProjectsApiClient(ILogger logger, IHttpClientFactory httpClientFactory, string server, string? apiKey,
        bool useConsole) : base(logger, httpClientFactory, server, apiKey, new StringMessageHubClient(server, apiKey),
        useConsole)
    {
    }

    public Task<Result<string>> GetAppSettingsVersionByProxy(int serverSidePort, string apiVersionId,
        CancellationToken cancellationToken = default)
    {
        return GetAsyncAsString(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.GetAppSettingsVersionPrefix}/{serverSidePort}/{apiVersionId}",
            cancellationToken);
    }

    public Task<Result<string>> GetVersionByProxy(int serverSidePort, string apiVersionId,
        CancellationToken cancellationToken = default)
    {
        return GetAsyncAsString(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.GetVersionPrefix}/{serverSidePort}/{apiVersionId}",
            cancellationToken);
    }

    public ValueTask<Result> RemoveProjectAndService(string projectName, string environmentName, bool isService,
        CancellationToken cancellationToken = default)
    {
        return DeleteAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.RemoveProjectServicePrefix}/{projectName}/{environmentName}/{isService}",
            cancellationToken);
    }

    public ValueTask<Result> StartService(string projectName, string environmentName,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.StartServicePrefix}/{projectName}/{environmentName}",
            cancellationToken);
    }

    public ValueTask<Result> StopService(string projectName, string environmentName,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{ProjectsApiRoutes.Projects.ProjectBase}{ProjectsApiRoutes.Projects.StopServicePrefix}/{projectName}/{environmentName}",
            cancellationToken);
    }

    public ValueTask<Result<string>> InstallProgram(string projectName, string environmentName,
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

        string bodyJsonData = JsonConvert.SerializeObject(body);

        return PostAsyncReturnString(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.Update, true,
            bodyJsonData, cancellationToken);
    }

    public ValueTask<Result<string>> InstallService(string projectName, string environmentName, string serviceUserName,
        string appSettingsFileName, string programArchiveDateMask, string programArchiveExtension,
        string parametersFileDateMask, string parametersFileExtension, string? serviceDescriptionSignature,
        string? projectDescription, CancellationToken cancellationToken = default)
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

        string bodyJsonData = JsonConvert.SerializeObject(body);

        return PostAsyncReturnString(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.UpdateService,
            true, bodyJsonData, cancellationToken);
    }

    public ValueTask<Result> UpdateAppParametersFile(string projectName, string environmentName,
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
        string bodyJsonData = JsonConvert.SerializeObject(body);

        return PostAsync(ProjectsApiRoutes.Projects.ProjectBase + ProjectsApiRoutes.Projects.UpdateSettings, true,
            bodyJsonData, cancellationToken);
    }
}
