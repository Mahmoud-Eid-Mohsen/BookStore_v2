
namespace core.Unitofwork
{
    public interface Iunitofwork: IDisposable
    {

        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Book> Books { get; }

        

         Task<int> CompleteAsync();
    }


}
