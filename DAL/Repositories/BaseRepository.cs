

using DAL.Dbcontext;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private  ApplicationDbContext _context;
        private DbContext context;

       

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        // Implementing the methods of IBaseRepository interface
        public Task AddAsync(T entity)
        {

            
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();

        }

        public Task DeleteAsync(int id)
        {

            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            
            var  entities = await _context.Set<T>().ToListAsync();
            return  entities;

        }

        public Task<T> GetByIdAsync(int id)
        {

            var entity = _context.Set<T>().Find(id);
            return Task.FromResult(entity);
        }

        public Task UpdateAsync(T entity)
        {

            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}
