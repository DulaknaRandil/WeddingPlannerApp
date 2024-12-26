using Microsoft.EntityFrameworkCore;
using TaskService0032.Models;

namespace TaskService0032.Data
{
    public class TaskDbContext0032 : DbContext
    {
        public TaskDbContext0032(DbContextOptions<TaskDbContext0032> options) : base(options) { }

        public DbSet<Task0032> Tasks { get; set; }
        public DbSet<TaskCheckList0032> TaskCheckLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task0032>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskCheckList0032>().HasKey(c => c.Id);
        }
    }
}
