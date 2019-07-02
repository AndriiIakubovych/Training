var hasResult = false;

function onButtonClick()
{
    var display = document.getElementsByName("display")[0];
    var value = event.target.value;
    var valueElement;
    var newDisplayValue = "";
    var isNumber = false;
    var isLastNumber = false;
    var openBracketsCount = 0;
    var closeBracketsCount = 0;
    var result;
    if (value)
    {
        for (var i = 0; i < 10; i++)
            if (Number(value) === i)
            {
                isNumber = true;
                break;
            }
        if (isNumber)
        {
            if (display.value != "0" && !hasResult)
                display.value += value;
            else
            {
                if (display.value.length === 1 && display.value[display.value.length - 1] === "-")
                    display.value += value;
                else
                    display.value = value;
            }
            hasResult = false;
        }
        else
        {
            switch (value)
            {
                case "+":
                    if (display.value[display.value.length - 1] != " " && display.value[display.value.length - 1] != "(" && display.value.length > 0 && !hasResult)
                        display.value += " " + value + " ";
                    break;
                case "-":
                    if (display.value.length === 0 || hasResult)
                        display.value = value;
                    else
                    {
                        if (display.value[display.value.length - 1] != " " && display.value[display.value.length - 1] != "-" && !hasResult)
                            display.value += " " + value + " ";
                    }
                    break;
                case "×":
                    if (display.value[display.value.length - 1] != " " && display.value[display.value.length - 1] != "(" && display.value.length > 0 && !hasResult)
                        display.value += " " + value + " ";
                    break;
                case "/":
                    if (display.value[display.value.length - 1] != " " && display.value[display.value.length - 1] != "(" && display.value.length > 0 && !hasResult)
                        display.value += " " + value + " ";
                    break;
                case "=":
                    if (display.value.length > 0)
                    {
                        try
                        {
                            hasResult = true;
                            for (var i = 0; i < display.value.length; i++)
                                if (display.value[i] != "×" && display.value[i] != ",")
                                    newDisplayValue += display.value[i];
                                else
                                {
                                    if (display.value[i] === "×")
                                        newDisplayValue += "*";
                                    if (display.value[i] === ",")
                                        newDisplayValue += ".";
                                }
                            result = eval(newDisplayValue);
                            display.value = result != "Infinity" ? display.value + " = " + result : "Invalid operation!";
                            newDisplayValue = "";
                            for (var i = 0; i < display.value.length; i++)
                                if (display.value[i] != ".")
                                    newDisplayValue += display.value[i];
                                else
                                    newDisplayValue += ",";
                            display.value = newDisplayValue;
                        }
                        catch (exception)
                        {
                            display.value = "Invalid operation!";
                        }
                    }
                    break;
                case "C":
                    display.value = "";
                    break;
                case "←":
                    if (display.value[display.value.length - 1] != " " && !hasResult)
                        display.value = display.value.substring(0, display.value.length - 1);
                    else
                        if (display.value[display.value.length - 1] === " ")
                            display.value = display.value.substring(0, display.value.length - 3);
                    break;
                case "(":
                    isNumber = false;
                    for (var i = 0; i < 10; i++)
                        if (Number(display.value[display.value.length - 1]) === i)
                        {
                            isNumber = true;
                            break;
                        }
                    if ((!isNumber || display.value[display.value.length - 1] === " ") && display.value[display.value.length - 1] != ")" && !hasResult)
                        display.value += value;
                    else
                        if (hasResult)
                        {
                            display.value = value;
                            hasResult = false;
                        }
                    break;
                case ")":
                    isNumber = false;
                    for (var i = 0; i < 10; i++)
                        if (Number(display.value[display.value.length - 1]) === i)
                        {
                            isNumber = true;
                            break;
                        }
                    for (var i = 0; i < display.value.length; i++)
                    {
                        if (display.value[i] === "(")
                            openBracketsCount++;
                        if (display.value[i] === ")")
                            closeBracketsCount++;
                    }
                    if ((isNumber || display.value[display.value.length - 1] === ")") && openBracketsCount > closeBracketsCount && !hasResult)
                        display.value += value;
                    break;
                case ",":
                    if (display.value.length > 0 && display.value[display.value.length - 1] != " " && display.value[display.value.length - 1] != "," && display.value[display.value.length - 1] != "(" && display.value[display.value.length - 1] != ")" && display.value.substring(display.value.indexOf(" ") + 1, display.value.length).indexOf(",") === -1 && !hasResult)
                        display.value += ",";
                    break;
            }
        }
    }
}