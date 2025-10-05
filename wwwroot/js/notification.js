// Build connection
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7099/notificationHub")
    .build();

// Function: show toast
function showToast(message) {
    Toastify({
        text: message,
        duration: 4000,
        gravity: "top",
        position: "right",
        backgroundColor: "linear-gradient(to right, #00b09b, #96c93d)",
        stopOnFocus: true,
        close: true,
    }).showToast();
}

// Function: add notification to UL
function addNotification(message) {
    const li = document.createElement("li");
    li.textContent = message;
    document.getElementById("notificationsList").prepend(li);
}

// When notification arrives
connection.on("ReceiveNotification", function (message) {
    showToast(message);
    addNotification(message);
});

// Start connection
connection.start()
    .then(() => console.log("✅ Connected to SignalR Hub"))
    .catch(err => console.error("❌ Connection Error:", err));
