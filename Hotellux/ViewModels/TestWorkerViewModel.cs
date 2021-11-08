using DataBase.DataModels;
using Hotellux.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Hotellux.ViewModels
{
    public class TestWorkerViewModel : INotifyPropertyChanged
    {
        private readonly WorkerRepository _workerRepository = new();

        public ObservableCollection<WorkerDataModel> Workers { get; }

        public TestWorkerViewModel()
        {
            List<WorkerDataModel> workers = _workerRepository.GetAll().ToList();
            Workers = new ObservableCollection<WorkerDataModel>(workers);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
