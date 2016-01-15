/**
 * Created by Edi on 15-Jan-16.
 */
function main(input) {
    function sortObject(o) {
        var sorted = {},
            key, a = [];

        for (key in o) {
            if (o.hasOwnProperty(key)) {
                a.push(key);
            }
        }

        a.sort();

        for (key = 0; key < a.length; key++) {
            sorted[a[key]] = o[a[key]];
        }
        return sorted;
    }

    var result = {};

    for (var i = 0; i < input.length; i++) {
        var tokens = input[i].split(' | '),
            band = tokens[0],
            town = tokens[1],
            date = tokens[2],
            venue = tokens[3];

        if(!result[town]) {
            result[town] = {};
        }

        if(!result[town][venue]) {
            result[town][venue] = [];
        }

        if(result[town][venue].indexOf(band) === -1) {
            result[town][venue].push(band);
        }
    }

    result = sortObject(result);

    for (var town in result)
    {
        result[town] = sortObject(result[town]);
        for (var venue in result[town])
        {
            result[town][venue].sort();
        }
    }

    console.log(JSON.stringify(result));
}

