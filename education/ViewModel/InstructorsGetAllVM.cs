namespace education.ViewModel
{
    public class InstructorsGetAllVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public int CourseCount { get; set; }
        public double AverageRating { get; set; }
        public int FollowerCount { get; set; }
        public string? Title { get; set; }
        public string? Skills { get; set; }
        public string? Bio { get; set; }
        public DateTime? Joined { get; set; }
    }
}
