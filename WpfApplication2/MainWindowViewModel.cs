using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication2
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;

        private int _progress = 0;
        private string _progressStatus;
        private bool _isEnabled = true;

        private AsyncDelegateCommand cancelTest_Command;
        private AsyncDelegateCommand cancel_Command;
        private DelegateCommand find_Command;
        private DelegateCommand some_Command;
        #endregion

        #region Properties
        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                NotifyPropertyChanged();
            }
        }

        public string ProgressStatus
        {
            get
            {
                return _progressStatus;
            }
            set
            {
                _progressStatus = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Find_Command
        {
            get
            {
                if (find_Command == null)
                {
                    find_Command = new DelegateCommand(Find);
                }
                return find_Command;
            }
        }

        public ICommand Some_Command
        {
            get
            {
                if (some_Command == null)
                {
                    some_Command = new DelegateCommand(Some);
                }
                return some_Command;
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
        }
        #endregion

        #region Methods
        public void Some(object obj)
        {
            ProgressStatus = "";
            IsEnabled = false;
            

            var firstTask = new Task(() => SomeTaskOne(_token), _token);
            var secondTask = firstTask.ContinueWith((t) => SomeTaskTwo(_token), _token);
            var thirdTask = secondTask.ContinueWith((t) => SomeTaskThree(_token), _token);

            firstTask.Start();

            if (Progress == 25)
            {
                MessageBox.Show("Cancelled");
                _tokenSource.Cancel();
            }

            
        }

        public void CheckToken(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
        }

        public void SomeTaskOne(CancellationToken token)
        {
            CheckToken(token);

            ProgressStatus = "Starting task one...";

            for (int i = 0; i < 10; i++)
            {
                CheckToken(token);

                Thread.Sleep(500);
                Progress++;
            }
        }

        public void SomeTaskTwo(CancellationToken token)
        {
            CheckToken(token);

            ProgressStatus = "Starting task two...";

            Thread.Sleep(2000);

            for (int i = 0; i < 10; i++)
            {
                CheckToken(token);

                Thread.Sleep(500);
                Progress++;

                if (Progress == 15)
                {
                    MessageBox.Show("Cancelled");
                    _tokenSource.Cancel();
                }
            }
        }

        public void SomeTaskThree(CancellationToken token)
        {
            CheckToken(token);

            ProgressStatus = "Starting task three...";

            Thread.Sleep(2000);

            for (int i = 0; i < 10; i++)
            {
                CheckToken(token);

                Thread.Sleep(500);
                Progress++;
            }

            IsEnabled = true;
            ProgressStatus = "Complete";
        }

        public void Find(object obj)
        {
            try
            {

                Uri uri = new Uri("\\Data\\config.xml", UriKind.RelativeOrAbsolute);
                MessageBox.Show(uri.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        

        private void UpdateProgress(int milliseconds, int value)
        {
            for (int i = 0; i < value; i++)
            {
                Thread.Sleep(milliseconds / value);
                Progress++;
            }
        }
        #endregion
    }
}
