using System.ComponentModel.DataAnnotations;

namespace VendorService0032.Models
{
    public class Vendor0032
    {
        [Key] 
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string EventId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ServiceType { get; set; } // Catering, Photography, Flowers, etc.
        public string Status { get; set; } // Contacted, Booked, Confirmed, Cancelled
        public decimal QuotedPrice { get; set; }
        public string ContractStatus { get; set; }
        public DateTime? ContractSignedDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
