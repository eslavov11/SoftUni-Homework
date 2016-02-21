var models = models || {};

(function(scope) {
    "use strict";

    function Item(content) {
        this._id = Item.idCounter++;
        this._content = content;
        this._isChecked = false;
    }

    Item.idCounter = 1;

    Item.prototype.toggleStatus = function() {
        this._isChecked = !this._isChecked;
    }

    Item.prototype.addToDOM = function(containerId) {
        var wrap = document.createElement('div'),
            checkbox = document.createElement('input'),
            label = document.createElement('label'),
            _this = this;

        checkbox.setAttribute('type', 'checkbox');
        checkbox.id = 'completed' + this._id;
        label.setAttribute('for', checkbox.id);
        label.innerHTML = this._content;

        wrap.appendChild(checkbox);
        wrap.appendChild(label);
        wrap.style = 'margin-left: 10px;';

        checkbox.addEventListener('click', function () {
            _this.toggleStatus();

            if (_this._isChecked) {
                label.style.background = 'lightgreen';
            } else {
                label.style.background = 'none';
            }
        }, false);

        var container = document.querySelector('#' + containerId);
        container.insertBefore(wrap, container.lastElementChild);
    }

    scope.Item = Item;
})(models);