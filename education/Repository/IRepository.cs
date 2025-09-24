using education.ViewModel;

namespace education.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        
        Task Insert(T entity); 
        
        Task Save();
    }
}
