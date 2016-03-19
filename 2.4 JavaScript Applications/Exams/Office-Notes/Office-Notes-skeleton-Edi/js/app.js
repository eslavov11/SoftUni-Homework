var app = app || {};

(function() {
    var router = Sammy(function () {
        var selector = '#container';

        var requester = app.requester.load('kid_WJ9x0_2nJb', '93c6490e90c346db8b209a40c3ad283c', 'https://baas.kinvey.com/');

        var userViewBag = app.userViewBag.load();
        var homeViewBag = app.homeViewBag.load();
        var notesViewBag = app.notesViewBag.load();

        var userModel = app.userModel.load(requester);
        var notesModel = app.notesModel.load(requester);

        var userController = app.userController.load(userViewBag, userModel);
        var homeController = app.homeController.load(homeViewBag);
        var notesController = app.notesController.load(notesViewBag, notesModel);

        this.before({except:{path:'#\/(login\/|register\/)?'}}, function() {
            if(!sessionStorage['sessionId']) {
                this.redirect('#/');
                return false;
            }
        });

        this.before(function() {
            if (!window.navigator.onLine) {
                noty({
                    theme: 'relax',
                    text: 'It appears that your internet connection was lost. Please connect your internet provider.',
                    type:'error',
                    timeout: 4000,
                    closeWith: ['click']
                });

                return false;
            }

            if(!sessionStorage['sessionId']) {
                $('#menu').hide();
            } else {
                $('#welcomeMenu').text('Welcome, ' + sessionStorage['fullName']);
                $('#menu').show();
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

        this.get('#/office/', function() {
            notesController.loadOfficeNotes(selector);
        });

        this.get('#/myNotes/([-0-9]+)?', function() {
            var page = 1;

            if(this.params['splat'][0]){
                page = this.params['splat'][0];
            }

            console.log(page);

            notesController.loadMyNotes(selector);
        });

        this.get('#/addNote/', function() {
            notesController.loadAddNote(selector);
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

        this.bind('addNote', function(ev, data) {
            notesController.addNote(data);
        });

        this.bind('showEditNote', function(ev, data) {
            notesController.loadEditNote(selector, data);
        });

        this.bind('editNote', function(ev, data) {
            notesController.editNote(data);
        });

        this.bind('showDeleteNote', function(ev, data) {
            notesController.loadDeleteNote(selector, data);
        });

        this.bind('deleteNote', function(ev, data) {
            notesController.deleteNote(data._id);
        })
    });

    router.run('#/');
})();