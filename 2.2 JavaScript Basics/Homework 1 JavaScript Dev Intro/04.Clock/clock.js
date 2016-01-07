/**
 * Created by Edi on 07-Jan-16.
 */

function update() {
    var date = new Date();
    document.getElementById("clock").innerHTML = date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
    setTimeout(update, 1000);
}
 update();
