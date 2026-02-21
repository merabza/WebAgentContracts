namespace WebAgentContracts.WebAgentProjectsApiContracts.V1.Routes;

public static class ProjectsApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    public const string ApiBase = Root + "/" + Version;

    public static class Projects
    {
        public const string ProjectBase = "/projects";

        public const string GetAppSettingsVersionPrefix = "/getappsettingsversion";
        public const string GetAppSettingsVersion = GetAppSettingsVersionPrefix + "/{serverSidePort}/{apiVersionId}";

        public const string GetVersionPrefix = "/getversion";
        public const string GetVersion = GetVersionPrefix + "/{serverSidePort}/{apiVersionId}";

        public const string RemoveProjectServicePrefix = "/removeprojectservice";

        public const string RemoveProjectService =
            RemoveProjectServicePrefix + "/{projectName}/{environmentName}/{isService}";

        public const string StartServicePrefix = "/startservice";
        public const string StartService = StartServicePrefix + "/{projectName}/{environmentName}";

        public const string StopServicePrefix = "/stop";
        public const string StopService = StopServicePrefix + "/{projectName}/{environmentName}";

        public const string Update = "/update";
        public const string UpdateService = "/updateservice";
        public const string UpdateSettings = "/updatesettings";
    }
}
