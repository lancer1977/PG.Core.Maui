using System.Collections.ObjectModel;
using System.Windows.Input;


namespace PolyhydraGames.Core.Maui.Controls.MultiPickerDialog;

public class MultiPickerDialogViewModel : ModalViewModelAsyncBase, ISingleton
{
    private int _maxChoices = 0;
    private int _minChoices = 0;
    private Action<List<object>>? _onOkTask;
    public ICommand? TestCommand { get; }
    public ObservableCollection<MultiPickerItem> Options { get; } = new();

    public MultiPickerDialogViewModel(INavigatorAsync navigator) : base(navigator)
    {
    }





    internal void ItemSelected(MultiPickerItem selected)
    {
        selected.Selected = !selected.Selected;
    }

    protected override async Task<bool> OnOK()
    {
        _onOkTask?.Invoke(Options
            .Where(i => i.Selected)
            .Select(i => i.Data)
            .ToList());
        return await Task.FromResult(true);
    }


    internal void Load(Action<List<object?>> p, List<MultiPickerItem> pickerItems, string title, int minChoices, int maxChoices)
    {
        Title = title;
        Options.Clear();
        Options.AddRange(pickerItems);
        //Options.CollectionChanged += (e,x)=>Validate();
        _onOkTask = p;
        _minChoices = minChoices;
        _maxChoices = maxChoices;
    }


    public override async Task OnDisappearingAsync()
    {
        await base.OnDisappearingAsync();
        Options.Clear();
        _onOkTask = null;
    }

    public override bool IsValid()
    {
        var ct = Options.Count(i => i.Selected);
        var valid = ct >= _minChoices && ct <= _maxChoices;

        return valid;
    }

    protected override void OnCancel()
    {
#pragma warning disable CS8625
        _onOkTask?.Invoke(default);
#pragma warning restore CS8625
    }
}