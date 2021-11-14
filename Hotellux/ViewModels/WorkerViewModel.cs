using DataBase.DataModels;
using DataBase.Enums;
using Hotellux.Commands;
using Hotellux.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class WorkerViewModel : BaseViewModel
    {
        private WorkerDataModel _workerModel;

        private readonly WorkerRepository _workerRepository = new();

        public int Id => _workerModel.Id;

        public bool IsActive
        {
            get => _workerModel.IsActive;
            set
            {
                _workerModel.IsActive = value;
                OnPropertyChanged();
            }
        }

        public List<WorkerType> AvaliableWorkerTypes => Enum.GetValues(typeof(WorkerType)).Cast<WorkerType>().ToList();

        public WorkerType WorkerType
        {
            get => _workerModel.Type;
            set
            {
                _workerModel.Type = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _workerModel.Name;
            set
            {
                _workerModel.Name = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => _workerModel.Lastname;
            set
            {
                _workerModel.Lastname = value;
                OnPropertyChanged();
            }
        }

        public List<Gender> AvaliableGenders => Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

        public Gender? Gender
        {
            get => _workerModel.Gender;
            set
            {
                _workerModel.Gender = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _workerModel.DateOfBirth;
            set
            {
                _workerModel.DateOfBirth = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(IsOfAge));
            }
        }

        public int Age => new DateTime((DateTime.Today - DateOfBirth).Ticks).Year;//DO SPRAWDZENIA!!!

        public bool IsOfAge => Age >= 18;

        public string Email
        {
            get => _workerModel.Email;
            set
            {
                _workerModel.Email = value;
                OnPropertyChanged();
            }
        }

        public string PhonNumber
        {
            get => _workerModel.PhonNumber;
            set
            {
                _workerModel.PhonNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public WorkerViewModel()
        {
            _workerModel = new WorkerDataModel { DateOfBirth = DateTime.Today };
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void Save(object obj) => _workerRepository.Create(_workerModel);

        private bool CanSave(object obj) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Lastname) && IsOfAge;

    }
}
