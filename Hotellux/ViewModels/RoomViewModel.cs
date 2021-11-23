using DataBase.DataModels;
using Hotellux.Commands;
using Hotellux.Interfaces;
using Hotellux.Repositories;
using System.Windows.Input;

namespace Hotellux.ViewModels
{
    public class RoomViewModel : BaseViewModel, IRequiredFields
    {
        #region Properties
        private RoomDataModel _roomModel;
        private RoomRepository _roomRepository;

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
        #endregion

        #region Commands
        public ICommand SaveCommand { get; set; }

        private void Save(object obj)
        {
            _roomRepository.Create(_roomModel);
            _roomModel = new RoomDataModel();
        }

        private bool CanSave(object obj) => HasRequiredFields();

        public ICommand CancelCommand { get; set; }

        private void Cancel(object obj)
        {
            //wyjście z formularza pokoju
        }
        #endregion

        public RoomViewModel()
        {
            _roomModel = new RoomDataModel();
            _roomRepository = new RoomRepository();
            InitializeCommands();
        }

        public RoomViewModel(RoomDataModel roomModel) : this()
        {
            _roomModel = roomModel;
        }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        public bool HasRequiredFields() => string.IsNullOrWhiteSpace(Number) && Size > 0 && Capacity > 0;
    }
}
