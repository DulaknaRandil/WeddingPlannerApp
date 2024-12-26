using VendorService0032.Models;

namespace VendorService0032.Service.IService
{
    public interface IVendorSchedule0032Service
    {
        VendorSchedule0032 AddVendorSchedule(VendorSchedule0032 schedule);
        VendorSchedule0032 GetVendorScheduleById(string id);
        List<VendorSchedule0032> GetSchedulesByEventId(string eventId);
        bool DeleteVendorSchedule(string id);
    }
}
