window.onload = function ()
{
    var ball = document.getElementById("ball");
    var position = 0;
    var moveRight = true, moveBottom = false, moveLeft = false, moveTop = false;

    setInterval(move, 5);

    function move()
    {
        if (moveRight)
        {
            if (ball.style.left != (document.documentElement.clientWidth - ball.clientWidth) + "px")
            {
                position += 1;
                ball.style.left = position + "px";
                ball.style.top = "0px";
            }
            else
            {
                position = 0;
                moveRight = false;
                moveBottom = true;
            }
        }
        if (moveBottom)
        {
            if (ball.style.top != (document.documentElement.clientHeight - ball.clientHeight) + "px")
            {
                position += 1;
                ball.style.top = position + "px";
                ball.style.left = (document.documentElement.clientWidth - ball.clientWidth) + "px";
            }
            else
            {
                position = document.documentElement.clientWidth - ball.clientWidth;
                moveBottom = false;
                moveLeft = true;
            }
        }
        if (moveLeft)
        {
            if (ball.style.left != "0px")
            {
                position -= 1;
                ball.style.left = position + "px";
                ball.style.top = (document.documentElement.clientHeight - ball.clientHeight) + "px";
            }
            else
            {
                position = document.documentElement.clientHeight - ball.clientHeight;
                moveLeft = false;
                moveTop = true;
            }
        }
        if (moveTop)
        {
            if (ball.style.top != "0px")
            {
                position -= 1;
                ball.style.top = position + "px";
                ball.style.left = "0px";
            }
            else
            {
                position = 0;
                moveTop = false;
                moveRight = true;
            }
        }
    }

    window.onresize = function ()
    {
        position = 0;
        moveRight = true;
        moveBottom = false;
        moveLeft = false;
        moveTop = false;
    }
};