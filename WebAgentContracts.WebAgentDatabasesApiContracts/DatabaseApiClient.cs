using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DatabaseTools.DbTools;
using DatabaseTools.DbTools.Models;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneOf;
using ParametersManagement.LibDatabaseParameters;
using SystemTools.ApiContracts;
using SystemTools.StringMessagesApiContracts;
using SystemTools.SystemToolsShared.Errors;
using WebAgentContracts.WebAgentDatabasesApiContracts.V1.Requests;
using WebAgentContracts.WebAgentDatabasesApiContracts.V1.Responses;
using WebAgentContracts.WebAgentDatabasesApiContracts.V1.Routes;

namespace WebAgentContracts.WebAgentDatabasesApiContracts;

public sealed class DatabaseApiClient : ApiClient
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public DatabaseApiClient(ILogger logger, IHttpClientFactory httpClientFactory, string server, string? apiKey,
        bool useConsole) : base(logger, httpClientFactory, server, apiKey, new StringMessageHubClient(server, apiKey),
        useConsole)
    {
    }

    //შემოწმდეს არსებული ბაზის მდგომარეობა და საჭიროების შემთხვევაში გამოასწოროს ბაზა
    public ValueTask<Option<Err[]>> CheckRepairDatabase(string databaseName,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.CheckRepairDatabasePrefix}/{databaseName}",
            cancellationToken);
    }

    //დამზადდეს ბაზის სარეზერვო ასლი სერვერის მხარეს.
    //ასევე ამ მეთოდის ამოცანაა უზრუნველყოს ბექაპის ჩამოსაქაჩად ხელმისაწვდომ ადგილას მოხვედრა
    public Task<OneOf<BackupFileParameters, Err[]>> CreateBackup(
        DatabaseBackupParametersDomain databaseBackupParameters, string backupBaseName, string dbServerFoldersSetName,
        CancellationToken cancellationToken = default)
    {
        return PostAsyncReturn<BackupFileParameters>(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.CreateBackupPrefix}/{backupBaseName}/{dbServerFoldersSetName}",
            true, JsonConvert.SerializeObject(databaseBackupParameters), cancellationToken);
    }

    //სერვერის მხარეს მონაცემთა ბაზაში ბრძანების გაშვება
    public ValueTask<Option<Err[]>> ExecuteCommand(string executeQueryCommand, string? databaseName = null,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.ExecuteCommandPrefix}{(string.IsNullOrWhiteSpace(databaseName) ? string.Empty : $"/{databaseName}")}",
            true, executeQueryCommand, cancellationToken);
    }

    //მონაცემთა ბაზების სიის მიღება სერვერიდან
    public Task<OneOf<List<DatabaseInfoModel>, Err[]>> GetDatabaseNames(CancellationToken cancellationToken = default)
    {
        return GetAsyncReturn<List<DatabaseInfoModel>>(
            DatabaseApiRoutes.Database.DatabaseBase + DatabaseApiRoutes.Database.GetDatabaseNames, true,
            cancellationToken);
    }

    //გამოიყენება ბაზის დამაკოპირებელ ინსტრუმენტში, იმის დასადგენად,
    //მიზნის ბაზა უკვე არსებობს თუ არა, რომ არ მოხდეს ამ ბაზის ისე წაშლა ახლით,
    //რომ არსებულის გადანახვა არ მოხდეს.
    public Task<OneOf<bool, Err[]>> IsDatabaseExists(string databaseName, CancellationToken cancellationToken = default)
    {
        return GetAsyncReturn<bool>(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.IsDatabaseExistsPrefix}/{databaseName}",
            true, cancellationToken);
    }

    //გამოიყენება ბაზის დამაკოპირებელ ინსტრუმენტში, დაკოპირებული ბაზის აღსადგენად,
    public Task<Option<Err[]>> RestoreDatabaseFromBackup(string prefix, string suffix, string name, string dateMask,
        string databaseName, string dbServerFoldersSetName, EDatabaseRecoveryModel databaseRecoveryModel,
        CancellationToken cancellationToken = default)
    {
        var bodyJsonData = JsonConvert.SerializeObject(new RestoreBackupRequest
        {
            Prefix = prefix,
            Suffix = suffix,
            Name = name,
            DateMask = dateMask,
            DatabaseRecoveryModel = databaseRecoveryModel
        });
        return PutAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.RestoreBackupPrefix}/{databaseName}/{dbServerFoldersSetName}",
            bodyJsonData, cancellationToken);
    }

    //მონაცემთა ბაზაში არსებული პროცედურების რეკომპილირება
    public ValueTask<Option<Err[]>> RecompileProcedures(string databaseName,
        CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.RecompileProceduresPrefix}/{databaseName}",
            cancellationToken);
    }

    public Task<Option<Err[]>> TestConnection(string? databaseName, CancellationToken cancellationToken = default)
    {
        return GetAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.TestConnectionPrefix}{(databaseName == null ? string.Empty : $"/{databaseName}")}",
            cancellationToken);
    }

    //მონაცემთა ბაზაში არსებული სტატისტიკების დაანგარიშება
    public ValueTask<Option<Err[]>> UpdateStatistics(string databaseName, CancellationToken cancellationToken = default)
    {
        return PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.UpdateStatisticsPrefix}/{databaseName}",
            cancellationToken);
    }

    public Task<OneOf<List<string>, Err[]>> GetDatabaseFoldersSetNames(CancellationToken cancellationToken)
    {
        return GetAsyncReturn<List<string>>(
            DatabaseApiRoutes.Database.DatabaseBase + DatabaseApiRoutes.Database.GetDatabaseFoldersSetNames, true,
            cancellationToken);
    }

    public Task<OneOf<List<string>, Err[]>> GetDatabaseConnectionNames(CancellationToken cancellationToken)
    {
        return GetAsyncReturn<List<string>>(
            DatabaseApiRoutes.Database.DatabaseBase + DatabaseApiRoutes.Database.GetDatabaseConnectionNames, true,
            cancellationToken);
    }

    public ValueTask<Option<Err[]>> ChangeDatabaseRecoveryModel(string databaseName,
        EDatabaseRecoveryModel databaseRecoveryModel, CancellationToken cancellationToken)
    {
        return PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.ChangeDatabaseRecoveryModel}/{databaseName}/{databaseRecoveryModel.ToString()}",
            cancellationToken);
    }
}