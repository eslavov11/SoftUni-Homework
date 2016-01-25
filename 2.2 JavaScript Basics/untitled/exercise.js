/**
 * Created by Ed on 20-Jan-16.
 */
function main(input) {
    var pattern = /<p.*?>(.*?)<\/p>/g,
        paragraph,
        result = "";

    while (paragraph = pattern.exec(input)) {
        result += paragraph[1];
    }

    result = result.split('');
    for (var i = 0; i < result.length; i++) {
        if (/[^A-Za-z0-9 ]/.test(result[i])) {
            result[i] = ' ';
        } else if(/[A-Za-z]/.test(result[i])) {
            var letter = result[i].charAt(0);
            result[i] = transformLetter(letter);
        }
    }
    result = result.join('');
    result = result.replace(/\s+/g, ' ');
    console.log(result);


    function transformLetter(letter) {
        if (letter.charCodeAt(0) === letter.toUpperCase().charCodeAt(0)) {
            if (letter.charCodeAt(0) < 'N'.charCodeAt(0)) {
                letter = letter.charCodeAt(0) + 13;
            } else {
                letter = letter.charCodeAt(0) - 13;
            }
        } else {
            if (letter.charCodeAt(0) < 'n'.charCodeAt(0)) {
                letter = letter.charCodeAt(0) + 13;
            } else {
                letter = letter.charCodeAt(0) - 13;
            }
        }

        return  String.fromCharCode(letter);
    }

}

main('<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>');

//main([
//'mine bobovdol - gold: 10',
//'mine - diamonds: 5',
//'mine colas - wood: 10',
//'mine myMine - silver:  14',
//'mine silver:14 - silver: 14',
//]
//);

//main(
//    ["Captain Obvious was walking down the street. As the captain was walking a person came and told him: You are Captain Obvious! He replied: Thank you CAPTAIN OBVIOUS you are the man!",
//        "The captain was walking and he was obvious. He did not know what was going to happen to you in the future. Was he curious? We do not know."]
//);
