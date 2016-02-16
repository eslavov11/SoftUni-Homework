;var models = models || {};

(function(scope) {
    'use strict';

    function User(username, fullName, balance) {
        this.username = username;
        this.fullName = fullName;
        this._balance = balance;
        this._shoppingCart = scope.getShoppingCart();
    }

    User.prototype.addItemToCart = function(item) {
        this._shoppingCart.addItems(item);
    };

    scope.getUser = function(username, fullName, balance) {
        return new User(username, fullName, balance);
    };
})(models);
