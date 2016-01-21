/**
 * Created by Ed on 20-Jan-16.
 */
function main(input) {
    var output = {};

    for (var lineKey in input) {
        var tokens = input[lineKey].split('|');
        var student = tokens[0].trim(),
            course = tokens[1].trim(),
            grade = Number(tokens[2].trim()),
            visits = Number(tokens[3].trim());

        if(!output[course]) {
            output[course] = {
              'grades': [],
              'visits': [],
              'students': []
            };
        }

        output[course].grades.push(grade);
        output[course].visits.push(visits);
        output[course].students.push(student);
    }


    Array.prototype.removeDuplicates = function (){
        var temp= new Array();
        this.sort();
        for(i=0;i<this.length;i++){
            if(this[i]==this[i+1]) {continue}
            temp[temp.length]=this[i];
        }
        return temp;
    };

    output = sortObject(output);

    for(var elem in output) {
        output[elem].students.sort();
        output[elem].students = output[elem].students.removeDuplicates();
    }

    function calculateArrSum(arr) {
        var sum = 0;
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i];
        }

        return sum;
    }

    var result = {};
    for(var elem in output) {
        result[elem] = {
            'avgGrade': [],
            'avgVisits': [],
            'students': []};

        result[elem].avgGrade = Math.round((calculateArrSum(output[elem].grades) / output[elem].grades.length) * 100) / 100;
        result[elem].avgVisits = Math.round((calculateArrSum(output[elem].visits) / output[elem].visits.length) * 100) / 100;
        result[elem].students = output[elem].students;
    };

    console.log(JSON.stringify(result));

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
}

main([
    'Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'
]);

var a = {
    "C#":
    {
        "avgGrade": 4.61,
        "avgVisits": 5.5,
        "students": ["Ivan Petrov","Maria Ivanova","Peter     Nikolov"]
    },

    "Java":
    {
        "avgGrade": 5.92,
        "avgVisits": 8,
        "students": ["Maria Ivanova","Peter     Nikolov"]
    },

    "PHP":
    {
        "avgGrade": 3.87,
        "avgVisits": 4,
        "students": ["Ivan Petrov","Peter   Nikolov"]
    }
};