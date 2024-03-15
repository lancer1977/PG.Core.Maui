using Windows.Storage;

namespace PolyhydraGames.Core.Maui.Platforms;
public class FileService : IFileService
{
    public async Task<string[]> GetFilesAsync(string directory)
    {
        var files = Directory.GetFiles(directory);
        List<string> items = new List<string>();
        foreach (var item in files)
        {
            var file = await GetFileAsync(item);
            items.Add(file);
        }

        return items.ToArray();
    }

    public async Task<string> GetAssetAsync(string fileName)
    {
        var appUri = new Uri(fileName); //File name should be prefixed with 'ms-appx:///Assets/* 
        var anjFile = await StorageFile.GetFileFromApplicationUriAsync(appUri);
        var text = await FileIO.ReadTextAsync(anjFile);
        return text;
    }

    public async Task<string> GetFileAsync(string fullFileName)
    {
        var appUri = new Uri(fullFileName); //File name should be prefixed with 'ms-appx:///Assets/* 
        var anjFile = await StorageFile.GetFileFromApplicationUriAsync(appUri);
        var text = await FileIO.ReadTextAsync(anjFile);
        return text;
    }
}