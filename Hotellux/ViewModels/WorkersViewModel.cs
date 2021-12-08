﻿using DataBase.DataModels;
using DataBase.Enums;
using Hotellux.Repositories;
using Hotellux.Tools;
using Hotellux.Tools.Extensions;
using Hotellux.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class WorkersViewModel : BaseViewModel
    {
        #region Properties
        private WorkerDataModel _workerModel = new();
        private WorkerRepository _workerRepository = new();
        private int _selectedWorkerIndex;
        private string _selectedName;
        private string _selectedLastname;
        private WorkerType? _selectedType;

        #region List
        public ObservableCollection<WorkerDataModel> WorkersList { get; set; } = new();

        public int SelectedWorkerIndex
        {
            get => _selectedWorkerIndex;
            set
            {
                _selectedWorkerIndex = value;
                if (value < 0) return;
                _workerModel = WorkersList[value];
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

        public string SelectedLastname
        {
            get => _selectedLastname;
            set
            {
                if (_selectedLastname == value) return;
                _selectedLastname = value;
                OnPropertyChanged();
                CreateListView();
            }
        }

        public WorkerType[] AllTypes => GetAllTypesFilter();

        public WorkerType? SelectedType
        {
            get => _selectedType;
            set
            {
                if (_selectedType == value) return;
                _selectedType = value;
                OnPropertyChanged();
                CreateListView();
            }
        }

        public Gender[] AllGenders => GetAllGendersFilter();
        #endregion

        #region Fields
        public override string ViewModelName => "Pracownicy";

        public int Id => _workerModel.Id;

        public bool IsActive
        {
            get => _workerModel.IsActive;
            set
            {
                if (value == _workerModel.IsActive) return;
                _workerModel.IsActive = value;
                OnPropertyChanged();
            }
        }

        public WorkerType Type
        {
            get => _workerModel.Type;
            set
            {
                if (value == _workerModel.Type) return;
                _workerModel.Type = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _workerModel.Name;
            set
            {
                if (value == _workerModel.Name) return;
                _workerModel.Name = value;
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
            get => _workerModel.Lastname;
            set
            {
                if (value == _workerModel.Lastname) return;
                _workerModel.Lastname = value;
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                    AddError(nameof(Lastname), "Wartość nie może być pusta.");
                if (value.HasDigit())
                    AddError(nameof(Lastname), "Wartość nie może zawierać liczby");
                OnPropertyChanged();
            }
        }

        public Gender? Gender
        {
            get => _workerModel.Gender;
            set
            {
                if (value == _workerModel.Gender) return;
                _workerModel.Gender = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _workerModel.DateOfBirth;
            set
            {
                if (value == _workerModel.DateOfBirth) return;
                _workerModel.DateOfBirth = value;
                ClearErrors();
                if (value > DateTime.Today)
                    AddError(nameof(DateOfBirth), "Nieprawidłowa data.");
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _workerModel.Email;
            set
            {
                if (value == _workerModel.Email) return;
                _workerModel.Email = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _workerModel.PhoneNumber;
            set
            {
                if (value == _workerModel.PhoneNumber) return;
                _workerModel.PhoneNumber = value;
                ClearErrors();
                if (value.Length > 15)
                    AddError(nameof(PhoneNumber), "Maksymalna długość to 15 znaków.");
                OnPropertyChanged();
            }
        }

        public DateTime CreatedDate => _workerModel.Timestamp.CreateDate();
        #endregion

        #region Commands
        public ICommand ClearNameFilterCommand { get; set; }

        public ICommand ClearLastNameFilterCommand { get; set; }

        public ICommand ClearTypeFilterCommand { get; set; }

        public ICommand ClearGenderFieldCommand { get; set; }

        public ICommand NewRoomCommand { get; set; }

        public ICommand SaveRoomCommand { get; set; }
        #endregion
        #endregion

        public WorkersViewModel()
        {
            ClearNameFilterCommand = new RelayCommand(ClearNameFilter);
            ClearLastNameFilterCommand = new RelayCommand(ClearLastNameFilter);
            ClearTypeFilterCommand = new RelayCommand(ClearTypeFilter);
            ClearGenderFieldCommand = new RelayCommand(ClearGenderField);
            NewRoomCommand = new RelayCommand(NewWorker);
            SaveRoomCommand = new RelayCommand(SaveWorker, CanSaveWorker);
            NewWorker(null);
            CreateListView();
        }

        #region Methods
        #region List
        private WorkerType[] GetAllTypesFilter() => EnumHelper.GetValues<WorkerType>();
       
        private Gender[] GetAllGendersFilter() => EnumHelper.GetValues<Gender>();

        private void CreateListView()
        {
            List<WorkerDataModel> filteredList = _workerRepository.GetAll();

            if (!string.IsNullOrEmpty(_selectedName))
                filteredList = filteredList.Where(x => x.Name.ToUpper().Contains(_selectedName.ToUpper())).ToList();
            if (!string.IsNullOrEmpty(_selectedLastname))
                filteredList = filteredList.Where(x => x.Lastname.ToUpper().Contains(_selectedLastname.ToUpper())).ToList();
            if (_selectedType != null)
                filteredList = filteredList.Where(x => x.Type == _selectedType).ToList();

            WorkersList = new ObservableCollection<WorkerDataModel>(filteredList);
            OnPropertyChanged(nameof(WorkersList));
        }
        #endregion

        #region Commands
        private void ClearNameFilter(object obj) => SelectedName = null;

        private void ClearLastNameFilter(object obj) => SelectedLastname = null;

        private void ClearTypeFilter(object obj) => SelectedType = null;

        private void ClearGenderField(object obj) => SelectedType = null;

        private void NewWorker(object obj)
        {
            _workerModel = new WorkerDataModel();
            _workerModel.DateOfBirth = DateTime.Today.AddYears(-18);
            ClearAllErrors();
            PropertyChangedAllFields();
        }

        private void SaveWorker(object obj)
        {
            if (_workerRepository.GetById(Id) == null)
                _workerRepository.Create(_workerModel);
            else
                _workerRepository.Update(_workerModel);
            CreateListView();
        }

        private bool CanSaveWorker(object obj) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Lastname) && !HasErrors;
        #endregion

        private void PropertyChangedAllFields()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(IsActive));
            OnPropertyChanged(nameof(Type));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Lastname));
            OnPropertyChanged(nameof(Gender));
            OnPropertyChanged(nameof(DateOfBirth));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(CreatedDate));
        }
        #endregion
    }
}
