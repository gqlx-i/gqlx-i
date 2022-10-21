using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace test.Common
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> execute) : this(execute, null)
        {

        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        private readonly Action<object> _execute;

        private readonly Predicate<object> _canExecute;
    }
}
