getMinutesCountFromLessonStart();

function getMinutesCountFromLessonStart()
{
    var startLessonTime = new Date();
    var currentTime = new Date();
    var minutesCount;
    startLessonTime.setHours(18);
    startLessonTime.setMinutes(0);
    startLessonTime.setSeconds(0);
    if (currentTime.getHours() >= startLessonTime.getHours())
    {
        minutesCount = Math.floor((currentTime - startLessonTime) / 1000 / 60);
        document.write("Number of minutes since the lesson was started: " + minutesCount);
    }
    else
        document.write("The lesson hasn't started yet!");
}