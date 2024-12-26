namespace TaskService0032.Models
{
    public class Task0032
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public string Status { get; set; } // Pending, InProgress, Completed, Overdue
        public string AssignedTo { get; set; }
        public string Category { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
