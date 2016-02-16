;var models = models || {};

(function(scope) {
    'use strict';

    function ShoppingCart() {
        this._items = [];
    }

    ShoppingCart.prototype.addItems = function(item) {
        this._items.push(item);
    };

    ShoppingCart.prototype.getTotalPrice = function() {
        var totalPrice = 0;
        this._items.forEach(function (item) {
            totalPrice += item.price;
        });

        return totalPrice;
    };

    scope.getShoppingCart = function() {
        return new ShoppingCart();
    };
})(models);
