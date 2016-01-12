function cylinderVolume(input) {
    console.log((Math.PI * Math.pow(Number(input[0]), 2) * Number(input[1])).toFixed(3));
}

cylinderVolume([2, 4]);
console.log();
cylinderVolume([5, 8]);
console.log();
cylinderVolume([12, 3]);
console.log();