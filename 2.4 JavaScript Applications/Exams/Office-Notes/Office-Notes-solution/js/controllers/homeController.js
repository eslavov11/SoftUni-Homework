var app = app || {};

app.homeController = (function() {
    function HomeController(views) {
        this.viewBag = views;
    }

    HomeController.prototype.showWelcomeScreen = function(selector) {
        this.viewBag.loadWelcomeView(selector);
    };

    HomeController.prototype.showHomeScreen = function(selector) {
        var data = {
            username: sessionStorage['username'],
            fullName: sessionStorage['fullName']
        };

        this.viewBag.loadHomeView(selector, data);
    };

    return {
        load: function(views) {
            return new HomeController(views);
        }
    }
}());