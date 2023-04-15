using System.Windows.Input;

namespace ViewModel;

public sealed class ButtonAction : ICommand {
    private readonly Action _action;

    public ButtonAction(Action executeAction) {
        _action = executeAction;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _action();


    public event EventHandler? CanExecuteChanged;

    private void OnCanExecuteChanged() {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}