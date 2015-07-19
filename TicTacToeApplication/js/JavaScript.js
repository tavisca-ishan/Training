var player = 1;

function onClickButton(getButton) {
    if (player == 1) {
        document.getElementById(getButton).value = "X";
        document.getElementById(getButton).disabled = "disabled";
        player -= 1;
        winner();
    }
    else {
        document.getElementById(getButton).value = "O";
        document.getElementById(getButton).disabled = "disabled";
        player += 1;
        winner();
    }
}
function winner() {
    for (var count = 1; count <= 7; count += 3)
     {
        if (document.getElementById(count).value == "X" &&
        document.getElementById(count + 1).value == "X" &&
        document.getElementById(count + 2).value == "X")
        {
            document.getElementById("Winner").innerHTML = "Player X Won!";
            reset();
        }
        else if (document.getElementById(count).value == "O" &&
        document.getElementById(count + 1).value == "O" &&
        document.getElementById(count + 2).value == "O")
        {
            document.getElementById("Winner").innerHTML = "Player O Won!";
            reset();
        }
    }
    for (var count = 1; count <= 7; count += 1)
    {
        if (document.getElementById(count).value == "X" &&
        document.getElementById(count + 3).value == "X" &&
        document.getElementById(count + 6).value == "X")
        {
            document.getElementById("Winner").innerHTML = "Player X Won!";
            reset();
        }
        else if (document.getElementById(count).value == "O" &&
        document.getElementById(count + 3).value == "O" &&
        document.getElementById(count + 6).value == "O")
       {
            document.getElementById("Winner").innerHTML = "Player O Won!";
            reset();
        }
    }
    for (var count = 1; count <= 3; count += 2)
    {
        if (document.getElementById(count).value == "X" &&
        document.getElementById(count + 4).value == "X" &&
        document.getElementById(count + 8).value == "X")
        {
            document.getElementById("Winner").innerHTML = "Player X Won!";
            reset();
        }
        else if (document.getElementById(count).value == "O" &&
       document.getElementById(count + 4).value == "O" &&
       document.getElementById(count + 8).value == "O")
        {
            document.getElementById("Winner").innerHTML = "Player O Won!";
            reset();
        }
    }
    function reset()
    {
        location.reload();

    }
}