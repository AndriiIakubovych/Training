window.onload = function ()
{
    function Instance()
    {
        this.playerField = new Field("player-field");
        this.computerField = new Field("computer-field");
        this.fieldCoordinates = [];
        this.elementCatched = false;
        this.canStartGame = false;
        this.gameStarted = false;
        this.gameFinished = false;
        this.shotInit = { firstArray: [], secondArray: [], thirdArray: [], fourthArray: [] };
        document.getElementsByClassName("random")[0].addEventListener("click", this.onRandomSetShipsClick.bind(this));
        document.getElementsByClassName("manually")[0].addEventListener("click", this.onManuallySetShipsClick.bind(this));
        document.addEventListener("click", this.onClick.bind(this));
        document.addEventListener("mousemove", this.onMouseMove.bind(this));
        document.addEventListener("contextmenu", this.onContextMenu.bind(this));
        document.getElementsByClassName("start-game")[0].addEventListener("click", this.startGame.bind(this));
    }

    Instance.prototype.createShipsOnPanel = function ()
    {
        var ships, row, ship, deck;
        ships = document.getElementsByClassName("ships")[0];
        for (var i = 0; i < this.playerField.shipsInfo.length; i++)
        {
            row = document.createElement("div");
            row.className = "row";
            ships.appendChild(row);
            for (var j = 0; j < this.playerField.shipsInfo[i].count; j++)
            {
                ship = document.createElement("div");
                ship.className = "ship";
                ship.classList.add("horizontal-ship");
                ship.classList.add(this.playerField.shipsInfo[i].name);
                row.appendChild(ship);
                for (var k = 0; k < this.playerField.shipsInfo[i].decksCount; k++)
                {
                    deck = document.createElement("div");
                    deck.className = "deck";
                    ship.appendChild(deck);
                }
            }
        }
    }

    Instance.prototype.createStatistisOnPanel = function (statusText, field)
    {
        var statistics = document.getElementsByClassName("statistics")[0];
        var header = document.createElement("h2");
        var string, span;
        header.innerHTML = statusText;
        statistics.appendChild(header);
        for (var i = 0; i < field.shipsInfo.length; i++)
        {
            string = document.createElement("p");
            string.innerHTML = "Потоплено " + field.shipsInfo[i].russianName.slice(0, field.shipsInfo[i].russianName.length - 1) + "х: <span class='killed-ship-number " + field.fieldName + "-d-" + field.shipsInfo[i].decksCount + "'>0</span>";
            statistics.appendChild(string);
        }
    }

    Instance.prototype.getFieldCoordinates = function (field)
    {
        for (var i = 0; i < field.fieldCells.length; i++)
        {
            this.fieldCoordinates[i] = [];
            for (var j = 0; j < field.fieldCells.length; j++)
                this.fieldCoordinates[i][j] = { x: field.fieldCells[i][j].getClientRects()[0].left - 1, y: field.fieldCells[i][j].getClientRects()[0].top - this.playerField.cellSize / 4 - 1 };
        }
    }

    Instance.prototype.onRandomSetShipsClick = function ()
    {
        var ships = document.getElementsByClassName("ships")[0];
        ships.style.display = "none";
        this.setType = 0;
        this.playerField.randomSetShips();
        this.playerField.showRandomShips();
        this.canStartGame = true;
        this.showMessage("Корабли расставлены! Можете начинать игру!", true);
    }

    Instance.prototype.onManuallySetShipsClick = function ()
    {
        var ships = document.getElementsByClassName("ships")[0];
        var shipElements = document.getElementsByClassName("ship");
        ships.style.display = "block";
        this.setType = 1;
        this.canStartGame = false;
        for (var i = 0; i < shipElements.length; i++)
            shipElements[i].style.display = "flex";
        this.playerField.manuallySetShips();
        this.manualShipsCount = 0;
        for (var i = 0; i < this.playerField.shipsInfo.length; i++)
            this.manualShipsCount += this.playerField.shipsInfo[i].count;
        this.showMessage("Перетащите мышкой корабли на игровое поле (левая кнопка - взять, правая кнопка - повернуть)!", true);
    }

    Instance.prototype.shoot = function (field, x, y, isYourTurn)
    {
        var isKilled = true;
        var existingShipNumber = -1;
        var shipsCount;
        var canFinishGame = false;
        var result;
        if (field.fieldMatrix[y][x] === 1)
        {
            field.fieldMatrix[y][x] = -1;
            for (var i = 0; i < field.createdShips.length; i++)
                for (var j = 0; j < field.createdShips[i].coordinates.length; j++)
                    if (field.createdShips[i].coordinates[j].x === x && field.createdShips[i].coordinates[j].y === y)
                    {
                        existingShipNumber = i;
                        break;
                    }
            if (existingShipNumber > -1)
                for (var i = 0; i < field.createdShips[existingShipNumber].coordinates.length; i++)
                    if (field.fieldMatrix[field.createdShips[existingShipNumber].coordinates[i].y][field.createdShips[existingShipNumber].coordinates[i].x] === 1)
                    {
                        isKilled = false;
                        break;
                    }
            if (isKilled)
            {
                field.createdShips[existingShipNumber].isKilled = true;
                shipsCount = +document.getElementsByClassName(field.fieldName + "-d-" + field.createdShips[existingShipNumber].decksCount)[0].innerHTML;
                shipsCount += 1;
                document.getElementsByClassName(field.fieldName + "-d-" + field.createdShips[existingShipNumber].decksCount)[0].innerHTML = shipsCount;
                this.showMessage(isYourTurn ? "Вы потопили корабль! Ваш ход!" : "Компьютер потопил корабль! Ход компьютера!", isYourTurn);
                for (var i = 0; i < field.createdShips[existingShipNumber].coordinates.length; i++)
                    field.createShipEncirclement(-field.encirclementValue * 10, field.createdShips[existingShipNumber].arrangementType, field.createdShips[existingShipNumber].decksCount, i, field.createdShips[existingShipNumber].coordinates[i]);
                result = 2;
            }
            else
            {
                this.showMessage(isYourTurn ? "Вы попали в корабль! Ваш ход!" : "Компьютер попал в корабль! Ход компьютера!", isYourTurn);
                result = 1;
            }
            if (!isYourTurn)
                field.fieldCells[y][x].style.backgroundColor = "white";
            field.fieldCells[y][x].style.backgroundImage = "url(images/cross.png)";
            canFinishGame = true;
            for (var i = 0; i < field.createdShips.length; i++)
                if (!field.createdShips[i].isKilled)
                {
                    canFinishGame = false;
                    break;
                }
            if (canFinishGame)
            {
                this.gameFinished = true;
                this.showMessage(isYourTurn ? "Игра окончена! Вы победили!" : "Игра окончена! Вы проиграли!", isYourTurn);
                if (!isYourTurn)
                    for (var i = 0; i < this.computerField.fieldSize; i++)
                        for (var j = 0; j < this.computerField.fieldSize; j++)
                            if (this.computerField.fieldMatrix[i][j] === 1)
                                this.computerField.fieldCells[i][j].style.backgroundColor = "#00496d";
            }
        }
        else
            if (field.fieldMatrix[y][x] != -1)
            {
                field.fieldMatrix[y][x] = -field.encirclementValue;
                field.fieldCells[y][x].style.backgroundImage = "url(images/point.png)";
                this.showMessage(isYourTurn ? "Вы промахнулись! Стреляет компьютер!" : "Компьютер промахнулся! Ваш ход!", !isYourTurn);
                this.turn = isYourTurn ? 1 : 0;
                result = 0;
            }
        return result;
    }

    Instance.prototype.playerShoot = function (e)
    {
        for (var i = 0; i < this.computerField.fieldCells.length; i++)
            for (var j = 0; j < this.computerField.fieldCells.length; j++)
                if (e.target === this.computerField.fieldCells[i][j])
                    if (this.shoot(this.computerField, j, i, true) === 0)
                        this.computerShoot();
    }

    Instance.prototype.computerShoot = function ()
    {
        var coordinateNumber, x, y;
        var context = this;
        var result;
        var numberForRemove;
        var timerId = setInterval(function ()
        {
            if (context.shotInit.firstArray.length > 0)
            {
                coordinateNumber = getRandom(context.shotInit.firstArray.length - 1);
                x = context.shotInit.firstArray[coordinateNumber].x;
                y = context.shotInit.firstArray[coordinateNumber].y;
                context.shotInit.firstArray.splice(coordinateNumber, 1);
                for (var i = 0; i < context.shotInit.thirdArray.length; i++)
                    if (context.shotInit.thirdArray[i].x === x && context.shotInit.thirdArray[i].y === y)
                        context.shotInit.thirdArray[i] = 0;
                numberForRemove = context.shotInit.thirdArray.indexOf(0);
                while (numberForRemove != -1)
                {
                    context.shotInit.thirdArray.splice(numberForRemove, 1);
                    numberForRemove = context.shotInit.thirdArray.indexOf(0);
                }
            }
            else
            {
                if (context.shotInit.secondArray.length > 0)
                {
                    for (var i = 0; i < context.shotInit.secondArray.length; i++)
                        if (context.playerField.fieldMatrix[context.shotInit.secondArray[i].y][context.shotInit.secondArray[i].x] < 0)
                            context.shotInit.secondArray[i] = 0;
                    numberForRemove = context.shotInit.secondArray.indexOf(0);
                    while (numberForRemove != -1)
                    {
                        context.shotInit.secondArray.splice(numberForRemove, 1);
                        numberForRemove = context.shotInit.secondArray.indexOf(0);
                    }
                    coordinateNumber = getRandom(context.shotInit.secondArray.length - 1);
                    x = context.shotInit.secondArray[coordinateNumber].x;
                    y = context.shotInit.secondArray[coordinateNumber].y;
                    context.shotInit.secondArray.splice(coordinateNumber, 1);
                }
                else
                {
                    for (var i = 0; i < context.shotInit.thirdArray.length; i++)
                        if (context.playerField.fieldMatrix[context.shotInit.thirdArray[i].y][context.shotInit.thirdArray[i].x] < 0)
                            context.shotInit.thirdArray[i] = 0;
                    numberForRemove = context.shotInit.thirdArray.indexOf(0);
                    while (numberForRemove != -1)
                    {
                        context.shotInit.thirdArray.splice(numberForRemove, 1);
                        numberForRemove = context.shotInit.thirdArray.indexOf(0);
                    }
                    coordinateNumber = getRandom(context.shotInit.thirdArray.length - 1);
                    x = context.shotInit.thirdArray[coordinateNumber].x;
                    y = context.shotInit.thirdArray[coordinateNumber].y;
                    context.shotInit.thirdArray.splice(coordinateNumber, 1);
                }
            }
            result = context.shoot(context.playerField, x, y, false);
            if (result === 0 || context.gameFinished)
                clearInterval(timerId);
            else
            {
                if (result === 1)
                {
                    if (x > 0 && context.playerField.fieldMatrix[y][x - 1] >= 0)
                        context.shotInit.firstArray.push({ x: x - 1, y: y });
                    if (x < context.playerField.fieldSize - 1 && context.playerField.fieldMatrix[y][x + 1] >= 0)
                        context.shotInit.firstArray.push({ x: x + 1, y: y });
                    if (y > 0 && context.playerField.fieldMatrix[y - 1][x] >= 0)
                        context.shotInit.firstArray.push({ x: x, y: y - 1 });
                    if (y < context.playerField.fieldSize - 1 && context.playerField.fieldMatrix[y + 1][x] >= 0)
                        context.shotInit.firstArray.push({ x: x, y: y + 1 });
                    context.shotInit.fourthArray.push({ x: x, y: y });
                    if (context.shotInit.fourthArray.length > 1)
                    {
                        for (var i = 0; i < context.shotInit.firstArray.length; i++)
                        {
                            if (x === context.shotInit.fourthArray[0].x && context.shotInit.firstArray[i].x != x)
                                context.shotInit.firstArray[i] = 0;
                            if (y === context.shotInit.fourthArray[0].y && context.shotInit.firstArray[i].y != y)
                                context.shotInit.firstArray[i] = 0;
                        }
                        numberForRemove = context.shotInit.firstArray.indexOf(0);
                        while (numberForRemove != -1)
                        {
                            context.shotInit.firstArray.splice(numberForRemove, 1);
                            numberForRemove = context.shotInit.firstArray.indexOf(0);
                        }
                    }
                }
                else
                {
                    context.shotInit.firstArray = [];
                    context.shotInit.fourthArray = [];
                }
            }
        }, 1000);
    }

    Instance.prototype.onClick = function (e)
    {
        var rightClick;
        var decks;
        var existingShipNumber = -1;
        var existingShipsCount = 0;
        if (!e)
            var e = window.event;
        if (e.which)
            rightClick = (e.which == 3);
        else
            if (e.button)
                rightClick = (e.button == 2);
        if (!this.gameStarted)
        {
            if (this.setType === 1 && !rightClick)
            {
                if (!this.elementCatched)
                {
                    this.shipElement = e.target.closest(".ship");
                    this.elementCatched = Boolean(this.shipElement);
                    if (this.elementCatched)
                    {
                        this.offsetX = e.pageX - this.shipElement.getClientRects()[0].left;
                        this.offsetY = e.pageY - this.shipElement.getClientRects()[0].top;
                    }
                    if (!this.elementCatched && this.playerField.createdShips.length > 0)
                    {
                        for (var i = 0; i < this.playerField.createdShips.length; i++)
                            for (var j = 0; j < this.playerField.createdShips[i].coordinates.length; j++)
                                if (e.target === this.playerField.fieldCells[this.playerField.createdShips[i].coordinates[j].y][this.playerField.createdShips[i].coordinates[j].x])
                                {
                                    existingShipNumber = i;
                                    break;
                                }
                        if (existingShipNumber > -1)
                        {
                            for (var i = 0; i < this.playerField.createdShips[existingShipNumber].coordinates.length; i++)
                            {
                                this.playerField.fieldMatrix[this.playerField.createdShips[existingShipNumber].coordinates[i].y][this.playerField.createdShips[existingShipNumber].coordinates[i].x] = 0;
                                this.playerField.createShipEncirclement(-this.playerField.encirclementValue, this.playerField.createdShips[existingShipNumber].arrangementType, this.playerField.createdShips[existingShipNumber].decksCount, i, this.playerField.createdShips[existingShipNumber].coordinates[i]);
                                this.playerField.fieldCells[this.playerField.createdShips[existingShipNumber].coordinates[i].y][this.playerField.createdShips[existingShipNumber].coordinates[i].x].style.backgroundColor = "white";
                                this.playerField.fieldCells[this.playerField.createdShips[existingShipNumber].coordinates[i].y][this.playerField.createdShips[existingShipNumber].coordinates[i].x].style.cursor = "default";
                            }
                            this.manualShipsCount++;
                            this.shipElement = document.getElementsByClassName(this.playerField.createdShips[existingShipNumber].id.slice(0, this.playerField.createdShips[existingShipNumber].id.indexOf("-")))[0];
                            this.shipElement.style.display = "flex";
                            this.playerField.arrangementType = this.playerField.createdShips[existingShipNumber].arrangementType;
                            if (this.playerField.arrangementType == 1)
                            {
                                this.shipElement.classList.remove("horizontal-ship");
                                this.shipElement.classList.add("vertical-ship");
                                this.shipElement.style.top = (e.pageY - this.offsetX) + "px";
                                this.shipElement.style.left = (e.pageX - this.offsetY) + "px";
                            }
                            this.canStartGame = false;
                            this.showMessage("Перетащите мышкой корабли на игровое поле (левая кнопка - взять, правая кнопка - повернуть)!", true);
                            this.elementCatched = true;
                            this.playerField.createdShips.splice(existingShipNumber, 1);
                            this.onMouseMove(e);
                        }
                    }
                }
                else
                {
                    decks = this.shipElement.getElementsByClassName("deck");
                    for (var i = 0; i < decks.length; i++)
                    {
                        decks[i].style.width = decks[i].style.height = "20px";
                        decks[i].style.borderColor = "#032139";
                    }
                    this.shipElement.style.position = "static";
                    if (this.playerField.arrangementType === 1)
                    {
                        this.shipElement.classList.remove("vertical-ship");
                        this.shipElement.classList.add("horizontal-ship");
                    }
                    if (this.playerField.isValid)
                    {
                        for (var i = 0; i < decks.length; i++)
                        {
                            this.playerField.fieldMatrix[this.playerField.coordinates[i].y][this.playerField.coordinates[i].x] = 1;
                            this.playerField.createShipEncirclement(this.playerField.encirclementValue, this.playerField.arrangementType, decks.length, i, this.playerField.coordinates[i]);
                            this.playerField.fieldCells[this.playerField.coordinates[i].y][this.playerField.coordinates[i].x].style.backgroundColor = "#00496d";
                            this.playerField.fieldCells[this.playerField.coordinates[i].y][this.playerField.coordinates[i].x].style.cursor = "move";
                        }
                        for (var i = 0; i < this.playerField.createdShips.length; i++)
                            if (this.playerField.createdShips.length > 0 && this.playerField.createdShips[i].decksCount === decks.length)
                                existingShipsCount++;
                        for (var i = 0; i < this.playerField.shipsInfo.length; i++)
                            if (this.playerField.shipsInfo[i].decksCount === decks.length)
                                this.playerField.createdShips.push({ id: this.playerField.shipsInfo[i].name + "-" + (existingShipsCount + 1), decksCount: this.playerField.shipsInfo[i].decksCount, arrangementType: this.playerField.arrangementType, coordinates: this.playerField.coordinates, isKilled: false });
                        this.shipElement.style.display = "none";
                        this.manualShipsCount--;
                        if (this.manualShipsCount === 0)
                        {
                            this.canStartGame = true;
                            this.showMessage("Корабли расставлены! Можете начинать игру!", true);
                        }
                    }
                    this.elementCatched = false;
                    this.playerField.arrangementType = 0;
                    this.playerField.isValid = false;
                }
            }
        }
        else
            if (!this.gameFinished && this.turn === 0 && !rightClick)
                this.playerShoot(e);
    }

    Instance.prototype.onMouseMove = function (e)
    {
        var decks;
        this.playerField.isValid = false;
        if (this.elementCatched)
        {
            decks = this.shipElement.getElementsByClassName("deck");
            for (var i = 0; i < decks.length; i++)
            {
                decks[i].style.width = this.playerField.cellSize + "px";
                decks[i].style.height = this.playerField.cellSize + "px";
                decks[i].style.borderColor = "red";
            }
            this.shipElement.style.position = "absolute";
            this.shipElement.style.top = (e.pageY - (this.playerField.arrangementType === 0 ? this.offsetY : this.offsetX)) + "px";
            this.shipElement.style.left = (e.pageX - (this.playerField.arrangementType === 0 ? this.offsetX : this.offsetY)) + "px";
            for (var i = 0; i < this.fieldCoordinates.length; i++)
                for (var j = 0; j < this.fieldCoordinates.length; j++)
                    if (e.pageX - (this.playerField.arrangementType === 0 ? this.offsetX : this.offsetY) >= this.fieldCoordinates[i][j].x && e.pageX - (this.playerField.arrangementType === 0 ? this.offsetX : this.offsetY) < this.fieldCoordinates[i][j].x + this.playerField.cellSize + 1 && e.pageY - (this.playerField.arrangementType === 0 ? this.offsetY : this.offsetX) >= this.fieldCoordinates[i][j].y && e.pageY - (this.playerField.arrangementType === 0 ? this.offsetY : this.offsetX) < this.fieldCoordinates[i][j].y + this.playerField.cellSize + 1)
                    {
                        this.playerField.isValid = true;
                        for (var k = 0; k < decks.length; k++)
                            if ((this.playerField.arrangementType === 1 && i + k >= this.fieldCoordinates.length) || (this.playerField.arrangementType === 0 && j + k >= this.fieldCoordinates.length) || this.playerField.fieldMatrix[this.playerField.arrangementType === 0 ? i : i + k][this.playerField.arrangementType === 0 ? j + k : j] > 0)
                            {
                                this.playerField.isValid = false;
                                break;
                            }
                        if (this.playerField.isValid)
                        {
                            this.playerField.coordinates = [];
                            for (var k = 0; k < decks.length; k++)
                            {
                                this.playerField.coordinates[k] = { x: this.playerField.arrangementType === 0 ? j + k : j, y: this.playerField.arrangementType === 0 ? i : i + k };
                                decks[k].style.borderColor = "green";
                            }
                        }
                        else
                            for (var k = 0; k < decks.length; k++)
                                decks[k].style.borderColor = "red";
                        break;
                    }
        }
    }

    Instance.prototype.onContextMenu = function (e)
    {
        if (this.elementCatched)
        {
            if (this.playerField.arrangementType === 0)
            {
                this.shipElement.classList.remove("horizontal-ship");
                this.shipElement.classList.add("vertical-ship");
                this.shipElement.style.top = (e.pageY - this.offsetX) + "px";
                this.shipElement.style.left = (e.pageX - this.offsetY) + "px";
                this.playerField.arrangementType = 1;
            }
            else
            {
                this.shipElement.classList.remove("vertical-ship");
                this.shipElement.classList.add("horizontal-ship");
                this.shipElement.style.top = (e.pageY - this.offsetY) + "px";
                this.shipElement.style.left = (e.pageX - this.offsetX) + "px";
                this.playerField.arrangementType = 0;
            }
            return false;
        }
    }

    Instance.prototype.showMessage = function (text, isGreen)
    {
        var gameStatus = document.getElementsByClassName("game-status")[0];
        gameStatus.style.color = isGreen ? "#59fa49" : "#ff3737";
        gameStatus.innerHTML = text;
    }

    Instance.prototype.startGame = function (e)
    {
        var killedShipsNumbers;
        var step = 2, stepValue;
        var firstStartCoordinatesArray = [], secondStartCoordinatesArray = [], firstCoordinatesArray = [], secondCoordinatesArray = [];
        var hasElement;
        if (!this.gameStarted)
        {
            if (this.canStartGame)
            {
                this.shotInit = { firstArray: [], secondArray: [], thirdArray: [], fourthArray: [] };
                stepValue = step;
                for (var i = 0; i < this.playerField.fieldCells.length; i += stepValue)
                {
                    if (i === stepValue)
                        stepValue += stepValue;
                    if (i > 0)
                    {
                        firstStartCoordinatesArray.push({ x: i, y: 0 });
                        firstStartCoordinatesArray.push({ x: 0, y: i });
                    }
                }
                stepValue = step;
                for (var i = 0; i < this.playerField.fieldCells.length; i += stepValue)
                {
                    if (i === stepValue)
                        stepValue += stepValue;
                    if (i > 0)
                    {
                        secondStartCoordinatesArray.push({ x: i, y: this.playerField.fieldCells.length - 1 });
                        secondStartCoordinatesArray.push({ x: 0, y: this.playerField.fieldCells.length - i - 1 });
                    }
                }
                for (var i = 0; i < firstStartCoordinatesArray.length; i++)
                    for (var j = firstStartCoordinatesArray[i].x, k = firstStartCoordinatesArray[i].y; j < this.playerField.fieldCells.length && k < this.playerField.fieldCells.length; j++, k++)
                        firstCoordinatesArray.push({ x: j, y: k });
                for (var i = 0; i < secondStartCoordinatesArray.length; i++)
                    for (var j = secondStartCoordinatesArray[i].x, k = secondStartCoordinatesArray[i].y; j < this.playerField.fieldCells.length && k >= 0; j++, k--)
                        secondCoordinatesArray.push({ x: j, y: k });
                this.shotInit.secondArray = this.shotInit.secondArray.concat(firstCoordinatesArray, secondCoordinatesArray);
                for (var i = 0; i < this.playerField.fieldCells.length; i++)
                    for (var j = 0; j < this.playerField.fieldCells.length; j++)
                    {
                        this.playerField.fieldCells[i][j].style.cursor = "default";
                        hasElement = false;
                        for (var k = 0; k < this.shotInit.secondArray.length; k++)
                            if (this.shotInit.secondArray[k].x === j && this.shotInit.secondArray[k].y === i)
                            {
                                hasElement = true;
                                break;
                            }
                        if (!hasElement)
                            this.shotInit.thirdArray.push({ x: j, y: i });
                    }
                document.getElementsByClassName("set-ships")[0].style.display = "none";
                document.getElementsByClassName("statistics")[0].style.display = "block";
                killedShipsNumbers = document.getElementsByClassName("killed-ship-number");
                for (var i = 0; i < killedShipsNumbers.length; i++)
                    killedShipsNumbers[i].innerHTML = "0";
                document.getElementsByClassName("start-game")[0].getElementsByTagName("button")[0].innerHTML = "Закончить игру";
                this.computerField.randomSetShips();
                this.gameStarted = true;
                this.turn = getRandom(1);
                if (this.turn === 0)
                    this.showMessage("Игра началась! Ваш ход", true);
                else
                {
                    this.showMessage("Игра началась! Ходит компьютер", false);
                    this.computerShoot();
                }
            }
            else
                this.showMessage("Вы не можете начать игру, не расставив корабли!", false);
        }
        else
        {
            this.playerField.clearField();
            this.computerField.clearField();
            document.getElementsByClassName("set-ships")[0].style.display = "block";
            document.getElementsByClassName("statistics")[0].style.display = "none";
            this.showMessage("Расставьте свои корабли!", true);
            document.getElementsByClassName("start-game")[0].getElementsByTagName("button")[0].innerHTML = "Начать игру";
            this.canStartGame = false;
            this.gameStarted = false;
            this.gameFinished = false;
        }
    }

    function Field(fieldName)
    {
        this.fieldName = fieldName;
        this.fieldSize = 10;
        this.cellSize = 32;
        this.letters = ["А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К"];
        this.shipsInfo = [{ name: "fourdeck", russianName: "четырёхпалубный", decksCount: 4, count: 1 }, { name: "tripledeck", russianName: "трёхпалубный", decksCount: 3, count: 2 }, { name: "doubledeck", russianName: "двухпалубный", decksCount: 2, count: 3 }, { name: "singledeck", russianName: "однопалубный", decksCount: 1, count: 4 }];
        this.fieldCells = this.createField();
        this.fieldMatrix = [];
        this.createdShips = [];
        this.arrangementType = 0;
        this.coordinates = [];
        this.encirclementValue = 2;
    }

    Field.prototype.createField = function ()
    {
        var field = document.getElementsByClassName(this.fieldName)[0];
        var content = field.getElementsByTagName("thead")[0];
        var tr, td;
        var fieldCells = [];
        tr = document.createElement("tr");
        content.appendChild(tr);
        for (var i = 0; i < this.fieldSize + 1; i++)
        {
            td = document.createElement("th");
            tr.appendChild(td);
            if (i > 0)
                td.innerHTML = this.letters[i - 1];
        }
        content = field.getElementsByTagName("tbody")[0];
        for (var i = 0; i < this.fieldSize; i++)
        {
            tr = document.createElement("tr");
            content.appendChild(tr);
            fieldCells[i] = [];
            for (var j = 0; j < this.fieldSize + 1; j++)
            {
                td = document.createElement("td");
                td.style.width = td.style.height = this.cellSize + "px";
                tr.appendChild(td);
                if (j === 0)
                    td.innerHTML = i + 1;
                else
                    fieldCells[i][j - 1] = td;
            }
        }
        return fieldCells;
    }

    Field.prototype.randomSetShips = function ()
    {
        this.clearField();
        for (var i = 0, j = 0; i < this.shipsInfo.length; i++)
            for (var k = 0; k < this.shipsInfo[i].count; k++)
            {
                this.createdShips[j] = { id: this.shipsInfo[i].name + "-" + (k + 1), decksCount: this.shipsInfo[i].decksCount, coordinates: this.getRandomCoordinates(this.shipsInfo[i].decksCount), arrangementType: this.arrangementType, isKilled: false };
                j++;
            }
    }

    Field.prototype.getRandomCoordinates = function (decksCount)
    {
        var x, y;
        this.isValid = false;
        while (!this.isValid)
        {
            this.coordinates = [];
            this.arrangementType = getRandom(1);
            x = getRandom(this.arrangementType === 0 ? this.fieldSize - decksCount : this.fieldSize - 1);
            y = getRandom(this.arrangementType === 0 ? this.fieldSize - 1 : this.fieldSize - decksCount);
            this.isValid = true;
            for (var i = 0; i < decksCount; i++)
                if (this.fieldMatrix[this.arrangementType === 0 ? y : y + i][this.arrangementType === 0 ? x + i : x] > 0)
                {
                    this.isValid = false;
                    break;
                }
            if (this.isValid)
                for (var i = 0; i < decksCount; i++)
                {
                    this.coordinates[i] = { x: this.arrangementType === 0 ? x + i : x, y: this.arrangementType === 0 ? y : y + i };
                    this.fieldMatrix[this.coordinates[i].y][this.coordinates[i].x] = 1;
                    this.createShipEncirclement(this.encirclementValue, this.arrangementType, decksCount, i, this.coordinates[i]);
                }
        }
        return this.coordinates;
    }

    Field.prototype.showRandomShips = function ()
    {
        for (var i = 0; i < this.createdShips.length; i++)
            for (var j = 0; j < this.createdShips[i].coordinates.length; j++)
                this.fieldCells[this.createdShips[i].coordinates[j].y][this.createdShips[i].coordinates[j].x].style.backgroundColor = "#00496d";
    }

    Field.prototype.manuallySetShips = function ()
    {
        this.clearField();
    }

    Field.prototype.createShipEncirclement = function (encirclementValue, arrangementType, decksCount, deckNumber, coordinate)
    {
        if (arrangementType === 0)
        {
            if (deckNumber === 0 && coordinate.x != 0)
            {
                if (coordinate.y != 0)
                    this.fieldMatrix[coordinate.y - 1][coordinate.x - 1] += encirclementValue;
                this.fieldMatrix[coordinate.y][coordinate.x - 1] += encirclementValue;
                if (coordinate.y < this.fieldMatrix.length - 1)
                    this.fieldMatrix[coordinate.y + 1][coordinate.x - 1] += encirclementValue;
            }
            if (coordinate.y != 0)
                this.fieldMatrix[coordinate.y - 1][coordinate.x] += encirclementValue;
            if (coordinate.y < this.fieldMatrix.length - 1)
                this.fieldMatrix[coordinate.y + 1][coordinate.x] += encirclementValue;
            if (deckNumber === decksCount - 1 && coordinate.x < this.fieldMatrix.length - 1)
            {
                if (coordinate.y != 0)
                    this.fieldMatrix[coordinate.y - 1][coordinate.x + 1] += encirclementValue;
                this.fieldMatrix[coordinate.y][coordinate.x + 1] += encirclementValue;
                if (coordinate.y < this.fieldMatrix.length - 1)
                    this.fieldMatrix[coordinate.y + 1][coordinate.x + 1] += encirclementValue;
            }
        }
        else
        {
            if (deckNumber === 0 && coordinate.y != 0)
            {
                if (coordinate.x != 0)
                    this.fieldMatrix[coordinate.y - 1][coordinate.x - 1] += encirclementValue;
                this.fieldMatrix[coordinate.y - 1][coordinate.x] += encirclementValue;
                if (coordinate.x < this.fieldMatrix.length - 1)
                    this.fieldMatrix[coordinate.y - 1][coordinate.x + 1] += encirclementValue;
            }
            if (coordinate.x != 0)
                this.fieldMatrix[coordinate.y][coordinate.x - 1] += encirclementValue;
            if (coordinate.x < this.fieldMatrix.length - 1)
                this.fieldMatrix[coordinate.y][coordinate.x + 1] += encirclementValue;
            if (deckNumber === decksCount - 1 && coordinate.y < this.fieldMatrix.length - 1)
            {
                if (coordinate.x != 0)
                    this.fieldMatrix[coordinate.y + 1][coordinate.x - 1] += encirclementValue;
                this.fieldMatrix[coordinate.y + 1][coordinate.x] += encirclementValue;
                if (coordinate.x < this.fieldMatrix.length - 1)
                    this.fieldMatrix[coordinate.y + 1][coordinate.x + 1] += encirclementValue;
            }
        }
    }

    Field.prototype.clearField = function ()
    {
        this.arrangementType = 0;
        for (var i = 0; i < this.fieldSize; i++)
        {
            this.fieldMatrix[i] = [];
            for (var j = 0; j < this.fieldSize; j++)
            {
                this.fieldMatrix[i][j] = 0;
                this.fieldCells[i][j].style.backgroundColor = "white";
                this.fieldCells[i][j].style.backgroundImage = "none";
                this.fieldCells[i][j].style.cursor = "default";
            }
        }
        this.createdShips = [];
        this.coordinates = [];
    }

    function getRandom(n)
    {
        return Math.floor(Math.random() * (n + 1));
    }

    window.onresize = function ()
    {
        var minWidth = window.getComputedStyle(document.body, null).getPropertyValue("min-width");
        var minHeight = window.getComputedStyle(document.body, null).getPropertyValue("min-height");
        instance.fieldCoordinates = [];
        instance.getFieldCoordinates(instance.playerField);
        document.body.style.backgroundSize = (document.documentElement.clientWidth > +minWidth.slice(0, minWidth.length - 2) ? "100%" : minWidth) + " " + (document.documentElement.clientHeight > +minHeight.slice(0, minHeight.length - 2) ? "100%" : minHeight);
    }

    document.oncontextmenu = function ()
    {
        if (instance.elementCatched)
            return false;
    }

    var instance = new Instance();
    instance.getFieldCoordinates(instance.playerField);
    instance.createShipsOnPanel();
    instance.createStatistisOnPanel("Ваш статус", instance.playerField);
    instance.createStatistisOnPanel("Статус компьютера", instance.computerField);
    window.onresize();
};

;(function (ELEMENT)
{
    ELEMENT.matches = ELEMENT.matches || ELEMENT.mozMatchesSelector || ELEMENT.msMatchesSelector || ELEMENT.oMatchesSelector || ELEMENT.webkitMatchesSelector;
    ELEMENT.closest = ELEMENT.closest || function closest(selector)
    {
        if (!this)
            return null;
        if (this.matches(selector))
            return this;
        if (!this.parentElement)
            return null;
        else
            return this.parentElement.closest(selector);
    };
}
(Element.prototype));