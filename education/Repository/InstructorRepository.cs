using education.Models;
using education.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace education.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public InstructorRepository(ApplicationDbContext context ,UserManager<ApplicationUser> userManager) {
           this.context = context;
            this.userManager = userManager;

        }
        public async Task Delete(string id)
        {
            context.InstructorProfiles.Remove(context.InstructorProfiles.Find(id));
            await userManager.DeleteAsync(context.Users.Find(id));
        }

        public IEnumerable<InstructorProfile> GetAll()
        {
            return context.InstructorProfiles;
        }

        public async Task<InstructorProfile> GetById(string id)
        {
            return await context.InstructorProfiles.
                FindAsync(id);
        }

        public Task<InstructorProfile> GetByIdWithDetails(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(InstructorProfile instructor)
        {
           await context.InstructorProfiles.AddAsync(instructor);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(InstructorProfile instructor)
        {
           context.InstructorProfiles.Update(instructor);
           await userManager.UpdateAsync(context.Users.Find(instructor.Id));

        }
    }
}
