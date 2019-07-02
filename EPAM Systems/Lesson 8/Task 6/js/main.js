var opacity = 1;

function changeTransparency()
{
    var elements = document.getElementsByClassName("play");
    opacity -= 0.1;
    for (var i = 0; i < elements.length; i++)
        elements[i].style.opacity = opacity;
}