namespace WebAgentDatabasesApiContracts.V1.Routes;

public static class DatabaseApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public static class Database
    {
        private const string DatabaseBase = Base + "/database";

        //// POST api/database/checkrepairdatabase
        public const string CheckRepairDatabase = DatabaseBase + "/checkrepairdatabase/{databaseName}";

        //// POST api/database/createbackup/{databaseName}
        public const string CreateBackup = DatabaseBase + "/createbackup/{databaseName}";

        //// POST api/database/executecommand/{databaseName}
        public const string ExecuteCommand = DatabaseBase + "/executecommand/{databaseName}";

        //// GET api/database/getdatabasenames
        //[HttpGet("getdatabasenames")]
        public const string GetDatabaseNames = DatabaseBase + "/getdatabasenames";

        //// GET api/database/isdatabaseexists
        //[HttpGet("isdatabaseexists/{databaseName}")]
        public const string IsDatabaseExists = DatabaseBase + "/isdatabaseexists/{databaseName}";

        //[HttpPut("restorebackup/{databaseName}")]
        public const string RestoreBackup = DatabaseBase + "/restorebackup/{databaseName}";

        //// POST api/database/recompileprocedures
        //[HttpPost("recompileprocedures/{databaseName}")]
        public const string RecompileProcedures = DatabaseBase + "/recompileprocedures/{databaseName}";

        //// GET api/database/testconnection
        //[HttpGet("testconnection/{databaseName?}")]
        public const string TestConnection = DatabaseBase + "/testconnection/{databaseName?}";

        //// POST api/database/updatestatistics
        //[HttpPost("updatestatistics/{databaseName}")]
        public const string UpdateStatistics = DatabaseBase + "/updatestatistics/{databaseName}";
    }
}