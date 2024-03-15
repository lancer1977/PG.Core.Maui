namespace PolyhydraGames.Core.Maui;

public class FileData : IFileData
{
    public FileData(string fileName, string contents, string extension)
    {
        FileName = fileName;
        Contents = contents;
        Extension = extension;
    }

    public string FileName { get; set; }
    public string Contents { get; set; }
    public string Extension { get; set; }
}