function Horse(name)
{
    this.name = name;
    this.mileage = 0;
    this.run = function (value)
    {
        this.mileage += value;
        Horse.prototype.totalMileage += value;
    };
}

function runHorse()
{
    var horseNumber = event.target.parentElement.parentElement.id.split("-")[1];
    var horseInfo = document.getElementById("horse-" + horseNumber);
    var mileage = +prompt("Введите количество километров, которые нужно пробежать:", 0);
    if (mileage && mileage > 0)
    {
        horseInfo.getElementsByTagName("img")[0].src = "images/horse.gif";
        horseInfo.getElementsByTagName("form")[0].getElementsByTagName("input")[0].disabled = true;
        setTimeout(function () { horses[horseNumber - 1].run(mileage); horseInfo.getElementsByTagName("img")[0].src = "images/horse.png"; horseInfo.getElementsByTagName("form")[0].getElementsByTagName("input")[0].disabled = false; }, mileage * 1000);
    }
    else
        if (mileage < 0)
            alert("Километраж задан неверно!");
}

function getHorseMileage()
{
    var horseNumber = event.target.parentElement.parentElement.id.split("-")[1];
    alert(horses[horseNumber - 1].mileage + " км");
}

function createHorse()
{
    var horseName = prompt("Введите имя лошади:");
    var horseInfo;
    var newHorseInfo;
    var total;
    if (horseName && horseName.length > 0)
    {
        horses.push(new Horse(horseName));
        horseInfo = document.getElementsByClassName("horse-info")[0];
        newHorseInfo = horseInfo.cloneNode(true);
        newHorseInfo.classList.remove("invisible");
        newHorseInfo.id = "horse-" + horses.length;
        newHorseInfo.getElementsByTagName("h4")[0].innerHTML += " " + horseName;
        total = document.getElementById("total");
        total.insertAdjacentHTML("beforeBegin", newHorseInfo.outerHTML);
    }
}

function getHorsesTotalMileage()
{
    alert(Horse.prototype.totalMileage + " км");
}

var horses = [];
Horse.prototype.totalMileage = 0;