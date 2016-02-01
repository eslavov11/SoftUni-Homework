function solve(input) {
    var sequenceLength = Number(input[input.length - 1]);
    var elements = [];
    var matrix = [];

    if (sequenceLength === 1) {
        for (var i = 0; i < input.length-1; i++) {
            console.log('(empty)');
        }
        return;
    }

    //TODO: tova reshenie dava 90/100, kato izleznat testovete da go testvam
    for (var i = 0; i < input.length - 1; i++) {
        var inputLine = input[i].split(/\s/)
            .filter(function(element) {
                return element !== '';
            });
        matrix.push(inputLine);
        inputLine.forEach(function(str) {
            elements.push(str);
        });
    }
    elements = elements.join(' ');
    elements += " ";

    var regexString = '(?: |[^A-z\\d]|^)([^ ]+?) \\1 ';
    var regexReplaceString = 'removed removed ';

    for (var i = 0; i < sequenceLength - 2; i++) {
        regexString = regexString + '\\1 ';
        regexReplaceString += 'removed ';
    }

    var currentReg = new RegExp(regexString, 'gi');

    console.log(elements);

    elements = elements.replace(currentReg, function(full) {
        return regexReplaceString;
    });
    console.log(elements);

    elements = elements.split(' ')
        .filter(function(element) {
            return element !== ''
        });

    var currentNumberPositon = 0;
    for (var row = 0; row < matrix.length; row++) {
        var currentRow = [];
        for (var col = 0; col < matrix[row].length; col++) {
            if (elements[currentNumberPositon] !== 'removed') {
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


//solve([
//          '3 3 3 2 5 9 9 9 9 1 2',
//          '1 1 1 1 1 2 5 8 1 1 7',
//          '7 7 1 2 3 5 7 4 4 1 2',
//          '2'
//      ]);

//solve([
//          '1 2 3 3',
//          '3 5 7 8',
//          '3 2 2 1',
//          '3'
//      ]);

solve([
'Z Z 1 aZ',
'Z Z',
'2',
]);