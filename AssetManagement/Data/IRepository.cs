namespace AssetManagement.Data
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Add(T Entity);
        public void Delete(int id);
        public void Update(T Entity);
        public IQueryable<T> GetEntitiesByFilter(Func<T, bool> filterCriteria);
    }
}
