namespace BudgetService0032.Models
{
    public class Budget0032
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal RemainingBudget { get; set; }
        public decimal TotalSpent { get; set; }
        public List<BudgetCategory0032> Categories { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
