using SystemToolsShared.Errors;

namespace WebAgentDatabasesApiContracts.Errors;

public static class DatabaseApiClientErrors
{
    public static readonly Err DatabasesBackupFilesExchangeParametersIsNotConfigured = new()
    {
        ErrorCode = nameof(DatabasesBackupFilesExchangeParametersIsNotConfigured),
        ErrorMessage = "Databases Backup Files Exchange Parameters Is Not Configured"
    };

    public static readonly Err BaseBackupParametersIsNotCreated = new()
    {
        ErrorCode = nameof(BaseBackupParametersIsNotCreated), ErrorMessage = "Base Backup Parameters Is Not Created"
    };

    public static readonly Err BackupFileParametersIsNull = new()
    {
        ErrorCode = nameof(BackupFileParametersIsNull), ErrorMessage = "BackupFileParameters Is Null"
    };
}