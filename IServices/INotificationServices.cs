using Real_Time_Notifications_using_SignalR.Models;

namespace Real_Time_Notifications_using_SignalR.IServices
{
    public interface INotificationServices
    {
        public Task SendNotificationToAll(NotificationDto notificationDto);
    }
}
