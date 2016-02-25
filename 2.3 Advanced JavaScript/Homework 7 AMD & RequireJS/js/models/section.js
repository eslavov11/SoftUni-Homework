define(['item', 'extensions'], function (Item) {
    return (function () {
        var id = 0;
        function Section(title) {
            this._id = ++id;
            this.title = title;
            this._items = [];
        }

        Section.prototype.addItem = function (item) {
            this._items.push(item)
        };

        Section.prototype.getItems = function () {
            return this._items.clone();
        };

        Section.prototype.addToDom = function (selector) {
            var _this = this;
            var title = document.createElement('h4');
            title.textContent = this.title;
            var sectionWrapper = document.createElement('div');
            sectionWrapper.setAttribute('class', 'wrapper');
            var domSection = document.createElement('section');
            domSection.setAttribute('id', this.title + this._id);
            var inputSection = document.createElement('input');
            inputSection.setAttribute('type', 'text');
            inputSection.setAttribute('id', 'input-' + this.title);
            inputSection.setAttribute('placeholder', 'Add item...');
            inputSection.setAttribute('class', 'input-section');
            var buttonSection = document.createElement('button');
            buttonSection.textContent = '+';
            buttonSection.addEventListener('click', function () {
                var itemTitle = inputSection.value;
                var item = new Item(itemTitle, 'not-completed');
                _this.addItem(item);
                item.addToDom(_this.title + _this._id);
            });

            this._items.forEach(function (item) {
                item.addToDom(_this.title);
            });

            appendElementsToParent(sectionWrapper, title, domSection, inputSection, buttonSection);
            appendElementsToParentSelector(selector, sectionWrapper);
        };

        return Section;
    }());
});