window.onload = function ()
{
    var dayOfWeek = [{ key: 0, name: "Sunday" }, { key: 1, name: "Monday" }, { key: 2, name: "Tuesday" }, { key: 3, name: "Wednesday" }, { key: 4, name: "Thursday" }, { key: 5, name: "Friday" }, { key: 6, name: "Saturday" }];
    var today = new Date().getDay();
    for (var i = 0; i < dayOfWeek.length; i++)
        if (dayOfWeek[i].key === today)
            document.getElementById("day-of-week-name").innerHTML = dayOfWeek[i].name;
};