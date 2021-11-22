using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class CleaningsRepository : ICRUD<CleaningsDataModel>
    {
        public void Create(CleaningsDataModel toCreate)
        {
            using var context = new Context();
            context.Cleanings.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(CleaningsDataModel toDelete)
        {
            using var context = new Context();
            context.Cleanings.Remove(toDelete);
            context.SaveChanges();
        }

        public List<CleaningsDataModel> GetAll()
        {
            using var context = new Context();
            return context.Cleanings.ToList();
        }

        public CleaningsDataModel GetById(int id)
        {
            using var context = new Context();
            return context.Cleanings.SingleOrDefault(x => x.Id == id);
        }

        public void Update(CleaningsDataModel toUpdate)
        {
            using var context = new Context();
            context.Cleanings.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
