;var models = models || {};

(function(scope) {
    'use strict';

    function CustomerReview(customer, content, rating, createdOn) {
        this.customer = customer;
        this.content = content;
        this.rating = rating;
        this.createdOn = createdOn;
    }

    CustomerReview.prototype.addItemToCart = function(item) {
        this._shoppingCart.addItemToCart(item);
    };

    scope.getCustomerReview = function(customer, content, rating, createdOn) {
        return new CustomerReview(customer, content, rating, createdOn);
    };
})(models);
