using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class AssignTaskEntity
    {
        public string? Id { get; set; }

        public string? TaskID { get; set; }

        public string? MemberID { get; set; }

        public int? Priority { get; set; }

        public string? Status { get; set; }

        public int? Duration { get; set; }

        public string? Remark {  get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public TaskEntity? taskEntity { get; set; }

       
    }
}
