using GuestService0032.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestService0032.Data
{
    public class GuestDbContext0032 : DbContext
    {
        public GuestDbContext0032(DbContextOptions<GuestDbContext0032> options) : base(options)
        {
        }

        public DbSet<Guest0032> Guests { get; set; }
        public DbSet<GuestGroup0032> GuestGroups { get; set; }
    }
}
