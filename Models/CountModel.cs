namespace TaskManagementSystem.Models
{
    public class CountModel 
    {
        public int projectCount { get; set; }
        public int taskCount { get; set; }
        public int completeCount { get; set; }
        public int progressCount { get; set; }
        public int notstartCount { get; set; }
    }

    public class CountRes {

        public string code { get; set; }
        public string description { get; set; }

        public CountModel count { get;set; }


    }


}
