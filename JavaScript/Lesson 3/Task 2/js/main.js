function makeCounter()
{
    var i = 10;

    return function()
    {
        if (i >= 0)
            document.getElementById("timer").textContent = i;
        else
        {
            alert("BOOOM!!!");
            clearTimeout(n);
        }
        return --i;
    };
}

var n = setInterval(makeCounter(), 1000);