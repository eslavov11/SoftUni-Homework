function calcExpression() {

    var input = document.getElementById('input').value;
    var numbers = input.split('([\/\+\-\*])+');
    var operands = input.split('^[0 - 9]');
    var result = 0;
    document.getElementById('result').innerHTML = numbers[0];

    for (var i = 0; i < numbers.length; i++) {
        switch (operands[i]) {
            case '+':

                break;
            case '-':
                break;
            case '*':
                break;
            case '/':
                break;
        }
    }
}
