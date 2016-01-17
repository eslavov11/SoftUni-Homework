// ------------------------------------------------------------
// Read the input from the console as array and process it
// ------------------------------------------------------------

var arr = [];
require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
}).on('line', function (line) {
    arr.push(line);
}).on('close', function () {
    revealTriangles(arr);
});