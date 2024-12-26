namespace BudgetService0032.Models
{
    public class BudgetCategory0032
    {
        public string Id { get; set; }
        public string BudgetId { get; set; }
        public string CategoryName { get; set; } // Venue, Catering, Flowers, etc.
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public List<Expense0032> Expenses { get; set; }
    }
}
