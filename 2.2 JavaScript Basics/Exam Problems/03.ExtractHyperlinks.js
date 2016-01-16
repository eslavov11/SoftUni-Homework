/**
 * Created by Edi on 15-Jan-16.
 */
function main(input) {
    var full = input.join('\n'),
        matches = [];

    var pattern = /<a\s+([^>]+\s+)?href\s*=\s*('([^']*)'|"([^"]*)|([^\s>]+))[^>]*>/g;

    do {
        var matchReg = pattern.exec(full);

        if (matchReg) {
            var link = matchReg[3];
            if (link == undefined) {
                var link = matchReg[4];
            }
            if (link == undefined) {
                var link = matchReg[5];
            }
            console.log(link);
        }
    } while(matchReg);
}
