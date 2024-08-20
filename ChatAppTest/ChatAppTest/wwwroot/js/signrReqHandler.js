var connection = new signalR.HubConnectionBuilder()
    .withUrl('/chatHub')
    .configureLogging(signalR.LogLevel.Debug)
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.start()
    .then(() => {
        console.log('SignalR connection established.');
    })
    .catch(err => {
        console.error('Error establishing SignalR connection:', err.toString());
    });

connection.onclose(async () => {
    console.log('SignalR connection closed. Reconnecting...');
    try {
        await connection.start();
        console.log('SignalR connection re-established.');
    } catch (err) {
        console.error('Error re-establishing SignalR connection:', err.toString());
    }
});

function sendMessage(user, message) {
    if (connection.state === signalR.HubConnectionState.Connected) {
        connection.invoke('SendMessage', user, message)
            .catch(err => {
                console.error('Error sending message:', err.toString());
            });
    } else {
        console.warn('SignalR connection is not established.');
    }
}

function sendMessageToHub(message) {
    connection.invoke('SendMessage', message)
        .catch(function (err) {
            return console.error(err.toString());
        });
}
