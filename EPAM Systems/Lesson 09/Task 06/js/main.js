window.onload = function ()
{
    var questionsForm = document.getElementsByName("questions")[0];
    var questionsArray =
    [
        {
            text: "If an object is in motion, what kind of energy does it possess?",
            variants:
            [
                {
                    text: "Kinetic energy",
                    isTrueAnswer: true
                },
                {
                    text: "Metabolic energy",
                    isTrueAnswer: false
                },
                {
                    text: "Potential energy",
                    isTrueAnswer: false
                },
                {
                    text: "Caloric energy",
                    isTrueAnswer: false
                }
            ]
        },
        {
            text: "What is the force that holds back a sliding object?",
            variants:
            [
                {
                    text: "Gravity",
                    isTrueAnswer: false
                },
                {
                    text: "Deceleration",
                    isTrueAnswer: false
                },
                {
                    text: "Friction",
                    isTrueAnswer: true
                }
            ]
        },
        {
            text: "At what temperature Fahrenheit does water boil?",
            variants:
            [
                {
                    text: "204",
                    isTrueAnswer: false
                },
                {
                    text: "198",
                    isTrueAnswer: false
                },
                {
                    text: "235",
                    isTrueAnswer: false
                },
                {
                    text: "212",
                    isTrueAnswer: true
                },
                {
                    text: "240",
                    isTrueAnswer: false
                }
            ]
        },
        {
            text: "Force is measured by what unit of measure?",
            variants:
            [
                {
                    text: "Joules",
                    isTrueAnswer: false
                },
                {
                    text: "Calories",
                    isTrueAnswer: false
                },
                {
                    text: "Degrees",
                    isTrueAnswer: false
                },
                {
                    text: "Newtons",
                    isTrueAnswer: true
                }
            ]
        },
        {
            text: "Which particles are found in the nucleus of an atom?",
            variants:
            [
                {
                    text: "Protons",
                    isTrueAnswer: true
                },
                {
                    text: "Photons",
                    isTrueAnswer: false
                },
                {
                    text: "Electrons",
                    isTrueAnswer: false
                }
            ]
        }
    ];
    var element;
    var listElement;
    for (var i = 0; i < questionsArray.length; i++)
    {
        element = document.createElement("p");
        element.innerHTML = (i + 1) + ". " + questionsArray[i].text;
        questionsForm.appendChild(element);
        listElement = document.createElement("ul");
        for (var j = 0; j < questionsArray[i].variants.length; j++)
        {
            element = document.createElement("li");
            element.innerHTML = "<input type='radio' name = 'variant-" + i + "'/><span>" + questionsArray[i].variants[j].text + "</span>";
            listElement.appendChild(element);
        }
        questionsForm.appendChild(listElement);
    }
    element = document.createElement("input");
    element.type = "button";
    element.value = "Complete";
    element.onclick = completeTest;
    questionsForm.appendChild(element);
    for (var i = 0; i < questionsArray.length; i++)
    {
        element = document.createElement("p");
        element.className = "answer-" + i;
        document.body.appendChild(element);
    }
    element = document.createElement("p");
    element.className = "true-answers-percent";
    document.body.appendChild(element);

    function completeTest()
    {
        var variantsElements;
        var isChecked;
        var isTrueAnswer;
        var isTrueAnswerText;
        var trueAnswersCount = 0;
        for (var i = 0; i < questionsArray.length; i++)
        {
            isChecked = false;
            isTrueAnswer = false;
            variantsElements = document.getElementsByName("variant-" + i);
            for (var j = 0; j < questionsArray[i].variants.length; j++)
                if (variantsElements[j].checked)
                {
                    isChecked = true;
                    isTrueAnswer = questionsArray[i].variants[j].isTrueAnswer;
                    break;
                }
            if (isChecked && isTrueAnswer)
            {
                isTrueAnswerText = "True";
                trueAnswersCount++;
            }
            else
            {
                if (isChecked && !isTrueAnswer)
                    isTrueAnswerText = "False";
                else
                    isTrueAnswerText = "Not answered";
            }
            document.getElementsByClassName("answer-" + i)[0].innerHTML = (i + 1) + ". " + isTrueAnswerText;
        }
        document.getElementsByClassName("true-answers-percent")[0].innerHTML = "Percent of true answered questions: " + (trueAnswersCount / questionsArray.length * 100) + "%";
    }
};