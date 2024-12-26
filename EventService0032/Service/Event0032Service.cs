using EventService0032.Models;
using EventService0032.Service.IService;
using EventService0032.Data;
using System.Collections.Generic;
using System.Linq;

namespace EventService0032.Service
{
    public class Event0032Service : IEvent0032Service
    {
        private readonly Event0032DbContext _dbContext;

        public Event0032Service(Event0032DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Event0032 CreateEvent0032(Event0032 newEvent)
        {
            newEvent.Id = Guid.NewGuid().ToString();
            newEvent.CreatedAt = DateTime.UtcNow;
            newEvent.UpdatedAt = DateTime.UtcNow;

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();

            return newEvent;
        }

        public List<Event0032> GetAllEvents0032()
        {
            return _dbContext.Events.ToList();
        }

        public Event0032 GetEventById0032(string id)
        {
            return _dbContext.Events.FirstOrDefault(e => e.Id == id);
        }

        public Event0032 UpdateEvent0032(string id, Event0032 updatedEvent)
        {
            var existingEvent = _dbContext.Events.FirstOrDefault(e => e.Id == id);
            if (existingEvent == null) return null;

            existingEvent.Title = updatedEvent.Title;
            existingEvent.EventDate = updatedEvent.EventDate;
            existingEvent.StartTime = updatedEvent.StartTime;
            existingEvent.EndTime = updatedEvent.EndTime;
            existingEvent.Venue = updatedEvent.Venue;
            existingEvent.VenueAddress = updatedEvent.VenueAddress;
            existingEvent.EventType = updatedEvent.EventType;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.Status = updatedEvent.Status;
            existingEvent.UpdatedAt = DateTime.UtcNow;

            _dbContext.SaveChanges();
            return existingEvent;
        }

        public bool DeleteEvent0032(string id)
        {
            var existingEvent = _dbContext.Events.FirstOrDefault(e => e.Id == id);
            if (existingEvent == null) return false;

            _dbContext.Events.Remove(existingEvent);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
