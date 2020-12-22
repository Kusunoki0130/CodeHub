
// Config
var editor = CodeMirror.fromTextArea(document.getElementById("code"), {
        mode: "text/x-csrc",
        lineNumbers: true,
        theme: "3024-day",
        lineWrapping: true,
        foldGutter: true,
        matchBrackets: true,
        autoCloseBrackets: true,
        gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"],
});
$(function () {
    var heightwind = $(window).height();
    var heightbar1 = $("#navbar1").height();
    var heightbar2 = $("#navbar2").height();
    var height = heightwind - heightbar1 - heightbar2 - 20;
    editor.setSize('100%', height.toString() + 'px');

    testEditor = editormd("description-editormd", {
        width: "100%",
        height: height,
        syncScrolling: "single",
        path: "/Static/editormd/lib/"
    });

    testEditor = editormd("abstract-editormd", {
        width: "100%",
        height: height,
        syncScrolling: "single",
        path: "/Static/editormd/lib/"
    });
});

// function
function load() {
    document.getElementById("barCode").className = "active";
    document.getElementById("barMd").className = "";
    document.getElementById("barAb").className = "";
    document.getElementById("codeArea").style.display = "inline";
    document.getElementById("description").style.display = "none";
    document.getElementById("abstract").style.display = "none";
    var ifexist = parseInt(document.getElementById("ifexist").innerHTML, 10);
    if (ifexist == 0) {
        return;
    }
    document.getElementById("title").value = document.getElementById("articleTitle").innerText;
    editor.setValue(document.getElementById("articleCode").innerText);
    var converter = new showdown.Converter();
    document.getElementById("abstrac").value = converter.makeMarkdown(document.getElementById("articleAbstract").innerHTML);
    document.getElementById("md").value = converter.makeMarkdown(document.getElementById("articleMd").innerHTML);

    var isPublish = parseInt(document.getElementById("articleIsPublish").innerText, 10);
    var isPersonal = parseInt(document.getElementById("articleIsPersonal").innerText, 10);
    if (isPublish == 1) {
        document.getElementById("publish").checked = true;
    }
    if (isPersonal == 1) {
        document.getElementById("personal").checked = true;
    }

    var lan = document.getElementById("seLangauge");
    for (var i = 0; i < lan.options.length; ++i) {
        if (lan[i].value === document.getElementById("articleLangaugemode").innerText) {
            lan.selectedIndex = i;
            editor.setOption('mode', document.getElementById("articleLangaugemode").innerText);
            break;
        }
    }
    var the = document.getElementById("seTheme");
    for (var i = 0; i < the.options.length; ++i) {
        if (the[i].innerText === document.getElementById("articleTheme").innerText) {
            the.selectedIndex = i;
            editor.setOption('theme', the[i].innerText);
            break;
        }
    }
}

function setVisable(num) {
    if (num == 0) {
        document.getElementById("barCode").className = "active";
        document.getElementById("barMd").className = "";
        document.getElementById("barAb").className = "";
        document.getElementById("codeArea").style.display = "inline";
        document.getElementById("description").style.display = "none";
        document.getElementById("abstract").style.display = "none";
    }
    else if (num == 1) {
        document.getElementById("barCode").className = "";
        document.getElementById("barMd").className = "active";
        document.getElementById("barAb").className = "";
        document.getElementById("codeArea").style.display = "none";
        document.getElementById("description").style.display = "inline";
        document.getElementById("abstract").style.display = "none";
    }
    else {
        document.getElementById("barCode").className = "";
        document.getElementById("barMd").className = "";
        document.getElementById("barAb").className = "active";
        document.getElementById("codeArea").style.display = "none";
        document.getElementById("description").style.display = "none";
        document.getElementById("abstract").style.display = "inline";
    }
}
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
function save() {
    var title = document.getElementById("title").value;
    var lan = document.getElementById("seLangauge");
    var lanindex = lan.selectedIndex;
    var language = lan[lanindex].text;
    var languagemode = lan[lanindex].value;
    var the = document.getElementById("seTheme");
    var theindex = the.selectedIndex;
    var theme = the[theindex].value;
    var isPublish = document.getElementById("publish").checked ? 1 : 0;
    var isPersonal = document.getElementById("personal").checked ? 1 : 0;
    var code = editor.getValue();
    var converter = new showdown.Converter();
    var md = converter.makeHtml(document.getElementById("md").value);
    var abstract = converter.makeHtml(document.getElementById("abstrac").value);
    var date = new Date();
    var time = date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + " " + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    var userId = parseInt(document.getElementById("userId").innerHTML, 10);
    var ifexist = parseInt(document.getElementById("ifexist").innerText, 10);
    console.log(ifexist);
    if (ifexist === 0) {
        console.log(1);
        var jsonObj = {
            "id": 0,
            "title": title,
            "userId": userId,
            "abstrac": abstract,
            "code": code,
            "md": md,
            "language": language,
            "languagemode": languagemode,
            "theme": theme,
            "isPublish": isPublish,
            "isPersonal": isPersonal,
            "isHidden": 0,
            "like": 0,
            "collect": 0,
            "time": time
        }
        var jsonStr = JSON.stringify(jsonObj);
        $.ajax({
            url: "/Article/saveArticle",
            method: "post",
            dataType: "json",
            data: jsonStr,
            contentType: 'application/json',
            async: true,
            success: function (data) {
                alert(data.result);
                window.location.href = "/Article/editor/" + data.id;
            }
        });
    }
    else {
        console.log(2);
        var jsonObj = {
            "id": ifexist,
            "title": title,
            "userId": userId,
            "abstrac": abstract,
            "code": code,
            "md": md,
            "language": language,
            "languagemode": languagemode,
            "theme": theme,
            "isPublish": isPublish,
            "isPersonal": isPersonal,
            "isHidden": 0,
            "like": 0,
            "collect": 0,
            "time": time
        }
        var jsonStr = JSON.stringify(jsonObj);
        $.ajax({
            url: "/Article/saveArticle",
            method: "post",
            dataType: "json",
            data: jsonStr,
            contentType: 'application/json',
            async: true,
            success: function (data) {
                alert(data.result); 
            }
        });
    }
}