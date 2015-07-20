var moveBy = 5;
var timeout = 20;
var height = 0;
var width = 0;
var yIndicator = false;
var xIndicator = false;
var interval;
var xPosition = 20;
var yPosition = 20;

function moveBall() {
    var e = document.getElementById("bouncingBall");
    height = window.innerHeight - 60;
    width = window.innerWidth - 60;
    e.style.top = yPosition +'px';
    e.style.left = xPosition +'px';

    if (yIndicator) {
        yPosition = yPosition + moveBy;
    }
    else {
        yPosition = yPosition - moveBy;
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
        xPosition = xPosition + moveBy;
    }
    else {
        xPosition = xPosition - moveBy;
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
   
    window.setInterval(moveBall, timeout);
}

window.onload = start;