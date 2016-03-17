var app = app || {};

app.homeViews = (function () {
    function showWelcomePage(selector) {
        $.get('templates/welcome.html', function(templ) {
            $(selector).html(templ);
        })
    }

    function showHomePage(selector, data) {
        $.get('templates/home.html', function(templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
        })
    }


    return {
        load: function() {
            return {
                showWelcomePage: showWelcomePage,
                showHomePage: showHomePage
            }
        }
    }
}());