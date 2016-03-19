var app = app || {};

app.homeViewBag = (function () {
    function showWelcomePage(selector) {
        $.get('templates/welcome.html', function(templ) {
            $(selector).html(templ);
        })
    }

    function showHomePage(selector, data) {
        $.get('templates/home.html', function(templ) {
            var renderedData = Mustache.render(templ, data);
            $(selector).html(renderedData);
        })
    }

    return {
        load: function () {
            return {
                showWelcomePage: showWelcomePage,
                showHomePage: showHomePage
            }
        }
    }
}());