namespace WebAgentDatabasesApiContracts.V1.Routes;

public static class DatabaseApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public static class Database
    {
        public const string DatabaseBase = Base + "/databases";

        //// POST api/databases/checkrepairdatabase/{databaseName}
        public const string CheckRepairDatabase = "/checkrepairdatabase/{databaseName}";

        //// POST api/databases/createbackup/{databaseName}
        public const string CreateBackup = "/createbackup/{databaseName}";

        //// POST api/databases/executecommand/{databaseName}
        public const string ExecuteCommand = "/executecommand/{databaseName}";

        //// GET api/databases/getdatabasenames
        public const string GetDatabaseNames = "/getdatabasenames";

        //// GET api/databases/isdatabaseexists/{databaseName}
        public const string IsDatabaseExists = "/isdatabaseexists/{databaseName}";

        //// PUT api/databases/restorebackup/{databaseName}
        public const string RestoreBackup = "/restorebackup/{databaseName}";

        //// POST api/databases/recompileprocedures/{databaseName}
        public const string RecompileProcedures = "/recompileprocedures/{databaseName}";

        //// GET api/databases/testconnection/{databaseName?}
        public const string TestConnection = "/testconnection/{databaseName?}";

        //// POST api/databases/updatestatistics/{databaseName}
        public const string UpdateStatistics = "/updatestatistics/{databaseName}";
    }
}