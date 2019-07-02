function changeImage(imageNumber, mouseMoved)
{
    switch (imageNumber)
    {
        case 0:
            if (mouseMoved)
            {
                document.getElementById("second-image").src = "images/wolf.png";
                document.getElementById("third-image").src = "images/hare.png";
            }
            else
            {
                document.getElementById("second-image").src = "images/hare.png";
                document.getElementById("third-image").src = "images/wolf.png";
            }
            break;
        case 1:
            if (mouseMoved)
            {
                document.getElementById("first-image").src = "images/wolf.png";
                document.getElementById("third-image").src = "images/fox.png";
            }
            else
            {
                document.getElementById("first-image").src = "images/fox.png";
                document.getElementById("third-image").src = "images/wolf.png";
            }
            break;
        case 2:
            if (mouseMoved)
                document.getElementById("third-image").src = "images/bear.png";
            else
                document.getElementById("third-image").src = "images/wolf.png";
            break;
    }
}