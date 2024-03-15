
/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-ios)'
Before:
using System.Collections.ObjectModel;
using DynamicData;
using PolyhydraGames.Core.Interfaces;
After:
using DynamicData;
using PolyhydraGames.Core.Interfaces;
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'PolyhydraGames.Core.Maui (net7.0-windows10.0.22621.0)'
Before:
using System.Collections.ObjectModel;
using DynamicData;
using PolyhydraGames.Core.Interfaces;
After:
using DynamicData;
using PolyhydraGames.Core.Interfaces;
using System.Collections.ObjectModel;
*/
namespace PolyhydraGames.Core.Maui.Services;

public class HistoryService : IHistoryService
{
    //private ReadOnlyObservableCollection<Descriptor> _descriptors;

    //private SourceList<Descriptor> _sourceList;

    // public ReadOnlyObservableCollection<Descriptor> Items => _descriptors;
    public void Add(string title, string data)
    {
        Items.Add(new Descriptor
        {
            Description = data,
            Title = title
        });
    }

    public IList<IDescriptor> Items { get; set; } = new List<IDescriptor>();
}