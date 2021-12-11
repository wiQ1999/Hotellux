using DataBase;
using DataBase.DataModels;
using Hotellux.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hotellux.Repositories
{
    public class RoomRepository : ICRUD<RoomDataModel>
    {
        public void Create(RoomDataModel toCreate)
        {
            using var context = new Context();
            context.Rooms.Add(toCreate);
            context.SaveChanges();
        }

        public void Delete(RoomDataModel toDelete)
        {
            using var context = new Context();
            context.Rooms.Add(toDelete);
            context.SaveChanges();
        }

        public List<RoomDataModel> GetAll()
        {
            using var context = new Context();
            return context.Rooms.ToList();
        }

        public RoomDataModel GetById(int id)
        {
            using var context = new Context();
            return context.Rooms.SingleOrDefault(x => x.Id == id);
        }

        public void Update(RoomDataModel toUpdate)
        {
            using var context = new Context();
            context.Rooms.Update(toUpdate);
            context.SaveChanges();
        }
    }
}
