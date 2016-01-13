function scoreModification (input) {
    var numbersInRange = input.filter(function (elem) {
        return elem > -1 && elem < 401;
    });
    numbersInRange = numbersInRange.sort(function(a,b) {
        return a > b;
    });
    for (var i = 0; i < numbersInRange.length; i++) {
        numbersInRange[i] = (Number(numbersInRange[i]) * 0.8).toFixed(1);
    }
    console.log(numbersInRange);
}


scoreModification([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);