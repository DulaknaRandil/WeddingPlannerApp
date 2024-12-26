using Microsoft.EntityFrameworkCore;
using VendorService0032.Models;

namespace VendorService0032.Data
{
    public class Vendor0032DbContext : DbContext
    {
        public Vendor0032DbContext(DbContextOptions<Vendor0032DbContext> options) : base(options) { }

        public DbSet<Vendor0032> Vendors { get; set; }
        public DbSet<VendorSchedule0032> VendorSchedules { get; set; }
    }
}
