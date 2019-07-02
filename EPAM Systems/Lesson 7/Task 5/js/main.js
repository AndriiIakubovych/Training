var counter = 0;

function getClickCount()
{
    counter++;
    document.getElementById("click-counter").value = "Pressed " + counter + " times";
}

window.onload = function ()
{
    document.getElementById("click-counter").value = "Pressed " + counter + " times";
}