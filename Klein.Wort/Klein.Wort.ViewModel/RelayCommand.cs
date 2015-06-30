using System;
using System.Windows.Input;
using Klein.Wort.ViewModel.Annotations;

namespace Klein.Wort.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action;

        public RelayCommand([NotNull] Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}