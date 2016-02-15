/**
 * Created by Edi on 14-Feb-16.
 */
var Person = (function() {
    function Person(firstName, lastName) {
        this._firstName = firstName;
        this._lastName = lastName;

        Object.defineProperty(this, "fullName", {
            get: function() {
                return this._firstName + " " + this._lastName;
            } ,
            set: function(fullName) {
                var names = fullName.split(/\s+/g);
                this._firstName = names[0];
                this._lastName = names[1];
            }
        });
    }

    return Person;
})();

var person = new Person("Peter", "Jackson");

console.log("Problem 2. Bug Fix, Level 2");

// Getting values
console.log(person._firstName);
console.log(person._lastName);
console.log(person.fullName);
// Changing values
person._firstName = "Michael";
console.log(person._firstName);
console.log(person.fullName);
person._lastName = "Williams";
console.log(person._lastName);
console.log(person.fullName);
// Changing the full name should work too
person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person._firstName);
console.log(person._lastName);
console.log("\n\n");