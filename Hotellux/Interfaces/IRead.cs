using System.Collections.Generic;

namespace Hotellux.Interfaces
{
    public interface IRead<T>
    {
        public IEnumerable<T> GetAll();
    }
}
