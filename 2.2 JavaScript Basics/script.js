/**
 * Created by Edi on 12-Feb-16.
 */
var SortedList = (function() {
    function SortedList() {
        this._list = [];
        this.length = 0;
    }

    SortedList.prototype.add = function(elem) {
        var index = this.length;

        for (var i = 0; i < this.length; i++) {
            if (elem < this._list[i]) {
                index = i;
                break;
            }
        }

        this._list.splice(index, 0, elem);
        this.length++;
    };

    SortedList.prototype.get = function(index) {
        return this._list[index];
    };

    return SortedList;
})();

var list = new SortedList();

list.add(5);
list.add(0);
list.add(2);
list.add(-500);
console.log(list);
console.log(list.length);

