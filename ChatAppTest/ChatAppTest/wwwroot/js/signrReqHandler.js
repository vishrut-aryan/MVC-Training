var connection = new signalR.HubConnextionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.on('receiveMessage', addMessageToChat);
connection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message)
}