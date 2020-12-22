function postRegister() {
    var username = document.getElementById("username").value;
    var email = document.getElementById("email").value;
    var phone = document.getElementById("phone").value;
    var password = document.getElementById("password").value;
    if (username == null || username === "") {
        return;
    }
    if (email == null || email === "") {
        return;
    }
    if (phone == null || phone === "") {
        return;
    }
    if (password == null || password === "") {
        return;
    }
    var id = 0;
    var date = new Date();
    var regitserTime = date.getFullYear().toString() + "-" + (date.getMonth() + 1).toString() + "-" + date.getDate().toString() + " " + date.getHours().toString() + ":" + date.getMinutes().toString() + ":" + date.getSeconds().toString();
    var is_admin = 0;
    var follow = 0;
    var fans = 0;
    var like = 0;
    var collect = 0;
    var comment = 0;
    var jsonObj = {
        "id": 0,
        "name": username,
        "password": password,
        "phone": phone,
        "email": email,
        "registerTime": regitserTime,
        "isAdmin": 0,
        "follow": 0,
        "fans": 0,
        "like": 0,
        "collect": 0,
        "comment": 0
    }
    var jsonStr = JSON.stringify(jsonObj);
    $.ajax({
        url: "/Index/registerUser",
        method: "post",
        dataType: "json",
        data: jsonStr,
        contentType: 'application/json',
        async: false,
        success: function (data) {
            alert(data.result);
            window.location.href = "/Index/welcome";
        }
    });
}