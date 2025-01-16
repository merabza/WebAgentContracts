using SystemToolsShared.Errors;

namespace WebAgentDatabasesApiContracts.Errors;

public static class DatabaseApiClientErrors
{
    public static readonly Err AppSettingsIsNotCreated = new()
    {
        ErrorCode = nameof(AppSettingsIsNotCreated), ErrorMessage = "appSettings is not created"
    };
}