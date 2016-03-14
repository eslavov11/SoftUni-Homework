var app = app || {};

app.homeViews = (function() {
    function HomeViews() {
        this.welcomeView = {
            load : loadWelcome
        };
        this.homeView = {
            load : loadHome
        };
        this.loginMenu = {
            load : loadLoginMenu
        };
        this.homeMenu = {
            load : loadHomeMenu
        };
    }

    function loadWelcome (selector) {
        $.get('templates/welcome-guest.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        })
    }

    function loadHome (selector, data) {
        $.get('templates/welcome-user.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        })
    }

    function loadLoginMenu(selector) {
        $.get('templates/menu-login.html', function(template) {
            $(selector).html(template);
        })
    }

    function loadHomeMenu(selector) {
        $.get('templates/menu-home.html', function(template) {
            $(selector).html(template);
        })
    }

    return {
        load: function() {
            return new HomeViews();
        }
    }
}());