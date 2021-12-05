using DataBase.DataModels;
using Hotellux.Repositories;
using Hotellux.Tools;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class ReservationViewModel : BaseViewModel
    {
        #region Properties
        private ReservationDataModel _reservationModel;
        private ReservationRepository _reservationRepository;

        public ObservableCollection<CustomersViewModel> Customers { get; set; }

        public CustomerDataModel SelectedCustomer
        {
            get => _reservationModel.Customer;
            set
            {
                _reservationModel.Customer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomersViewModel> Rooms { get; set; }

        public RoomDataModel SelectedRoom
        {
            get => _reservationModel.Room;
            set
            {
                _reservationModel.Room = value;
                OnPropertyChanged();
            }
        }

        public override string ViewModelName => "Rezerwacje";

        public int PersonCount
        {
            get => _reservationModel.PersonCount;
            set
            {
                _reservationModel.PersonCount = value;
                OnPropertyChanged();
            }
        }

        public bool WithBreakfast
        {
            get => _reservationModel.WithBreakfast;
            set
            {
                _reservationModel.WithBreakfast = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDatePlanned
        {
            get => _reservationModel.StartDatePlanned;
            set
            {
                _reservationModel.StartDatePlanned = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDatePlanned
        {
            get => _reservationModel.EndDatePlanned;
            set
            {
                _reservationModel.EndDatePlanned = value;
                OnPropertyChanged();
            }
        }

        public DateTime? StartDateReal
        {
            get => _reservationModel.StartDateReal;
            set
            {
                _reservationModel.StartDateReal = value;
                OnPropertyChanged();
            }
        }

        public DateTime? EndDateReal
        {
            get => _reservationModel.EndDateReal;
            set
            {
                _reservationModel.EndDateReal = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ReservationViewModel()
        {
            _reservationModel = new ReservationDataModel();
            _reservationRepository = new ReservationRepository();
            Customers = new ObservableCollection<CustomersViewModel>();
            //new CustomerRepository().GetAll().ForEach(x => Customers.Add(new CustomersViewModel(x)));
            Rooms = new ObservableCollection<CustomersViewModel>();
            //new RoomRepository().GetAll().ForEach(x => Rooms.Add(new ))
            InitializeCommands();
        }

        public ReservationViewModel(ReservationDataModel reservationModel) : this()
        {
            _reservationModel = reservationModel;
        }

        #region Commands
        public ICommand ComfirmCommand { get; set; }

        private void ComfirmReservation(object obj) => _reservationRepository.Create(_reservationModel);

        private bool CanComfirmReservation(object obj) => HasRequiredInformations();

        public ICommand CancelCommand { get; set; }

        private void CancelReservation(object obj) => _reservationRepository.Create(_reservationModel);
        #endregion

        private void InitializeCommands()
        {
            ComfirmCommand = new RelayCommand(ComfirmReservation, CanComfirmReservation);
            CancelCommand = new RelayCommand(CancelReservation);
        }

        private bool HasRequiredInformations() => SelectedCustomer != null && SelectedRoom != null && PersonCount > 0;
    }
}
