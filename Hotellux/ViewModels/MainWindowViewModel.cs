using Hotellux.Commands;
using Hotellux.ViewModels.Collections;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        private BaseViewModel _activeViewModel;

        public BaseViewModel ActiveViewModel
        {
            get => _activeViewModel;
            set
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
            OpenWorkersList = new RelayCommand(OpenWorkersListComand, CanOpenWorkersListComand);
        }

        #region Commands
        public ICommand OpenWorkersList { get; set; }

        private void OpenWorkersListComand(object obj) => _activeViewModel = new WorkersViewModel();

        private bool CanOpenWorkersListComand(object obj) => !(_activeViewModel is WorkersViewModel);
        #endregion
    }
}
