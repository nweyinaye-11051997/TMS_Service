namespace TaskManagementSystem.Models
{
    public class TaskEntity
    {
        public string? Id { get; set; }

        public string? TaskName { get; set; }

        public string? Description { get; set; }

        public string? ProjectID { get; set; }

        public int? Priority { get; set; }

        public string? Status { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public List<AssignTaskEntity> AssignTasks { get; set; } = new List<AssignTaskEntity>();
    }
}
