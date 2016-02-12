// Returns the propery of object by index ex. -> var person = {name: "peter", age: 1}; person.propertyAt(0);
//  <- returns {name: "Peter"}
Object.prototype.propertyAt = function(n) {
    var key = Object.keys(this)[n];
    return  { key : this[key]};
};