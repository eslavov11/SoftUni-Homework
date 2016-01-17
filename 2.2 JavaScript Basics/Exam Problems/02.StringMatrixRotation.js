
  Created by Ed on 16-Jan-16.
 
function main(input) {
    var degrees = Number(input[0].substring(7,input[0].length-1)),
        arr = [],
        longestLength = 0;
    while(degrees = 360) {
        degrees -= 360;
    }

    for (var i = 1; i  input.length; i++) {
        if(longestLength  input[i].length) longestLength = input[i].length;

        var line = input[i];
        arr.push(line.split(''));
    }

    for (var i = 0; i  input.length-1; i++) {
        if (arr[i].length  longestLength) {
            for (var j = arr[i].length; j  longestLength; j++) {
                arr[i][j] = ' ';
            }
        }
    }

    for (var i = 0; i  i.length; i++) {
        for (var j = 0; j  i.length; j++) {
            var obj = i[j];

        }
    }

    var row = 0, col = 0, rowEnd = arr.length, colEnd = arr[0].length, str = ;
    switch (degrees) {
        case 0
            for (var i = 0; i  rowEnd; i++) {
                for (var j = 0; j  colEnd; j++) {
                    str += arr[i][j];
                }
                console.log(str);
                str = ;
            }
            row = 0;
            col = 0;
            colEnd = arr[0].length;
            rowEnd = arr.length;
            break;
        case 90
            for (var i = 0; i  colEnd; i++) {
                for (var j = rowEnd-1; j = 0; j--) {
                    str += arr[j][i];
                }
                console.log(str);
                str = ;
            }
            break;
        case 180
            for (var i = rowEnd-1; i = 0; i--) {
                for (var j = colEnd-1; j = 0; j--) {
                    str += arr[i][j];
                }
                console.log(str);
                str = ;
            }
            break;
        case 270
            for (var i = colEnd-1; i = 0; i--) {
                for (var j = 0; j  rowEnd; j++) {
                    str += arr[j][i];
                }
                console.log(str);
                str = ;
            }
            break;
    }
}