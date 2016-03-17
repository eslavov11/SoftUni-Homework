var app = app || {};

(function() {
    var router = Sammy(function () {
        var selector = '#wrapper';

        var requester = app.requester.config('kid_-yoPnnU5yb','38b074daf65047cc9270265d4315a788');

        var userViewBag = app.userViews.load();
       // var phoneViewBag = app.phoneViews.load();
        var homeViewBag = app.homeViews.load();

        var userModel = app.userModel.load(requester);
        //var phoneModel = app.phoneModel.load(requester);

        var userController = app.userController.load(userModel, userViewBag);
        //var phoneController = app.phoneController.load(phoneModel, phoneViewBag);
        var homeController = app.homeController.load(homeViewBag);

        this.before('#/[^login|register]', function () {
            if (!sessionStorage['sessionAuth']) {
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function() {
            homeController.showWelcomePage(selector);
        });

        this.get('#/home', function() {
            homeController.showHomePage(selector);
        });

        this.get('#/login', function() {
            userController.showLoginPage(selector);
        });

        this.get('#/logout', function() {
            userController.logout();
            this.redirect('#/');
        });

        this.get('#/register', function() {
            userController.showRegisterPage(selector);
        });

        this.get('#/edit-profile', function() {
            userController.showEditProfilePage(selector);
        });

        this.get('#/phones', function() {
           // phoneController.loadPhones(selector);
        });

        this.get('#/phones/add', function() {
           // phoneController.loadAddPhonePage(selector);
        });

        this.get('#/phones/edit', function() {
          //  phoneController.loadEditPhonePage(selector);
        });

        this.get('#/phones/delete', function() {
           // phoneController.loadDeletePhonePage(selector);
        });

        this.bind('redirectUrl', function(e, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(e, data) {
            userController.login(data);
        });

        this.bind('register', function(e, data) {
            userController.register(data);
        });

        this.bind('add-new-book', function(e, data) {
          //  booksController.addNewBook(data);
        });

        this.bind('show-add-author', function (e, data) {

        })

    });

    router.run('#/');
}());