using education.Models;
using education.ViewModel;

namespace education.Repository
{
    public interface IInstructorRepository : IRepository<InstructorProfile>
    {
        Task Delete(string id);
        Task Update(InstructorProfile entity);
        Task<InstructorProfile> GetById(string id);
    }
}
