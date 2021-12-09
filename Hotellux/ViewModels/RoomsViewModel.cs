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
    public class RoomsViewModel : BaseViewModel
    {
        #region Properties
        private RoomDataModel _roomModel = new();
        private RoomRepository _roomRepository = new();
        private int _selectedRoomIndex = -1;
        private int? _selectedFloor;
        private int? _selectedCapacity;

        #region List
        public ObservableCollection<RoomDataModel> RoomsList { get; set; } = new();

        public int SelectedRoomIndex
        {
            get => _selectedRoomIndex;
            set
            {
                _selectedRoomIndex = value;
                if (value < 0) return;
                _roomModel = RoomsList[value];
                PropertyChangedAllFields();
            }
        }

        public int[] AllFloors => GetAllFloorsFilter();

        public int? SelectedFloor
        {
            get => _selectedFloor;
            set
            {
                if (value == _selectedFloor) return;
                _selectedFloor = value;
                OnPropertyChanged();
                CreateListView();
            }
        }

        public int[] AllCapacities => GetAllCapacitiesFilter();

        public int? SelectedCapacity
        {
            get => _selectedCapacity;
            set
            {
                if (value == _selectedCapacity) return;
                _selectedCapacity = value;
                OnPropertyChanged();
                CreateListView();
            }
        }
        #endregion

        #region Fields
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
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                    AddError(nameof(Number), "Wartość nie może być pusta.");
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
                ClearErrors();
                if (value < 0)
                    AddError(nameof(Size), "Wielkość pokoju musi być większa od zera.");
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
                ClearErrors();
                if (value < 0)
                    AddError(nameof(Capacity), "Pojemność pokoju musi być większa od zera.");
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
                ClearErrors();
                if (value < 0)
                    AddError(nameof(PricePerDay), "Cena za dobę musi być większa od zera.");
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
        public ICommand ClearFloorFilterCommand { get; set; }

        public ICommand ClearCapacityFilterCommand { get; set; }

        public ICommand NewRoomCommand { get; set; }

        public ICommand SaveRoomCommand { get; set; }
        #endregion
        #endregion

        public RoomsViewModel()
        {
            ClearFloorFilterCommand = new RelayCommand(ClearFloorFilter);
            ClearCapacityFilterCommand = new RelayCommand(ClearCapacityFilter);
            NewRoomCommand = new RelayCommand(NewRoom);
            SaveRoomCommand = new RelayCommand(SaveRoom, CanSaveRoom);
            CreateListView();
        }

        #region Methods
        #region List
        private int[] GetAllFloorsFilter() => _roomRepository.GetAll().Select(x => x.Floor).Distinct().ToArray();

        private int[] GetAllCapacitiesFilter() => _roomRepository.GetAll().Select(x => x.Capacity).Distinct().ToArray();

        private void CreateListView()
        {
            List<RoomDataModel> filteredList = _roomRepository.GetAll();

            if (_selectedFloor != null)
                filteredList = filteredList.Where(x => x.Floor == _selectedFloor).ToList();
            if (_selectedCapacity != null)
                filteredList = filteredList.Where(x => x.Capacity == _selectedCapacity).ToList();

            RoomsList = new ObservableCollection<RoomDataModel>(filteredList);
            OnPropertyChanged(nameof(RoomsList));
        }
        #endregion

        #region Commands
        private void ClearFloorFilter(object obj) => SelectedFloor = null;

        private void ClearCapacityFilter(object obj) => SelectedCapacity = null;

        private void NewRoom(object obj)
        {
            _roomModel = new RoomDataModel();
            ClearAllErrors();
            PropertyChangedAllFields();
        }

        private void SaveRoom(object obj)
        {
            if (_roomRepository.GetById(Id) == null)
                _roomRepository.Create(_roomModel);
            else
                _roomRepository.Update(_roomModel);
            CreateListView();
        }

        private bool CanSaveRoom(object obj) => !string.IsNullOrWhiteSpace(Number) && !HasErrors;
        #endregion

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
