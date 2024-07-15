using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiContracts;
using DbTools;
using DbTools.Models;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneOf;
using SystemToolsShared.Errors;
using WebAgentDatabasesApiContracts.V1.Requests;
using WebAgentDatabasesApiContracts.V1.Responses;
using WebAgentDatabasesApiContracts.V1.Routes;

namespace WebAgentDatabasesApiContracts;

public sealed class DatabaseApiClient : ApiClient
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public DatabaseApiClient(ILogger logger, IHttpClientFactory httpClientFactory, string server, string? apiKey,
        bool useConsole) : base(logger, httpClientFactory, server, apiKey, null,
        new StingMessageHubClient(server, apiKey), useConsole)
    {
    }

    //შემოწმდეს არსებული ბაზის მდგომარეობა და საჭიროების შემთხვევაში გამოასწოროს ბაზა
    public async Task<Option<Err[]>> CheckRepairDatabase(string databaseName, CancellationToken cancellationToken)
    {
        return await PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.CheckRepairDatabasePrefix}/{databaseName}",
            cancellationToken);
    }

    //დამზადდეს ბაზის სარეზერვო ასლი სერვერის მხარეს.
    //ასევე ამ მეთოდის ამოცანაა უზრუნველყოს ბექაპის ჩამოსაქაჩად ხელმისაწვდომ ადგილას მოხვედრა
    public async Task<OneOf<BackupFileParameters, Err[]>> CreateBackup(string backupNamePrefix, string dateMask,
        string backupFileExtension, string backupNameMiddlePart, bool compress, bool verify, EBackupType backupType,
        string? dbServerSideBackupPath, string backupBaseName, CancellationToken cancellationToken)
    {
        var bodyJsonData = JsonConvert.SerializeObject(new CreateBackupRequest
        {
            BackupNamePrefix = backupNamePrefix,
            DateMask = dateMask,
            BackupFileExtension = backupFileExtension,
            BackupNameMiddlePart = backupNameMiddlePart,
            Compress = compress,
            Verify = verify,
            BackupType = backupType,
            DbServerSideBackupPath = dbServerSideBackupPath
        });


        return await PostAsyncReturn<BackupFileParameters>(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.CreateBackupPrefix}/{backupBaseName}",
            cancellationToken, bodyJsonData);
    }

    //სერვერის მხარეს მონაცემთა ბაზაში ბრძანების გაშვება
    public async Task<Option<Err[]>> ExecuteCommand(string executeQueryCommand, CancellationToken cancellationToken,
        string? databaseName = null)
    {
        return await PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.ExecuteCommandPrefix}{(string.IsNullOrWhiteSpace(databaseName) ? string.Empty : $"/{databaseName}")}",
            cancellationToken, executeQueryCommand);
    }

    //მონაცემთა ბაზების სიის მიღება სერვერიდან
    public async Task<OneOf<List<DatabaseInfoModel>, Err[]>> GetDatabaseNames(CancellationToken cancellationToken)
    {
        return await GetAsyncReturn<List<DatabaseInfoModel>>(
            DatabaseApiRoutes.Database.DatabaseBase + DatabaseApiRoutes.Database.GetDatabaseNames, cancellationToken);
    }

    //გამოიყენება ბაზის დამაკოპირებელ ინსტრუმენტში, იმის დასადგენად,
    //მიზნის ბაზა უკვე არსებობს თუ არა, რომ არ მოხდეს ამ ბაზის ისე წაშლა ახლით,
    //რომ არსებულის გადანახვა არ მოხდეს.
    public async Task<OneOf<bool, Err[]>> IsDatabaseExists(string databaseName, CancellationToken cancellationToken)
    {
        return await GetAsyncReturn<bool>(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.IsDatabaseExistsPrefix}/{databaseName}",
            cancellationToken);
    }

    //გამოიყენება ბაზის დამაკოპირებელ ინსტრუმენტში, დაკოპირებული ბაზის აღსადგენად,
    public async Task<Option<Err[]>> RestoreDatabaseFromBackup(string prefix, string suffix, string name,
        string dateMask, string? destinationDbServerSideDataFolderPath, string? destinationDbServerSideLogFolderPath,
        string databaseName, CancellationToken cancellationToken)
    {
        var bodyJsonData = JsonConvert.SerializeObject(new RestoreBackupRequest
        {
            Prefix = prefix, Suffix = suffix, Name = name, DateMask = dateMask,
            DestinationDbServerSideDataFolderPath = destinationDbServerSideDataFolderPath,
            DestinationDbServerSideLogFolderPath = destinationDbServerSideLogFolderPath
        });
        return await PutAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.RestoreBackupPrefix}/{databaseName}",
            cancellationToken, bodyJsonData);
    }

    //მონაცემთა ბაზაში არსებული პროცედურების რეკომპილირება
    public async Task<Option<Err[]>> RecompileProcedures(string databaseName, CancellationToken cancellationToken)
    {
        return await PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.RecompileProceduresPrefix}/{databaseName}",
            cancellationToken);
    }

    public async Task<Option<Err[]>> TestConnection(string? databaseName, CancellationToken cancellationToken)
    {
        return await GetAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.TestConnectionPrefix}{(databaseName == null ? string.Empty : $"/{databaseName}")}",
            cancellationToken);
    }

    //მონაცემთა ბაზაში არსებული სტატისტიკების დაანგარიშება
    public async Task<Option<Err[]>> UpdateStatistics(string databaseName, CancellationToken cancellationToken)
    {
        return await PostAsync(
            $"{DatabaseApiRoutes.Database.DatabaseBase}{DatabaseApiRoutes.Database.UpdateStatisticsPrefix}/{databaseName}",
            cancellationToken);
    }
}