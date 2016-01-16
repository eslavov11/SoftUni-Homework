/**
 * Created by Edi on 16-Jan-16.
 */
function extractObjects(input) {
    input = input.filter(function(element) {
        return (element.constructor !== Array && typeof element === 'object');
    });

    console.log(input);
}

extractObjects([
        "Pesho",
        4,
        4.21,
        { name : 'Valyo', age : 16 },
        { type : 'fish', model : 'zlatna ribka' },
        [1,2,3],
        "Gosho",
        { name : 'Penka', height: 1.65}
    ]
);