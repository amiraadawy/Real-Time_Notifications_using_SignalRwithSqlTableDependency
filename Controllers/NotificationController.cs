using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Real_Time_Notifications_using_SignalR.Hubs;
using Real_Time_Notifications_using_SignalR.IServices;
using Real_Time_Notifications_using_SignalR.Models;

namespace Real_Time_Notifications_using_SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
       private readonly INotificationServices _notificationService;
        public NotificationController(INotificationServices notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody]  NotificationDto dto)
        {
            await _notificationService.SendNotificationToAll(dto);
            return Ok(new { Message = "Notification sent successfully." });
        }
    }
}
