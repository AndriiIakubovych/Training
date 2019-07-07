$(document).ready(function ()
{
    $(".img-slider img:gt(0)").hide();
    setInterval(function () { $(".img-slider :first-child").fadeTo(0, 0).next("img").fadeTo(500, 1).end().appendTo(".img-slider"); }, 4000);
    $(".menu").click(function ()
    {
        $(this).toggleClass("active");
        $(".nav").toggleClass("active");
        return false;
    });
    $(".menu-tabs li").click(function (event)
    {
        var a = $("#main .description .header-main li a");
        for (var i = 0; i < a.length; i++)
            a.get(i).style.color = "#a7a7a7";
        event.target.style.color = "black";
        $("div.t1").hide();
        $("div.t2").hide();
        $("div.t3").hide();
        $("div." + this.className).fadeIn(500);
        return false;
    });
    $("li.t1").click();
    $("#main .description .header-main li:first-child a").css("color", "black");
    $("#main .description .browse-all .browse-scroll").click(function ()
    {
        $("html, body").animate({ scrollTop: $(this.hash).offset().top }, 1000);
        return false;
    });
    $(".bxslider").bxSlider();
    $(window).scroll(function ()
    {
        if ($(this).scrollTop() > 100)
            $(".scroll").fadeIn();
        else
            $(".scroll").fadeOut();
    });
    $(".scroll").click(function ()
    {
        $("html, body").animate({ scrollTop: 0 }, 1000);
        return false;
    });
});