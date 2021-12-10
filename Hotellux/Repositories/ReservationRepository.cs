using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class ReservationRepository : ICRUD<ReservationDataModel>
    {
        public ViewModels.ReservationsViewModel ReservationsViewModel
        {
            get => default;
            set
            {
            }
        }

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

        public List<ReservationDataModel> GetAll()
        {
            using var context = new Context();
            return context.Reservations.ToList();
        }

        public ReservationDataModel GetById(int id)
        {
            using var context = new Context();
            return context.Reservations.SingleOrDefault(x => x.Id == id);
        }

        public void Update(ReservationDataModel toUpdate)
        {
            using var context = new Context();
            context.Reservations.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
