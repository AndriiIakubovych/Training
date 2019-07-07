window.onload = function ()
{
    var flag = true;

    function Calculator()
    {
        this.read = function ()
        {
            this.a = +prompt("Введите первое значение:", 0);
            if (this.a)
                this.b = +prompt("Введите второе значение:", 0);
            if (!this.a || !this.b)
                flag = false;
        };
        this.sum = function ()
        {
            return (this.a + this.b);
        };
        this.mul = function ()
        {
            return (this.a * this.b);
        };
    }

    var calculator = new Calculator();
    calculator.read();
    if (flag)
    {
        alert("Сумма = " + calculator.sum());
        alert("Произведение = " + calculator.mul());
    }
}