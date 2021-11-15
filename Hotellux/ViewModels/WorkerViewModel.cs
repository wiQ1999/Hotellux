using DataBase.DataModels;
using DataBase.Enums;
using Hotellux.Commands;
using Hotellux.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (value != _workerModel.IsActive)
                {
                    _workerModel.IsActive = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<WorkerType> AvaliableWorkerTypes => Enum.GetValues(typeof(WorkerType)).Cast<WorkerType>().ToList();

        public WorkerType WorkerType
        {
            get => _workerModel.Type;
            set
            {
                if (value != _workerModel.Type)
                {
                    _workerModel.Type = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _workerModel.Name;
            set
            {
                if (value != _workerModel.Name)
                {
                    _workerModel.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Lastname
        {
            get => _workerModel.Lastname;
            set
            {
                if (value != _workerModel.Lastname)
                {
                    _workerModel.Lastname = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Gender> AvaliableGenders => Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

        public Gender? Gender
        {
            get => _workerModel.Gender;
            set
            {
                if (value != _workerModel.Gender)
                {
                    _workerModel.Gender = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateOfBirth
        {
            get => _workerModel.DateOfBirth;
            set
            {
                if (value != _workerModel.DateOfBirth)
                {
                    _workerModel.DateOfBirth = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(IsOfAge));
                }
            }
        }

        public int Age => new DateTime((DateTime.Today - DateOfBirth).Ticks).Year;//DO SPRAWDZENIA!!!

        public bool IsOfAge => Age >= 18;

        public string Email
        {
            get => _workerModel.Email;
            set
            {
                if (value != _workerModel.Email)
                {
                    _workerModel.Email = value;
                    OnPropertyChanged();
                }
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

        public ICommand SaveCommand { get; set; }

        public WorkerViewModel()
        {
            //_workerModel = new WorkerDataModel { DateOfBirth = DateTime.Today };
            var test = _workerRepository.GetAll();
            _workerModel = test.FirstOrDefault();
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void Save(object obj) => _workerRepository.Create(_workerModel);

        private bool CanSave(object obj) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Lastname) && IsOfAge;

    }
}
