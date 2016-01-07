/**
 * Created by Edi on 07-Jan-16.
 */
function calcCircleArea(r) {
    return Math.PI * r * r;
}

document.getElementById("rad1").innerHTML = calcCircleArea(7);
document.getElementById("rad2").innerHTML = calcCircleArea(1.5);
document.getElementById("rad3").innerHTML = calcCircleArea(20);