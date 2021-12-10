using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class WorkerRepository : ICRUD<WorkerDataModel>
    {
        public ViewModels.WorkersViewModel WorkersViewModel
        {
            get => default;
            set
            {
            }
        }

        public void Create(WorkerDataModel toCreate)
        {
            using var context = new Context();
            context.Workers.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(WorkerDataModel toDelete)
        {
            using var context = new Context();
            context.Workers.Remove(toDelete);
            context.SaveChanges();
        }

        public List<WorkerDataModel> GetAll()
        {
            using var context = new Context();
            return context.Workers.ToList();
        }

        public WorkerDataModel GetById(int id)
        {
            using var context = new Context();
            return context.Workers.SingleOrDefault(x => x.Id == id);
        }

        public void Update(WorkerDataModel toUpdate)
        {
            using var context = new Context();
            context.Workers.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
