namespace TaskManagementSystem.Models
{
    public class TaskEntity
    {
        public string Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Project { get; set; }

        public string? Priority { get; set; }

        public string? Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public string? CreateBy { get; set; }
    }
}
