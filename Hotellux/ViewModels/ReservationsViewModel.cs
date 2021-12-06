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
    public class ReservationsViewModel : BaseViewModel
    {
        #region Properties
        private ReservationDataModel _reservationModel = new();
        private ReservationRepository _reservationRepository = new();
        private CustomerRepository _customerRepository = new();
        private RoomRepository _roomRepository = new();
        private int _selectedReservationIndex;
        private string _selectedCustomerFullName;
        private int? _selectedPersonCount;
        private DateTime? _selectedStartDatePlanned;
        private DateTime? _selectedEndDatePlanned;
        private int _selectedCustomerIndex;
        private int _selectedRoomIndex;

        #region List
        public ObservableCollection<ReservationDataModel> ReservationsList { get; set; }

        public int SelectedReservationIndex
        {
            get => _selectedReservationIndex;
            set
            {
                _selectedReservationIndex = value;
                if (value < 0) return;
                _reservationModel = ReservationsList[value];
                PropertyChangedAllFields();
            }
        }

        public string SelectedCustomerFullName
        {
            get => _selectedCustomerFullName;
            set
            {
                _selectedCustomerFullName = value;
                OnPropertyChanged();
                CreateReservationsListView();
            }
        }

        public int[] AllPersonCount => GetAllPersonCountFilter();

        public int? SelectedPersonCount
        {
            get => _selectedPersonCount;
            set
            {
                if (value == _selectedPersonCount) return;
                _selectedPersonCount = value;
                OnPropertyChanged();
                CreateReservationsListView();
            }
        }

        public DateTime? SelectedStartDatePlanned
        {
            get => _selectedStartDatePlanned;
            set
            {
                if (value == _selectedStartDatePlanned) return;
                _selectedStartDatePlanned = value;
                OnPropertyChanged();
                CreateReservationsListView();
            }
        }

        public DateTime? SelectedEndDatePlanned
        {
            get => _selectedEndDatePlanned;
            set
            {
                if (value == _selectedEndDatePlanned) return;
                _selectedEndDatePlanned = value;
                OnPropertyChanged();
                CreateReservationsListView();
            }
        }

        public ObservableCollection<CustomerDataModel> CustomersList { get; set; }

        public int SelectedCustomerIndex
        {
            get => _selectedCustomerIndex;
            set
            {
                _selectedCustomerIndex = value;
                if (value < 0) return;
                Customer = CustomersList[value];
            }
        }

        public ObservableCollection<RoomDataModel> RoomsList { get; set; }

        public int SelectedRoomIndex
        {
            get => _selectedRoomIndex;
            set
            {
                _selectedRoomIndex = value;
                if (value < 0) return;
                Room = RoomsList[value];
            }
        }
        #endregion

        #region Fields
        public override string ViewModelName => "Rezerwacje";

        public int Id => _reservationModel.Id;

        public CustomerDataModel Customer
        {
            get => _reservationModel.Customer;
            private set
            {
                if (value == _reservationModel.Customer) return;
                _reservationModel.Customer = value;
                OnPropertyChanged();
            }
        }

        public RoomDataModel Room
        {
            get => _reservationModel.Room;
            private set
            {
                if (value == _reservationModel.Room) return;
                _reservationModel.Room = value;
                OnPropertyChanged();
            }
        }

        public int PersonCount
        {
            get => _reservationModel.PersonCount;
            set
            {
                if (value == _reservationModel.PersonCount) return;
                _reservationModel.PersonCount = value;
                ClearErrors();
                if (value < 0)
                    AddError(nameof(PersonCount), "Ilość osób musi być większa od zera.");
                if (Room != null && value > Room.Capacity)
                    AddError(nameof(PersonCount), "Ilość osób przekracza dostępną ilość miejsc.");
                OnPropertyChanged();
            }
        }

        public bool WithBreakfast
        {
            get => _reservationModel.WithBreakfast;
            set
            {
                if (value == _reservationModel.WithBreakfast) return;
                _reservationModel.WithBreakfast = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDatePlanned
        {
            get => _reservationModel.StartDatePlanned;
            set
            {
                if (value == _reservationModel.StartDatePlanned) return;
                _reservationModel.StartDatePlanned = value;
                ClearErrors();
                if (value > EndDatePlanned)
                    AddError(nameof(StartDatePlanned), "Planowana data rozpoczęcia większa od daty zakończenia.");
                OnPropertyChanged();
            }
        }

        public DateTime EndDatePlanned
        {
            get => _reservationModel.EndDatePlanned;
            set
            {
                if (value == _reservationModel.EndDatePlanned) return;
                _reservationModel.EndDatePlanned = value;
                ClearErrors();
                if (value < StartDatePlanned)
                    AddError(nameof(EndDatePlanned), "Planowana data zakończenia mniejsza od daty rozpoczęcia.");
                OnPropertyChanged();

            }
        }

        public DateTime? StartDateReal
        {
            get => _reservationModel.StartDateReal;
            set
            {
                if (value == _reservationModel.StartDateReal) return;
                _reservationModel.StartDateReal = value;
                ClearErrors();
                if (EndDateReal != null && value > EndDateReal)
                    AddError(nameof(StartDateReal), "Data rozpoczęcia większa od daty zakończenia.");
                OnPropertyChanged();

            }
        }

        public DateTime? EndDateReal
        {
            get => _reservationModel.EndDateReal;
            set
            {
                if (value == _reservationModel.EndDateReal) return;
                _reservationModel.EndDateReal = value;
                ClearErrors();
                if (StartDateReal != null && value < StartDateReal)
                    AddError(nameof(EndDateReal), "Data zakończenia mniejsza od daty rozpoczęcia.");
                OnPropertyChanged();

            }
        }

        public DateTime CreatedDate => _reservationModel.Timestamp.CreateDate();
        #endregion

        #region Commands
        public ICommand ClearCustomerFullNameFilterCommand { get; set; }

        public ICommand ClearPersonCountFilterCommand { get; set; }

        public ICommand ClearStartDatePlannedFilterCommand { get; set; }

        public ICommand ClearEndDatePlannedFilterCommand { get; set; }

        public ICommand NewRoomCommand { get; set; }

        public ICommand SaveRoomCommand { get; set; }
        #endregion
        #endregion

        public ReservationsViewModel()
        {
            ClearCustomerFullNameFilterCommand = new RelayCommand(ClearCustomerFullNameFilter);
            ClearPersonCountFilterCommand = new RelayCommand(ClearCapacityFilter);
            ClearStartDatePlannedFilterCommand = new RelayCommand(ClearStartDatePlannedFilter);
            ClearEndDatePlannedFilterCommand = new RelayCommand(ClearEndDatePlannedFilter);
            NewRoomCommand = new RelayCommand(NewReservation);
            SaveRoomCommand = new RelayCommand(SaveRoom, CanSaveRoom);
            CreateReservationsListView();
            CustomersList = new ObservableCollection<CustomerDataModel>(_customerRepository.GetAll());
            RoomsList = new ObservableCollection<RoomDataModel>(_roomRepository.GetAll());
        }

        #region Methods
        #region List
        private int[] GetAllPersonCountFilter() => _reservationRepository.GetAll().Select(x => x.PersonCount).Distinct().ToArray();

        private void CreateReservationsListView()
        {
            List<ReservationDataModel> filteredList = _reservationRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(_selectedCustomerFullName))
                filteredList = filteredList.Where(x => x.Customer != null && (x.Customer.Name + " " + x.Customer.Lastname).Contains(_selectedCustomerFullName)).ToList();
            if (_selectedPersonCount != null)
                filteredList = filteredList.Where(x => x.Room != null && x.Room.Capacity == _selectedPersonCount).ToList();
            if (_selectedStartDatePlanned != null)
                filteredList = filteredList.Where(x => x.StartDatePlanned <= _selectedStartDatePlanned).ToList();
            if (_selectedEndDatePlanned != null)
                filteredList = filteredList.Where(x => x.EndDateReal >= _selectedEndDatePlanned).ToList();

            ReservationsList = new ObservableCollection<ReservationDataModel>(filteredList);
            OnPropertyChanged(nameof(RoomsList));
        }
        #endregion

        #region Commands
        private void ClearCustomerFullNameFilter(object obj) => SelectedCustomerFullName = null;

        private void ClearCapacityFilter(object obj) => SelectedPersonCount = null;

        private void ClearStartDatePlannedFilter(object obj) => SelectedStartDatePlanned = null;

        private void ClearEndDatePlannedFilter(object obj) => SelectedEndDatePlanned = null;

        private void NewReservation(object obj)
        {
            _reservationModel = new ReservationDataModel();
            ClearAllErrors();
            PropertyChangedAllFields();
        }

        private void SaveRoom(object obj)//validate!!! TODO
        {
            if (_reservationRepository.GetById(Id) == null)
                _reservationRepository.Create(_reservationModel);
            else
                _reservationRepository.Update(_reservationModel);
            CreateReservationsListView();
        }

        private bool CanSaveRoom(object obj) => !HasErrors;
        #endregion

        private void PropertyChangedAllFields()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Customer));
            OnPropertyChanged(nameof(Room));
            OnPropertyChanged(nameof(PersonCount));
            OnPropertyChanged(nameof(WithBreakfast));
            OnPropertyChanged(nameof(StartDatePlanned));
            OnPropertyChanged(nameof(EndDatePlanned));
            OnPropertyChanged(nameof(StartDateReal));
            OnPropertyChanged(nameof(EndDateReal));
            OnPropertyChanged(nameof(CreatedDate));
        }
        #endregion
    }
}
