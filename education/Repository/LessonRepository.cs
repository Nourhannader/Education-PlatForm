using education.Models;
using Microsoft.EntityFrameworkCore;

namespace education.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext context;
        public LessonRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Delete(int id)
        {
            var lesson = await GetById(id);
            if (lesson != null)
            {
                lesson.isDeleted = true;
            }
        }

        public IEnumerable<Lesson> GetAll()
        {
            return context.Lessons.Where(l => !l.isDeleted);
        }

        public IEnumerable<Lesson> GetAllByCourse(int courseId)
        {
            return context.Lessons.Where(l => l.CourseId == courseId && !l.isDeleted);
        }

        public async Task<Lesson> GetById(int id)
        {
            return await context.Lessons
                .FirstOrDefaultAsync(l => l.Id == id && !l.isDeleted);
        }

        public async Task Insert(Lesson lesson)
        {
           await context.Lessons.AddAsync(lesson);
        }

        public async Task Save()
        {
           await context.SaveChangesAsync();
        }

        public async Task Update(Lesson lesson)
        {
            context.Lessons.Update(lesson);
        }
    }
}
