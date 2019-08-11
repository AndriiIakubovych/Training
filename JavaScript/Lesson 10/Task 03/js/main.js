window.onload = function ()
{
    var SIZE = 8;
    var table = document.createElement("table");
    var tbody = document.createElement("tbody");
    var td, tr;
    table.appendChild(tbody);
    for (var i = 0; i < SIZE; i++)
    {
        tr = document.createElement("tr");
        tbody.appendChild(tr);
        for (var j = 0; j < SIZE; j++)
        {
            td = document.createElement("td");
            tr.appendChild(td);
            if ((i % 2 === 0 && j % 2 === 0) || (i % 2 != 0 && j % 2 != 0))
                td.className = "black-cell";
        }
    }
    document.body.appendChild(table);
};