var app = app || {};

(function() {
    var appId= 'MeY0LrbmFEjgpueqKbSttTegrLKnTdWOJ8l3LaLk';
    var restAPI = 'zf74j1zF20E3IsiS1JOFJagExon5ByqLBCb4EXat';
    var baseUrl = 'https://api.parse.com/1/';

    var headers = app.headers.load(appId, restAPI);
    var requester = app.requester.load();

    var userModel = app.userModel.load(baseUrl, requester, headers);
    var userViewBag = app.userViews.load();
    var userController = app.userController.load(userModel, userViewBag);

    var homeViewBag = app.homeViews.load();
    var homeController = app.homeController.load(homeViewBag);

    var estateModel = app.estateModel.load(baseUrl, requester, headers);
    var estateViewBag = app.estateViews.load();
    var estateController = app.estateController.load(estateModel, estateViewBag);

    app.router = Sammy(function() {
        var selector = '#main';

        this.before(function() {
            var userId = sessionStorage['userId'];
            if(userId) {
                homeController.loadHomeMenu('#menu');
            } else {
                homeController.loadLoginMenu('#menu');
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
            homeController.welcomeScreen(selector);
        });

        this.get('#/home/', function() {
            homeController.homeScreen(selector);
        });

        this.get('#/login/', function() {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function() {
            userController.loadRegisterPage(selector);
        });

        this.get('#/estate/:action/', function() {
            switch (this.params['action']) {
                case 'list':
                    estateController.listEstates(selector);
                    break;
                case 'add':
                    estateController.showAddPage(selector);
                    break;
            }
        });

        this.get('#/logout/', function() {
            userController.logout();
        });

        this.bind('login', function(e, data) {
            userController.login(data.username, data.password);
        });

        this.bind('register', function(e, data) {
            userController.register(data.username, data.password);
        });

        this.bind('add' ,function(e, data) {
            var _this = this;
            estateController.addEstate(data)
                .then(function() {
                    noty({
                        theme: 'relax',
                        text: 'Successfully added estate!',
                        type:'success',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                    _this.redirect('#/home/');
                }, function(error) {
                    noty({
                        theme: 'relax',
                        text: error.responseText,
                        type:'error',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                });
        });

        this.bind('showEditEstate', function(e, data) {
           estateController.showEditPage(selector, data);
        });

        this.bind('editEstate', function(e, data) {
            var _this = this;
            estateController.editEstate(data)
                .then(function() {
                    _this.redirect('#/estate/list/');
                    noty({
                        theme: 'relax',
                        text: 'Successfully edited estate!',
                        type:'success',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                }, function(error) {
                    noty({
                        theme: 'relax',
                        text: error.responseText,
                        type:'error',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                });
        });

        this.bind('showDeleteEstate', function(e, data) {
            estateController.showDeletePage(selector, data);
        });

        this.bind('deleteEstate', function(e, data) {
            var _this = this;
            estateController.deleteEstate(data)
                .then(function() {
                    _this.redirect('#/estate/list/');
                    noty({
                        theme: 'relax',
                        text: 'Successfully deleted estate!',
                        type:'success',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                }, function(error) {
                    noty({
                        theme: 'relax',
                        text: error.responseText,
                        type:'error',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                });
        });

        this.bind('filter', function(e, data) {
            estateController.filterEstates(selector, data);
        })
    });

    app.router.run('#/');
}());