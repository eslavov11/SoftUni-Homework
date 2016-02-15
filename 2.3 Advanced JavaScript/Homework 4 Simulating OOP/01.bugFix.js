var Person = (function() {
    function Person(firstName, lastName) {
        this._firstName = firstName;
        this._lastName = lastName;
        this.name = this._firstName + " " + this._lastName;
    }

    return Person;
})();



var peter = new Person("Peter", "Jackson");
console.log(peter.name);
console.log(peter._firstName);
console.log(peter._lastName);
