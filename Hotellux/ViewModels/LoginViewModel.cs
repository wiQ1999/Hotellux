using DataBase.DataModels;
using Hotellux.LoggedUser;
using Hotellux.Repositories;
using Hotellux.Tools;
using Hotellux.Tools.Helpers;
using System;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private LoginRepository _loginRepository;

        #region Properties
        public override string ViewModelName => "Logowanie";

        public string Login { get; set; }

        public string Password { get; set; }
        #endregion

        public LoginViewModel()
        {
            _loginRepository = new LoginRepository();
            LoginUserCommand = new RelayCommand(LoginUser, CanLoginUser);
            ClearLoginCommand = new RelayCommand(ClearLogin);
        }

        #region Commands
        public ICommand LoginUserCommand { get; set; }

        private void LoginUser(object obj)
        {
            string hashedPassword = PasswordHasherHelper.Hash(Password);

            LoginDataModel model = _loginRepository.GetByLoginAndPassword(Login, hashedPassword);

            if (model == null)
            {
                //komunikat błędu - zobaczę jak to oprogramować
            }
            else
            {
                WorkerDataModel workerModel =  new WorkerRepository().GetById(model.Id);
                if (workerModel == null)
                    throw new Exception("Nie znaleziono modelu pracownika, błąd relacji 1-1");

                User.Initialize(workerModel);
                //zalogowanie
            }
        }

        private bool CanLoginUser(object obj) => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        public ICommand ClearLoginCommand { get; set; }

        private void ClearLogin(object obj)
        {
            Login = string.Empty;
            Password = string.Empty;
        }
        #endregion
    }
}
