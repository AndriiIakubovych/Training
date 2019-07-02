var birthdate = new Date(1987, 5, 10, 0, 0, 0, 0);

function daysCountCalculating(birthdate)
{
    var currentDate = new Date();
    var daysCount;
    if (birthdate.getMonth() <= currentDate.getMonth())
        birthdate.setYear(currentDate.getFullYear());
    else
        birthdate.setYear(currentDate.getFullYear() - 1);
    daysCount = Math.ceil((currentDate - birthdate) / (1000 * 60 * 60 * 24));
    document.write("Number of days after my birthday: " + daysCount);
}

daysCountCalculating(birthdate);