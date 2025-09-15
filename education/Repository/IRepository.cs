using education.ViewModel;

namespace education.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(string id);
        Task Insert(T entity); 
        Task Update(T entity);
        Task Delete(string id);
        Task Save();
    }
}
