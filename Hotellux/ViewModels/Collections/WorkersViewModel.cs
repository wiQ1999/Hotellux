using Hotellux.Repositories;
using Hotellux.ViewModels.Units;
using System.Collections.ObjectModel;

namespace Hotellux.ViewModels.Collections
{
    public class WorkersViewModel : ObservableCollection<WorkerViewModel>
    {
        private WorkerRepository _workerRepository;

        public WorkersViewModel()
        {
            _workerRepository = new WorkerRepository();
            _workerRepository.GetAll().ForEach(x => Add(new WorkerViewModel(x)));
        }

    }
}
