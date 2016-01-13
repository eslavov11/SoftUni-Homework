function manipulation(input) {
    var numbers = [];
    for (var i = 0, numbersIndex = 0; i < input.length; i++) {
       if (!isNaN(input[i])) {
           numbers[numbersIndex++] = input[i];
       }
    }
    console.log('Min number: ' + Math.min.apply(Math,numbers));
    console.log('Max number: ' + Math.max.apply(Math,numbers));
    console.log('Most frequent number: ' + mode(numbers));
    console.log(numbers);
}

function mode(array)
{
    if(array.length == 0)
        return null;
    var modeMap = {};
    var maxEl = array[0], maxCount = 1;
    for(var i = 0; i < array.length; i++)
    {
        var el = array[i];
        if(modeMap[el] == null)
            modeMap[el] = 1;
        else
            modeMap[el]++;
        if(modeMap[el] > maxCount)
        {
            maxEl = el;
            maxCount = modeMap[el];
        }
    }
    return maxEl;
}


manipulation(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]);