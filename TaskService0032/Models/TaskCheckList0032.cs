namespace TaskService0032.Models
{
    public class TaskCheckList0032
    {
        public string Id { get; set; }
        public string TaskId { get; set; }
        public string ItemDescription { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
