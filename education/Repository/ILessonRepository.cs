using education.Models;

namespace education.Repository
{
    public interface ILessonRepository :IRepository<Lesson>
    {
        Task<Lesson> GetById(int id);
        Task Delete(int id);
        Task Update(Lesson entity);
        IEnumerable<Lesson> GetAllByCourse(int courseId);
    }
}
