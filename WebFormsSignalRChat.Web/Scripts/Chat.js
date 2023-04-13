// Función para enviar un mensaje
function sendMessage(name, message) {
    // Declare a proxy to reference the hub.
    var chat = $.connection.chatHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        var encodedName = name;
        var encodedMsg = message;
        alert(encodedMsg);
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        // Call the Send method on the hub with the passed name and message.
        chat.server.send(name, message);
    });
}
