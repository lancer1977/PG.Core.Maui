
/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using System.Collections.Generic;
After:
using PolyhydraGames.Core.Interfaces;
using System.Collections.Generic;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using System.Collections.Generic;
After:
using PolyhydraGames.Core.Interfaces;
using System.Collections.Generic;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using System.Threading.Tasks;
using PolyhydraGames.Core.Interfaces;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using System.Threading.Tasks;
using PolyhydraGames.Core.Interfaces;
After:
using System.Threading.Tasks;
*/
namespace PolyhydraGames.Core.Maui.Controls.MultiPickerDialog;

public static class MultiPickerExtensions
{
    public static async Task<List<T>> ShowPickerAsync<T>(this IList<T> items, string title, Func<T, string> nameFunc,
        int minChoices = 0, int maxChoices = 99) where T : class
    {
        var tcs = new TaskCompletionSource<List<T>>();
        var pickerItems = items.Select(x => new MultiPickerItem(x, nameFunc(x))).ToList();

        await IOC.IOC.Get<INavigatorAsync>().PushPopupAsync<MultiPickerDialogViewModel>(
            async i => i.Load(x =>
                {
                    var results = x.Select(v => v as T).ToList();
#pragma warning disable CS8620
                    tcs.SetResult(results.ToList());
#pragma warning restore CS8620
                },
                pickerItems,
                title,
                minChoices,
                maxChoices));

        return await tcs.Task;
    }
}