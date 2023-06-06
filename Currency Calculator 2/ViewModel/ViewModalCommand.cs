using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Currency_Calculator_2.ViewModel
{
    class ViewModalCommand : ICommand
    {
        //Fields
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canexecuteAction;

        //Constructor
        public ViewModalCommand(Action<object> _executeAction)
        {
            this._executeAction = _executeAction;
            this._canexecuteAction = null;
        }

        public ViewModalCommand(Action<object> _executeAction, Predicate<object> _canexecuteAction)
        {
            this._executeAction = _executeAction;
            this._canexecuteAction = _canexecuteAction;
        }

        //Event
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Method
        public bool CanExecute(object parameter)
        {
            return _canexecuteAction == null ? true : _canexecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
