/**
 * Created by Ed on 16-Jan-16.
 */
function main(input) {
    var database = [],
        noSorted = true;
    console.log(input[0]);
    console.log(input[1]);

    for (var i = 2; i < input.length-1; i++) {
        database.push(input[i]);
    }

    do {
        noSorted = true;

        for (var i = 0; i < database.length - 1; i++) {
            var num = (/<tr><td>.*?<\/td><td>(.*?)<\/td><td>.*?<\/td><\/tr>/g).exec(database[i]);
            var num2 = (/<tr><td>.*?<\/td><td>(.*?)<\/td><td>.*?<\/td><\/tr>/g).exec(database[i+1]);

            if (Number(num[1]) > Number(num2[1])) {
                var oldValue = database[i];
                database[i] = database[i+1];
                database[i+1] = oldValue;
                noSorted = false;
            }
        }
    } while (!noSorted);

    function sortObject(o) {
        var sorted = {},
            key, a = [];

        for (key in o) {
            if (o.hasOwnProperty(Number(key))) {
                a.push(Number(key));
            }
        }

        a = a.sort(function(e1, e2) {
            return Number(e1) > Number(e2);
        });

        for (key = 0; key < a.length; key++) {
            sorted[a[Number(key)]] = o[a[Number(key)]];
        }
        return sorted;
    }

    database = sortObject(database);

    for (var el in database) {
        console.log(database[el]);
    }
    //for (var i = 2; i < database.length-1; i++) {
    //    var num = (/<tr><td>(.*?)<\/td><td>.*?<\/td><td>.*?<\/td><\/tr>/g).exec(database);
    //    database[Number(num[1])] = input[i];
    //
    //}

    console.log(input[input.length-1]);
}

main([
'<table>',
'<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
'<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
'<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
'<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
'<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
'</table>']);