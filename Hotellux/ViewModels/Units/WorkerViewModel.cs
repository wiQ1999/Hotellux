using DataBase.DataModels;
using DataBase.Enums;
using Hotellux.Commands;
using Hotellux.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Hotellux.ViewModels.Units
{
    public class WorkerViewModel : BaseViewModel
    {
        #region Properties
        private readonly WorkerDataModel _workerModel;

        private readonly WorkerRepository _workerRepository;

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

        public List<WorkerType> AvaliableWorkerTypes => Enum.GetValues(typeof(WorkerType)).Cast<WorkerType>().ToList();

        public WorkerType WorkerType
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
                OnPropertyChanged();
            }
        }

        public List<Gender> AvaliableGenders => Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

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
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(IsOfAge));
            }
        }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - DateOfBirth.Year;
                if (now < DateOfBirth.AddYears(age))
                    return --age;
                return age;
            }
        }

        public bool IsOfAge => Age >= 18;

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

        public string PhonNumber
        {
            get => _workerModel.PhonNumber;
            set
            {
                if (value != _workerModel.PhonNumber && value.Length <= 15)
                {
                    _workerModel.PhonNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime CreatedDate => DateTime.FromBinary(BitConverter.ToInt64(_workerModel.Timestamp, 0));
        #endregion

        public WorkerViewModel()
        {
            _workerRepository = new WorkerRepository();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        public WorkerViewModel(WorkerDataModel model) : this()
        {
            _workerModel = model;
        }

        #region Commands
        public ICommand SaveCommand { get; set; }

        private void Save(object obj) => _workerRepository.Create(_workerModel);

        private bool CanSave(object obj) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Lastname) && IsOfAge;
        #endregion

    }
}
