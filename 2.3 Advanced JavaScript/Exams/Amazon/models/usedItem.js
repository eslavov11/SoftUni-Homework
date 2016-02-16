;var models = models || {};

(function(scope) {
    'use strict';

    function UsedItem(title, description, price, condition) {
        scope._Item.call(this, title, description, price, condition);
        this.condition = condition;
    }

    UsedItem.extends(scope._Item);

    scope.getUsedItem = function(title, description, price, condition) {
        return new UsedItem(title, description, price, condition);
    }
})(models);