using SystemTools.SharedKernel;

namespace WebAgentContracts.WebAgentDatabasesApiContracts.Errors;

public static class DatabaseApiClientErrors
{
    public static Error DatabasesBackupFilesExchangeParametersIsNotConfigured =>
        Error.Problem(nameof(DatabasesBackupFilesExchangeParametersIsNotConfigured),
            "Databases Backup Files Exchange Parameters Is Not Configured");

    public static Error BaseBackupParametersIsNotCreated =>
        Error.Problem(nameof(BaseBackupParametersIsNotCreated), "Base Backup Parameters Is Not Created");

    public static Error BackupFileParametersIsNull =>
        Error.Problem(nameof(BackupFileParametersIsNull), "BackupFileParameters Is Null");

    public static Error ErrorWhenRestoreDatabase =>
        Error.Problem(nameof(ErrorWhenRestoreDatabase), "Error When Restore Database");

    public static Error DatabaseServerDataIsNotConfigured =>
        Error.Problem(nameof(DatabaseServerDataIsNotConfigured), "Database Server Data Is Not Configured");
}
