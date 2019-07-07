function swap()
{
    var a = Number(document.getElementsByName("first-number")[0].value);
    var b = Number(document.getElementsByName("second-number")[0].value);
    var c = a;
    a = b;
    b = c;
    document.getElementById("first-result").innerHTML = "С использованием третьей переменной: a = " + a + ", b = " + b;
    a = Number(document.getElementsByName("first-number")[0].value);
    b = Number(document.getElementsByName("second-number")[0].value);
    a = a + b;
    b = b - a;
    b = -b;
    a = a - b;
    document.getElementById("second-result").innerHTML = "Без использования третьей переменной: a = " + a + ", b = " + b;
}