var isPlayerX = true;

var success = [
    [1, 4, 7],  // col
    [2, 5, 8],  // col
    [3, 6, 9],  // col
    [1, 2, 3],  // row
    [4, 5, 6],  // row
    [7, 8, 9],  // row
    [1, 5, 9],  // diagonal
    [3, 5, 7]   // diagonal
];

function onClickButton(btnId) {
    var label = isPlayerX ? 'X' : 'O';
    document.getElementById(btnId).value = label;
    document.getElementById(btnId).disabled = 'disabled';
    winner();
    isPlayerX = !isPlayerX;
}

function winner() {
    for (var index = 0; index < success.length; index++) {                              
        for (var player = 0; player < 2; player++) {
            var label = player === 0 ? 'X' : 'O',
                combination = success[index];

            if (document.getElementById(combination[0]).value == label &&
                    document.getElementById(combination[1]).value == label &&
                    document.getElementById(combination[2]).value == label) {
                document.getElementById("Winner").innerHTML = 'Player ' + label + ' Won!';
            }
        }
    }
}
function reset() {
    location.reload();
}