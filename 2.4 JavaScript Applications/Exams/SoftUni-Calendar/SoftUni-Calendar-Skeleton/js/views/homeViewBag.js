var app = app || {};

app.homeViewBag = (function () {
    function showLoginMenu(selector) {
        $.get('templates/menu-login.html', function(templ) {
            $(selector).html(templ);
        });
    }

    function showWelcomePage(selector) {
        $.get('templates/welcome-guest.html', function(templ) {
            $(selector).html(templ);
        })
    }

    function showHomeMenu(selector) {
        $.get('templates/menu-home.html', function(templ) {
            $(selector).html(templ);
        });
    }

    function showHomePage(selector, data) {
        $.get('templates/welcome-user.html', function(templ) {
            var renderedData = Mustache.render(templ, data);
            $(selector).html(renderedData);
        })
    }

    return {
        load: function () {
            return {
                showLoginMenu: showLoginMenu,
                showWelcomePage: showWelcomePage,
                showHomeMenu: showHomeMenu,
                showHomePage: showHomePage
            }
        }
    }
}());