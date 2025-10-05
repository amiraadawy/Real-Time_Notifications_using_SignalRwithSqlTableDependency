using Microsoft.AspNetCore.SignalR;
using Real_Time_Notifications_using_SignalR.Hubs;
using Real_Time_Notifications_using_SignalR.IServices;
using Real_Time_Notifications_using_SignalR.Models;

namespace Real_Time_Notifications_using_SignalR.Services
{
    public class NotificationServices:INotificationServices
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationServices(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendNotificationToAll(NotificationDto notificationDto)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", notificationDto.Message);
        }
    }
}
