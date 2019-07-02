$(document).ready(function ()
{
    var slider = $("#main .slider");
    var target;
    var animationSpeed = 600;
    var slideShowSpeed = 7000;
    slider.animateSlides = function ()
    {
        target = (slider.currentSlide === slider.slides.length - 1) ? 0 : slider.currentSlide + 1;
        slider.slides.eq(slider.currentSlide).fadeOut(animationSpeed);
        slider.slides.eq(target).fadeIn(animationSpeed, function () { slider.currentSlide = target; });
    }
    slider.currentSlide = 0;
    slider.slides = $("#main .slider .slides li");
    slider.slides.css({ "width": "100%", "position": "relative", "marginRight": "-100%", "float": "left", "display": "none" });
    slider.slides.eq(slider.currentSlide).fadeIn(animationSpeed);
    setInterval(slider.animateSlides, slideShowSpeed);
    $("footer .links ul li a").tooltip();
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