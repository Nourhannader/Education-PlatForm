using System.Threading.Tasks;
using education.Models;
using Microsoft.EntityFrameworkCore;

namespace education.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext context;
        public CourseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Delete(int id)
        {
            var course = await GetById(id);
            if (course != null)
            {
                course.isDeleted = true;
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return context.Courses.Where(c => !c.isDeleted);
        }

        public IEnumerable<Course> GetAllByInstructor(string instructorId)
        {
            return context.Courses
                .Where(c => c.InstructorId == instructorId);
        }

        public async Task<Course> GetById(int id)
        {
            return await context.
                Courses.FirstOrDefaultAsync(c => c.Id == id && !c.isDeleted);
        }

        public async Task Insert(Course course)
        {
            await context.Courses.AddAsync(course);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(Course course)
        {
            context.Courses.Update(course); // Removed 'await' as DbSet.Update is a synchronous method
        }
    }
}
