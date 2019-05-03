function getNotificationId() {
    var id = Math.floor(Math.random() * 9007199254740992);
    return id.toString();
}

function messageReceived(message) {
    if (message.data && message.data.message) {
        chrome.notifications.create(getNotificationId(),
            {
                title: 'Notification From Azure',
                iconUrl: 'icons/logo.png',
                type: 'basic',
                message: message.data.message
            }, function () { })

        chrome.storage.sync.get(['console'], function (result) {
            var log = result.console + "\n" + "New push: " + message.data.message;
            chrome.storage.sync.set({
                "console": log
            }, function () { });
        });
    }
}

chrome.gcm.onMessage.addListener(messageReceived);
