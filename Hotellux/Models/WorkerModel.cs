using DataBase.DataModels;
using DataBase.Enums;
using Hotellux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Models
{
    public class WorkerModel
    {
        private WorkerDataModel _workerDataModel;

        public int Id => _workerDataModel.Id;

        public bool IsActive
        {
            get => _workerDataModel.IsActive;
            private set
            {
                _workerDataModel.IsActive = value;
                //OnPropertyChanged();
            }
        }

        public List<WorkerType> AvaliableWorkerTypes => Enum.GetValues(typeof(WorkerType)).Cast<WorkerType>().ToList();

        public WorkerType WorkerType
        {
            get => _workerDataModel.Type;
            set
            {
                _workerDataModel.Type = value;
                //OnPropertyChanged();
                IsActive = true;
                //OnPropertyChanged(nameof(IsActive));
            }
        }

        public WorkerModel()
        {
            _workerDataModel = new WorkerDataModel();
        }
    }
}
