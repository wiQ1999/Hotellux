using DataBase.DataModels;
using Hotellux.LoggedUser;
using Hotellux.Repositories;
using Hotellux.Tools;
using Hotellux.Tools.Helpers;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties
        private LoginRepository _loginRepository = new();
        private string _passwordBlanc = string.Empty;
        private string _passwordClean = string.Empty;

        public override string ViewModelName => "Logowanie";

        public string Login { get; set; }

        public string Password
        {
            get => _passwordBlanc;
            set
            {
                _passwordBlanc = new string('*', value.Length);

                if (string.IsNullOrEmpty(value))
                    _passwordClean = string.Empty;
                else
                {
                    if (value.Length > _passwordClean.Length)
                        _passwordClean += value.Last();
                    else
                        _passwordClean = _passwordClean.Remove(value.Length);
                }
                
            }
        }

        public ICommand LoginUserCommand { get; set; }

        #endregion

        public LoginViewModel()
        {
            LoginUserCommand = new RelayCommand(LoginUser, CanLoginUser);
        }

        #region Methods
        private void LoginUser(object obj)
        {
            LoginDataModel model = _loginRepository.GetByLoginAndPassword(Login, _passwordClean);

            if (model == null)
                MessageBox.Show("Niepoprawne dane logowania.");
            else
            {
                WorkerDataModel workerModel =  new WorkerRepository().GetById(model.Id);
                if (workerModel == null)
                    throw new Exception("Nie znaleziono modelu pracownika, błąd relacji 1-1");

                User.Initialize(workerModel);
            }
        }

        private bool CanLoginUser(object obj) => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        #endregion
    }
}
