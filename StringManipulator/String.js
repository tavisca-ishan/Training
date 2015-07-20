String.prototype.Concatenate = function () {

    var concatenatedString = this;
    for (var index = 0; index < arguments.length; index++) {
        if (arguments[index] === null) {
            concatenatedString += 'null';
        }
        else if (arguments[index] === undefined) {
            concatenatedString += 'undefined';
        }

        else {
            concatenatedString += arguments[index];
        }
    }
    return concatenatedString;


};

String.prototype.GetSubstring = function (position1, position2) {

    var subString = "";

    if (position1 < 0 || position1 === null || position1 === undefined) {
        for (var index = 0 ; index < position2; index++)
            subString += this[index];

    }
    else if (position2 < 0 || position2 === null || position2 === undefined) {
        for (var index = 0 ; index < position1; index++)
            subString += this[index];

    }
    else if (position1 > position2) {
        for (var index = position2 ; index < position1; index++)
            subString += this[index];

    }
    else {
        for (var index = position1 ; index < position2; index++)
            subString += this[index];
    }
    return subString;

};