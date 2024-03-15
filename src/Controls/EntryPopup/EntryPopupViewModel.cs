
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;
 
namespace PolyhydraGames.Core.Maui.Controls.EntryPopup;

public class EntryPopupViewModel : ModalViewModelAsyncBase
{
    private Action<DialogResult<bool>>? _boolResponse;
    private Action? _cancelled;
    private Action<bool>? _getBool;
    private Action<bool, int>? _getInt;
    private Action<bool, string>? _getString;
    private Action<bool, object>? _getT;
    private Action<DialogResult<int>>? _intResponse;
    private Action<DialogResult<object>>? _objResponse;

    private Action<DialogResult<string>>? _stringResponse;
    private EntryStyle _style;

    public EntryPopupViewModel(INavigatorAsync navigator) : base(navigator)
    {
        ShowChoices = false;
        OKCommand = ReactiveCommand.CreateFromTask<bool>(async x =>
        {
            IsBusy = true;
            await PopAsync();
            await Task.Delay(500);
            switch (_style)
            {
                case EntryStyle.String:
                    _getString?.Invoke(x, Value ?? "");
                    break;
                case EntryStyle.Int:
                    _getInt?.Invoke(x, Value.ToInt());
                    break;
                case EntryStyle.Boolean:
                    _getBool?.Invoke(x);
                    break;
                case EntryStyle.Choice:
                    _getT?.Invoke(x, Choice ?? new object());
                    break;
            }

            ;
        });

        this.WhenAnyValue(x => x.Choice).Where(x => x != null).Subscribe(x => { OKCommand.Execute(true); });
    }

    [Reactive] public string? Message { get; set; }
    [Reactive] public string? Value { get; set; }
    [Reactive] public object? Choice { get; set; }
    [Reactive] public string? PositiveButtonText { get; set; }
    [Reactive] public string? NegativeButtonText { get; set; }
    [Reactive] public bool ShowChoices { get; set; }
    [Reactive] public bool ShowEntry { get; set; }
    [Reactive] public bool ShowButtons { get; set; }
    [Reactive] public IList<object>? Choices { get; set; }
    public Keyboard? KeyboardType { get; set; }

    protected override Task<bool> OnOK()
    {
        throw new NotImplementedException();
    }

    protected override void OnCancel()
    {
        _cancelled?.Invoke();
    }

    public void LoadString(string? message, string title, Action<DialogResult<string>>? response, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        _style = EntryStyle.String;
        Message = message;
        Title = title;
        ShowChoices = false;
        ShowEntry = true;
        ShowButtons = true;
        PositiveButtonText = Pad(labelOk);
        NegativeButtonText = Pad(labelCancel);
        _cancelled = () => _stringResponse?.Invoke(new DialogResult<string>());
        _getString = (can, x) => _stringResponse?.Invoke(new DialogResult<string>(can, x));
        _stringResponse = response;
    }

    internal void LoadToast(string? message)
    {
        _style = EntryStyle.String;
        Message = message;
        ShowChoices = false;
    }

    public void LoadInt(string? message, string title, Action<DialogResult<int>>? response, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        _style = EntryStyle.Int;
        KeyboardType = Keyboard.Numeric;
        ShowChoices = false;
        ShowEntry = true;
        ShowButtons = true;
        Message = message;
        Title = title;
        PositiveButtonText = Pad(labelOk);
        NegativeButtonText = Pad(labelCancel);
        _cancelled = () => _intResponse?.Invoke(new DialogResult<int>());
        _getInt = (cancel, x) => _intResponse?.Invoke(new DialogResult<int>(cancel, x));
        _intResponse = response;
    }

    public void LoadBoolean(string? message, string title, Action<DialogResult<bool>>? response, string labelOk = "OK",
        string labelCancel = "Cancel")
    {
        _style = EntryStyle.Boolean;
        Message = message;
        ShowChoices = false;
        ShowEntry = false;
        ShowButtons = true;
        Title = title;
        PositiveButtonText = Pad(labelOk);
        NegativeButtonText = Pad(labelCancel);

        _cancelled = () => _boolResponse?.Invoke(new DialogResult<bool>());
        _getBool = x => _boolResponse?.Invoke(new DialogResult<bool>(true, x));
        _boolResponse = response;
    }

    public void LoadObj<T>(string? message, string title, IEnumerable<object> choices, Action<DialogResult<T>> response,
        string labelCancel = "Cancel")
    {
        _style = EntryStyle.Choice;
        ShowButtons = false;
        ShowEntry = false;
        Message = message;
        Title = title;
        Choices = choices.ToList();
        ShowChoices = true;

        NegativeButtonText = Pad(labelCancel);
        _cancelled = () => _objResponse?.Invoke(new DialogResult<object>());
        _getT = (cancel, x) => _objResponse?.Invoke(new DialogResult<object>(cancel, x));

        _objResponse = x => { response.Invoke(new DialogResult<T>(x.Ok, (T)x.Result)); };
    }

    private string? Pad(string data)
    {
        return " " + data + " ";
    }

    public override bool IsValid()
    {
        return true;
    }
}