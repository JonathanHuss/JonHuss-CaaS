
function SendMessage() {
    var textBox = $("#message-box textarea");

    if (textBox.val() != "") {
       AddMessageText("Me", textBox.val());

        $.ajax({
            type: "GET",
            url: "/Home/SendMessage?messageText=" + textBox.val(),
            cache: false
        })
        .done(function (response) {
            AddMessageText("Bot", response);
        }).error(function (jqXHR, textStatus, errorThrown) {

        });

        textBox.val("");
    }

    textBox.focus();
}

function AddMessageText(userName, message) {

    var html =
        '<div class=\'messageRow\'>' +
            '<div class=\'message ' + userName.toLowerCase() + '\'>' +
                '<div class=\'message-content\'>' + message + '</div>' +
            '</div>'
        '</div>';
    
    $('#message-window').append(html);

    $("#message-window").animate({
        scrollTop: $("#message-window")[0].scrollHeight
    });
    }

function KeyUp(e) {
    if (e.keyCode === 13 || e.which === 13) {
        SendMessage();
    }
}

function StartConversation() {
    $.ajax({
        type: "GET",
        url: "/Home/StartConversation",
        cache: false
    })
        .done(function (response) {
            AddMessageText("Bot", response);
        }).error(function (jqXHR, textStatus, errorThrown) {

        });;
}

StartConversation();