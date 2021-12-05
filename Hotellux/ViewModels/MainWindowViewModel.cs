using Hotellux.Tools;
using System;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        private BaseViewModel _activeViewModel;

        public override string ViewModelName => "Główny widok";

        public string ActiveViewModelName => "Zakładka: " + _activeViewModel.ViewModelName;

        public string UserName => "Użytkownik: " + "Zdzisiu Tester";//User.Get.FullName;

        public BaseViewModel ActiveViewModel
        {
            get => _activeViewModel;
            private set
            {
                if (value == _activeViewModel) return;
                _activeViewModel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            _activeViewModel = new WorkersViewModel();//zmiana na jakiś bazowy widok startowy
            OpenFolderCommand = new RelayCommand(OpenFolder, CanOpenFolder);
        }

        #region Commands
        public ICommand OpenFolderCommand { get; set; }

        private void OpenFolder(object folderName)
        {
            switch (folderName.ToString())
            {
                case "POKOJE":
                    ActiveViewModel = new RoomsViewModel();
                    break;
                case "KLIENCI":
                    ActiveViewModel = new CustomersViewModel();
                    break;

                default:
                    throw new ArgumentException("Przesłano niepoprawny parametr w widoku");
            }
            OnPropertyChanged(nameof(ActiveViewModelName));
        }

        private bool CanOpenFolder(object obj) => true;//!(_activeViewModel is WorkersViewModel);
        #endregion
    }
}
