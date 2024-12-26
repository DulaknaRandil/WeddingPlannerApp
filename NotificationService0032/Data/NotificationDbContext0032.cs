using Microsoft.EntityFrameworkCore;
using NotificationService0032.Models;

namespace NotificationService0032.Data
{
    public class NotificationDbContext0032 : DbContext
    {
        public NotificationDbContext0032(DbContextOptions<NotificationDbContext0032> options) : base(options) { }

        public DbSet<Notification0032> Notifications { get; set; }
        public DbSet<NotificationPreference0032> NotificationPreferences { get; set; }
    }
}
