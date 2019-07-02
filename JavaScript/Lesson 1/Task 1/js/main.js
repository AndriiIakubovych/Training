window.onload = function ()
{
    calculateForThreeNumbers();
    calculateForFourNumbers();
    calculateForFiveNumbers();
}

function calculateForThreeNumbers()
{
    var a = Number(document.getElementsByName("first-number")[0].value);
    var b = Number(document.getElementsByName("second-number")[0].value);
    var c = Number(document.getElementsByName("third-number")[0].value);
    if (a > b && a > c)
    {
        a *= 100;
        if (b > c)
            b *= 10;
        else
            c *= 10;
    }
    if (b > a && b > c)
    {
        b *= 100;
        if (a > c)
            a *= 10;
        else
            c *= 10;
    }
    if (c > a && c > b)
    {
        c *= 100;
        if (a > b)
            a *= 10;
        else
            b *= 10;
    }
    document.getElementById("first-result").innerHTML = "Новые значения переменных: " + a + ", " + b + ", " + c;
}

function calculateForFourNumbers()
{
    var a = Number(document.getElementsByName("fourth-number")[0].value);
    var b = Number(document.getElementsByName("fifth-number")[0].value);
    var c = Number(document.getElementsByName("sixth-number")[0].value);
    var d = Number(document.getElementsByName("seventh-number")[0].value);
    if (a > b && a > c && a > d)
    {
        a *= 1000;
        if (b > c && b > d)
        {
            b *= 100;
            if (c > d)
                c *= 10;
            else
                d *= 10;
        }
        if (c > b && c > d)
        {
            c *= 100;
            if (b > d)
                b *= 10;
            else
                d *= 10;
        }
        if (d > b && d > c)
        {
            d *= 100;
            if (b > c)
                b *= 10;
            else
                c *= 10;
        }
    }
    if (b > a && b > c && b > d)
    {
        b *= 1000;
        if (a > c && a > d)
        {
            a *= 100;
            if (c > d)
                c *= 10;
            else
                d *= 10;
        }
        if (c > a && c > d)
        {
            c *= 100;
            if (a > d)
                a *= 10;
            else
                d *= 10;
        }
        if (d > a && d > c)
        {
            d *= 100;
            if (a > c)
                a *= 10;
            else
                c *= 10;
        }
    }
    if (c > a && c > b && b > d)
    {
        c *= 1000;
        if (a > b && a > d)
        {
            a *= 100;
            if (c > d)
                c *= 10;
            else
                d *= 10;
        }
        if (b > a && b > d)
        {
            b *= 100;
            if (a > d)
                a *= 10;
            else
                d *= 10;
        }
        if (d > a && d > b)
        {
            d *= 100;
            if (a > b)
                a *= 10;
            else
                b *= 10;
        }
    }
    if (d > a && d > b && d > c)
    {
        d *= 1000;
        if (a > b && a > c)
        {
            a *= 100;
            if (b > c)
                b *= 10;
            else
                c *= 10;
        }
        if (b > a && b > c)
        {
            b *= 100;
            if (a > c)
                a *= 10;
            else
                c *= 10;
        }
        if (c > a && c > b)
        {
            c *= 100;
            if (a > b)
                a *= 10;
            else
                b *= 10;
        }
    }
    document.getElementById("second-result").innerHTML = "Новые значения переменных: " + a + ", " + b + ", " + c + ", " + d;
}

function calculateForFiveNumbers()
{
    var a = Number(document.getElementsByName("eighth-number")[0].value);
    var b = Number(document.getElementsByName("ninth-number")[0].value);
    var c = Number(document.getElementsByName("tenth-number")[0].value);
    var d = Number(document.getElementsByName("eleventh-number")[0].value);
    var e = Number(document.getElementsByName("twelfth-number")[0].value);
    var n = 1;
    var array = [a, b, c, d, e];
    for (var i = 0; i < array.length - 1; i++)
        n *= 10;
    array.sort(function (n1, n2) { if (n1 < n2) return 1; if (n1 > n2) return -1; })
    for (var i = 0; i < array.length; i++)
    {
        array[i] *= n;
        n /= 10;
    }
    for (var i = 0; i < array.length; i++)
    {
        if (Number(array[i].toString().slice(0, a.toString().length)) === a)
            a = array[i];
        else
        {
            if (Number(array[i].toString().slice(0, b.toString().length)) === b)
                b = array[i];
            else
            {
                if (Number(array[i].toString().slice(0, c.toString().length)) === c)
                    c = array[i];
                else
                {
                    if (Number(array[i].toString().slice(0, d.toString().length)) === d)
                        d = array[i];
                    else
                        if (Number(array[i].toString().slice(0, e.toString().length)) === e)
                            e = array[i];
                }
            }
        }
    }
    document.getElementById("third-result").innerHTML = "Новые значения переменных: " + a + ", " + b + ", " + c + ", " + d + ", " + e;
}