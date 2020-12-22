// Config
var editor = CodeMirror.fromTextArea(document.getElementById("code"), {
    mode: "text/x-csrc",
    lineNumbers: true,
    theme: "3024-day",
    lineWrapping: true,
    foldGutter: true,
    matchBrackets: true,
    autoCloseBrackets: true,
    indentUnit: 4,
    gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"],
});
$(function () {
    var heightwind = $(window).height();
    var heightbar1 = $("#navbar1").height();
    var heightbar2 = $("#navbar2").height();
    var height = heightwind*0.9 - heightbar1 - heightbar2 - 20;
    editor.setSize('100%', height.toString() + 'px');
});


// function
function changeLanguage() {
    var lan = document.getElementById("seLangauge");
    var index = lan.selectedIndex;
    editor.setOption('mode', lan[index].value);
}
function changeTheme() {
    var theme = document.getElementById("seTheme");
    var index = theme.selectedIndex;
    editor.setOption('theme', theme[index].value);
}

function postCode() {
    var poster = document.getElementById("poster").value;
    var lan = document.getElementById("seLangauge");
    var index1 = lan.selectedIndex;
    var language = lan[index1].text;
    var langaugemode = lan[index1].value;
    var the = document.getElementById("seTheme");
    var index2 = the.selectedIndex;
    var theme = the[index2].value;
    var code = editor.getValue();
    var date = new Date();
    var time = date.getFullYear().toString() + "-" + (date.getMonth()+1).toString() + "-" + date.getDate().toString() + " " + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    var jsonObj = {
        "id": 0,
        "poster": poster,
        "language": language,
        "languagemode": langaugemode,
        "theme": theme,
        "code": code,
        "time": time
    }
    var jsonStr = JSON.stringify(jsonObj);
    $.ajax({
        url: "/Pastebin/postCode",
        method: "post",
        dataType: "json",
        data: jsonStr,
        contentType: 'application/json',
        async: false,
        success: function (data) {
            var id = parseInt(data.id, 10);
            window.location.href = "/Pastebin/show/" + id;       
        },
        error: function () {
            console.log("error");
        }
    });
}