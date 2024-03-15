namespace PolyhydraGames.Core.Maui.Services.Folders;

public class FolderService : IStorageFolder
{
    /// <inheritdoc />
    public string Get()
    {
            return AppDomain.CurrentDomain.BaseDirectory;
            //return Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
        }
}