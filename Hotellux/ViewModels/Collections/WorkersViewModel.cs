using DataBase.Enums;
using Hotellux.Enums;
using Hotellux.Repositories;
using Hotellux.ViewModels.Units;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hotellux.ViewModels.Collections
{
    public class WorkersViewModel : BaseViewModel
    {
        private WorkerRepository _workerRepository;
        private List<WorkerViewModel> _allWorkers;
        private WorkerActivityFilter _workerActivity;
        private WorkerTypeFilter _workerType;

        public ObservableCollection<WorkerViewModel> Workers { get; set; }

        public WorkerViewModel SelectedItem { get; set; }

        public WorkerActivityFilter WorkerActivity
        {
            get => _workerActivity;
            set
            {
                if (value == _workerActivity) return;
                _workerActivity = value;
                OnPropertyChanged();
                BuildCollection();
            }
        }

        public WorkerTypeFilter WorkerType
        {
            get => _workerType;
            set
            {
                if (value == _workerType) return;
                _workerType = value;
                OnPropertyChanged();
                BuildCollection();
            }
        }

        public WorkersViewModel()
        {
            _workerRepository = new WorkerRepository();
            _workerRepository.GetAll().ForEach(x => _allWorkers.Add(new WorkerViewModel(x)));
            Workers = new ObservableCollection<WorkerViewModel>(_allWorkers);
            InitializeFilters();
        }

        private void InitializeFilters()
        {
            _workerActivity = WorkerActivityFilter.Active;
            _workerType = WorkerTypeFilter.All;
        }

        private void BuildCollection()
        {
            var filteredCollection = _allWorkers.AsEnumerable();

            if (_workerActivity != WorkerActivityFilter.All)
                filteredCollection = filteredCollection.Where(x => x.IsActive == (_workerActivity == WorkerActivityFilter.Active));
            if (_workerType != WorkerTypeFilter.All)
                filteredCollection = filteredCollection.Where(x => x.WorkerType == (WorkerType)_workerType);

            Workers = new ObservableCollection<WorkerViewModel>(filteredCollection);
        }
    }
}
