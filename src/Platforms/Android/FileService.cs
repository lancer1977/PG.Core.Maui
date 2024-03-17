using System.Diagnostics;
using Android.Content.Res;
using PolyhydraGames.Core.Maui.Services.Abstract;

namespace PolyhydraGames.Core.Maui.Services.FileService;

public class FileService : ActivityServiceBase, IFileService
{
    /// <summary>
    /// </summary>
    /// <param name="locator"></param>
    public FileService(ICurrentActivityLocator locator) : base(locator)
    {
        }

#pragma warning disable CS8603
    private AssetManager Assets => Activity.Assets;
#pragma warning restore CS8603


    private async Task<string> ReadFileAsync(string filename)
    {
            var tcs = new TaskCompletionSource<string>();
            using (var input = new StreamReader(Assets.Open(filename)))
            {
                tcs.SetResult(await input.ReadToEndAsync());
            }

            return await tcs.Task;
        }


    /// <inheritdoc />
    public async Task<string[]> GetFilesAsync(string directory)
    {
            var tcs = new TaskCompletionSource<string[]>();

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) ?? throw new InvalidOperationException("storage directory was nothing"));
            tcs.SetResult(Directory.Exists(path)
                ? Directory.GetFiles(path).Select(File.ReadAllText).ToArray()
                : new string[0]);
            return await tcs.Task;
        }

    /// <inheritdoc />
    public async Task<string> GetAssetAsync(string fileName)
    {
            var contents = await ReadFileAsync(fileName);
            return contents;
        }

    /// <inheritdoc />
    public async Task<string> GetFileAsync(string fullFileName)
    {
            var tcs = new TaskCompletionSource<string>();

            tcs.SetResult(await File.ReadAllTextAsync(fullFileName));
            return await tcs.Task;
        }
}