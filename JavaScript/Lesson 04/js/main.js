window.onload = function ()
{
    var actions =
    {
        AND: function (statesArray)
        {
            return statesArray[0] && statesArray[1];
        },
        OR: function (statesArray)
        {
            return statesArray[0] || statesArray[1];
        },
        XOR: function (statesArray)
        {
            return statesArray[0] ^ statesArray[1];
        },
        NOT: function (statesArray)
        {
            return !statesArray[0];
        }
    };
    var getSignal = document.getElementsByClassName("get-signal")[0];
    document.getElementsByClassName("bulb")[0].innerHTML = getBulbElementSignal(initializeScheme());

    function initializeScheme()
    {
        var scheme =
        {
            name: "Gate",
            type: "XOR",
            children:
            [
                {
                    name: "Gate",
                    type: "OR",
                    children:
                    [
                        {
                            name: "Gate",
                            type: "NOT",
                            children:
                            [
                                {
                                    name: "Switch",
                                    type: +document.getElementsByClassName("switch-1")[0].value === 0 ? "OFF" : "ON",
                                    state: +document.getElementsByClassName("switch-1")[0].value
                                }
                            ]
                        },
                        {
                            name: "Gate",
                            type: "AND",
                            children:
                            [
                                {
                                    name: "Gate",
                                    type: "OR",
                                    children:
                                    [
                                        {
                                            name: "Gate",
                                            type: "NOT",
                                            children:
                                            [
                                                {
                                                    name: "Gate",
                                                    type: "OR",
                                                    children:
                                                    [
                                                        {
                                                            name: "Gate",
                                                            type: "AND",
                                                            children:
                                                            [
                                                                {
                                                                    name: "Switch",
                                                                    type: +document.getElementsByClassName("switch-2")[0].value === 0 ? "OFF" : "ON",
                                                                    state: +document.getElementsByClassName("switch-2")[0].value
                                                                },
                                                                {
                                                                    name: "Switch",
                                                                    type: +document.getElementsByClassName("switch-3")[0].value === 0 ? "OFF" : "ON",
                                                                    state: +document.getElementsByClassName("switch-3")[0].value
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            name: "Switch",
                                                            type: +document.getElementsByClassName("switch-4")[0].value === 0 ? "OFF" : "ON",
                                                            state: +document.getElementsByClassName("switch-4")[0].value
                                                        }
                                                    ]
                                                }
                                            ]
                                        },
                                        {
                                            name: "Gate",
                                            type: "OR",
                                            children:
                                            [
                                                {
                                                    name: "Gate",
                                                    type: "XOR",
                                                    children:
                                                    [
                                                        {
                                                            name: "Gate",
                                                            type: "AND",
                                                            children:
                                                            [
                                                                {
                                                                    name: "Gate",
                                                                    type: "AND",
                                                                    children:
                                                                    [
                                                                        {
                                                                            name: "Gate",
                                                                            type: "OR",
                                                                            children:
                                                                            [
                                                                                {
                                                                                    name: "Switch",
                                                                                    type: +document.getElementsByClassName("switch-5")[0].value === 0 ? "OFF" : "ON",
                                                                                    state: +document.getElementsByClassName("switch-5")[0].value
                                                                                },
                                                                                {
                                                                                    name: "Switch",
                                                                                    type: +document.getElementsByClassName("switch-6")[0].value === 0 ? "OFF" : "ON",
                                                                                    state: +document.getElementsByClassName("switch-6")[0].value
                                                                                }
                                                                            ]
                                                                        },
                                                                        {
                                                                            name: "Switch",
                                                                            type: +document.getElementsByClassName("switch-7")[0].value === 0 ? "OFF" : "ON",
                                                                            state: +document.getElementsByClassName("switch-7")[0].value
                                                                        }
                                                                    ]
                                                                },
                                                                {
                                                                    name: "Gate",
                                                                    type: "NOT",
                                                                    children:
                                                                    [
                                                                        {
                                                                            name: "Switch",
                                                                            type: +document.getElementsByClassName("switch-8")[0].value === 0 ? "OFF" : "ON",
                                                                            state: +document.getElementsByClassName("switch-8")[0].value
                                                                        }
                                                                    ]
                                                                }
                                                            ]
                                                        },
                                                        {
                                                            name: "Gate",
                                                            type: "XOR",
                                                            children:
                                                            [
                                                                {
                                                                    name: "Switch",
                                                                    type: +document.getElementsByClassName("switch-9")[0].value === 0 ? "OFF" : "ON",
                                                                    state: +document.getElementsByClassName("switch-9")[0].value
                                                                },
                                                                {
                                                                    name: "Switch",
                                                                    type: +document.getElementsByClassName("switch-10")[0].value === 0 ? "OFF" : "ON",
                                                                    state: +document.getElementsByClassName("switch-10")[0].value
                                                                }
                                                            ]
                                                        }
                                                    ]
                                                },
                                                {
                                                    name: "Gate",
                                                    type: "AND",
                                                    children:
                                                    [
                                                        {
                                                            name: "Switch",
                                                            type: +document.getElementsByClassName("switch-11")[0].value === 0 ? "OFF" : "ON",
                                                            state: +document.getElementsByClassName("switch-11")[0].value
                                                        },
                                                        {
                                                            name: "Switch",
                                                            type: +document.getElementsByClassName("switch-12")[0].value === 0 ? "OFF" : "ON",
                                                            state: +document.getElementsByClassName("switch-12")[0].value
                                                        }
                                                    ]
                                                }
                                            ]
                                        }
                                    ]
                                },
                                {
                                    name: "Gate",
                                    type: "NOT",
                                    children:
                                    [
                                        {
                                            name: "Gate",
                                            type: "AND",
                                            children:
                                            [
                                                {
                                                    name: "Switch",
                                                    type: +document.getElementsByClassName("switch-13")[0].value === 0 ? "OFF" : "ON",
                                                    state: +document.getElementsByClassName("switch-13")[0].value
                                                },
                                                {
                                                    name: "Switch",
                                                    type: +document.getElementsByClassName("switch-14")[0].value === 0 ? "OFF" : "ON",
                                                    state: +document.getElementsByClassName("switch-14")[0].value
                                                }
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                },
                {
                    name: "Switch",
                    type: +document.getElementsByClassName("switch-15")[0].value === 0 ? "OFF" : "ON",
                    state: +document.getElementsByClassName("switch-15")[0].value
                }
            ]
        };
        return scheme;
    }

    function getBulbElementSignal(node)
    {
        var state;
        var statesArray;
        switch (node.name)
        {
            case "Switch":
                state = node.state;
                break;
            case "Gate":
                statesArray = [];
                for (var i = 0; i < node.children.length; i++)
                    statesArray.push(getBulbElementSignal(node.children[i]));
                state = actions[node.type](statesArray);
                break;
        }
        return state;
    }

    getSignal.onclick = function ()
    {
        var elements = document.getElementsByTagName("input");
        var hasError = false;
        for (var i = 0; i < elements.length - 1; i++)
            if (elements[i].value != "0" && elements[i].value != "1")
            {
                hasError = true;
                break;
            }
        if (!hasError)
            document.getElementsByClassName("bulb")[0].innerHTML = getBulbElementSignal(initializeScheme());
        else
            alert("Значение некоторых элементов введено неверно!");
    }
};