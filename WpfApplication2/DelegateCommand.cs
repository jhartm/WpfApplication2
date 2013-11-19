using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication2
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

    public class AsyncDelegateCommand : ICommand
    {
        private Action _execute;
        private Predicate<object> _canexecute;

        public AsyncDelegateCommand(Action execute)
        {
            _execute = execute;
        }

        public AsyncDelegateCommand(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentException("execute");

            _execute = execute;
            _canexecute = canExecute;
        }

        public void Execute(object parameter)
        {
            ExecuteAsync(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
            await Task.Run(_execute);
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canexecute == null || _canexecute(parameter);
        }
    }
}
