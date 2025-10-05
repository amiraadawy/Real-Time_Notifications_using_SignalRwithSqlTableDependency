# 🔔 Real-Time Notifications using SignalR & SQL Table Dependency

This project demonstrates real-time notifications in **ASP.NET Core** using **SignalR** and **SQL Table Dependency**.  
Whenever data changes in the SQL database, notifications are instantly pushed to all connected clients.

---

## 🚀 Technologies

- ASP.NET Core 8.0  
- SignalR  
- SQL Server  
- TableDependency   
- JavaScript (client-side notifications)

---

## ⚙️ Features

- Real-time database change detection  
- SignalR hub for live updates  
- Toast-style client notifications  
- Dependency Injection & clean structure  

---

## 🧩 Architecture

SQL Table Change → TableDependency → SignalR Hub → Clients

yaml
Copy code

---

## 📂 Project Structure

Real-Time_Notifications_using_SignalR/
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
│ ├── NotificationSqlService.cs
│ └── NotificationService.cs
│
├── wwwroot/
│ ├── js/
│ │ └── notification.js
│ └── css/
│
├── appsettings.json
└── Program.cs

yaml
Copy code

---

## 🛠️ Setup

### 1️⃣ Clone the project
```bash
git clone https://github.com/amira-adawy/Real-Time_Notifications_using_SignalR.git
cd Real-Time_Notifications_using_SignalR
2️⃣ Configure SQL Connection
Edit appsettings.json:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=NotificationDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
3️⃣ Create Database & Table
sql
Copy code
CREATE DATABASE NotificationDb;
GO

USE NotificationDb;
GO

CREATE TABLE Notifications (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(100),
    Message NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);
4️⃣ Run the App
bash
Copy code
dotnet run
Then navigate to:
👉 https://localhost:7099

💬 API Endpoint
Method	Endpoint	Description
POST	/api/notification/send	Broadcasts a new notification

Example:

json
Copy code
{
  "Message": "A new order has been placed!"
}
