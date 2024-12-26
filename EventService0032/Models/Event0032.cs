namespace EventService0032.Models
{
    public class Event0032
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Venue { get; set; }
        public string VenueAddress { get; set; }
        public string EventType { get; set; } // Ceremony, Reception, Rehearsal, etc.
        public string Description { get; set; }
        public string Status { get; set; } // Planning, Confirmed, Completed, Cancelled
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
