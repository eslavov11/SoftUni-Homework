/**
 * Created by Edi on 16-Jan-16.
 */
function Person(firstName, lastName, age){
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.toString = function(){
        return this.firstName + ' ' + this.lastName + ' ' + '('+ 'age' + ' ' + this.age+')';
    }
}

function groupBy(criteria){
    var selectedByCriteria = [];

    for (var i = 0; i < people.length; i++) {
        if (selectedByCriteria.indexOf(people[i][criteria])===-1)
        {
            selectedByCriteria.push(people[i][criteria])
        }
    }

    return selectedByCriteria;
}

function printPeople(selectedByCriteria, criteria) {
    for (var i = 0; i < selectedByCriteria.length; i++) {
        var result = 'Group ' + selectedByCriteria[i];
        var outputLine = [];

        for (var index in people){
            if (people[index][criteria] === selectedByCriteria[i]){
                outputLine.push(people[index].toString());
            }
        }

        console.log(result + ' : [' + outputLine.join(', ') + ']');
    }
}

var people = [
    new Person("Scott", "Guthrie", 38),
    new Person("Scott", "Johns", 36),
    new Person("Scott", "Hanselman", 39),
    new Person("Jesse", "Liberty", 57),
    new Person("Jon", "Skeet", 38)
];


var peopleByFirstName = groupBy('firstName');
printPeople(peopleByFirstName, 'firstName');
console.log();
var peopleByLastName = groupBy('lastName');
printPeople(peopleByLastName, 'lastName');
console.log();
var peopleByAge = groupBy('age');
printPeople(peopleByAge, 'age');