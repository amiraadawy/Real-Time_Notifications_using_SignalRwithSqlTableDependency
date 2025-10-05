# 🔔 Real-Time Notifications using SignalR + SQL Table Dependency

A real-time notification system built with **ASP.NET Core**, **SignalR**, and **SQL Table Dependency**.  
It listens to SQL Server table changes and instantly sends updates to all connected clients using SignalR.

---

## 🚀 Features
✅ Real-time communication between server & clients  
✅ SQL Table Dependency to detect table data changes  
✅ SignalR for broadcasting updates instantly  
✅ Toastify.js notifications for a clean UI  
✅ Lightweight and fast – no external message broker needed  

---

## 🧱 Architecture Flow
SQL Table Change → TableDependency → SignalR Hub → Clients (Browser)

yaml
Copy code

---

## 📁 Project Structure
Real-Time_Notifications_using_SignalRwithSqlTableDependency/
│
├── Controllers/
│ └── NotificationController.cs
│
├── Hubs/
│ └── NotificationHub.cs
│
├── Models/
│ └── Notification.cs
│
├── Services/
│ ├── NotificationService.cs
│ └── NotificationSqlService.cs
│
├── wwwroot/
│ ├── js/
│ │ └── notification.js
│ └── css/
│ └── site.css
│
├── appsettings.json
├── Program.cs
└── README.md

yaml
Copy code

---

## ⚙️ Setup Instructions

### 1️⃣ Clone the project
```bash
git clone https://github.com/amiraadawy/Real-Time_Notifications_using_SignalRwithSqlTableDependency.git
cd Real-Time_Notifications_using_SignalRwithSqlTableDependency
2️⃣ Configure SQL Connection
Edit your appsettings.json file:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=NotificationDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
3️⃣ Create Database & Table
Run these queries in SQL Server:

sql
Copy code
CREATE DATABASE NotificationDb;
GO

USE NotificationDb;
GO

CREATE TABLE Notifications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Message NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);
4️⃣ Run the App
bash
Copy code
dotnet run
Then open in your browser:

arduino
Copy code
https://localhost:7099
💻 Client (Front-end)
The notification.js script connects to the SignalR Hub and displays incoming notifications using Toastify.

javascript
Copy code
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7099/notificationHub")
    .build();

connection.on("ReceiveNotification", function (message) {
    Toastify({ text: message, duration: 4000, gravity: "top", position: "right" }).showToast();
});

connection.start().then(() => console.log("✅ Connected to SignalR Hub"));
🧠 How It Works
The backend uses TableDependency to monitor the Notifications table in SQL Server.

When a new record is inserted, TableDependency triggers an event.

The service pushes this change to all clients via SignalR.

The browser receives the notification and displays a toast message.

🧩 Technologies Used
ASP.NET Core 8.0

SignalR

TableDependency.SqlClient

SQL Server

Toastify.js (for front-end notifications)

