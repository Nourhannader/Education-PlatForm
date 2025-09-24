using education.Models;

namespace education.Repository
{
    public interface IFollowRepository 
    {
        Task<bool> toggleFollow(string userId, string instructorId);
        Task Save();
    }
}
