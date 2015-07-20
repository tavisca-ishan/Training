window.bouncingBall = window.bouncingBall || {};

bouncingBall.boundaryCondition = function () {

var height = 0;
var width = 0;
height = window.innerHeight - 60;
width = window.innerWidth - 60;

    if (window.bouncingBall.
        yPosition < 0) {
        window.bouncingBall.yIndicator = true;
        window.bouncingBall.yPosition = 0;
    }
    if (window.bouncingBall.yPosition >= (height)) {
        window.bouncingBall.yIndicator = false;
        window.bouncingBall.yPosition = (height);
    }


    if (window.bouncingBall.xPosition < 0) {
        window.bouncingBall.xIndicator = true;
        window.bouncingBall.xPosition = 0;
    }
    if (window.bouncingBall.xPosition >= (width)) {
        window.bouncingBall.xIndicator = false;
        window.bouncingBall.xPosition = (width);
    }
}