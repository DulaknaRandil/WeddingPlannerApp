using VendorService0032.Data;
using VendorService0032.Models;
using VendorService0032.Service.IService;

namespace VendorService0032.Service
{
    public class VendorSchedule0032Service : IVendorSchedule0032Service
    {
        private readonly Vendor0032DbContext _context;

        public VendorSchedule0032Service(Vendor0032DbContext context)
        {
            _context = context;
        }

        public VendorSchedule0032 AddVendorSchedule(VendorSchedule0032 schedule)
        {
            _context.VendorSchedules.Add(schedule);
            _context.SaveChanges();
            return schedule;
        }

        public VendorSchedule0032 GetVendorScheduleById(string id)
        {
            return _context.VendorSchedules.FirstOrDefault(s => s.Id == id);
        }

        public List<VendorSchedule0032> GetSchedulesByEventId(string eventId)
        {
            return _context.VendorSchedules.Where(s => s.EventId == eventId).ToList();
        }

        public bool DeleteVendorSchedule(string id)
        {
            var schedule = _context.VendorSchedules.FirstOrDefault(s => s.Id == id);
            if (schedule == null) return false;

            _context.VendorSchedules.Remove(schedule);
            _context.SaveChanges();
            return true;
        }
    }
}
