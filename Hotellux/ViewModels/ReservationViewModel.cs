using DataBase.DataModels;
using Hotellux.Repositories;
using System;
using System.Collections.ObjectModel;

namespace Hotellux.ViewModels
{
    public class ReservationViewModel : BaseViewModel
    {
        private ReservationDataModel _reservationModel;
        private ReservationRepository _reservationRepository;

        public ObservableCollection<CustomerViewModel> Customers { get; set; }

        public CustomerDataModel SelectedCustomer
        {
            get => _reservationModel.Customer;
            set
            {
                _reservationModel.Customer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomerViewModel> Rooms { get; set; }

        public RoomDataModel SelectedRoom
        {
            get => _reservationModel.Room;
            set
            {
                _reservationModel.Room = value;
                OnPropertyChanged();
            }
        }

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

        public ReservationViewModel()
        {
            _reservationModel = new ReservationDataModel();
            _reservationRepository = new ReservationRepository();
            new CustomerRepository().GetAll().ForEach(x => Customers.Add(new CustomerViewModel(x)));
        }
    }
}
