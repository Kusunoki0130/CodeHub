
// function
function load() {
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

function addfollow(fanId, followerId, num) {
    var str = "";
    if (num == 0) {
        str = "" + fanId + "a" + followerId;
    }
    else {
        str = "" + fanId + "b" + followerId;
    }
    console.log(str);
    $.ajax({
        url: "/Home/follow?str=" + str,
        method: "get",
        success(data) {
            window.location.reload();
        }
    });
}