﻿namespace WebAgentProjectsApiContracts.V1.Routes;

public static class ProjectsApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public static class Projects
    {
        public const string ProjectBase = Base + "/projects";
        public const string UpdateSettings = "/updatesettings";
        public const string Update = "/update";
        public const string UpdateService = "/updateservice";
        public const string StopService = "/stop/{projectName}/{environmentName}";
        public const string StartService = "/start/{projectName}/{environmentName}";
        public const string RemoveProjectService = "/removeprojectservice/{projectName}/{environmentName}/{isService}";
        public const string GetAppSettingsVersion = "/getappsettingsversion/{serverSidePort}/{apiVersionId}";
        public const string GetVersion = "/getversion/{serverSidePort}/{apiVersionId}";
    }
}