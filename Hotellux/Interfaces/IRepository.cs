using System.Collections.Generic;

namespace Hotellux.Interfaces
{
    public interface IRepository<T>
    {
        public void Create(T toCreate);

        public IEnumerable<T> GetAll();

        public void Update(T toUpdate);

        public void Delete(T toDelete);
    }
}
