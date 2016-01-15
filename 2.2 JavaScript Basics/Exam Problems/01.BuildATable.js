	function main(input) {
  var a = Number(input[0]),
  	  b = Number(input[1]);
      
    var fibNums = calcFibonacciNums(b);
      
  console.log('<table>');
  console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
  for(var i = a; i <= b; i++) {
  	console.log(
      '<tr><td>%d</td><td>%d</td><td>%s</td></tr>',
      (i),
      (i*i), 
      (fibNums[i] ? "yes" : "no"));
  }
  console.log('</table>');	
      
      
      
function calcFibonacciNums(maxNum) {
        var fibNums = { 1: true };
        var f1 = 1;
        var f2 = 1;
        while (true) {
            var f3 = f1 + f2;
            if (f3 > maxNum) {
                return fibNums;
            }
            fibNums[f3] = true;
            f1 = f2;
            f2 = f3;
        }
    }
}