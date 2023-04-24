//// Function to send the message and start listening option A
////function sendMessage(name, message) {
////    // Declare a proxy to reference the hub.
////    var chat = $.connection.chatHub;

////    // Create a function that the hub can call to broadcast messages.
////    chat.client.broadcastMessage = function (name, message) {
////        // Html encode display name and message.
        
////        if (message) {
////            alert(name + message);
////        }
////    };
////    // Start the connection.
////    $.connection.hub.start().done(function () {
////        // Call the Send method on the hub with the passed name and message.
////        chat.server.send(name, message);
////    });
////}

////Start listening and after send the message option B
//// Declare a proxy to reference the hub.
//var chat = $.connection.chatHub;
//// Start the connection as soon as the script is loaded.
//$.connection.hub.start();
//// Create a function that the hub can call to broadcast messages.
//chat.client.broadcastMessage = function (name, message) {
//    // Html encode display name and message.    
//    if (message) {
//        alert(name + message);
//    }
//};

//function sendMessage(name, message) {
//    // Start the connection.
//    $.connection.hub.start().done(function () {
//        // Call the Send method on the hub with the passed name and message.
//        chat.server.send(name, message);
//    });
//}
////function showAlertBox(title, message) {
////    var alertBox = document.getElementById("alertBox");
////    var alertBoxTitle = document.getElementById("alertBoxTitle");
////    var alertBoxMessage = document.getElementById("alertBoxMessage");
////    alertBoxTitle.innerHTML = title;
////    alertBoxMessage.innerHTML = message;
////    alertBox.style.display = "block";
////}

////function closeAlertBox() {
////    var alertBox = document.getElementById("alertBox");
////    alertBox.style.display = "none";
////}


"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7206/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (image, message) {
    //var li = document.createElement("li");
    //document.getElementById("messagesList").appendChild(li);
    //// We can assign user-supplied strings to an element's textContent because it
    //// is not interpreted as markup. If you're assigning in any other way, you 
    //// should be aware of possible script injection concerns.
    //li.textContent = `${user} says ${message}`;
    alert(image + message);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
function sendMessage(image, message) {
    // Start the connection.
    connection.invoke("SendMessage", image, message).catch(function (err) {
        return console.error(err.toString());
    });
}