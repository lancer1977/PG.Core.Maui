namespace PolyhydraGames.Core.Maui.Services.Folders;

public class FolderService : IStorageFolder
{
    public string Get()
    {
            return AppDomain.CurrentDomain.BaseDirectory;
            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return path;
        }
}