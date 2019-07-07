var START_NUM = 0, END_NUM = 100;

function rand(startNum, endNum)
{
    return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
}

function generateArray()
{
    var N = document.getElementsByName("count").item(0).value;
    var array = [];
    var maxOddElementIndex, maxOddElementValue, oddElementsCount = 0;
    if (N > 0 && N % 1 === 0)
    {
        for (var i = 0; i < N; i++)
            array[i] = rand(START_NUM, END_NUM);
        document.getElementById("array").innerHTML = "Array: ";
        maxOddElementIndex = 0;
        maxOddElementValue = array[0];
        for (var i = 0; i < array.length; i++)
        {
            document.getElementById("array").innerHTML += array[i] + " ";
            if (array[i] > maxOddElementIndex && array[i] % 2 != 0)
            {
                maxOddElementIndex = i;
                maxOddElementValue = array[i];
                oddElementsCount++;
            }
        }
        if (oddElementsCount > 0)
        {
            document.getElementById("result-element-index").innerHTML = "Index of first maximum odd number from array: " + maxOddElementIndex;
            document.getElementById("result-element-value").innerHTML = "Value of first maximum odd number from array: " + maxOddElementValue;
        }
        else
        {
            document.getElementById("result-element-index").innerHTML = "Odd numbers are absent!";
            document.getElementById("result-element-value").innerHTML = "";
        }
    }
    else
    {
        document.getElementById("array").innerHTML = "Number of array elements is wrong!";
        document.getElementById("result-element-index").innerHTML = "";
        document.getElementById("result-element-value").innerHTML = "";
    }
}