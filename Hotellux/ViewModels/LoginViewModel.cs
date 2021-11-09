using DataBase.DataModels;
using Hotellux.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hotellux.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private LoginDataModel _loginModel;
        private LoginRepository _loginRepository = new();

        //public WorkerDataModel 

        public LoginViewModel()
        {
            _loginModel = new LoginDataModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
