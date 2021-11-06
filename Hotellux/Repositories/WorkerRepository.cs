using DataBase;
using DataBase.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellux.Repositories
{
    public class WorkerRepository
    {
        public List<WorkerDataModel> GetAll()
        {
            using var context = new Context();
            return context.Workers.ToList();
        }
    }
}
