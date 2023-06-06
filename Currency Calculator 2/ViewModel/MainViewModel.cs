using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Currency_Calculator_2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public ICommand ShowCurrencyViewCommand { get; }
        public ICommand ShowTemperatureViewCommand { get; }

        public MainViewModel()
        {
            ShowCurrencyViewCommand = new ViewModalCommand(ExecuteShowCurrencyCommand);
            ShowTemperatureViewCommand = new ViewModalCommand(ExecuteShowTemperatureCommand);

            ExecuteShowHomeCommand(null);
        }

        private void ExecuteShowHomeCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
        }

        private void ExecuteShowCurrencyCommand(object obj)
        {
            CurrentChildView = new CurrencyViewModel();
            Caption = "Currency";
        }

        private void ExecuteShowTemperatureCommand(object obj)
        {
            CurrentChildView = new TemperatureViewModel();
            Caption = "Temperature";
        }
    }
}
