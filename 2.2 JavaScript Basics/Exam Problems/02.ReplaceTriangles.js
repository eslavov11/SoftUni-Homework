/**
 * Created by Edi on 15-Jan-16.
 */
function main(input) {
    String.prototype.replaceAt=function(index, character) {
        return this.substr(0, index) + character + this.substr(index+character.length);
    }


    for (var i = 0; i < input.length-1; i++) {
        var line = input[i],
            nextLine = input[i+1];

        for (var j = 1; j < line.length; j++) {
            if ((line[j] === nextLine[j-1] &&
                line[j] === nextLine[j] &&
                line[j] === nextLine[j+1]) ||

                (line[j] === '*' &&
                nextLine[j-1] === nextLine[j] &&
                nextLine[j] === nextLine[j+1])||

                (line[j] === '*' &&
                nextLine[j-1] === '*' &&
                nextLine[j] === nextLine[j+1])||

                (line[j] === '*' &&
                nextLine[j-1] === '*' &&
                nextLine[j] === '*')


            ) {
                line = line.replaceAt(j, "*");
                nextLine = nextLine.replaceAt(j-1, '*');
                nextLine = nextLine.replaceAt(j,'*');
                nextLine = nextLine.replaceAt(j+1, '*');
            }
        }
        input[i] = line;
        input[i+1] = nextLine;
    }

    for (var i = 0; i < input.length; i++) {
        console.log(input[i]);

    }


}

