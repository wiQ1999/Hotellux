using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class ReservationRepository : ICRUD<ReservationDataModel>
    {
        public void Create(ReservationDataModel toCreate)
        {
            using var context = new Context();
            context.Reservations.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(ReservationDataModel toDelete)
        {
            using var context = new Context();
            context.Reservations.Remove(toDelete);
            context.SaveChanges();
        }

        public IEnumerable<ReservationDataModel> GetAll()
        {
            using var context = new Context();
            return context.Reservations.AsEnumerable();
        }

        public void Update(ReservationDataModel toUpdate)
        {
            using var context = new Context();
            context.Reservations.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
