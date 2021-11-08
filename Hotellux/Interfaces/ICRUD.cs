namespace Hotellux.Interfaces
{
    public interface ICRUD<T> : IRead<T>, IDelete<T>
    {
        public void Create(T toCreate);

        public void Update(T toUpdate);
    }
}
