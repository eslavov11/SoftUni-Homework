function solve(input) {
    var sequenceLength = Number(input[input.length - 1]);
    var numbers = [];
    var matrix = [];

    for (var i = 0; i < input.length - 1; i++) {
        var inputLine = input[i].split(/\s/).filter(function(element){
            return element !=='';
        });
        matrix.push(inputLine);
        inputLine.forEach(function(str) {
            numbers.push(str);
        });
    }
    numbers = numbers.join('');

    var regexString = '([^ ])\\1';
    var regexReplaceString = '  ';

    for (var i = 0; i < sequenceLength - 2; i++) {
        regexString = regexString + '\\1';
        regexReplaceString += ' ';
    }

    var currentReg = new RegExp(regexString, 'g');

    var replaced = numbers.replace(currentReg, function(full) {
        return regexReplaceString;
    });

    var currentNumberPositon = 0;
    for (var row = 0; row < matrix.length; row++) {
        var currentRow = [];
        for (var col = 0; col < matrix[row].length; col++) {
            if (replaced[currentNumberPositon] !== ' ') {
                currentRow.push(matrix[row][col]);
            }
            currentNumberPositon++;
        }
        if (currentRow.length > 0) {
            console.log(currentRow.join(' '))
        }
        else {
            console.log("(empty)");
        }
    }
}

solve([
    '2 1 1 1',
    '1 1 1',
    '3 7 3 3 1',
    '2',

]);

