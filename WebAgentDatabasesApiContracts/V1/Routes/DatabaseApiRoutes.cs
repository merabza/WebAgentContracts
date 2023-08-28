namespace WebAgentDatabasesApiContracts.V1.Routes;

public static class DatabaseApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public static class Database
    {
        public const string DatabaseBase = Base + "/database";

        //// POST api/database/checkrepairdatabase/{databaseName}
        public const string CheckRepairDatabase = "/checkrepairdatabase/{databaseName}";

        //// POST api/database/createbackup/{databaseName}
        public const string CreateBackup = "/createbackup/{databaseName}";

        //// POST api/database/executecommand/{databaseName}
        public const string ExecuteCommand = "/executecommand/{databaseName}";

        //// GET api/database/getdatabasenames
        public const string GetDatabaseNames = "/getdatabasenames";

        //// GET api/database/isdatabaseexists/{databaseName}
        public const string IsDatabaseExists = "/isdatabaseexists/{databaseName}";

        //// PUT restorebackup/{databaseName}
        public const string RestoreBackup = "/restorebackup/{databaseName}";

        //// POST api/database/recompileprocedures/{databaseName}
        public const string RecompileProcedures = "/recompileprocedures/{databaseName}";

        //// GET api/database/testconnection/{databaseName?}
        public const string TestConnection = "/testconnection/{databaseName?}";

        //// POST api/database/updatestatistics/{databaseName}
        public const string UpdateStatistics = "/updatestatistics/{databaseName}";
    }
}