using DataBase.DataModels;
using Hotellux.Repositories;

namespace Hotellux.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private LoginDataModel _loginModel;
        private LoginRepository _loginRepository = new();

        //public WorkerDataModel 

        public LoginViewModel()
        {
            _loginModel = new LoginDataModel();
        }

    }
}
