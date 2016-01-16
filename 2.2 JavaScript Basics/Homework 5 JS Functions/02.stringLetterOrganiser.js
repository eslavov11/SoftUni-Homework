/**
 * Created by Ed on 16-Jan-16.
 */
function sortLetters(input, order) {
    input = input.split('');

    input.sort(function(letterA, letterB) {
        return order ?
            (letterA.toLowerCase() > letterB.toLowerCase()) :
            (letterA.toLowerCase() < letterB.toLowerCase());
    });

    console.log(input.join(''));
}

sortLetters('HelloWorld', true);
console.log();
sortLetters('HelloWorld', false);