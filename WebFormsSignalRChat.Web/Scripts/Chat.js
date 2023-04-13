// Función para enviar un mensaje
function sendMessage(name, message) {
    // Declare a proxy to reference the hub.
    var chat = $.connection.chatHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        
        if (message) {
            alert(name + message);
        }
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        // Call the Send method on the hub with the passed name and message.
        chat.server.send(name, message);
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
//// Declare a proxy to reference the hub.
//var chat = $.connection.chatHub;

//// Create a function that the hub can call to broadcast messages.
//chat.client.broadcastMessage = function (name, message) {
//    // Html encode display name and message.
//    var encodedName = name;
//    var encodedMsg = message;
//    if (encodedMsg) {
//        alert(encodedMsg);
//    }
//};

//function sendMessage(name, message) {
//    // Start the connection.
//    $.connection.hub.start().done(function () {
//        // Call the Send method on the hub with the passed name and message.
//        chat.server.send(name, message);
//    });
//}
