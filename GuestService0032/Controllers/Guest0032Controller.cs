using GuestService0032.Models;
using GuestService0032.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestService0032.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Guest0032Controller : ControllerBase
    {
        private readonly IGuest0032Service _guestService;

        public Guest0032Controller(IGuest0032Service guestService)
        {
            _guestService = guestService;
        }

        // Guest Endpoints
        [HttpPost("AddGuest")]
        public IActionResult AddGuest([FromBody] Guest0032 newGuest)
        {
            var result = _guestService.AddGuest0032(newGuest);
            return CreatedAtAction(nameof(GetGuestById), new { id = result.Id }, result);
        }

        [HttpGet("GetGuestsByEvent/{eventId}")]
        public IActionResult GetGuestsByEvent(string eventId)
        {
            return Ok(_guestService.GetGuestsByEventId0032(eventId));
        }

        [HttpGet("GetGuestById/{id}")]
        public IActionResult GetGuestById(string id)
        {
            var result = _guestService.GetGuestById0032(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("UpdateGuest/{id}")]
        public IActionResult UpdateGuest(string id, [FromBody] Guest0032 updatedGuest)
        {
            var result = _guestService.UpdateGuest0032(id, updatedGuest);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("DeleteGuest/{id}")]
        public IActionResult DeleteGuest(string id)
        {
            var result = _guestService.DeleteGuest0032(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // Guest Group Endpoints
        [HttpPost("AddGuestGroup")]
        public IActionResult AddGuestGroup([FromBody] GuestGroup0032 newGroup)
        {
            var result = _guestService.AddGuestGroup0032(newGroup);
            return CreatedAtAction(nameof(GetGuestGroupById), new { id = result.Id }, result);
        }

        [HttpGet("GetGuestGroupsByEvent/{eventId}")]
        public IActionResult GetGuestGroupsByEvent(string eventId)
        {
            return Ok(_guestService.GetGuestGroupsByEventId0032(eventId));
        }

        [HttpGet("GetGuestGroupById/{id}")]
        public IActionResult GetGuestGroupById(string id)
        {
            var result = _guestService.GetGuestGroupById0032(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("UpdateGuestGroup/{id}")]
        public IActionResult UpdateGuestGroup(string id, [FromBody] List<string> guestIds)
        {
            var result = _guestService.UpdateGuestGroup0032(id, guestIds);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("DeleteGuestGroup/{id}")]
        public IActionResult DeleteGuestGroup(string id)
        {
            var result = _guestService.DeleteGuestGroup0032(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
