$(document).ready(function ()
{
    var count = $("#main .layout .content .products .navigation .items-count .count li");
    var slider = $(".slider").children(":first");
    var margin = Number(slider.children().css("margin-right").slice(0, slider.children().css("margin-right").length - 2));
    var itemWidth = slider.children().outerWidth() + margin * 2;
    var fproductsCount = slider.children().length;
    var running = false;
    var products = [
        { name: "Fairy Dish Washing", photo: "product-1.png", price: 12 },
        { name: "Student Backpack", photo: "product-2.png", price: 43.16 },
        { name: "Gouache Painting", photo: "product-3.png", price: 32.76 },
        { name: "Pink Backpack", photo: "product-4.png", price: 56 },
        { name: "Black Men's T-Shirt", photo: "product-5.png", price: 23.42 },
        { name: "Lavie Cork Bag", photo: "product-6.png", price: 63.21 },
        { name: "Gussaci Italy Bag", photo: "product-7.png", price: 68.45 },
        { name: "Lavie Adobe Bag", photo: "product-8.png", price: 52.11 },
        { name: "Green Pen", photo: "product-9.png", price: 2 },
        { name: "Blue Pen", photo: "product-10.png", price: 2 },
        { name: "School Album", photo: "product-11.png", price: 8.55 },
        { name: "School Album", photo: "product-12.png", price: 8.55 },
        { name: "Refugio Backpack", photo: "product-13.png", price: 78.67 },
        { name: "Travel Gear", photo: "product-14.png", price: 93.42 },
        { name: "Deep Casserole Pan", photo: "product-15.png", price: 24.55 },
        { name: "Estee Lauder", photo: "product-16.png", price: 63.12 },
        { name: "Jordana Matte", photo: "product-17.png", price: 65.72 },
        { name: "Nivea Creme", photo: "product-18.png", price: 32.12 },
        { name: "Garmin Fenix Watch", photo: "product-19.png", price: 106.42 },
        { name: "Men's Shorts", photo: "product-20.png", price: 12.63 },
        { name: "Ariel", photo: "product-21.png", price: 7 },
        { name: "Flora Red Bag", photo: "product-22.png", price: 45.96 },
        { name: "Razer Kraken", photo: "product-23.png", price: 89.65 },
        { name: "Crucial DDR3L", photo: "product-24.png", price: 50.12 },
        { name: "Gaming Mouse", photo: "product-25.png", price: 23.11 },
        { name: "Sandisk 128GB SDDD3", photo: "product-26.png", price: 45.67 },
        { name: "SwissGear Travel Gear", photo: "product-27.png", price: 74.88 },
        { name: "Simple Pen", photo: "product-28.png", price: 2 },
        { name: "Red Pen", photo: "product-29.png", price: 2 },
        { name: "Lavie Corundum Bag", photo: "product-30.png", price: 87.19 },
        { name: "Plastic Dishes", photo: "product-31.png", price: 12.61 },
        { name: "Dish Washing", photo: "product-32.png", price: 12 },
        { name: "Stationary Materials", photo: "product-33.png", price: 34.21 },
        { name: "Kitchen Washing", photo: "product-34.png", price: 12 },
        { name: "School Album", photo: "product-35.png", price: 8.55 },
        { name: "School Album", photo: "product-36.png", price: 8.55 }
    ];
    for (var i = 0; i < products.length; i++)
    {
        var newItem = "<li class='.new-item'><a href='#'><img src='images/" + products[i].photo + "' alt='product'/><figcaption><span class='product-name'>" + products[i].name + "</span><span class='price-text'>Price: </span><span class='price-value'>$" + products[i].price + "</span></figcaption></a></li>";
        $(newItem).appendTo("#main .layout .content .products .products-list");
    }
    $("#main .layout .content .products .products-list li:nth-child(n + " + (Number(count.children(":first").html()) + 1) + ")").css("display", "none");

    $(count.children()).click(function (event)
    {
        var products = $("#main .layout .content .products .products-list li");
        for (var i = 0; i < count.children().length; i++)
            count.children().get(i).style.color = "#747474";
        event.target.style.color = "#b20e00";
        products.css("display", "none");
        for (var i = 0; i < Number($(event.target).html()); i++)
            products.get(i).style.display = "block";
        return false;
    });

    function slide(dir)
    {
        var direction = !dir ? -1 : 1;
        var animateData;
        if (!running)
        {
            running = true;
            if (!dir)
                slider.children(":last").after(slider.children().slice(0, 1).clone(true));
            else
            {
                slider.children(":first").before(slider.children().slice(fproductsCount - 1, fproductsCount).clone(true));
                slider.css("left", -itemWidth + "px");
            }
            animateData = { left: parseInt(slider.css("left")) + (itemWidth * direction) };
            slider.animate(animateData, { queue: false, duration: 1000, complete: function ()
            {
                if (!dir)
                {
                    slider.children().slice(0, 1).remove();
                    slider.css("left", 0);
                }
                else
                    slider.children().slice(fproductsCount, fproductsCount + 1).remove();
                running = false;
            } });
        }
        return false;
    }

    $(".back").click(function ()
    {
        return slide(true);
    });

    $(".next").click(function ()
    {
        return slide(false);
    });
});