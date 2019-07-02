var SIZE = 10;

document.write("<table><tbody>");
for (var i = 0; i < SIZE * SIZE; i += SIZE)
{
    document.write("<tr>");
    for (var j = 1; j <= SIZE; j++)
        document.write("<td>" + (i + j) + "</td>");
    document.write("</tr>");
}
document.write("</tbody></table>");