using VendorService0032.Data;
using VendorService0032.Models;
using VendorService0032.Service.IService;

namespace VendorService0032.Service
{
    public class Vendor0032Service : IVendor0032Service
    {
        private readonly Vendor0032DbContext _context;

        public Vendor0032Service(Vendor0032DbContext context)
        {
            _context = context;
        }

        public Vendor0032 AddVendor(Vendor0032 vendor)
        {
            vendor.CreatedAt = DateTime.UtcNow;
            vendor.UpdatedAt = DateTime.UtcNow;
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
            return vendor;
        }

        public Vendor0032 GetVendorById(string id)
        {
            return _context.Vendors.FirstOrDefault(v => v.Id == id);
        }

        public List<Vendor0032> GetAllVendors()
        {
            return _context.Vendors.ToList();
        }

        public Vendor0032 UpdateVendor(string id, Vendor0032 updatedVendor)
        {
            var vendor = _context.Vendors.FirstOrDefault(v => v.Id == id);
            if (vendor == null) return null;

            vendor.CompanyName = updatedVendor.CompanyName;
            vendor.ContactPerson = updatedVendor.ContactPerson;
            vendor.Email = updatedVendor.Email;
            vendor.PhoneNumber = updatedVendor.PhoneNumber;
            vendor.ServiceType = updatedVendor.ServiceType;
            vendor.Status = updatedVendor.Status;
            vendor.QuotedPrice = updatedVendor.QuotedPrice;
            vendor.ContractStatus = updatedVendor.ContractStatus;
            vendor.ContractSignedDate = updatedVendor.ContractSignedDate;
            vendor.Notes = updatedVendor.Notes;
            vendor.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();
            return vendor;
        }

        public bool DeleteVendor(string id)
        {
            var vendor = _context.Vendors.FirstOrDefault(v => v.Id == id);
            if (vendor == null) return false;

            _context.Vendors.Remove(vendor);
            _context.SaveChanges();
            return true;
        }
    }
}
