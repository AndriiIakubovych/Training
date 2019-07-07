var SIZE = 30, START_NUM = 0, END_NUM = 100;
var array = [];

function rand(startNum, endNum)
{
    return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
}

document.write("Сгенерированный массив:<br/>");
for (var i = 0; i < SIZE; i++)
{
    array[i] = rand(START_NUM, END_NUM);
    document.write(array[i] + " ");
}