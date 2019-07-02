function sum()
{
    var firstNumber = Number(document.getElementsByName("first-number")[0].value);
    var secondNumber = Number(document.getElementsByName("second-number")[0].value);
    var result = firstNumber + secondNumber;
    document.getElementById("result").innerHTML = "Sum of two numbers: " + result;
}