var Shape = {
    init: function(color) {
        this._color = color;
    },
    toString: function () {
        return "Shape: " + this.constructor.name + "\n\rColor: " + this._color;
    },
    Rectangle: {
        init: function(x,y, color) {
            this._x = x;
            this._y = y;
            Shape.init.call(this, color);
        },
        toString: function () {
            return Shape.toString.call(this) + "\n\rx: " + this._x + "\n\ry: " + this._y;
        }
    }
}

var rect = Object.create(Shape.Rectangle);
rect.init(50, 40, 'red');
console.log(rect.toString());

var shape = Object.create(Shape);
shape.init('red');
console.log(shape.toString());
