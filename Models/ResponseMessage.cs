namespace TaskManagementSystem.Models
{
    public class ResponseMessage
    {
        public string? code { get; set; }
        public string? description { get; set; }
    }

   public class ListResponse<T> : ResponseMessage where T : class
    {
        public IEnumerable<T> ResponseList { get; set; }
    }
}
