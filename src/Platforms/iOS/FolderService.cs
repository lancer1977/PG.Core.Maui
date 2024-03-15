namespace PolyhydraGames.Core.Maui.Services.Folders;

public class FolderService : IStorageFolder
{
    public string Get()
    {
            return AppDomain.CurrentDomain.BaseDirectory;
            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            //var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            //return libraryPath;
        }
}