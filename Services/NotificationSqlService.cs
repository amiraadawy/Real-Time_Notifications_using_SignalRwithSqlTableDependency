using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Real_Time_Notifications_using_SignalR.Hubs;
using Real_Time_Notifications_using_SignalR.IServices;
using Real_Time_Notifications_using_SignalR.Models;
using System;
using TableDependency;

using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;


namespace Real_Time_Notifications_using_SignalR.Services
{
    public class NotificationSqlService
    {
       
        private SqlTableDependency<Notification> _dependency;
        private readonly NotificationHub _notificationHub;

        private readonly string _connectionString;

        public NotificationSqlService(IHubContext<NotificationHub> hubContext, IConfiguration configuration, NotificationHub notificationHub)
        {
          
            Console.WriteLine("✅ Using Connection String: " + _connectionString);

            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _notificationHub = notificationHub;
        }

        public void Start()
        {
            _dependency = new SqlTableDependency<Notification>(_connectionString, tableName: "Notifications");

            _dependency.OnChanged += async (sender, e) =>
            {
                // فقط عند إدخال Notification جديد
                if (e.ChangeType == ChangeType.Insert)
                {
                    var notification = e.Entity;
                    var notificationDto = new NotificationDto
                    {
                        Message = notification.Message
                    };
                   await _notificationHub.SendNotification(notificationDto.Message);
                  
                    Console.WriteLine($"🔔 New notification: {notification.Message}");
                }
            };

            _dependency.OnError += (sender, e) =>
            {
                Console.WriteLine($"❌ SQL Dependency Error: {e.Message}");
            };

            _dependency.Start();
            Console.WriteLine("✅ SQL Table Dependency started and listening for changes...");
        }

        public void Stop()
        {
            _dependency.Stop();
            Console.WriteLine("🛑 SQL Table Dependency stopped.");
        }
    }
}
