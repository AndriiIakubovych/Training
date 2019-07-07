function checkExpression()
{
    var expression = document.getElementsByName("expression")[0].value;
    var regexp = /^(([0-1][0-9])|(2[0-3])):[0-5][0-9]:[0-5][0-9]$/;
    alert(regexp.test(expression) ? "Время валидно!" : "Время не валидно!");
}