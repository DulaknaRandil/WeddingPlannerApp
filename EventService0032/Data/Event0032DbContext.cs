using EventService0032.Models;
using Microsoft.EntityFrameworkCore;

namespace EventService0032.Data
{
    public class Event0032DbContext : DbContext
    {
        public Event0032DbContext(DbContextOptions<Event0032DbContext> options) : base(options) { }

        public DbSet<Event0032> Events { get; set; }
    }
}
