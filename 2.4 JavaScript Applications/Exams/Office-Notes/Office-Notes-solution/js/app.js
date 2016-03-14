var app = app || {};

(function() {
    var notesPerPage = 10;

    var headers = app.headers.load('8FUsEB1aku6Dg1AeMOFqZ6mVQlE5qIqrO91ceE3P', 'zvXvHY1O02F6UGTItd097JyuWFu7GVSJGXEkebZz');
    var requester = app.requester.load();

    var noteModel = app.noteModel.load('https://api.parse.com/1/',requester, headers);
    var userModel = app.userModel.load('https://api.parse.com/1/',requester, headers);

    var userViews = app.userViews.load();
    var notesViews = app.notesViews.load();
    var homeViews = app.homeViews.load();

    var homeController = app.homeController.load(homeViews);
    var userController = app.userController.load(userModel, userViews);
    var notesController = app.notesController.load(noteModel, notesViews, notesPerPage);


    app.router = Sammy(function () {
        var selector = '#container';

        this.before(function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                $('#menu').show();
                $('#welcomeMenu').text('Welcome, ' + sessionStorage['username']);
            } else {
                $('#menu').hide();
            }
        });

        this.before({except: {path:'#\/(register\/|login\/)?'}}, function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                noty({
                    theme: 'relax',
                    text: 'You should be logged in to do this action!',
                    type:'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function() {
            homeController.showWelcomeScreen(selector);
        });

        this.get('#/register/', function() {
            userController.showRegisterScreen(selector);
        });

        this.get('#/login/', function() {
            userController.showLoginScreen(selector);
        });

        this.get('#/logout/', function() {
            var _this = this;
            userController.logout()
                .then(function(data) {
                    _this.redirect('#/');
                }).done();
        });

        this.get('#/home/', function() {
            homeController.showHomeScreen(selector);
        });

        this.get('#/office/([-0-9]+)?', function () {
            var page = 1;

            if(this.params['splat'][0]){
                page = this.params['splat'][0];
            }

            notesController.showTodayNotes(selector, page);
        });

        this.get('#/myNotes/([-0-9]+)?', function () {
            var page = 1;

            if(this.params['splat'][0]){
                page = this.params['splat'][0];
            }

            notesController.showMyNotes(selector, page);
        });

        this.get('#/addNote/', function () {
            notesController.showAddNote(selector);
        });

        this.bind('login', function (e, data) {
            var _this = this;
            userController.login(data)
                .then(function() {
                    _this.redirect('#/home/');
                }).done();
        });

        this.bind('register', function (e, data) {
            var _this = this;
            userController.register(data.username, data.password, data.fullName)
                .then(function() {
                    _this.redirect('#/home/');
                }).done();
        });

        this.bind('addNote', function (e, data) {
            notesController.addNote(selector, data);
        });

        this.bind('showEditNote', function (e, data) {
            notesController.showEditNote(selector, data);
        });

        this.bind('editNote', function (e, data) {
            notesController.editNote(selector, data);
        });

        this.bind('showDeleteNote', function (e, data) {
            notesController.showDeleteNote(selector, data);
        });

        this.bind('deleteNote', function (e, data) {
            notesController.deleteNote(selector, data);
        });

        this.bind('changePath', function (e, data) {
            this.redirect(data);
        })
    });

    app.router.run('#/');
}());