using DatabaseTools.DbTools;

namespace WebAgentContracts.WebAgentDatabasesApiContracts.V1.Requests;

public sealed class CreateDatabaseBackupRequest
{
    public string BackupNamePrefix { get; init; } = null!;
    public string DateMask { get; init; } = null!;
    public string BackupFileExtension { get; init; } = null!;
    public string BackupNameMiddlePart { get; init; } = null!;
    public bool Compress { get; init; }
    public bool Verify { get; init; }
    public EBackupType BackupType { get; init; } = EBackupType.Full;
}
