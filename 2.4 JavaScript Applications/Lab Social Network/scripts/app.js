var app = app || {};

(function () {
    app.router = Sammy(function () {
        var selector = '#container';

        var requester = app.requester.config('kid_W1uokZ28kZ', '0ec3f09f5ab14073a2604113d1468c89');

        var userViewBag = app.userViews.load();
        var postViewBag = app.postViews.load();
        var commentViewBag = app.commentViews.load();

        var userModel = app.userModel.load(requester);
        var postModel = app.postModel.load(requester);
        var commentModel = app.commentModel.load(requester);

        var userController = app.userController.load(userModel, userViewBag);
        var postController = app.postController.load(postModel, postViewBag);
        var commentController = app.commentController.load(commentModel, commentViewBag);

        this.get('#/', function () {
            this.redirect('#/login');

            // test na user
            //userModel.login({ username:'iva', password:'1234iva' })
            //    .then(function (data) {
            //        console.log(data);
            //    }).done(); // raboti !!!
        });

        this.get('#/login', function () {
            userController.showLoginPage(selector);
        });

        this.get('#/register', function () {
            userController.showRegisterPage(selector);
        });

        this.get('#/logout', function () {
            userController.logout();
        });

        this.get('#/posts', function () {
            postController.loadAllPosts(selector);
        });

        this.get('#/addNewPost', function () {
            postController.loadAddPostPage(selector);
        });

        this.get('#/comments', function () {
            commentController._model.getAllComments().then(function(successData) {
                console.log(successData);
            });
        });

        this.get('#/addNewComment', function () {
            commentController.loadAddCommentPage(selector);
        });

        this.bind('redirectUrl', function (e, data) {
            this.redirect(data.url);
        });

        this.bind('register', function (e, data) {        
            userController.register(data);
        });
    
        this.bind('login', function (e, data) {
            userController.login(data);
        });

        this.bind('add-new-post', function (e, data) {
            postController.addNewPost(data);
        });

        this.bind('add-new-comment', function (e, data) {
            commentController.addNewComment(data);
        });
    });
    
    app.router.run('#/');
})();