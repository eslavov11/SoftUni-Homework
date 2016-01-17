/**
 * Created by Ed on 16-Jan-16.
 */
function main(input) {
    var formatRakiya = "<li><span class=\'rakiya\'>%d</span><a href=\"view.php?id=%d>View</a></li>",
        formatNormal = "<li><span class=\'num\'>%d</span></li>",
        start = Number(input[0]),
        end = Number(input[1]);
    console.log("<ul>");

    for (var i = start; i <= end; i++) {
        if((/([0-9]{2})[0-9]*\1+/g).test(i.toString())){
            console.log(formatRakiya, i, i);
        } else {
            console.log(formatNormal, i);
        }
    }

    console.log("</ul>");

}