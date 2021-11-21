using DataBase.DataModels;
using Hotellux.Commands;
using Hotellux.Repositories;
using Hotellux.Tools.Helpers;
using System.Windows.Input;

namespace Hotellux.ViewModels.Units
{
    public class LoginViewModel : BaseViewModel
    {
        private LoginRepository _loginRepository;

        #region PropertiesS
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

            }
            else
            {

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
