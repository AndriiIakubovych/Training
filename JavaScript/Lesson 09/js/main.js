function Horse(name)
{
    var MAX_TIREDNESS = 10;
    var self = this;
    this.name = name;
    this.mileage = 0;
    this.tiredness = 0;
    this.run = function (info, value)
    {
        var newMileage = this.mileage + value;
        var animationStarted = true;
        setTimeout(function overcome()
        {
            if (self.tiredness < MAX_TIREDNESS)
            {
                if (self.tiredness === 0 || animationStarted)
                    changeAnimationMode(info, true);
                self.mileage++;
                self.tiredness++;
                Horse.prototype.totalMileage++;
                console.log(self.mileage);
                timerId = setTimeout(overcome, 1000);
                if (self.mileage === newMileage)
                {
                    changeAnimationMode(info, false);
                    changeRunButtonState(info, false);
                    clearTimeout(timerId);
                }
            }
            else
            {
                changeAnimationMode(info, false);
                animationStarted = false;
                if (self.tiredness >= MAX_TIREDNESS)
                    self.tiredness = 0;
                timerId = setTimeout(overcome, 5000);
            }
        }, 1);
    };
}

function runHorse()
{
    var horseNumber = event.target.parentElement.parentElement.id.split("-")[1];
    var horseInfo = document.getElementById("horse-" + horseNumber);
    var mileage = +prompt("Введите количество километров, которые нужно пробежать:", 0);
    if (mileage && mileage > 0)
    {
        changeRunButtonState(horseInfo, true);
        horses[horseNumber - 1].run(horseInfo, mileage);
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

function changeAnimationMode(horseInfo, animateHorse)
{
    horseInfo.getElementsByTagName("img")[0].src = animateHorse ? "images/horse.gif" : "images/horse.png";
}

function changeRunButtonState(horseInfo, disabledState)
{
    horseInfo.getElementsByTagName("form")[0].getElementsByTagName("input")[0].disabled = disabledState;
}

var horses = [];
Horse.prototype.totalMileage = 0;