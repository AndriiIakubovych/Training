var START_NUM = 1, END_NUM = 9;

function rand(startNum, endNum)
{
    return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
}

document.write("<img src='images/" + rand(START_NUM, END_NUM) + ".jpg' alt='Nature'/>");