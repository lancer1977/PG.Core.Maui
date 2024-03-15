using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace PolyhydraGames.Core.Maui.Controls.Abstracts;

public abstract class ListItemPickerViewModel<T> : ViewModelAsyncBase
{
    [Reactive] public T? SelectedItem { get; set; }

    public abstract List<T> Items { get; }
}

public class ListItemPickerViewModel : ViewModelAsyncBase
{
    private ListItemPickerModel? _model = null;

    public ListItemPickerViewModel()
    {
        ExecuteCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (_model == null) return;
            await _model.OK(SelectedItem);
        });
    }

    [Reactive] public string? SelectedItem { get; set; }

    public List<string>? Items => _model?.Items;

    public ICommand ExecuteCommand { get; private set; }


    public void Init(ListItemPickerModel? model)
    {
        _model = model ?? throw new NullReferenceException();
        Title = _model?.Title;

    }
}
