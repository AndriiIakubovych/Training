window.onload = function ()
{
    function rand(startNum, endNum)
    {
        return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
    }

    var SIZE = 10, START_NUM = 0, END_NUM = 100;
    var matrix = [];
    var array = [];
    var str = "<table><tbody>";
    for (var i = 0; i < SIZE; i++)
    {
        matrix[i] = [];
        str += "<tr>";
        for (var j = 0; j < SIZE; j++)
        {
            matrix[i][j] = rand(START_NUM, END_NUM);
            str += "<td>" + matrix[i][j] + "</td>";
        }
        str += "</tr>";
    }
    str += "</tbody></table>";
    document.body.innerHTML = str;
}