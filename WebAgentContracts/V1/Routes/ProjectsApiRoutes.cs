namespace WebAgentContracts.V1.Routes;

public static class ProjectsApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public static class Projects
    {
        private const string ProjectBase = Base + "/projects";
        public const string UpdateSettings = ProjectBase + "/updatesettings";
        public const string Update = ProjectBase + "/update";
        public const string UpdateService = ProjectBase + "/updateservice";
        public const string StopService = ProjectBase + "/stop/{serviceName}";
        public const string StartService = ProjectBase + "/start/{serviceName}";
        public const string RemoveProject = ProjectBase + "/remove/{projectName}";
        public const string RemoveService = ProjectBase + "/removeservice/{projectName}/{serviceName}";

        public const string GetAppSettingsVersion =
            ProjectBase + "/getappsettingsversion/{serverSidePort}/{apiVersionId}";

        public const string GetVersion = ProjectBase + "/getversion/{serverSidePort}/{apiVersionId}";
    }
}