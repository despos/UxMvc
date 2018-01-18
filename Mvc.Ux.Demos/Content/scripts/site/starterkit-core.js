///////////////////////////////////////////////////////////////////
//
// STARTER-KIT : demo app 
// Copyright (c) D.E. 2017
//
// Author: Dino Esposito
//


/// <summary>
/// Root object for any script function used throughout the application
/// </summary>
var StarterKit = StarterKit || {};
StarterKit.RootServer = "";        // Should be set to /vdir when deployed

/// <summary>
/// Localizable strings
/// </summary>
StarterKit.Strings = {
    "EnterYourEmail": "Enter your email address",
    "EnterYourPassword": "Enter your password",
    "InvalidEmail": "Not a valid email address",
};

/// <summary>
/// Return a root-based path
/// </summary>
StarterKit.fromServer = function (relativeUrl) {
    return StarterKit.RootServer + relativeUrl;
};

/// <summary>
/// Root object for any script function used throughout the application
/// </summary>
StarterKit.configureCommonElements = function () {
    // Any A element should blur itself after clicking
    $("a").click(function (e) {
        this.blur();
    });
    $(".alert").click(function (e) {
        $(this).hide();
    });

};

/// <summary>
/// Helper function to post the content of a HTML form
/// </summary>
StarterKit.postForm = function (formSelector, success, error) {
    var form = $(formSelector);
    $.ajax({
        cache: false,
        url: form.attr('action'),
        type: form.attr('method'),
        dataType: 'html',
        data: form.serialize(),
        success: success,
        error: error
    });
};

/// <summary>
/// Helper function to call a remote URL (GET)
/// </summary>
StarterKit.invoke = function (url, success, error) {
    $.ajax({
        cache: false,
        url: StarterKit.fromServer(url),
        success: success,
        error: error
    });
};

/// <summary>
/// Jump to the given ABSOLUTE URL (no transformation made on the URL)
/// </summary>
StarterKit.goto = function (url) {
    window.location = url;
}

/// <summary>
/// Jump to the given RELATIVE URL (modified with ROOTSERVER)
/// </summary>
StarterKit.gotoRelative = function (url) {
    window.location = StarterKit.fromServer(url);
}

/// <summary>
/// Helper function to call a remote URL (POST)
/// </summary>
StarterKit.post = function (url, data, success, error) {
    $.ajax({
        cache: false,
        url: StarterKit.fromServer(url),
        type: 'post',
        data: data,
        success: success,
        error: error
    });
};

/// <summary>
/// Display a timed alert message
/// </summary>
StarterKit.toast = function (selector, message, success) {
    var ms = 2500;

    $(selector).removeClass("alert-success alert-danger alert-info alert-warning");
    $(selector).html(message);
    $(selector).addClass(success ? "alert-success" : "alert-danger");
    $(selector).show();
    window.setTimeout(function() {
        $(selector).hide();
    }, ms);
}

/// <summary>
/// Validate an email address
/// </summary>
StarterKit.validateEmail = function (email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

/// <summary>
/// Supports hidden-mobile style
/// </summary>
StarterKit.mobilize = function () {
    try {
        var mobi = WURFL.is_mobile;
        if (mobi) {
            $(".hidden-mobile").hide();
        }
    } catch (e) {
    }
}


/// <summary>
/// Handles MultipleViewResult responses
/// </summary>
//Capua.processMultipleAjaxResponse = function (response) {
//    var chunkSeparator = "---|||---";
//    var tokens = response.split(chunkSeparator);
//    return tokens;
//};
