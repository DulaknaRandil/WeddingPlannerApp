using GuestService0032.Data;
using GuestService0032.Models;
using GuestService0032.Service.IService;

namespace GuestService0032.Service
{
    public class Guest0032Service : IGuest0032Service
    {
        private readonly GuestDbContext0032 _dbContext;

        public Guest0032Service(GuestDbContext0032 dbContext)
        {
            _dbContext = dbContext;
        }

        // Guest Operations
        public Guest0032 AddGuest0032(Guest0032 newGuest)
        {
            newGuest.Id = Guid.NewGuid().ToString();
            newGuest.CreatedAt = DateTime.UtcNow;
            newGuest.UpdatedAt = DateTime.UtcNow;
            _dbContext.Guests.Add(newGuest);
            _dbContext.SaveChanges();
            return newGuest;
        }

        public List<Guest0032> GetGuestsByEventId0032(string eventId)
        {
            return _dbContext.Guests.Where(g => g.EventId == eventId).ToList();
        }

        public Guest0032 GetGuestById0032(string id)
        {
            return _dbContext.Guests.FirstOrDefault(g => g.Id == id);
        }

        public Guest0032 UpdateGuest0032(string id, Guest0032 updatedGuest)
        {
            var existingGuest = _dbContext.Guests.FirstOrDefault(g => g.Id == id);
            if (existingGuest == null) return null;

            existingGuest.FirstName = updatedGuest.FirstName;
            existingGuest.LastName = updatedGuest.LastName;
            existingGuest.Email = updatedGuest.Email;
            existingGuest.PhoneNumber = updatedGuest.PhoneNumber;
            existingGuest.Address = updatedGuest.Address;
            existingGuest.NumberOfAccompanyingGuests = updatedGuest.NumberOfAccompanyingGuests;
            existingGuest.InvitationStatus = updatedGuest.InvitationStatus;
            existingGuest.RsvpStatus = updatedGuest.RsvpStatus;
            existingGuest.DietaryRestrictions = updatedGuest.DietaryRestrictions;
            existingGuest.GroupCategory = updatedGuest.GroupCategory;
            existingGuest.RsvpResponseDate = updatedGuest.RsvpResponseDate;
            existingGuest.UpdatedAt = DateTime.UtcNow;

            _dbContext.SaveChanges();
            return existingGuest;
        }

        public bool DeleteGuest0032(string id)
        {
            var existingGuest = _dbContext.Guests.FirstOrDefault(g => g.Id == id);
            if (existingGuest == null) return false;

            _dbContext.Guests.Remove(existingGuest);
            _dbContext.SaveChanges();
            return true;
        }

        // Guest Group Operations
        public GuestGroup0032 AddGuestGroup0032(GuestGroup0032 newGroup)
        {
            newGroup.Id = Guid.NewGuid().ToString();
            _dbContext.GuestGroups.Add(newGroup);
            _dbContext.SaveChanges();
            return newGroup;
        }

        public GuestGroup0032 GetGuestGroupById0032(string id)
        {
            return _dbContext.GuestGroups.FirstOrDefault(g => g.Id == id);
        }

        public List<GuestGroup0032> GetGuestGroupsByEventId0032(string eventId)
        {
            return _dbContext.GuestGroups.Where(g => g.EventId == eventId).ToList();
        }

        public bool UpdateGuestGroup0032(string id, List<string> guestIds)
        {
            var existingGroup = _dbContext.GuestGroups.FirstOrDefault(g => g.Id == id);
            if (existingGroup == null) return false;

            existingGroup.GuestIds = guestIds;
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteGuestGroup0032(string id)
        {
            var existingGroup = _dbContext.GuestGroups.FirstOrDefault(g => g.Id == id);
            if (existingGroup == null) return false;

            _dbContext.GuestGroups.Remove(existingGroup);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
