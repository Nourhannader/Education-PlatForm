using education.Models;

namespace education.Repository
{
    public interface ICourseRepository:IRepository<Course>
    {
        Task<Course> GetById(int id);
        Task Delete(int id);
        Task Update(Course entity);
        IEnumerable<Course> GetAllByInstructor(string instructorId);

    }
}
