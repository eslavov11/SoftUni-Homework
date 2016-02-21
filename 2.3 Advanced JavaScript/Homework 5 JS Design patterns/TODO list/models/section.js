var models = models || {};

(function(scope) {
    "use strict";

    function Section(title) {
        this._id = Section.idCounter++;
        this._title = title;
        this._items = [];
    }

    Section.idCounter = 1;

    Section.prototype.addItem = function(item) {
        this._items.push(item);
    }

    Section.prototype.getItems = function() {
        return this._items;
    }

    Section.prototype.addToDOM = function(containerId) {
        var element = document.createElement('section');
        element.id = 'section' + this._id;
        element.style = 'border: 2px solid black; margin: 10px auto; max-width: 380px;';
        var title = document.createElement('h2');
        title.innerHTML = this._title;
        title.style = 'text-align: right; margin-right: 10px;';

        var footer = document.createElement('footer');
        footer.style = 'margin: 10px auto; margin-left:180px; max-width: 280px;';

        var input = document.createElement('input');
        input.setAttribute('type', 'text');
        var button = document.createElement('button');
        button.innerHTML = '+';
        input.setAttribute('placeholder', 'Add item...');
        var _this = this;
        button.addEventListener('click', function () {
            var content = input.value;

            if (content === undefined || content === '') {
                alert('Cant add empty items, you dumb motherfucker!');
                return;
            }

            var item = new models.Item(content);
            item.addToDOM(element.id);
            input.value = '';
            _this.addItem(item);
        }, false);

        footer.appendChild(input);
        footer.appendChild(button);
        element.appendChild(title);
        element.appendChild(footer);

        var container = document.querySelector('#' + containerId);
        container.insertBefore(element, container.lastElementChild);
    }

    scope.Section = Section;
})(models);