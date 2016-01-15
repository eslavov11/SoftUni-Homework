/**
 * Created by Edi on 15-Jan-16.
 */
function main(input) {
    var pattern1 = /<a\s.*?href\s*?=\s*?"(.*?)".*?>.*?<\/a>/g,
        pattern2 = /<a\s.*?href\s*?=\s*?'(.*?)'.*?>.*?<\/a>/g,
        pattern3 = /<a\s.*?href\s*?=\s*?(.*) .*?>.*?<\/a>/g;

    if(pattern1.exec(input[0])) {

    }
}


main(
['<a href="http://softuni.bg" class="new"></a>']);
