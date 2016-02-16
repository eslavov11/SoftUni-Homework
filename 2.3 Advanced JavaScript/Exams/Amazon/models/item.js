;var models = models || {};

(function(scope) {
    'use strict';

    function Item(title, description, price) {
        this.title = title;
        this.description = description;
        this.price = price;
        this._customerReviews = [];
    }

    Item.prototype.addCustomerReview = function(customerReview) {
        this._customerReviews.push(customerReview);
    };

    Item.prototype.getCustomerReview = function() {
        return this._customerReviews;
    };

    scope.getItem = function(title, description, price) {
        return new Item(title, description, price);
    };

    scope._Item = Item;
})(models);

