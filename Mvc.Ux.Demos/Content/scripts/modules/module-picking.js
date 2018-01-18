///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M01 - Picking Items from a (Long) List
//
// Author: Dino Esposito
// Youbiquitous.net
//

function expand(code) {
    $("tr").removeClass("active");
    $("#tr_" + code).addClass("active");

    var url = "/country/details/" + code;
    $.getJSON(url).done(function (data) {
        $("#v_code").html(code);
        $("#v_name").html(data.CountryName);
        $("#v_capital").html(data.Capital);
        $("#v_continent").html(data.ContinentName);
        $("#v_population").html(data.Population);
        $("#v_area").html(data.AreaInSqKm);
        $("#v_languages").html(data.Languages);
        $("#v_currency").html(data.CurrencyCode);
        $("#drilldownViewer").collapse('show');
    });
}

function resetViewer() {
    $("#v_code").html("");
    $("#v_name").html("");
    $("#v_capital").html("");
    $("#v_population").html("");
    $("#v_currency").html("");
    $("#v_area").html("");
    $("#v_languages").html("");
    $("#v_continent").html("");
    $("#drilldownViewer").collapse('hide');
}