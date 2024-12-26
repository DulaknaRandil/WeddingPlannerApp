using BudgetService0032.Data;
using BudgetService0032.Models;
using BudgetService0032.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace BudgetService0032.Services
{
    public class Budget0032Service : IBudgetService0032
    {
        private readonly BudgetDbContext0032 _context;

        public Budget0032Service(BudgetDbContext0032 context)
        {
            _context = context;
        }

        public Budget0032 CreateBudget(Budget0032 budget)
        {
            budget.Id = Guid.NewGuid().ToString();
            budget.CreatedAt = DateTime.UtcNow;
            budget.UpdatedAt = DateTime.UtcNow;
            _context.Budgets.Add(budget);
            _context.SaveChanges();
            return budget;
        }

        public Budget0032 GetBudget(string budgetId)
        {
            return _context.Budgets
                .Include(b => b.Categories)
                .ThenInclude(c => c.Expenses)
                .FirstOrDefault(b => b.Id == budgetId);
        }

        public Budget0032 UpdateBudget(string budgetId, Budget0032 updatedBudget)
        {
            var budget = _context.Budgets.FirstOrDefault(b => b.Id == budgetId);
            if (budget == null) return null;

            budget.TotalBudget = updatedBudget.TotalBudget;
            budget.RemainingBudget = updatedBudget.RemainingBudget;
            budget.TotalSpent = updatedBudget.TotalSpent;
            budget.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return budget;
        }

        public bool DeleteBudget(string budgetId)
        {
            var budget = _context.Budgets.FirstOrDefault(b => b.Id == budgetId);
            if (budget == null) return false;

            _context.Budgets.Remove(budget);
            _context.SaveChanges();
            return true;
        }

        public List<BudgetCategory0032> GetBudgetCategories(string budgetId)
        {
            var budget = _context.Budgets
                .Include(b => b.Categories)
                .FirstOrDefault(b => b.Id == budgetId);
            return budget?.Categories;
        }

        public Expense0032 AddExpense(string categoryId, Expense0032 expense)
        {
            var category = _context.BudgetCategories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) return null;

            expense.Id = Guid.NewGuid().ToString();
            expense.CreatedAt = DateTime.UtcNow;
            _context.Expenses.Add(expense);

            category.SpentAmount += expense.Amount;

            _context.SaveChanges();
            return expense;
        }
    }
}
