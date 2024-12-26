using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendorService0032.Models;
using VendorService0032.Service.IService;

namespace VendorService0032.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorScheduleController0032 : ControllerBase
    {
        private readonly IVendorSchedule0032Service _scheduleService;

        public VendorScheduleController0032(IVendorSchedule0032Service scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("AddSchedule")]
        public IActionResult AddSchedule([FromBody] VendorSchedule0032 schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newSchedule = _scheduleService.AddVendorSchedule(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = newSchedule.Id }, newSchedule);
        }

        [HttpGet("GetScheduleById/{id}")]
        public IActionResult GetScheduleById(string id)
        {
            var schedule = _scheduleService.GetVendorScheduleById(id);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet("GetSchedulesByEventId/{eventId}")]
        public IActionResult GetSchedulesByEventId(string eventId)
        {
            return Ok(_scheduleService.GetSchedulesByEventId(eventId));
        }

        [HttpDelete("DeleteSchedule/{id}")]
        public IActionResult DeleteSchedule(string id)
        {
            var result = _scheduleService.DeleteVendorSchedule(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
