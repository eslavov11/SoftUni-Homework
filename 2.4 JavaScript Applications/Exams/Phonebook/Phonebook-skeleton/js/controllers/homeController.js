var app = app || {};

app.homeController = (function() {
    function HomeController(viewBag) {
        this._viewBag = viewBag;
    }

    HomeController.prototype.showWelcomePage = function(selector) {
        this._viewBag.showWelcomePage(selector);
    };

    HomeController.prototype.showHomePage = function(selector) {
        var data = {};
        data['username'] = sessionStorage['username'];
        data['fullName'] = sessionStorage['fullName'];

        this._viewBag.showHomePage(selector, data);
    };

    return {
        load: function (viewBag) {
            return new HomeController(viewBag);
        }
    }
}());