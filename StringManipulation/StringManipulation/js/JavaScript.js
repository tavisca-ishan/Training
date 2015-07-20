//concatenate two strings.
String.prototype.Concatenate = function (secondString) {

    if (secondString === null) {
        return this + 'null';
    }
    if (secondString === undefined) {
        return this + 'undefined';
    }
    var concatenatedString = this;
    for (var index = 0; index < secondString.length; index++) {
        concatenatedString += secondString.charAt(index);
    }
    return concatenatedString;

};
//find substring 
String.prototype.Substring = function (position1, position2) {
    if (position1 < 0 || position2 < 0) {
        document.write("Invalid Substring Indexes");
        return;
    }
    var newSubString = "";
    for (var index = position1 ; index < position2; index++)
        newSubString += this[index];
    return newSubString;

};