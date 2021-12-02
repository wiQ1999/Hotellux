using DataBase.DataModels;
using Hotellux.Repositories;
using Hotellux.Tools;
using Hotellux.Tools.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class RoomsViewModel : BaseViewModel
    {
        private RoomDataModel _roomModel = new();
        private RoomRepository _roomRepository = new();
        private List<RoomDataModel> _allRooms = new();

        #region List
        public ObservableCollection<RoomDataModel> RoomsList { get; set; } = new();


        #endregion

        #region Fields
        public RoomDataModel RoomModel
        {
            get => _roomModel;
            set
            {
                _roomModel = value;
                PropertyChangedAllFields();
            }
        }

        public override string ViewModelName => "Pokoje";

        public int Id => _roomModel.Id;

        public int Floor
        {
            get => _roomModel.Floor;
            set
            {
                if (value == _roomModel.Floor) return;
                _roomModel.Floor = value;
                OnPropertyChanged();
            }
        }

        public string Number
        {
            get => _roomModel.Number;
            set
            {
                if (value == _roomModel.Number) return;
                _roomModel.Number = value;
                OnPropertyChanged();
            }
        }

        public float Size
        {
            get => _roomModel.Size;
            set
            {
                if (value == _roomModel.Size) return;
                _roomModel.Size = value;
                OnPropertyChanged();
            }
        }

        public int Capacity
        {
            get => _roomModel.Capacity;
            set
            {
                if (value == _roomModel.Capacity) return;
                _roomModel.Capacity = value;
                OnPropertyChanged();
            }
        }

        public decimal PricePerDay
        {
            get => _roomModel.PricePerDay;
            set
            {
                if (value == _roomModel.PricePerDay) return;
                _roomModel.PricePerDay = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _roomModel.Description;
            set
            {
                if (value == _roomModel.Description) return;
                _roomModel.Description = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreatedDate => _roomModel.Timestamp.CreateDate();
        #endregion

        #region Commands
        public ICommand NewRoomCommand { get; set; }

        public ICommand SaveRoomCommand { get; set; }
        #endregion

        public RoomsViewModel()
        {
            _allRooms = new List<RoomDataModel>(_roomRepository.GetAll());
            RoomsList = new ObservableCollection<RoomDataModel>(_allRooms);
            NewRoomCommand = new RelayCommand(NewRoom);
            SaveRoomCommand = new RelayCommand(SaveRoom, CanSaveRoom);
        }

        #region Methods
        private void NewRoom(object obj)
        {
            _roomModel = new RoomDataModel();
            PropertyChangedAllFields();
        }

        private void SaveRoom(object obj)
        {
            _roomRepository.Create(_roomModel);
            _roomModel = new RoomDataModel();
        }

        private bool CanSaveRoom(object obj) => true;

        private void PropertyChangedAllFields()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Floor));
            OnPropertyChanged(nameof(Number));
            OnPropertyChanged(nameof(Size));
            OnPropertyChanged(nameof(Capacity));
            OnPropertyChanged(nameof(PricePerDay));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(CreatedDate));
        }
        #endregion
    }
}
