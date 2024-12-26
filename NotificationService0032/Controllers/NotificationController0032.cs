using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService0032.Models;
using NotificationService0032.Services.IService;

namespace NotificationService0032.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController0032 : ControllerBase
    {
        private readonly INotification0032Service _notificationService;

        public NotificationController0032(INotification0032Service notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public IActionResult CreateNotification(Notification0032 notification)
        {
            var created = _notificationService.CreateNotification(notification);
            return Ok(created);
        }

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            var notifications = _notificationService.GetAllNotifications();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(string id)
        {
            var notification = _notificationService.GetNotificationById(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }

        [HttpPut("mark-as-read/{id}")]
        public IActionResult MarkAsRead(string id)
        {
            var result = _notificationService.MarkAsRead(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
