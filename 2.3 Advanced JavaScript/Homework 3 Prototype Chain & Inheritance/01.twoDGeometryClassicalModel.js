var Shape = (function(){
    function Shape(color) {
        this._color = color;
    }

    Shape.prototype.toString = function() {
        return "Shape: " + this.constructor.name +
            "\n\rColor: " + this._color;
    }

    var Rectangle = (function() {
        function Rectangle(x, y, width, height, color) {
            this._x = x;
            this._y = x;
            this._width = x;
            this._height = x;
            Shape.call(this, color);
        }

        Rectangle.prototype = Object.create(Shape.prototype);
        Rectangle.prototype.constructor = Rectangle;

        Rectangle.prototype.toString = function() {
            var result = Shape.prototype.toString.call(this);
            result += "\n\rX: "+ this._x +
                "\n\rY:" + this._y;

            return result;
        }

        return Rectangle;
    })();


    return {
        Rectangle: Rectangle
    };
})();

var rect = new Shape.Rectangle(50,40,0,0,'green');
console.log(rect.toString());