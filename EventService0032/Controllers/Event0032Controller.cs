using EventService0032.Models;
using EventService0032.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventService0032.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventController0032 : ControllerBase
    {
        private readonly IEvent0032Service _eventService;

        public EventController0032(IEvent0032Service eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("CreateEvent0032")]
        public IActionResult CreateEvent0032([FromBody] Event0032 newEvent)
        {
            var createdEvent = _eventService.CreateEvent0032(newEvent);
            return CreatedAtAction(nameof(GetEventById0032), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpGet("GetAllEvents0032")]
        public IActionResult GetAllEvents0032()
        {
            var events = _eventService.GetAllEvents0032();
            return Ok(events);
        }

        [HttpGet("GetEventById0032/{id}")]
        public IActionResult GetEventById0032(string id)
        {
            var eventItem = _eventService.GetEventById0032(id);
            if (eventItem == null) return NotFound();
            return Ok(eventItem);
        }

        [HttpPut("UpdateEvent0032/{id}")]
        public IActionResult UpdateEvent0032(string id, [FromBody] Event0032 updatedEvent)
        {
            var eventItem = _eventService.UpdateEvent0032(id, updatedEvent);
            if (eventItem == null) return NotFound();
            return Ok(eventItem);
        }

        [HttpDelete("DeleteEvent0032/{id}")]
        public IActionResult DeleteEvent0032(string id)
        {
            var isDeleted = _eventService.DeleteEvent0032(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }
    }
}
