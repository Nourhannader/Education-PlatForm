
using education.Models;
using Microsoft.EntityFrameworkCore;

namespace education.Repository
{
    public class FollowRepository : IFollowRepository
    {
        public readonly ApplicationDbContext context;
        public FollowRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Save()
        {
           await context.SaveChangesAsync();
        }

        public async Task<bool> toggleFollow(string userId, string instructorId)
        {
            var follow = await context.Follows.FirstOrDefaultAsync(f => f.InstructorId == instructorId && f.StudentId == userId);
            if (follow != null)
            {
                context.Follows.Remove(follow);
                return false;
            }
            else
            {
               await context.Follows.AddAsync(new Follow { InstructorId = instructorId, StudentId = userId });
                return true;
            }
        }
    }
}
