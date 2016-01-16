/**
 * Created by Ed on 16-Jan-16.
 */
function findYoungestPerson(input) {

    input = input.filter(function(person){
        return person.hasSmartphone;
    });

    input = input.sort(function(person1, person2) {
       return person1.age > person2.age;
    });

    console.log('The youngest person is ' + input[0].firstname + ' ' + input[0].lastname);
}

findYoungestPerson([
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }]
);