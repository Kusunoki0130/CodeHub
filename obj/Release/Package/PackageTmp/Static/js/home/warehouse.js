
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

function deleteArticle(num) {
    $.ajax({
        url: "/Article/delete/" + num,
        method: "get",
        success: function (data) {
            alert("文章已删除");
            window.location.reload();
        }
    });
}

function logout() {
    $.ajax({
        url: "/Index/logout",
        method: "get",
        success: function (data) {
            window.location.href = "/Index/welcome";
        }
    });
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

function news(num) {
    window.location.href = "/Home/news/" + num;
}

function collect(str) {
    console.log(str);
    $.ajax({
        url: "/Article/collect?str=" + str,
        method: "get",
        success(data) {
            window.location.reload();
        }
    });
}