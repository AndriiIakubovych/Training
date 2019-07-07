﻿function Calculator()
{
    var methods =
    {
        "-": function (a, b)
        {
            return a - b;
        },
        "+": function (a, b)
        {
            return a + b;
        }
    };
    this.calculate = function (str)
    {
        var split = str.split(" "), a = +split[0], op = split[1], b = +split[2];
        if (!methods[op] || isNaN(a) || isNaN(b))
        {
            return "Неверная операция!";
        }
        return methods[op](+a, +b);
    }
    this.addMethod = function (name, func)
    {
        methods[name] = func;
    };
}

var calc = new Calculator;

calc.addMethod("*", function (a, b)
{
    return a * b;
});
calc.addMethod("/", function (a, b)
{
    return a / b;
});
calc.addMethod("**", function (a, b)
{
    return Math.pow(a, b);
});