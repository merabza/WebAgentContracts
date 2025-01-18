namespace WebAgentDatabasesApiContracts.V1.Responses;

public sealed class BackupFileParameters
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public BackupFileParameters(string? folderName, string name, string prefix, string suffix, string dateMask)
    {
        FolderName = folderName;
        Name = name;
        Prefix = prefix;
        Suffix = suffix;
        DateMask = dateMask;
    }

    public string Prefix { get; set; }
    public string Suffix { get; set; }
    public string? FolderName { get; }
    public string Name { get; set; }
    public string DateMask { get; set; }
}