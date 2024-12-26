using VendorService0032.Models;

namespace VendorService0032.Service.IService
{
    public interface IVendor0032Service
    {
        Vendor0032 AddVendor(Vendor0032 vendor);
        Vendor0032 GetVendorById(string id);
        List<Vendor0032> GetAllVendors();
        Vendor0032 UpdateVendor(string id, Vendor0032 updatedVendor);
        bool DeleteVendor(string id);
    }
}
