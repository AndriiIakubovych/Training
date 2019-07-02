﻿var SIZE = 10, START_NUM = 0, END_NUM = 100;
var matrix = [];
var array = [];

function rand(startNum, endNum)
{
    return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
}

document.write("Сгенерированная матрица:</br><table><tbody align='right'>");
for (var i = 0; i < SIZE; i++)
{
    matrix[i] = [];
    document.write("<tr>");
    for (var j = 0; j < SIZE; j++)
    {
        matrix[i][j] = rand(START_NUM, END_NUM);
        document.write("<td width = '25'>" + matrix[i][j] + "</td>");
    }
    document.write("</tr>");
}
document.write("</tbody></table>");

document.write("<br/>Массив, полученный из элементов матрицы, лежащих по периметру по часовой стрелке:<br/>");
for (var i = 0; i < (SIZE - 1) * 4; i++)
{
    if (i <= SIZE - 1)
        array[i] = matrix[0][i];
    if (i > SIZE - 1 && i <= (SIZE - 1) * 2)
        array[i] = matrix[i - (SIZE - 1)][SIZE - 1];
    if (i > (SIZE - 1) * 2 && i <= (SIZE - 1) * 3)
        array[i] = matrix[SIZE - 1][(SIZE - 1) * 3 - i];
    if (i > (SIZE - 1) * 3)
        array[i] = matrix[(SIZE - 1) * 4 - i][0];
    document.write(array[i] + " ");
}