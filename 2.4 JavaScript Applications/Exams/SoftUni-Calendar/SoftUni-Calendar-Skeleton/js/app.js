var app = app || {};

(function() {
    var router = Sammy(function () {
        var selector = '#container',
            menu = '#menu';

        var constants = app.constants;

        var requester = app.requester.load(
            constants.APPLICATION_ID,
            constants.APPLICATION_SECRET,
            constants.BASE_URL);

        var userViewBag = app.userViewBag.load();
        var homeViewBag = app.homeViewBag.load();
        var lecturesViewBag = app.lecturesViewBag.load();

        var userModel = app.userModel.load(requester);
        var lecturesModel = app.lecturesModel.load(requester);

        var userController = app.userController.load(userViewBag, userModel, constants);
        var homeController = app.homeController.load(homeViewBag, null, constants);
        var lecturesController = app.lecturesController.load(lecturesViewBag, lecturesModel, constants);

        this.before(function() {
            if (!window.navigator.onLine) {
                app.notyErrorMessage(constants.NO_INTERNET_CONNECTION_MSG);
                return false;
            }

            if(!sessionStorage['sessionId']) {
                homeController.loadLoginMenu(menu);
            } else {
                homeController.loadHomeMenu(menu);
            }
        });

        this.before({except:{path:'#\/(login\/|register\/)?'}}, function() {
            if(!sessionStorage['sessionId']) {
                app.notyErrorMessage(constants.NOT_LOGGED_IN_MSG)
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function() {
            homeController.loadWelcomePage(selector);
        });

        this.get('#/home/', function() {
            homeController.loadHomePage(selector);
        });

        this.get('#/login/', function() {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function() {
            userController.loadRegisterPage(selector);
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.get('#/calendar/list/', function() {
            lecturesController.loadAllLectures(selector);
        });

        this.get('#/calendar/my/', function() {
            lecturesController.loadMyLectures(selector);
        });

        this.get('#/calendar/add/', function() {
            lecturesController.loadAddLecture(selector);
        });

        this.get('#/calendar/edit/:id', function() {
            var id = this.params['id'];

            lecturesController.loadEditLecture(selector, id);
        });

        this.get('#/calendar/delete/:id', function() {
            var id = this.params['id'];

            lecturesController.loadDeleteLecture(selector, id);
        });

        this.bind('redirectUrl', function(ev, data) {
            this.redirect(data.url);
        });

        this.bind('login', function(ev, data) {
            userController.login(data);
        });

        this.bind('register', function(ev, data) {
            userController.register(data);
        });

        this.bind('addLecture', function(ev, data) {
            lecturesController.addLecture(data);
        });

        this.bind('editLecture', function(ev, data) {
            lecturesController.editLecture(data);
        });

        this.bind('deleteLecture', function(ev, data) {
            lecturesController.deleteLecture(data._id);
        })
    });

    router.run('#/');
})();