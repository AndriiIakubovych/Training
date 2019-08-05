$(document).ready(function ()
{
    var chat = $.connection.chatHub;
    var filterId = null;
    var sortType = "По идентификатору", sortOrder = "По возрастанию";

    $(".login .user-name").keyup(function ()
    {
        var isEmpty = false;
        $(".login .user-name").each(function ()
        {
            if ($(this).val().length === 0)
                isEmpty = true;
        });
        if (isEmpty)
            $(".login .sign-in").attr("disabled", "disabled");
        else
            $(".login .sign-in").attr("disabled", false);
    });

    $(".main .chat .messages .message-input .user-message").keyup(function ()
    {
        var isEmpty = false;
        $(".main .chat .messages .message-input .user-message").each(function ()
        {
            if ($(this).val().length === 0)
                isEmpty = true;
        });
        if (isEmpty)
            $(".main .chat .messages .message-input .send").attr("disabled", "disabled");
        else
            $(".main .chat .messages .message-input .send").attr("disabled", false);
    });

    $.connection.hub.start().done(function ()
    {
        $(".login .sign-in").click(function ()
        {
            var userName = $(".login .user-name").val();
            if (userName.length > 0)
                chat.server.connect(userName);
        });

        $(".main .chat .messages .message-input .send").click(function ()
        {
            chat.server.send($("#userid").val(), $("#username").val(), $(".chat .messages .message-input .user-message").val());
            $(".chat .messages .message-input .user-message").val("");
            $(".chat .messages .message-input .send").attr("disabled", "disabled");
        });

        $(".main .chat .messages .all-users").click(function ()
        {
            filterId = null;
            chat.server.removeFilter(sortType, sortOrder);
        });

        $(".main .chat .messages .sort-type").change(function ()
        {
            sortType = this.value;
            chat.server.sort(sortType, sortOrder);
        });

        $(".main .chat .messages .sort-order").change(function ()
        {
            sortOrder = this.value;
            chat.server.sort(sortType, sortOrder);
        });
    });

    chat.client.onConnected = function (userId, userName, usersList, messagesList)
    {
        $(".login").hide();
        $("body").css("align-items", "flex-start");
        $(".main").show();
        $("h1").html("Добро пожаловать, " + userName + "!");
        $("#userid").val(userId);
        $("#username").val(userName);
        chat.client.showAllMessages(userId, messagesList);
        for (var i = 0; i < usersList.length; i++) 
            addUser(usersList[i].UserId, usersList[i].UserName);
        messagesCount = messagesList.length;
    };

    chat.client.onNewUserConnected = function (userId, userName)
    {
        addUser(userId, userName);
    };

    function addUser(userId, userName)
    {
        $(".main .chat .users ul").append("<li id='" + userId + "'><span class='user-info'><span class='user-name'>" + userName + "</span> <span class='user-id'>(#" + userId.slice(0, userId.indexOf("-")) + ")</span></span></li>");

        $(".main .chat .users ul li .user-info").click(function (e)
        {
            chat.server.filterByUserId(e.target.closest("li").getAttribute("id"));
        });
    }

    chat.client.addMessage = function (messageId, user, date, text)
    {
        var date = new Date(date);
        var day = date.getDate(), month = date.getMonth() + 1, year = date.getFullYear(), hour = date.getHours(), minute = date.getMinutes(), second = date.getSeconds();
        date = (day < 10 ? "0" + day : day) + "." + (month < 10 ? "0" + month : month) + "." + (year < 10 ? "0" + year : year) + " " + (hour < 10 ? "0" + hour : hour) + ":" + (minute < 10 ? "0" + minute : minute) + ":" + (second < 10 ? "0" + second : second);
        $(".main .chat .messages ul").append("<li id='" + messageId + "'><div><span class='user-info'><span class='user-name'>" + user.UserName + "</span> <span class='user-id'>(#" + user.UserId.slice(0, user.UserId.indexOf("-")) + ")</span></span></div><div class='user-date'>" + date + "</div><div class='user-message'>" + text + "</div></li>");

        $(".main .chat .messages ul li .user-info").click(function (e)
        {
            chat.server.filterByMessageId(e.target.closest("li").getAttribute("id"));
        });
    };

    chat.client.filterMessages = function (user)
    {
        filterId = user.UserId;
        $(".main .chat .messages h2").html("Сообщения пользователя " + user.UserName);
        $(".main .chat .messages .sort").hide();
        $(".main .chat .messages .all-users").show();
        $(".main .chat .messages ul").empty();
        for (var i = 0; i < user.MessagesList.length; i++)
            chat.client.addMessage(user.MessagesList[i].MessageId, user, user.MessagesList[i].Date, user.MessagesList[i].Text);
    };

    chat.client.showAllMessages = function (userId, messagesList)
    {
        if (filterId === null || userId === $("#userid").val())
        {
            $(".main .chat .messages h2").html("Сообщения всех пользователей");
            $(".main .chat .messages .sort").show();
            $(".main .chat .messages .all-users").hide();
            $(".main .chat .messages ul").empty();
            for (var i = 0; i < messagesList.length; i++)
                chat.client.addMessage(messagesList[i].MessageId, messagesList[i].User, messagesList[i].Date, messagesList[i].Text);
            chat.server.sort(sortType, sortOrder);
        }
    };

    chat.client.onUserDisconnected = function (userId)
    {
        $("#" + userId).remove();
    };
});