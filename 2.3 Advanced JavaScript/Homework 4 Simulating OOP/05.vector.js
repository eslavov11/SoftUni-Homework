var Vector = (function() {
    function Vector(elems) {
        this._elems = elems;
        this._length = this._elems.length;
    }

    Vector.prototype.add = function(vector) {
        this.checkVectorsDimensions(vector);
        var result = new Vector(new Array(this._length))
        for (var elem in this._elems) {
            result._elems[elem] = this._elems[elem] + vector._elems[elem];
        }

        return result.toString();
    };

    Vector.prototype.subtract = function(vector) {
        this.checkVectorsDimensions(vector);
        var result = new Vector(new Array(this._length))
        for (var elem in this._elems) {
            result._elems[elem] = this._elems[elem] - vector._elems[elem];
        }

        return result.toString();
    };

    Vector.prototype.dot = function(vector) {
        this.checkVectorsDimensions(vector);
        var product = 0;
        for (var elem in this._elems) {
            product += this._elems[elem] * vector._elems[elem];
        }

        return product;
    };

    Vector.prototype.toString = function() {
        return '(' + this._elems + ')';
    };

    Vector.prototype.checkVectorsDimensions = function(vector) {
        if (this._length !== vector._length) {
            throw new Error("Cannot perform operation. Vectors dimensions don't match.");
        }
    };

    return Vector;
})();

var vect1 = new Vector([1,2,3]);
var vect2 = new Vector([4,5,6]);

console.log(vect1.add(vect2));
console.log(vect1.subtract(vect2));
console.log(vect1.dot(vect2));
