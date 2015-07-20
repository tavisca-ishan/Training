window.bouncingBall = window.bouncingBall || {

    yIndicator: false,
    xIndicator: false,
    xPosition: 20,
    yPosition: 20,
}
var moveBy = 5;
bouncingBall.moveBall=function() {
    var e = document.getElementById('bouncingBall');
    e.style.top = window.bouncingBall.yPosition + 'px';
    e.style.left = window.bouncingBall.xPosition + 'px';

    bouncingBall.boundaryCondition();

    if (window.bouncingBall.yIndicator) {
        window.bouncingBall.yPosition = window.bouncingBall.yPosition + moveBy;
    }
    else {
        window.bouncingBall.yPosition = window.bouncingBall.yPosition - moveBy;
    }
    if (window.bouncingBall.xIndicator) {
        window.bouncingBall.xPosition = window.bouncingBall.xPosition + moveBy;
    }
    else {
        window.bouncingBall.xPosition = window.bouncingBall.xPosition - moveBy;
    }

}
window.bouncingBall.start = function () {

    setInterval(window.bouncingBall.moveBall, 20);
}