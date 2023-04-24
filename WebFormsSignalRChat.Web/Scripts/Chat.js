// Function to send the message and start listening option A
//function sendMessage(name, message) {
//    // Declare a proxy to reference the hub.
//    var chat = $.connection.chatHub;

//    // Create a function that the hub can call to broadcast messages.
//    chat.client.broadcastMessage = function (name, message) {
//        // Html encode display name and message.
        
//        if (message) {
//            alert(name + message);
//        }
//    };
//    // Start the connection.
//    $.connection.hub.start().done(function () {
//        // Call the Send method on the hub with the passed name and message.
//        chat.server.send(name, message);
//    });
//}

//Start listening and after send the message option B
// Declare a proxy to reference the hub.
$.connection.hub.url = "http://207.244.253.16:8080/signalr";
var chat = $.connection.myHub;
// Start the connection as soon as the script is loaded.
$.connection.hub.start();
// Create a function that the hub can call to broadcast messages.
chat.client.addMessage = function (message) {
    // Html encode display name and message.    
    if (message) {
        alert(message);
    }
};

function sendMessage(name, message) {
    // Start the connection.
    $.connection.hub.start().done(function () {
        // Call the Send method on the hub with the passed name and message.
        chat.server.send(message);
    });
}
//function showAlertBox(title, message) {
//    var alertBox = document.getElementById("alertBox");
//    var alertBoxTitle = document.getElementById("alertBoxTitle");
//    var alertBoxMessage = document.getElementById("alertBoxMessage");
//    alertBoxTitle.innerHTML = title;
//    alertBoxMessage.innerHTML = message;
//    alertBox.style.display = "block";
//}

//function closeAlertBox() {
//    var alertBox = document.getElementById("alertBox");
//    alertBox.style.display = "none";
//}

