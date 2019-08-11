window.onload = function ()
{
    function mySuperBind(functionToRun, newThis)
    {
        return function ()
        {
            return functionToRun.apply(newThis, arguments);
        };
    }

    function sayHi()
    {
        var text = this.name + " сказал:";
        for (var i = 0; i < arguments.length; i++)
            text += i == 0 ? " \"" + arguments[i] : " " + arguments[i];
        text += "!\"";
        alert(text);
    }

    var user = { name: "Василий" };
    var hello = mySuperBind(sayHi, user);
    hello("Теперь", "функция-обёртка", "принимает", "неограниченное", "количество", "аргументов");
};