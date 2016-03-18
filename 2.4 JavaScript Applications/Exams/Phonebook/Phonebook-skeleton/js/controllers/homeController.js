var app = app || {};

app.homeController = (function() {
    function HomeController(model, viewBag, messages) {
        this._model = model;
        this._viewBag = viewBag;
        this._messages = messages;
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
        load: function (model, viewBag, messages) {
            return new HomeController(model, viewBag, messages);
        }
    }
}());