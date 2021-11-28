using DataBase.DataModels;
using Hotellux.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hotellux.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private CustomerDataModel _customerModel;
        private CustomerRepository _customerRepository;

        public override string ViewModelName => "Klient";

        public string Name
        {
            get => _customerModel.Name;
            set
            {
                _customerModel.Name = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => _customerModel.Lastname;
            set
            {
                _customerModel.Lastname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _customerModel.Email;
            set
            {
                _customerModel.Email = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _customerModel.PhoneNumber;
            set
            {
                _customerModel.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            _customerModel = new CustomerDataModel();
            _customerRepository = new CustomerRepository();
        }

        public CustomerViewModel(CustomerDataModel customerModel) : this()
        {
            _customerModel = customerModel;
        }
    }
}
