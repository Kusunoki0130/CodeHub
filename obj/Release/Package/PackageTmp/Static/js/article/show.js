
// Config

var editor = CodeMirror.fromTextArea(document.getElementById("code"), {
    mode: "text/x-csrc",
    lineNumbers: true,
    theme: "3024-day",
    lineWrapping: true,
    foldGutter: true,
    matchBrackets: true,
    autoCloseBrackets: true,
    readOnly: true,
    gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"],
});
$(function () {
    var heightwind = $(window).height();
    var widthwind = $(window).width();
    var heightbar1 = $("#narbar1").height();
    console.log(typeof heightbar1);
    console.log(heightbar1);
    var height = heightwind - heightbar1 - 20;
    var width = widthwind / 2;
    console.log(height);
    editor.setSize('100%', '100%');
});


// function

function load() {
    var converter = new showdown.Converter();
    var languagemode = document.getElementById("languagemode").innerText;
    var theme = document.getElementById("theme").innerText;
    var codeshow = document.getElementById("codeshow").innerText;
    console.log(codeshow);
    editor.setOption('mode', languagemode);
    editor.setOption('theme', theme);
    editor.setValue(codeshow);
    setVisable(0);
}

function setVisable(num) {
    var bar = document.getElementsByName("bar");
    var lists = document.getElementsByName("List");
    console.log(lists[num].style.display);
    for (var i = 0; i < bar.length; ++i) {
        bar[i].className = "";
        lists[i].style.display = "none";
    }
    bar[num].className = "active";
    lists[num].style.display = "inline";
    console.log(lists[num].style.display);
}

function like(articleId, userId) {
    var date = new Date();
    var time = date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + "a" + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    var str = "" + articleId + "a" + userId + "a" + time;
    $.ajax({
        url: "/Article/like?str=" + str,
        method: "get",
        success(data) {
            window.location.reload();
        }
    });
}

function collect(articleId, userId) {
    var date = new Date();
    var time = date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + "a" + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    var str = "" + articleId + "a" + userId + "a" + time;
    $.ajax({
        url: "/Article/collect?str=" + str,
        method: "get",
        success(data) {
            window.location.reload();
        }
    });
}

function comment() {
    var date = new Date();
    var time = date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + " " + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    var commentStr = document.getElementById("commentArea").value;
    var commentUserId = document.getElementById("comment_userId").innerText;
    var commentArticleid = document.getElementById("comment_articleId").innerText;
    var jsonObj = {
        "id": 0,
        "articleId": parseInt(commentArticleid, 10),
        "userId": parseInt(commentUserId, 10),
        "comment": commentStr,
        "time": time
    }
    var jsonStr = JSON.stringify(jsonObj);
    console.log(jsonStr);
    $.ajax({
        url: "/Article/commentPost",
        method: "post",
        dataType: "json",
        data: jsonStr,
        async: false,
        contentType: 'application/json',
        success: function (data) {
            alert(data.result);
            window.location.reload();
        }
    });
}

function reply(name) {
    document.getElementById("commentArea").innerText += "@" + name;
}

function deleteComment(id) {
    $.ajax({
        url: "/Article/commentDelete/" + id,
        method: "get",
        success: function (data) {
            alert("删除成功");
            window.location.reload();
        }
    });
}