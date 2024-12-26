using BudgetService0032.Models;

namespace BudgetService0032.Services.IService
{
    public interface IBudgetService0032
    {
        Budget0032 CreateBudget(Budget0032 budget);
        Budget0032 GetBudget(string budgetId);
        Budget0032 UpdateBudget(string budgetId, Budget0032 updatedBudget);
        bool DeleteBudget(string budgetId);
        List<BudgetCategory0032> GetBudgetCategories(string budgetId);
        Expense0032 AddExpense(string categoryId, Expense0032 expense);
    }
}
