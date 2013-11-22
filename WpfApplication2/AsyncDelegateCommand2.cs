using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication2
{
    public class AsyncDelegateCommand2 : ICommand
    {
        BackgroundWorker _worker = new BackgroundWorker();
        Func<bool> _canExecute;

        public AsyncDelegateCommand2(
            Action action,
            Func<bool> canExecute = null,
            Action<object> completed = null,
            Action<Exception> error = null)
        {
            _worker.DoWork += (s, e) =>
                {
                    CommandManager.InvalidateRequerySuggested();
                    action();
                };

            _worker.RunWorkerCompleted += (s, e) =>
                {
                    if ((completed != null) && (e.Error == null))
                    {
                        completed(e.Result);
                    }
                    if ((error != null) && (e.Error != null))
                    {
                        error(e.Error);
                    }

                    CommandManager.InvalidateRequerySuggested();
                };

            _canExecute = canExecute;
        }

        public void Cancel()
        {
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
            }
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute == null) ? !(_worker.IsBusy) : !(_worker.IsBusy) && _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _worker.RunWorkerAsync();
        }
    }
}
