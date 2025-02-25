namespace TaskManagementSystem.Models
{
    public class ResponseMessage
    {
        public string? code { get; set; }
        public string? description { get; set; }
    }

   public class TaskListResponse : ResponseMessage
    {
        public List<TaskEntity> taskList { get; set; }
    }
}
