function Machine()
{
    this._enabled = false;
    this.enable = function ()
    {
        this._enabled = true;
        alert("Устройство включено!");
    }
    this.disable = function ()
    {
        this._enabled = false;
        alert("Устройство отключено!");
    }
}

function CoffeeMachine(power, capacity)
{
    var WATER_HEAT_CAPACITY = 4200;
    var self = this;
    var timerId;
    var parentDisable;
    this.waterAmount = 0;
    Machine.apply(this, arguments);
    parentDisable = this.disable;
    function getBoilTime()
    {
        return self.waterAmount * WATER_HEAT_CAPACITY * 80 / power;
    }
    this.run = function ()
    {
        if (this._enabled)
            timerId = setTimeout(function () { timerId = null; onReady(); }, getBoilTime());
        else
            alert("Устройство не включено!");
    };
    this.getPower = function ()
    {
        return power;
    }
    this.getWaterAmount = function ()
    {
        return self.waterAmount;
    };
    this.setWaterAmount = function (amount)
    {
        if (amount < 0)
            alert("Количество воды должно быть положительным числом!");
        else
        {
            if (amount > capacity)
                alert("Ёмкость не позволяет залить такое количество воды!");
            else
            {
                self.waterAmount = amount;
                alert("Количество налитой воды: " + amount + " мл");
            }
        }
    };
    this.addWater = function (amount)
    {
        var newWaterAmount = self.waterAmount + amount;
        if (newWaterAmount > capacity)
            alert("Ёмкость не позволяет залить такое количество воды!");
        else
        {
            self.waterAmount = newWaterAmount;
            alert("Количество добавленной воды: " + amount + " мл");
        }
    }
    function onReady()
    {
        alert("Кофе готово!");
    }
    this.setOnReady = function (newOnReady)
    {
        onReady = newOnReady;
    };
    this.stop = function (flag)
    {
        clearTimeout(timerId);
        timerId = false;
        if (flag)
            alert("Процесс приготовления кофе остановлен!");
    };
    this.disable = function ()
    {
        parentDisable.call(this);
        this.stop(false);
    }
    this.isRunning = function ()
    {
        return !!timerId;
    };
}

function Fridge(power)
{
    var food = [];
    var parentDisable;
    Machine.apply(this, arguments);
    parentDisable = this.disable;
    this.getFood = function ()
    {
        return food;
    };
    this.addFood = function (foodArray)
    {
        if (!this._enabled)
        {
            alert("Устройство не включено!");
            return;
        }
        if ((food.length + foodArray.length) > power / 100)
        {
            alert("Данное количество еды не вмещается в холодильник!");
            return;
        }
        for (var i = 0; i < foodArray.length; i++)
            food.push(foodArray[i]);
    };
    this.filterFood = function (filter)
    {
        return food.filter(filter);
    };
    this.removeFood = function (item)
    {
        var index = food.indexOf(item);
        if (index != -1)
        {
            food.splice(index, 1);
            alert("Еда убрана из холодильника!");
        }
        else
            alert("Нет такой еды в холодильнике!");
    };
    this.disable = function ()
    {
        if (food.length)
        {
            alert("Нельзя выключить холодильник, когда внутри еда!");
            return;
        }
        parentDisable.call(this);
    }
}

function createMachine()
{
    var coffeeMachinePower = document.getElementsByName("coffee-machine-power")[0].value;
    var coffeeMachineCapacity = document.getElementsByName("coffee-machine-capacity")[0].value;
    var fridgePower = document.getElementsByName("fridge-power")[0].value;
    if (coffeeMachinePower > 0 && coffeeMachineCapacity > 0 && fridgePower > 0)
    {
        document.getElementById("input-data").style.display = "none";
        document.getElementById("coffee-machine").style.display = "flex";
        document.getElementById("fridge").style.display = "flex";
        coffeeMachine = new CoffeeMachine(coffeeMachinePower, coffeeMachineCapacity);
        fridge = new Fridge(fridgePower);
    }
    else
        alert("Входные данные не введены или введены неверно!");
}

function setCoffeeMachineWaterAmount()
{
    var amount = +prompt("Введите количество воды (мл):", 0);
    if (amount && amount >= 0)
        coffeeMachine.setWaterAmount(amount);
    if (amount < 0)
        alert("Количество воды введено неверно!");
}

function addCoffeeMachineWater()
{
    var amount = +prompt("Введите количество воды (мл):", 0);
    if (amount && amount >= 0)
        coffeeMachine.addWater(amount);
    if (amount < 0)
        alert("Количество воды введено неверно!");
}

function getFridgeFood()
{
    var foodString = "";
    var fridgeFood = fridge.getFood();
    for (var i = 0; i < fridgeFood.length; i++)
    {
        foodString += fridgeFood[i];
        if (i != fridgeFood.length - 1)
            foodString += ", ";
    }
    return foodString != "" ? foodString : "Пусто!";
}

function addFridgeFood()
{
    var foodString = prompt("Введите еду, которую нужно положить в холодильник (через запятую):");
    var foodArray;
    if (foodString && foodString.length > 0)
    {
        foodArray = foodString.split(", ");
        fridge.addFood(foodArray);
    }
}

function removeFridgeFood()
{
    var foodItem = prompt("Укажите еду, которую нужно убрать из холодильника (1 ед.):");
    if (foodItem && foodItem.length > 0)
        fridge.removeFood(foodItem);
}

var coffeeMachine;
var fridge;