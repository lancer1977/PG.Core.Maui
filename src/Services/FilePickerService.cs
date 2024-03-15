using System.Text;

namespace PolyhydraGames.Core.Maui.Services;

public class FilePickerService : IFilePickerService
{
    public async Task<string> GetString()
    {
        var result = await GetFile();
        return result != null ? result.Contents : string.Empty;
    }

    public async Task<bool> PermissionGranted(bool retry = true)
    {
        var access = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        if (access == PermissionStatus.Granted) return true;
        if (retry)
        {
            await Permissions.RequestAsync<Permissions.StorageRead>();
            return await PermissionGranted(false);
        }

        return false;
    }

    public async Task<IFileData?> GetFile()
    {
        var options = new PickOptions
        {
            PickerTitle = "Please select a file"
            //                FileTypes = F,
        };

        if (await PermissionGranted()) return null;
        var result = await PickAndShow(options);
        if (result == null) return null;
        var stream = await result.OpenReadAsync();
        var filename = result.FileName;
        using var sr = new StreamReader(stream, Encoding.UTF8);
        var content = await sr.ReadToEndAsync();
        return new FileData(content, filename.Substring(filename.Length - 3).ToLower(), filename);
    }

    private async Task<FileResult?> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}