using System.Windows.Input;

namespace PolyhydraGames.Core.Maui.Services;

public class UniversalCommand : ICommand
{
    private readonly Action _action;

    public UniversalCommand(Action action)
    {
            _action = action;
        }


    public bool CanExecute(object? parameter)
    {
            return true;
        }

    public void Execute(object? parameter)
    {
        }

    public event EventHandler? CanExecuteChanged;
}