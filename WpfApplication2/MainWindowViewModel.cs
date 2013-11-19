using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication2
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields
        private bool _isTestMode;

        private bool _isBooted;
        private bool _testIsBooted;
        private bool _liveIsBooted;

        private bool _isBootedOther;

        private DelegateCommand boot_Command;
        #endregion

        #region Properties
        public bool IsTestMode
        {
            get
            {
                return _isTestMode;
            }
            set
            {
                _isTestMode = value;
                NotifyPropertyChanged();

                if (_isTestMode)
                {
                    IsBooted = _testIsBooted;
                }
                else
                {
                    IsBooted = _liveIsBooted;
                }
            }
        }

        public bool IsBooted
        {
            get
            {
                return _isBooted;
            }
            set
            {
                _isBooted = value;
                NotifyPropertyChanged();
            }
        }

        public bool TestIsBooted
        {
            get
            {
                return _testIsBooted;
            }
            set
            {
                _testIsBooted = value;
                NotifyPropertyChanged();

                if (_isTestMode)
                {
                    IsBooted = _testIsBooted;
                }
            }
        }

        public bool LiveIsBooted
        {
            get
            {
                return _liveIsBooted;
            }
            set
            {
                _liveIsBooted = value;
                NotifyPropertyChanged();

                if (!_isTestMode)
                {
                    IsBooted = _liveIsBooted;
                }
            }
        }

        public bool IsBootedOther
        {
            get
            {
                return _isBootedOther;
            }
            set
            {
                _isBootedOther = value;
                NotifyPropertyChanged();

                if (_isTestMode)
                {
                    TestIsBooted = _isBootedOther;
                }
                else
                {
                    LiveIsBooted = _isBootedOther;
                }
            }
        }

        public ICommand Boot_Command
        {
            get
            {
                if (boot_Command == null)
                {
                    boot_Command = new DelegateCommand(Boot);
                }
                return boot_Command;
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {

        }
        #endregion

        #region Methods
        public void Boot(object obj)
        {
            if (_isBootedOther)
            {
                IsBootedOther = false;
            }
            else
            {
                IsBootedOther = true;
            }
        }
        #endregion
    }
}
