
var common = {};

common.errorInfoDialog = function () {
    $("#errorInfoDialog").dialog({ buttons: { "Ok": function () { $(this).dialog("close"); } }, height: 530, width: 530 });
}


function searchUrl(element, matchingUrl) {
    if (element.url == matchingUrl) {
        return element;
    } else if (element.children != null) {
        var result = null;
        for (i = 0; result == null && i < element.children.length; i++) {
            result = searchUrl(element.children[i], matchingUrl);
        }
        return result;
    }
    return null;
}
