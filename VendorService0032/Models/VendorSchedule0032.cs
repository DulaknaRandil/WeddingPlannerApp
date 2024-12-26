using System.ComponentModel.DataAnnotations;

namespace VendorService0032.Models
{
    public class VendorSchedule0032
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string VendorId { get; set; }
        public string EventId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Cancelled
        public string Notes { get; set; }
    }
}
