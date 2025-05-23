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