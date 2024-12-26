using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService0032.Models;
using NotificationService0032.Services.IService;

namespace NotificationService0032.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationPreferenceController0032 : ControllerBase
    {
        private readonly INotificationPreference0032Service _preferenceService;

        public NotificationPreferenceController0032(INotificationPreference0032Service preferenceService)
        {
            _preferenceService = preferenceService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetPreferences(string userId)
        {
            var preferences = _preferenceService.GetPreferencesByUserId(userId);
            if (preferences == null) return NotFound();
            return Ok(preferences);
        }

        [HttpPut]
        public IActionResult UpdatePreferences(NotificationPreference0032 preferences)
        {
            var updated = _preferenceService.UpdatePreferences(preferences);
            return Ok(updated);
        }
    }
}
