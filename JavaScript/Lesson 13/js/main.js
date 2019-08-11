window.onload = function ()
{
    var START_NUM = 0, END_NUM = 100;
    var MAX_HEX_VALUE = 16;
    var MAX_HEX_SIZE = 6;
    var TABLE_SIZE = 8;
    var CELL_SIZE = "30px";
    var DELAY = 1;
    var table = renderTable(TABLE_SIZE);
    var tds = table.querySelectorAll("td");
    var offset;
    var interval;
    addCommonStyles(tds);
    positionTable(table);
    offset = getCellsOffset(tds);
    positionCells(tds);
    startAnimation(tds);

    function renderTable(size)
    {
        var table = document.createElement("table");
        var tr;
        var td;
        for (var i = 0; i < size; i++)
        {
            tr = document.createElement("tr");
            for (var j = 0; j < size; j++)
            {
                td = document.createElement("td");
                td.textContent = rand(START_NUM, END_NUM);
                setCellColor(td)
                tr.appendChild(td);
            }
            table.appendChild(tr);
        }
        document.body.appendChild(table);
        return table;
    }

    function rand(startNum, endNum)
    {
        return Math.floor(startNum + Math.random() * ((endNum + 1) - startNum));
    }

    function addCommonStyles(tds)
    {
        for (var i = 0; i < tds.length; i++)
        {
            tds[i].style.width = CELL_SIZE;
            tds[i].style.height = CELL_SIZE;
            tds[i].style.textAlign = "center";
            tds[i].style.lineHeight = CELL_SIZE;
        }
    }

    function getRandomHexColor()
    {
        var hexColor = "#";
        for (var i = 0; i < MAX_HEX_SIZE; i++)
            hexColor += rand(0, MAX_HEX_VALUE - 1).toString(MAX_HEX_VALUE);
        return hexColor;
    }

    function getInvertedHexColor(hexColor)
    {
        var color = hexColor;
        color = color.substring(1);
        color = parseInt(color, MAX_HEX_VALUE);
        color = 0xFFFFFF ^ color;
        color = color.toString(MAX_HEX_VALUE);
        color = ("000000" + color).slice(-MAX_HEX_SIZE);
        return "#" + color;
    }

    function positionTable(table)
    {
        table.style.position = "absolute";
        table.style.top = "50%";
        table.style.left = "50%";
        table.style.marginTop = -table.offsetHeight / 2 + "px";
        table.style.marginLeft = -table.offsetWidth / 2 + "px";
    }

    function positionCells(tds)
    {
        for (var i = 0; i < tds.length; i++)
        {
            tds[i].style.position = "absolute";
            tds[i].style.top = offset[i].top + "px";
            tds[i].style.left = offset[i].left + "px";
        }
    }

    function setCellColor(td)
    {
        var mainColor;
        var invertedColor;
        mainColor = getRandomHexColor();
        td.style.backgroundColor = mainColor;
        invertedColor = getInvertedHexColor(mainColor);
        td.style.color = invertedColor;
    }

    function getCellsOffset(tds)
    {
        var array = [];
        for (var i = 0; i < tds.length; i++)
            array.push({ top: tds[i].offsetTop, left: tds[i].offsetLeft });
        return array;
    }

    function startAnimation(tds)
    {
        var array = ["top", "bottom", "left", "right"];
        for (var i = 0; i < tds.length; i++)
        {
            tds[i].direction = array[rand(0, array.length - 1)];
            tds[i].style.top = (parseInt(tds[i].style.top) + rand(0, 5)) + "px";
            tds[i].style.left = (parseInt(tds[i].style.left) + rand(0, 5)) + "px";
        }
        interval = setInterval(function () { animate(tds); }, DELAY);
    }

    function animate(tds)
    {
        var positions = getCellsOffset(tds);
        for (var i = 0; i < tds.length; i++)
            switch (tds[i].direction)
            {
                case "top":
                    if (tds[i].style.top != -table.offsetTop + "px")
                        tds[i].style.top = (positions[i].top - 1) + "px";
                    else
                    {
                        tds[i].direction = "bottom";
                        setCellColor(tds[i]);
                    }
                    break;
                case "bottom":
                    if (tds[i].style.top != (table.offsetTop + offset[offset.length - 1].top + 2) + "px")
                        tds[i].style.top = (positions[i].top + 1) + "px";
                    else
                    {
                        tds[i].direction = "top";
                        setCellColor(tds[i]);
                    }
                    break;
                case "left":
                    if (tds[i].style.left != -table.offsetLeft + "px")
                        tds[i].style.left = (positions[i].left - 1) + "px";
                    else
                    {
                        tds[i].direction = "right";
                        setCellColor(tds[i]);
                    }
                    break;
                case "right":
                    if (tds[i].style.left != (table.offsetLeft + offset[offset.length - 1].left + 2) + "px")
                        tds[i].style.left = (positions[i].left + 1) + "px";
                    else
                    {
                        tds[i].direction = "left";
                        setCellColor(tds[i]);
                    }
                    break;
            }
    }

    window.onresize = function ()
    {
        clearInterval(interval);
        document.body.removeChild(table);
        table = renderTable(TABLE_SIZE);
        tds = table.querySelectorAll("td");
        addCommonStyles(tds);
        positionTable(table);
        offset = getCellsOffset(tds);
        positionCells(tds);
        startAnimation(tds);
    }
};