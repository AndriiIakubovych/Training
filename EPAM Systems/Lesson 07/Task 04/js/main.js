function askAboutImage()
{
    var answer = prompt("Do you like this picture?", "Yes/No");
    if (answer === "Yes")
        alert("We are glad that you aren't indifferent to art!");
    else
        if (answer === "No")
            alert("We regret that we asked it!");
}