function Quadratic(input) {
    var a = parseFloat(input[0]),
        b = parseFloat(input[1]),
        c = parseFloat(input[2]);

    var D = b*b - 4*a*c;

    if(D > 0) {
        console.log('X1 = ' + (b*-1 + Math.sqrt(D)) / 2);
        console.log('X2 = ' + (b*-1 - Math.sqrt(D)) / 2);
    } else if (D === 0) {
        console.log('X = ' + (b*-1) / 2);
    } else {
        console.log('No real rots');
    }

}

Quadratic([2, -4, -2]);