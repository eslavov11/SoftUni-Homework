var models = models || {};

(function(scope) {
    "use strict";

    function Container(title) {
        this._title = title;
        this._sections = [];
    }

    Container.prototype.addSection = function(section) {
        this._sections.push(section);
    }

    Container.prototype.getSections = function() {
        return this._sections;
    }

    Container.prototype.addToDOM = function() {
        var element = document.createElement('div');
        element.id = 'container';
        element.style = 'border: 2px solid black; max-width: 400px; margin: 0 auto;';
        var title = document.createElement('h1');
        title.innerHTML = this._title;
        title.style = 'text-align: center;';

        var footer = document.createElement('footer');
        footer.style = 'margin: 10px auto; max-width: 280px;';

        var input = document.createElement('input');
        input.setAttribute('type', 'text');
        input.setAttribute('placeholder', 'Title...');
        var button = document.createElement('button');
        button.innerHTML = 'New section';
        var _this = this;
        button.addEventListener('click', function () {
            var sectionTitle = input.value;
            if (sectionTitle === undefined || sectionTitle === '') {
                alert('Cant add empty sections, you dumb motherfucker!');
                return;
            }

            var section = new models.Section(sectionTitle);
            section.addToDOM(element.id);
            input.value = '';
            _this.addSection(sectionTitle);
        }, false);

        footer.appendChild(input);
        footer.appendChild(button);
        element.appendChild(title);
        element.appendChild(footer);

        document.body.appendChild(element);
    }

    scope.Container = Container;
    console.log(5555);
})(models);