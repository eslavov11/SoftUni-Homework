function supplyCalculator(age, maxAge, food, foodPerDay) {
    console.log('%dkg of %s would be enough until I am %d years old.', ((maxAge - age) * 365 * foodPerDay), food, maxAge);
}

supplyCalculator(38, 118, 'chocolate', 0.5);
supplyCalculator(20, 87, 'fruits', 2);
