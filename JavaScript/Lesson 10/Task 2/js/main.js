window.onload = function ()
{
    function rand(startNum, endNum)
    {
        return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
    }

    var SIZE = 10, START_NUM = 0, END_NUM = 100;
    var matrix = [];
    var array = [];
    var table = document.createElement("table");
    var tbody = document.createElement("tbody");
    var td, tr;
    table.appendChild(tbody);
    for (var i = 0; i < SIZE; i++)
    {
        matrix[i] = [];
        tr = document.createElement("tr");
        tbody.appendChild(tr);
        for (var j = 0; j < SIZE; j++)
        {
            matrix[i][j] = rand(START_NUM, END_NUM);
            td = document.createElement("td");
            td.innerHTML = matrix[i][j];
            tr.appendChild(td);
        }
    }
    document.body.appendChild(table);
}