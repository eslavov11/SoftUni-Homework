var app = app || {};

app.homeController = (function() {
    function HomeController(viewBag) {
        this._viewBag = viewBag;
    }

    HomeController.prototype.loadLoginMenu = function(selector) {
        this._viewBag.loginMenu.load(selector);
    };

    HomeController.prototype.loadHomeMenu = function(selector) {
        this._viewBag.homeMenu.load(selector);
    };

    HomeController.prototype.welcomeScreen = function(selector) {
        this._viewBag.welcomeView.load(selector);
    };

    HomeController.prototype.homeScreen = function(selector) {
        var data = {
            username: sessionStorage['username']
        };

        this._viewBag.homeView.load(selector, data);
    };

    return {
        load: function(viewBag) {
            return new HomeController(viewBag)
        }
    }
}());