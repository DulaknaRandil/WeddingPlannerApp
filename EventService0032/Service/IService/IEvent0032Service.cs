using EventService0032.Models;

namespace EventService0032.Service.IService
{
    public interface IEvent0032Service
    {
        Event0032 CreateEvent0032(Event0032 newEvent);
        List<Event0032> GetAllEvents0032();
        Event0032 GetEventById0032(string id);
        Event0032 UpdateEvent0032(string id, Event0032 updatedEvent);
        bool DeleteEvent0032(string id);
    }
}
