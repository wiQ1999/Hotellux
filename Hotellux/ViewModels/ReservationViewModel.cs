using DataBase.DataModels;
using Hotellux.Repositories;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hotellux.ViewModels
{
    public class ReservationViewModel : INotifyPropertyChanged
    {
        private ReservationDataModel _reservationModel;
        private ReservationRepository _reservationRepository = new();

        public CustomerDataModel Customer
        {
            get => _reservationModel.Customer;
            set
            {
                _reservationModel.Customer = value;
                OnPropertyChanged();
            }
        }

        public RoomDataModel Room
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
