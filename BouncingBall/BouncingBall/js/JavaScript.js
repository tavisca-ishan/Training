var height = 0;
var width = 0;
var yIndicator = false;
var xIndicator = false;
var interval;
var xPosition = 20;
var yPosition = 20;

function moveBall() {
    height = window.innerHeight;
    width = window.innerWidth;
    document.getElementById("bouncingBall").style.top = yPosition;
    document.getElementById("bouncingBall").style.left = xPosition;
   // alert();
    if (yIndicator) {
        yPosition = yPosition + 5;
    }
    else {
        yPosition = yPosition - 5;
    }
    if (yPosition < 0) {
        yIndicator = true;
        yPosition = 0;
    }
    if (yPosition >= (height)) {
        yIndicator = false;
        yPosition = (height);
    }
    if (xIndicator) {
        xPosition = xPosition + 5;
    }
    else {
        xPosition = xPosition - 5;
    }
    if (xPosition < 0) {
        xIndicator = true;
        xPosition = 0;
    }
    if (xPosition >= (width)) {
        xIndicator = false;
        xPosition = (width);
    }
}
function start() {
    interval = setInterval(moveBall, 10);
}
