function printTime()
{
    var currentTime = new Date();
    var hours, minutes, seconds;
    if (currentTime.getHours() >= 10)
        hours = currentTime.getHours();
    else
        hours = "0" + currentTime.getHours();
    if (currentTime.getMinutes() >= 10)
        minutes = currentTime.getMinutes();
    else
        minutes = "0" + currentTime.getMinutes();
    if (currentTime.getSeconds() >= 10)
        seconds = currentTime.getSeconds();
    else
        seconds = "0" + currentTime.getSeconds();
    document.getElementById("time").textContent = hours + ":" + minutes + ":" + seconds;
}

setInterval(printTime, 1000);