using DbTools;

namespace WebAgentDatabasesApiContracts.V1.Requests;

public sealed class CreateDatabaseBackupRequest
{
    public string BackupNamePrefix { get; init; } = null!;
    public string DateMask { get; init; } = null!;
    public string BackupFileExtension { get; init; } = null!;
    public string BackupNameMiddlePart { get; init; } = null!;
    public bool Compress { get; init; } = false;
    public bool Verify { get; init; } = false;
    public EBackupType BackupType { get; init; } = EBackupType.Full;
}