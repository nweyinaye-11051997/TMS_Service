namespace TaskManagementSystem.Models
{
    public class ProjectEntity
    {
        public string? Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string? Remark { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
