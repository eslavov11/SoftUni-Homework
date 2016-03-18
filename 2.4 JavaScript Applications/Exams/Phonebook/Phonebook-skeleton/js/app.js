var app = app || {};

(function() {
    var router = Sammy(function () {
        var selector = '#wrapper';

        var requester = app.requester.config('kid_-yoPnnU5yb','38b074daf65047cc9270265d4315a788');
        var notyMessages = app.notyMessages.load();

        var userViewBag = app.userViews.load();
        var phoneViewBag = app.phoneViews.load();
        var homeViewBag = app.homeViews.load();

        var userModel = app.userModel.load(requester);
        var phoneModel = app.phoneModel.load(requester);

        var userController = app.userController.load(userModel, userViewBag, notyMessages);
        var phoneController = app.phoneController.load(phoneModel, phoneViewBag, notyMessages);
        var homeController = app.homeController.load(null, homeViewBag, notyMessages);

        this.before({except:{path:'#\/(login\/|register\/)?'}}, function () {
            if (!sessionStorage['sessionAuth']) {
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function() {
            homeController.showWelcomePage(selector);
        });

        this.get('#/home/', function() {
            homeController.showHomePage(selector);
        });

        this.get('#/login/', function() {
            userController.showLoginPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/register/', function() {
            userController.showRegisterPage(selector);
        });

        this.get('#/edit-profile/', function() {
            userController.showEditProfilePage(selector);
        });

        this.get('#/phones/', function() {
            phoneController.loadPhones(selector);
        });

        this.get('#/phones/add/', function() {
            phoneController.loadAddPhone(selector);
        });

        this.get('#/phones/edit/', function() {
            phoneController.loadEditPhone(selector);
        });

        this.get('#/phones/delete/', function() {
            phoneController.loadDeletePhone(selector);
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

        this.bind('edit-profile', function(e, data) {
            userController.editProfile(data);
        });

        this.bind('show-add-phone', function(e, data) {
            phoneController.loadAddPhone(selector, data);
        });

        this.bind('show-edit-phone', function(e, data) {
            phoneController.loadEditPhone(selector, data);
        });

        this.bind('show-delete-phone', function(e, data) {
            phoneController.loadDeletePhone(selector, data);
        });

        this.bind('add-phone', function(e, data) {
            phoneController.addPhone(data);
        });

        this.bind('edit-phone', function(e, data) {
            phoneController.editPhone(data);
        });

        this.bind('delete-phone', function(e, data) {
            phoneController.deletePhone(data);
        });
    });

    router.run('#/');
}());