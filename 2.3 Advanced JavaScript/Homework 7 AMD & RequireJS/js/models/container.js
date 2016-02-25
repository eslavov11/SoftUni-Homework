define(['section', 'extensions'], function(Section) {
    return (function () {
        var id = 0;

        function Container(title) {
            this._id = ++id;
            this.title = title;
            this._sections = [];
        }

        Container.prototype.addSection = function (section) {
            this._sections.push(section);
        };

        Container.prototype.getSections = function () {
            return this._sections.clone();
        };

        Container.prototype.addToDom = function (selector) {
            var _this = this;
            var containerId = 'container' + this._id;
            var containerWrapper = document.createElement('div');
            containerWrapper.setAttribute('class', 'wrapper');
            var title = document.createElement('h2');
            title.textContent = this.title + ' TODO List';
            var domContainer = document.createElement('div');
            domContainer.setAttribute('id', containerId);
            var inputContainer = document.createElement('input');
            inputContainer.setAttribute('type', 'text');
            inputContainer.setAttribute('id', 'input-' + containerId);
            inputContainer.setAttribute('placeholder', 'Title...');
            inputContainer.setAttribute('class', 'input-container');
            var buttonContainer = document.createElement('button');
            buttonContainer.textContent = 'New Section';
            buttonContainer.addEventListener('click', function () {
                var sectionTitle = inputContainer.value;
                var section = new Section(sectionTitle);
                _this.addSection(section);
                section.addToDom(containerId);
            });

            this._sections.forEach(function (section) {
                section.addToDom(containerId)
            });

            appendElementsToParent(containerWrapper, title, domContainer, inputContainer, buttonContainer);
            appendElementsToParentSelector(selector, containerWrapper);
        };


        return Container;
    }());
});
