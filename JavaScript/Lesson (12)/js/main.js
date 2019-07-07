window.onload = function ()
{
    var previous = document.querySelector(".previous");
    var next = document.querySelector(".next");
    var position = 0;
    var maxWidth = document.querySelectorAll("li").length * 130 - carousel.clientWidth;

    previous.onclick = function ()
    {
        position += 390;
        if (position > 0)
            position = 0;
        list.style.marginLeft = position + "px";
    };

    next.onclick = function ()
    {
        position -= 390;
        if (position < -maxWidth)
            position = -maxWidth;
        list.style.marginLeft = position + "px";
    };
}