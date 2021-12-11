using System.Collections.Generic;

namespace Hotellux.Interfaces
{
    public interface ICRUD<T>
    {
        public void Create(T toCreate);

        public List<T> GetAll();

        public T GetById(int id);

        public void Update(T toUpdate);

        public void Delete(T toDelete);
    }
}
