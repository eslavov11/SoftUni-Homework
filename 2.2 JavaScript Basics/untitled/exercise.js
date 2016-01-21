/**
 * Created by Ed on 20-Jan-16.
 */
function main(input) {
    var pattern = /<tr><td>.*?<\/td><td>([0-9\-\.]*)<\/td><td>([0-9\-\.]*)<\/td><td>([0-9\-\.]*)<\/td><\/tr>/,
        output = 'no data';

    for (var i = 2; i < input.length-1; i++) {
        var nums = pattern.exec(input[i]),
            tempSum = undefined;
        var num1 = Number(nums[1]);
        var num2 = Number(nums[2]);
        var num3 = Number(nums[3]);

        if (isNaN(num1) && isNaN(num2) && isNaN(num3)) continue;
        tempSum = 0;
        if (!isNaN(num1))
            tempSum += num1;
        if (!isNaN(num2))
            tempSum += num2;
        if (!isNaN(num3))
            tempSum += num3;

        if (output.sum >= tempSum) continue;

        output = {
          sum: tempSum,
            n1: nums[1],
            n2: nums[2],
            n3: nums[3]
        };
    }

    if (typeof output === 'object') {
        var arr = [];
        if (!isNaN(output.n1)) arr.push(output.n1);
        if (!isNaN(output.n2)) arr.push(output.n2);
        if (!isNaN(output.n3)) arr.push(output.n3);
        console.log(output.sum + ' = ' + arr.join(' + '));
    } else {
        console.log(output);
    }

}

main([
    '<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>',
    '<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>',
    '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
    '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
    '</table>'

]);