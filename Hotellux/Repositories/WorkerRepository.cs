using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class WorkerRepository //: ICRUD<WorkerDataModel>
    {
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

        public void Update(WorkerDataModel toUpdate)
        {
            using var context = new Context();
            context.Workers.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
