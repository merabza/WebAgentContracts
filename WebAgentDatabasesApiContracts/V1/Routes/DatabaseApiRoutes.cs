namespace WebAgentDatabasesApiContracts.V1.Routes;

public static class DatabaseApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    public const string ApiBase = Root + "/" + Version;

    public static class Database
    {
        public const string DatabaseBase = "/databases";

        //// POST api/databases/checkrepairdatabase/{databaseName}
        public const string CheckRepairDatabasePrefix = "/checkrepairdatabase";
        public const string CheckRepairDatabase = CheckRepairDatabasePrefix + "/{databaseName}";

        //// POST api/databases/createbackup/{databaseName}
        public const string CreateBackupPrefix = "/createbackup";
        public const string CreateBackup = CreateBackupPrefix + "/{databaseName}";

        //// POST api/databases/executecommand/{databaseName}
        public const string ExecuteCommandPrefix = "/executecommand";
        public const string ExecuteCommand = ExecuteCommandPrefix + "/{databaseName?}";

        //// GET api/databases/getdatabasenames
        public const string GetDatabaseNames = "/getdatabasenames";

        //// GET api/databases/isdatabaseexists/{databaseName}
        public const string IsDatabaseExistsPrefix = "/isdatabaseexists";
        public const string IsDatabaseExists = "/{databaseName}";

        //// PUT api/databases/restorebackup/{databaseName}
        public const string RestoreBackupPrefix = "/restorebackup";
        public const string RestoreBackup = RestoreBackupPrefix + "/{databaseName}";

        //// POST api/databases/recompileprocedures/{databaseName}
        public const string RecompileProceduresPrefix = "/recompileprocedures";
        public const string RecompileProcedures = RecompileProceduresPrefix + "/{databaseName}";

        //// GET api/databases/testconnection/{databaseName?}
        public const string TestConnectionPrefix = "/testconnection";
        public const string TestConnection = TestConnectionPrefix + "/{databaseName?}";

        //// POST api/databases/updatestatistics/{databaseName}
        public const string UpdateStatisticsPrefix = "/updatestatistics";
        public const string UpdateStatistics = UpdateStatisticsPrefix + "/{databaseName}";
    }
}