function calculateDaysCount()
{
    var birthdate = new Date(document.getElementsByName("birthdate")[0].value);
    var today = new Date();
    if (document.getElementsByName("birthdate")[0].value.toString() != "")
    {
        birthdate.setYear(today.getFullYear());
        birthdate.setHours(0);
        birthdate.setMinutes(0);
        today.setHours(0);
        today.setMinutes(0);
        if (today > birthdate)
            birthdate.setYear(birthdate.getFullYear() + 1);
        document.getElementById("days-count").style.color = "black";
        document.getElementById("days-count").innerHTML = "Days count before your birthdate: " + Math.floor((birthdate.getTime() - today.getTime()) / 24 / 60 / 60 / 1000);
    }
    else
    {
        document.getElementById("days-count").style.color = "red";
        document.getElementById("days-count").innerHTML = "Input the correct date!";
    }
}