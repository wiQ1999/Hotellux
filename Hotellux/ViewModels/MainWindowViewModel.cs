using DataBase.Enums;
using Hotellux.LoggedUser;
using Hotellux.Tools;
using Hotellux.Tools.Helpers;
using System;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        private BaseViewModel _activeViewModel;

        public override string ViewModelName => "Startowa";

        public string ActiveViewModelName => "Zakładka: " + (_activeViewModel != null ? _activeViewModel.ViewModelName : this.ViewModelName);

        public string UserName => User.IsInitialized() ? "Użytkownik: " + User.Get.FullName : string.Empty;

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

        public ICommand OpenFolderCommand { get; set; }
        #endregion

        public MainWindow MainWindow
        {
            get => default;
            set
            {
            }
        }

        public MainWindowViewModel()
        {
            _activeViewModel = new LoginViewModel();
            OpenFolderCommand = new RelayCommand(OpenFolder, CanOpenFolder);
        }

        #region Methods
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
                case "REZERWACJE":
                    ActiveViewModel = new ReservationsViewModel();
                    break;
                case "PRACOWNICY":
                    ActiveViewModel = new WorkersViewModel();
                    break;
                default:
                    throw new ArgumentException("Przesłano niepoprawny parametr w widoku");
            }
            OnPropertyChanged(nameof(ActiveViewModelName));
        }

        private bool CanOpenFolder(object folderName)
        {
            if (!User.IsInitialized())
                return false;

            if (_activeViewModel != null && _activeViewModel.ViewModelName == "Logowanie")
            {
                _activeViewModel = null;
                OnPropertyChanged(nameof(ActiveViewModel));
                OnPropertyChanged(nameof(UserName));
            }

            switch (folderName.ToString())
            {
                case "POKOJE":
                    return User.Get.WorkerType == WorkerType.Manager || User.Get.WorkerType == WorkerType.Reception || User.Get.WorkerType == WorkerType.CleaningService;
                case "KLIENCI":
                    return User.Get.WorkerType == WorkerType.Manager || User.Get.WorkerType == WorkerType.Reception;
                case "REZERWACJE":
                    return User.Get.WorkerType == WorkerType.Manager || User.Get.WorkerType == WorkerType.Reception;
                case "PRACOWNICY":
                    return User.Get.WorkerType == WorkerType.Manager;
            }

            return true;
        }
        #endregion
    }
}
