using System.Collections.Generic;

namespace Hotellux.Interfaces
{
    public interface ICRUD<T>
    {
        Repositories.LoginRepository LoginRepository { get; set; }
        Repositories.CustomerRepository CustomerRepository { get; set; }
        Repositories.RoomRepository RoomRepository { get; set; }
        Repositories.WorkerRepository WorkerRepository { get; set; }
        Repositories.ReservationRepository ReservationRepository { get; set; }

        public void Create(T toCreate);

        public List<T> GetAll();

        public T GetById(int id);

        public void Update(T toUpdate);

        public void Delete(T toDelete);
    }
}
