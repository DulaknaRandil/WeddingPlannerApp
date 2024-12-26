using GuestService0032.Models;

namespace GuestService0032.Service.IService
{
    public interface IGuest0032Service
    {
        // Guest operations
        Guest0032 AddGuest0032(Guest0032 newGuest);
        List<Guest0032> GetGuestsByEventId0032(string eventId);
        Guest0032 GetGuestById0032(string id);
        Guest0032 UpdateGuest0032(string id, Guest0032 updatedGuest);
        bool DeleteGuest0032(string id);

        // Guest Group operations
        GuestGroup0032 AddGuestGroup0032(GuestGroup0032 newGroup);
        GuestGroup0032 GetGuestGroupById0032(string id);
        List<GuestGroup0032> GetGuestGroupsByEventId0032(string eventId);
        bool UpdateGuestGroup0032(string id, List<string> guestIds);
        bool DeleteGuestGroup0032(string id);
    }
}
