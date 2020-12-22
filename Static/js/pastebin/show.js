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
    readOnly: true,
    gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"],
});
$(function () {
    var heightwind = $(window).height();
    var heightbar1 = $("#navbar1").height();
    var heightbar2 = $("#navbar2").height();
    console.log(heightwind);
    console.log(heightbar1);
    console.log(heightbar2);
    var height = heightwind*0.95 - heightbar1 - heightbar2 - 20;
    console.log(height);
    editor.setSize('100%', '100%');
});

// Function
function load() {
    var languagemode = document.getElementById("langaugemode").innerText;
    var theme = document.getElementById("theme").innerText;
    var codeshow = document.getElementById("codeshow").innerText;
    editor.setOption('mode', languagemode);
    editor.setOption('theme', theme);
    editor.setValue(codeshow);
}