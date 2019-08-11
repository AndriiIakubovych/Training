var cities =
[
    { name: "Алчевск", enName: "Alchevsk" },
    { name: "Белая Церковь", enName: "Bila Tserkva" },
    { name: "Бердянск", enName: "Berdyansk" },
    { name: "Бровары", enName: "Brovary" },
    { name: "Винница", enName: "Vinnitsa" },
    { name: "Горловка", enName: "Gorlovka" },
    { name: "Днепропетровск", enName: "Dnipropetrovsk" },
    { name: "Донецк", enName: "Donetsk" },
    { name: "Евпатория", enName: "Yevpatoriya" },
    { name: "Житомир", enName: "Zhytomyr" },
    { name: "Запорожье", enName: "Zaporizhzhia" },
    { name: "Ивано-Франковск", enName: "Ivano-Frankivsk" },
    { name: "Каменец-Подольский", enName: "Kamianets-Podilskyi" },
    { name: "Каменское", enName: "Kamenskoe" },
    { name: "Керчь", enName: "Kerch" },
    { name: "Киев", enName: "Kiev" },
    { name: "Кировоград", enName: "Kirovohrad" },
    { name: "Краматорск", enName: "Kramatorsk" },
    { name: "Кременчуг", enName: "Kremenchuk" },
    { name: "Кропивницкий", enName: "Kropyvnytskyi" },
    { name: "Кривой Рог", enName: "Kryvyi Rih" },
    { name: "Лисичанск", enName: "Lysychansk" },
    { name: "Луганск", enName: "Luhansk" },
    { name: "Луцк", enName: "Lutsk" },
    { name: "Львов", enName: "Lviv" },
    { name: "Мариуполь", enName: "Mariupol" },
    { name: "Никополь", enName: "Nikopol" },
    { name: "Одесса", enName: "Odessa" },
    { name: "Полтава", enName: "Poltava" },
    { name: "Ровно", enName: "Rivne" },
    { name: "Севастополь", enName: "Sevastopol" },
    { name: "Симферополь", enName: "Simferopol" },
    { name: "Сумы", enName: "Sumy" },
    { name: "Тернополь", enName: "Ternopil" },
    { name: "Ужгород", enName: "Uzhhorod" },
    { name: "Феодосия", enName: "Feodosia" },
    { name: "Харьков", enName: "Kharkiv" },
    { name: "Хмельницкий", enName: "Khmelnytskyi" },
    { name: "Черкассы", enName: "Cherkasy" },
    { name: "Чернигов", enName: "Chernihiv" },
    { name: "Черновцы", enName: "Chernivtsi" },
    { name: "Ялта", enName: "Yalta" }
];

var icons =
[
    { name: "01d", description: "Ясно" },
    { name: "02d", description: "Немного облачно" },
    { name: "03d", description: "Облачно" },
    { name: "04d", description: "Пасмурно" },
    { name: "09d", description: "Дождливо" },
    { name: "10d", description: "Немного дождливо" },
    { name: "11d", description: "Гроза" },
    { name: "13d", description: "Снег" },
    { name: "50d", description: "Туман" },
    { name: "01n", description: "Ясно" },
    { name: "02n", description: "Немного облачно" },
    { name: "03n", description: "Облачно" },
    { name: "04n", description: "Пасмурно" },
    { name: "09n", description: "Дождливо" },
    { name: "10n", description: "Немного дождливо" },
    { name: "11n", description: "Гроза" },
    { name: "13n", description: "Снег" },
    { name: "50n", description: "Туман" }
];

window.onload = function ()
{
    const DAYS_COUNT = 5;
    var startCity = "Харьков";
    var select = document.getElementsByTagName("select")[0];
    var option, trs, td;
    var months = ["января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря"];
    var days = ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"];
    var date = new Date();
    var newDate;
    document.getElementsByClassName("days-count")[0].innerHTML = "Отображение на ближайшие " + DAYS_COUNT + " дней";
    for (var i = 0; i < cities.length; i++)
    {
        option = document.createElement("option");
        option.value = option.innerHTML = cities[i].name;
        select.appendChild(option);
    }
    document.getElementsByClassName("current-date")[0].innerHTML = date.getDate() + " " + months[date.getMonth()];
    document.getElementsByClassName("current-time")[0].innerHTML = "На " + (date.getHours() < 10 ? "0" + date.getHours() : date.getHours()) + ":" + (date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes());
    trs = document.getElementsByClassName("forecast-table")[0].getElementsByTagName("tr");
    for (var i = 0; i < trs.length; i++)
    {
        if (i === 0)
            for (var j = 0; j < DAYS_COUNT; j++)
            {
                td = document.createElement("td");
                if (j % 2 === 0)
                    td.classList.add("dark");
                td.setAttribute("colspan", "2");
                newDate = new Date();
                newDate.setDate(newDate.getDate() + j + 1);
                td.innerHTML = "<span class='date'>" + (newDate.getDate() < 10 ? "0" + newDate.getDate() : newDate.getDate()) + "." + (newDate.getMonth() < 10 ? "0" + (newDate.getMonth() + 1) : (newDate.getMonth() + 1)) + "</span> <span class='day-name'>" + days[(newDate.getDay() > 0 ? newDate.getDay() - 1 : days.length - 1)] + "</span>";
                trs[i].appendChild(td);
            }
        else
            for (var j = 0, k = 0; j < DAYS_COUNT * 2; j++)
            {
                if (j % 2 === 0)
                {
                    k++;
                    td.classList.add("day");
                }
                else
                    td.classList.add("night");
                td = document.createElement("td");
                if (k % 2 != 0)
                    td.classList.add("dark");
                if (i === 1)
                {
                    if (j % 2 === 0)
                        td.innerHTML = "Ночь";
                    else
                        td.innerHTML = "День";
                }
                trs[i].appendChild(td);
            }
    }
    trs[trs.length - 1].getElementsByTagName("td")[trs[trs.length - 1].getElementsByTagName("td").length - 1].classList.add("day");
    for (var i = 0; i < cities.length; i++)
        if (cities[i].name === startCity)
        {
            document.getElementsByClassName("city")[0].innerHTML = startCity;
            getWeather(cities[i].enName);
            getForecast(cities[i].enName);
            break;
        }
};

function onCityChange()
{
    var select = document.getElementsByTagName("select")[0];
    var city;
    document.getElementsByClassName("city")[0].innerHTML = select.value;
    city = select.value;
    select.value = "Другой город";
    for (var i = 0; i < cities.length; i++)
        if (city === cities[i].name)
        {
            city = cities[i].enName;
            getWeather(city);
            getForecast(city);
            break;
        }
}

function getWeather(city)
{
    var xhr = new XMLHttpRequest();
    var weather;
    var description;
    xhr.open("GET", "http://api.openweathermap.org/data/2.5/weather?q=" + city + ",ua&APPID=adfedb9117fbe9b84cb6aed3037c5c8d&units=metric", true);
    xhr.send();
    xhr.onreadystatechange = function ()
    {
        if (xhr.readyState != 4)
            return;
        if (xhr.status === 200)
        {
            weather = JSON.parse(xhr.responseText);
            for (var i = 0; i < icons.length; i++)
                if (icons[i].name === weather.weather[0].icon)
                    description = icons[i].description;
            document.getElementsByClassName("weather-image")[0].innerHTML = "<img src='images/" + weather.weather[0].icon + ".png' alt='" + description + "'/>";
            document.getElementsByClassName("current-temperature")[0].innerHTML = Math.round(weather.main.temp) + " °С";
            document.getElementsByClassName("current-wind")[0].innerHTML = "<span>" + Math.round(weather.wind.speed) + "</span> м/с";
            document.getElementsByClassName("current-humidity")[0].innerHTML = "<span>" + Math.round(weather.main.humidity) + "</span> %";
            document.getElementsByClassName("current-pressure")[0].innerHTML = "<span>" + Math.round(weather.main.pressure) + "</span> мм рт. ст.";
        }
    }
}

function getForecast(city)
{
    var xhr = new XMLHttpRequest();
    var forecast;
    var tds;
    var newDate, forecastDate;
    var info;
    xhr.open("GET", "http://api.openweathermap.org/data/2.5/forecast?q=" + city + ",ua&APPID=adfedb9117fbe9b84cb6aed3037c5c8d&units=metric", true);
    xhr.send();
    xhr.onreadystatechange = function ()
    {
        if (xhr.readyState != 4)
            return;
        if (xhr.status === 200)
        {
            forecast = JSON.parse(xhr.responseText);
            info = "future-weather";
            tds = document.getElementsByClassName(info)[0].getElementsByTagName("td");
            inputInfo(forecast, tds, newDate, forecastDate, info);
            info = "future-temperature";
            tds = document.getElementsByClassName(info)[0].getElementsByTagName("td");
            inputInfo(forecast, tds, newDate, forecastDate, info);
            info = "future-wind";
            tds = document.getElementsByClassName(info)[0].getElementsByTagName("td");
            inputInfo(forecast, tds, newDate, forecastDate, info);
            info = "future-pressure";
            tds = document.getElementsByClassName(info)[0].getElementsByTagName("td");
            inputInfo(forecast, tds, newDate, forecastDate, info);
        }
    }
}

function inputInfo(forecast, tds, newDate, forecastDate, info)
{
    var description;
    for (var i = 1, j = 0; i < tds.length; i++)
    {
        if (i % 2 != 0)
            j++;
        newDate = new Date();
        newDate.setDate(newDate.getDate() + j);
        for (var k = 0; k < forecast.list.length; k++)
        {
            forecastDate = new Date(forecast.list[k].dt_txt);
            if ((forecastDate.getDate() === newDate.getDate() && forecastDate.getMonth() === newDate.getMonth() && forecastDate.getYear() === newDate.getYear() && forecastDate.getHours() === 0 && i % 2 != 0) || (forecastDate.getDate() === newDate.getDate() && forecastDate.getMonth() === newDate.getMonth() && forecastDate.getYear() === newDate.getYear() && forecastDate.getHours() === 12 && i % 2 === 0))
            {
                switch (info)
                {
                    case "future-weather":
                        for (var l = 0; l < icons.length; l++)
                            if (icons[l].name === forecast.list[k].weather[0].icon)
                                description = icons[l].description;
                        tds[i].innerHTML = "<img src='http://openweathermap.org/img/w/" + forecast.list[k].weather[0].icon + ".png' alt='" + description + "'/>";
                        break;
                    case "future-temperature":
                        tds[i].innerHTML = Math.round(forecast.list[k].main.temp);
                        break;
                    case "future-wind":
                        tds[i].innerHTML = Math.round(forecast.list[k].wind.speed);
                        break;
                    case "future-pressure":
                        tds[i].innerHTML = Math.round(forecast.list[k].main.pressure);
                        break;
                }
                break;
            }
        }
    }
    if (tds[tds.length - 2].innerHTML === "")
        tds[tds.length - 2].innerHTML = "-";
    if (tds[tds.length - 1].innerHTML === "")
        tds[tds.length - 1].innerHTML = "-";
}