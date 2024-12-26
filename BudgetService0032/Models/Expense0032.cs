namespace BudgetService0032.Models
{
    public class Expense0032
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string VendorId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string ReceiptUrl { get; set; }
        public string Status { get; set; } // Pending, Paid, Refunded
        public DateTime CreatedAt { get; set; }
    }
}
