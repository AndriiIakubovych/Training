window.onload = function ()
{
    var SIZE = 8;
    var str = "<table><tbody>";
    for (var i = 0; i < SIZE; i++)
    {
        str += "<tr>";
        for (var j = 0; j < SIZE; j++)
            if (i % 2 === 0)
            {
                if (j % 2 === 0)
                    str += "<td class='black-cell'></td>";
                else
                    str += "<td></td>";
            }
            else
            {
                if (j % 2 === 0)
                    str += "<td></td>";
                else
                    str += "<td class='black-cell'></td>";
            }
        str += "</tr>";
    }
    str += "</tbody></table>";
    document.body.innerHTML = str;
}