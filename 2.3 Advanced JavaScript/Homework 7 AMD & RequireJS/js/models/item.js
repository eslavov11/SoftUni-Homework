define(['extensions'], function () {
    return (function () {
        var id = 0;

        function Item(content, status) {
            this._id = ++id;
            this.content = content;
            this._status = status;
        }


        Item.prototype.addToDom = function (selector) {
            var _this = this;
            var itemWrapper = document.createElement('div');
            itemWrapper.setAttribute('class', 'wrapper');

            var itemCheckbox = document.createElement('input');
            itemCheckbox.setAttribute('type', 'checkbox');
            itemCheckbox.checked = this._status == 'completed';
            var domItem = document.createElement('div');
            domItem.setAttribute('id', 'item' + this._id);
            domItem.textContent = this.content;

            itemCheckbox.addEventListener('change', function () {
                _this._status = this.checked ? 'completed' : 'non-completed';
                if (_this._status == 'completed') {
                    itemWrapper.style.background = 'lightgreen';
                } else {
                    itemWrapper.style.background = 'none';
                }
            });
            appendElementsToParent(itemWrapper, itemCheckbox, domItem);
            appendElementsToParentSelector(selector, itemWrapper);
        };

        return Item;
    }());
});