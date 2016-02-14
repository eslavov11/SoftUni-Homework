String.prototype.startsWith = function(substring) {
    var compareString = this.substring(0, substring.length);

    return compareString === substring;
};

String.prototype.endsWith = function(substring) {
    var compareString = this.substring(this.length - substring.length, this.length);

    return compareString === substring;
};

String.prototype.left = function(count) {
    if (count > this.length) return this.toString();

    return this.substring(0, count);
};

String.prototype.right = function(count) {
    if (count > this.length) return this.toString();

    return this.substring(this.length - count, this.length);
};

String.prototype.padLeft = function(count, character) {
    character = character || ' ';
    return character.repeat(count) + this.toString();
};

String.prototype.padRight = function(count, character) {
    character = character || ' ' ;
    return this.toString() + character.repeat(count);
};

String.prototype.repeat = function(count) {
    var result = "",
        str = this.toString();
    for (var i = 0; i < count; i++) {
        result += str;
    }

    return result;
};

console.log("123".endsWith('45'));
console.log("123".startsWith('12'));
console.log("123".left(2));
console.log("123".right(2));
console.log("123".left(40));
console.log("123".right(50));
console.log("123".padLeft(40, '*'));
console.log("123".padRight(40, '+-+'));