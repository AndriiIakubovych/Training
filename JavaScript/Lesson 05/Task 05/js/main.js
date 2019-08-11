function Accumulator(startingValue)
{
    this.value = startingValue;
    this.read = function ()
    {
        this.value += +prompt("Введите число:", 0);
    }
}

var accumulator;

window.onload = function ()
{
    var beginValue = +prompt("Введите начальное значение:", 1);
    accumulator = new Accumulator(beginValue ? beginValue : 0);
};