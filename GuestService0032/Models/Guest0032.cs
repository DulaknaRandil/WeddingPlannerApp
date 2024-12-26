using System.ComponentModel.DataAnnotations;

namespace GuestService0032.Models
{
    public class Guest0032
    {
        [Key] // Ensure this annotation is present if using Entity Framework
        public string Id { get; set; } = Guid.NewGuid().ToString(); // Auto-generate a new GUID
        public string EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int NumberOfAccompanyingGuests { get; set; }
        public string InvitationStatus { get; set; } // Sent, NotSent
        public string RsvpStatus { get; set; } // Pending, Accepted, Declined
        public string DietaryRestrictions { get; set; }
        public string GroupCategory { get; set; } // Family, Friends, Colleagues, etc.
        public DateTime? RsvpResponseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
