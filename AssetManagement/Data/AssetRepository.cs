using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data
{
    public class AssetRepository<T> : IRepository<T> where T : class
    {
        private readonly SeatManagementDbContext _context;

        public AssetRepository(SeatManagementDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetEntitiesByFilter(Func<T, bool> filterCriteria)
        {
            // Apply the filter criteria to the DbSet and return the IQueryable
            return _context.Set<T>().Where(filterCriteria).AsQueryable();
        }

        public void Add(T Entity)
        {
            try
            {
                _context.Set<T>().Add(Entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                throw new Exception("Adding Entity Failed");
            }

        }

        public void Delete(int id)
        {
            try
            {
                var deleteEntity = _context.Set<T>().Find(id);
                if (deleteEntity != null)
                {
                    _context.Set<T>().Remove(deleteEntity);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Deleting Entity Failed");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Return of Entity List Failed !");
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception e)
            {
                throw new Exception("Retriving Entity by Id Failed");
            }
        }

        public void Update(T Entity)
        {
            try
            {
                _context.Entry(Entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw new Exception("Updating Entity Failed");
            }
        }
    }
}
