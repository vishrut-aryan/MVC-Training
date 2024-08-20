class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}

const username = userName;
const textInput = document.getElementById('messageText');
const chat = document.getElementById('chat');
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', (event) => {
    event.preventDefault(); // Prevent default form submission

    const text = textInput.value;
    if (text.trim() === "") return;

    $.ajax({
        type: "POST",
        url: '/Home/Create',
        data: { Text: text },
        success: function (response) {
            if (response.success) {
                debugger;
                clearInputField();
                sendMessage();
            } else {
                alert('Failed to send message');
            }
        },
        error: function () {
            alert('Error occurred while sending message');
        }
    });
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let when = new Date();
    let message = new Message(username, text, when);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    alert("You activated addMessageToChat");
    let isCurrentUserMessage = message.userName === username;

    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = message.userName;

    let text = document.createElement('p');
    text.innerHTML = message.text;

    let when = document.createElement('span');
    when.className = isCurrentUserMessage ? "time-right" : "time-left";

    when.innerHTML = new Date(message.when).toLocaleString('en-US', {
        hour: 'numeric', minute: 'numeric', second: 'numeric', month: 'numeric', day: 'numeric', year: 'numeric'
    });

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);
}