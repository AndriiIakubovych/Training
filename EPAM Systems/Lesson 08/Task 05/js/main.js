window.onload = function ()
{
    var images = document.getElementsByTagName("img");
    var urlsList;
    var urlsListItems = [];
    if (images.length > 0)
    {
        document.getElementById("list-name").innerHTML = "URLs of all images on the page:"
        urlsList = document.getElementById("urls-list");
        for (var i = 0; i < images.length; i++)
        {
            urlsListItems[i] = document.createElement("li");
            urlsListItems[i].innerHTML = images[i].getAttribute("src");
            urlsList.appendChild(urlsListItems[i]);
        }
    }
};