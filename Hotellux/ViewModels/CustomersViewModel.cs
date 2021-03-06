using DataBase.DataModels;
using Hotellux.Repositories;
using Hotellux.Tools;
using Hotellux.Tools.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        #region Properties
        private CustomerDataModel _customerModel = new();
        private CustomerRepository _customerRepository = new();
        private int _selectedCustomerIndex = -1;
        private string _selectedName;
        private string _selectedLastName;

        #region List
        public ObservableCollection<CustomerDataModel> CustomersList { get; set; } = new();

        public int SelectedCustomerIndex
        {
            get => _selectedCustomerIndex;
            set
            {
                _selectedCustomerIndex = value;
                if (value < 0) return;
                _customerModel = CustomersList[value];
                PropertyChangedAllFields();
            }
        }
        
        public string SelectedName
        {
            get => _selectedName;
            set
            {
                if (_selectedName == value) return;
                _selectedName = value;
                OnPropertyChanged();
                CreateListView();
            }
        }

        public string SelectedLastName
        {
            get => _selectedLastName;
            set
            {
                if (_selectedLastName == value) return;
                _selectedLastName = value;
                OnPropertyChanged();
                CreateListView();
            }
        }
        #endregion

        #region Fields
        public override string ViewModelName => "Klienci";

        public int Id => _customerModel.Id;

        public string Name
        {
            get => _customerModel.Name;
            set
            {
                if (value == _customerModel.Name) return;
                _customerModel.Name = value;
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                    AddError(nameof(Name), "Wartość nie może być pusta.");
                if (value.HasDigit())
                    AddError(nameof(Name), "Wartość nie może zawierać liczby");
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => _customerModel.Lastname;
            set
            {
                if (value == _customerModel.Lastname) return;
                _customerModel.Lastname = value;
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                    AddError(nameof(Lastname), "Wartość nie może być pusta.");
                if (value.HasDigit())
                    AddError(nameof(Lastname), "Wartość nie może zawierać liczby");
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _customerModel.Email;
            set
            {
                if (value == _customerModel.Email) return;
                _customerModel.Email = value;
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                    AddError(nameof(Email), "Wartość nie może być pusta.");
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _customerModel.PhoneNumber;
            set
            {
                if (value == _customerModel.PhoneNumber) return;
                _customerModel.PhoneNumber = value;
                ClearErrors();
                if (!value.ValidPhoneNumber())
                    AddError(nameof(PhoneNumber), "Wartość nie jest numerem telefonu.");
                OnPropertyChanged();
            }
        }
        public DateTime CreatedDate => _customerModel.Timestamp.CreateDate();
        #endregion

        #region Commands
        public ICommand ClearNameFilterCommand { get; set; }

        public ICommand ClearLastNameFilterCommand { get; set; }

        public ICommand DeleteModelCommand { get; set; }

        public ICommand NewModelCommand { get; set; }

        public ICommand SaveModelCommand { get; set; }
        #endregion
        #endregion

        public MainWindowViewModel MainWindowViewModel
        {
            get => default;
            set
            {
            }
        }

        public CustomerDataModel CustomerDataModel
        {
            get => default;
            set
            {
            }
        }

        public Views.CustomersView CustomersView
        {
            get => default;
            set
            {
            }
        }

        public CustomersViewModel()
        {
            ClearNameFilterCommand = new RelayCommand(ClearNameFilter);
            ClearLastNameFilterCommand = new RelayCommand(ClearLastNameFilter);
            DeleteModelCommand = new RelayCommand(DeleteModel, CanDeleteModel);
            NewModelCommand = new RelayCommand(NewModel);
            SaveModelCommand = new RelayCommand(SaveModel, CanSaveModel);
            CreateListView();
        }

        #region Methods
        #region List
        private void CreateListView()
        {
            List<CustomerDataModel> filteredList = _customerRepository.GetAll();

            if (!string.IsNullOrEmpty(_selectedName))
                filteredList = filteredList.Where(x => x.Name.ToUpper().Contains(_selectedName.ToUpper())).ToList();
            if (!string.IsNullOrEmpty(_selectedLastName))
                filteredList = filteredList.Where(x => x.Lastname.ToUpper().Contains(_selectedLastName.ToUpper())).ToList();

            CustomersList = new ObservableCollection<CustomerDataModel>(filteredList);
            OnPropertyChanged(nameof(CustomersList));
        }
        #endregion

        #region Commands
        private void ClearNameFilter(object obj) => SelectedName = null;

        private void ClearLastNameFilter(object obj) => SelectedLastName = null;

        private void DeleteModel(object obj)
        {
            _customerRepository.Delete(_customerModel);
            CreateListView();
            NewModel(null);
        }

        private bool CanDeleteModel(object obj) => _customerModel != null && _customerRepository.GetById(_customerModel.Id) != null;

        private void NewModel(object obj)
        {
            _customerModel = new CustomerDataModel();
            ClearAllErrors();
            PropertyChangedAllFields();
        }

        private void SaveModel(object obj)
        {
            if (_customerRepository.GetById(Id) == null)
                _customerRepository.Create(_customerModel);
            else
                _customerRepository.Update(_customerModel);
            CreateListView();
        }

        private bool CanSaveModel(object obj) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Lastname) && !HasErrors;
        #endregion

        private void PropertyChangedAllFields()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Lastname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(CreatedDate));
        }
        #endregion
    }
}
