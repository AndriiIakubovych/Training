var START_NUM = 0, END_NUM = 100;

function rand(startNum, endNum)
{
    return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
}

function calculateVolume()
{
    var radius = rand(START_NUM, END_NUM);
    alert("The assumed radius is: " + radius);
    alert("Sphere volume with given radius is: " + (Math.round(4 / 3 * Math.PI * Math.pow(radius, 3) * 100) / 100));
}