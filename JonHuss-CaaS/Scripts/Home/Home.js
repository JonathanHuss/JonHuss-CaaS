function OpenEmbedDialog(userId, conversationTemplateId) {
    if (!$("#embedDialog").hasClass('ui-dialog-content')) {
        $("#embedDialog").dialog({
            autoOpen: false,
            height: 400,
            width: 700,
            modal: true,
            closeOnEscape: false,
            draggable: false,
            position: { my: "center", at: "center", of: window },
            resizable: false,
            title: "Embed HTML"
        });
        //$(".ui-dialog-titlebar").hide();
    }
    //$("#loadingUsersGroupsDialog").dialog("close");

    $("input[name=style]").change(function() { SetEmbedText(userId, conversationTemplateId); });

    SetEmbedText(userId, conversationTemplateId);
    $("#embedDialog").dialog("open");
    $("#embedDialog").css("visibility", "visible");


}

function SetEmbedText(userId, conversationTemplateId) {
    var style = $("input[name=style]:checked").val();

    if (style == "SmallOverlay") {
        $("#embedText").text("<iframe src='https://jonhuss-caas-embed.azurewebsites.net/?userId=" + userId + "&conversationTemplateId=" + conversationTemplateId + "&style=" + style + "' height='300' width='300' style='position:fixed;bottom:0px;right:15%'></iframe>");
    }
    else {
        $("#embedText").text("<iframe src='https://jonhuss-caas-embed.azurewebsites.net/?userId=" + userId + "&conversationTemplateId=" + conversationTemplateId + "&style=" + style + "' height='800' width='400'></iframe>");
    }

}
