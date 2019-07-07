var SIZE = 30, START_NUM = 0, END_NUM = 100;
var array = [];
var index = -1;
var element;

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

element = prompt("Введите значение элемента массива, которое необходимо найти:", 0);
if (element)
{
    for (var i = 0; i < SIZE; i++)
    {
        if (array[i] === Number(element))
        {
            index = i;
            break;
        }
    }
    document.write("<br/><br/>Индекс элемента массива со значением " + element + ": " + index);
}