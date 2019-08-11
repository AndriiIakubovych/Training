window.onload = function ()
{
    var userName = prompt("Hello! What is your name?");
    var userMood;
    if (isNaN(userName)) {
        userMood = prompt("Good morning, " + userName + "! How is your mood?");
        if (isNaN(userMood)) {
            userMood = userMood.charAt(0).toUpperCase() + userMood.slice(1);
            alert(userMood + " is the same with me, " + userName + "!");
        }
    }
};