using BudgetService0032.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetService0032.Data
{
    public class BudgetDbContext0032 : DbContext
    {
        public BudgetDbContext0032(DbContextOptions<BudgetDbContext0032> options) : base(options) { }

        public DbSet<Budget0032> Budgets { get; set; }
        public DbSet<BudgetCategory0032> BudgetCategories { get; set; }
        public DbSet<Expense0032> Expenses { get; set; }
    }
}
