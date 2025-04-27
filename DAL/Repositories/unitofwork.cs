
using core.Unitofwork;

namespace DAL.Repositories
{
    public class unitofwork : Iunitofwork
    {

        private readonly DbContext _context;
        
        public IBaseRepository<Author> Authors {  get; private set; }
        public IBaseRepository<Book> Books { get; private set; }

      

        public unitofwork(DbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);
            Books = new BaseRepository<Book>(_context);
        }
       

       

        public Task<int> CompleteAsync()
        {

            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
