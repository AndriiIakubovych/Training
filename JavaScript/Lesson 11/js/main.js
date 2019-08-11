var isVisible = false;

window.onload = function ()
{
    document.getElementsByName("expact")[0].value = document.getElementById("list").getElementsByTagName("li")[0].innerText + " " + document.getElementById("arrow-down").innerText;
};

window.onclick = function ()
{
    if (event.target.name != "expact")
    {
        document.getElementsByName("expact")[0].value = document.getElementsByName("expact")[0].value.slice(0, document.getElementsByName("expact")[0].value.length - 1);
        document.getElementsByName("expact")[0].value += document.getElementById("arrow-down").innerText;
        document.getElementById("list").style.display = "none";
        isVisible = false;
    }
};

function expactMenu()
{
    if (!isVisible)
    {
        document.getElementsByName("expact")[0].value = document.getElementsByName("expact")[0].value.slice(0, document.getElementsByName("expact")[0].value.length - 1);
        document.getElementsByName("expact")[0].value += document.getElementById("arrow-up").innerText;
        document.getElementById("list").style.display = "block";
    }
    else
    {
        document.getElementsByName("expact")[0].value = document.getElementsByName("expact")[0].value.slice(0, document.getElementsByName("expact")[0].value.length - 1);
        document.getElementsByName("expact")[0].value += document.getElementById("arrow-down").innerText;
        document.getElementById("list").style.display = "none";
    }
    isVisible = !isVisible;
}

function menuElementClick()
{
    document.getElementById("list").style.display = "none";
    document.getElementsByName("expact")[0].value = event.target.innerText + " " + document.getElementById("arrow-down").innerText;
    isVisible = false;
}