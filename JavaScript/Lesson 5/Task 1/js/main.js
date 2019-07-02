window.onload = function ()
{
    var flag = true;
    var calculator =
    {
        read: function ()
        {
            this.a = +prompt("Введите первое значение:", 0);
            if (this.a)
                this.b = +prompt("Введите второе значение:", 0);
            if (!this.a || !this.b)
                flag = false;
        },
        sum: function ()
        {
            return (this.a + this.b);
        },
        mul: function ()
        {
            return (this.a * this.b);
        }
    };

    calculator.read();
    if (flag)
    {
        alert(calculator.sum());
        alert(calculator.mul());
    }
}