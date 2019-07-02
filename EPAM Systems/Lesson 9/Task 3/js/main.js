var i = 0;

function increase()
{
    i++;
    document.getElementById("counter").value = i;
}

window.onload = function ()
{
    increase();
}