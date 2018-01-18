///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//

$("#btn-login").click(function() {
    var e = $("#username").val();
    var p = $("#password").val();
    if (e.length == 0) {
        $("#login-message").show().html(StarterKit.Strings.EnterYourEmail);
        $("#form-group-user").addClass("has-error");
        $("#username").focus();
    } else if (p.length == 0) {
        $("#login-message").show().html(StarterKit.Strings.EnterYourPassword);
        $("#form-group-password").addClass("has-error");
        $("#password").focus();
    } else {
        StarterKit.postForm("#login-form",
            function (data) {
                var response = JSON.parse(data);
                if (!response.Success) {
                    $("#login-message").show().html(response.Message);
                    $("#username").val("").focus();
                    $("#password").val("");
                } else {
                    window.location.href = response.RedirectUrl;
                }
            });
    }
    window.setTimeout(__clearLogin, 2500);
});

$("#btn-recover").click(function () {
    var e = $("#email").val();
    if (e.length == 0) {
        $("#recover-message").show().html(StarterKit.Strings.EnterYourEmail);
        $("#form-group-email").addClass("has-error");
        $("#email").focus();
        window.setTimeout(__clearRecover, 4000);
    } else {
        StarterKit.postForm("#recover-form",
            function (data) {
                var response = JSON.parse(data);
                if (!response.Success) {
                    $("#recover-message").show().html(response.Message);
                    $("#email").val("").focus();
                    window.setTimeout(__clearRecover, 4000);
                } else {
                    $("#recover-message")
                        .removeClass("alert-info")
                        .addClass("alert-success")
                        .html(response.Message)
                        .show();
                    window.setTimeout(__gotoLogin, 4000);
                }
            });
    }
    
});

function __clearLogin() {
    $("#form-group-user").removeClass("has-error");
    $("#form-group-password").removeClass("has-error");
    $("#login-message").html("");
}

function __clearRecover() {
    $("#form-group-user").removeClass("has-error");
    $("#recover-message").html("");
}

function __gotoLogin() {
    StarterKit.goto("/home/index");
}

