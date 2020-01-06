window.onload = function ()
{
    const itemHeight = 50;
    const listSize = 1000000;
    const startElementsCount = 8;
    let itemsArray = createArray(listSize);
    let wrapHeight = itemHeight * startElementsCount;
    let listHeight = itemsArray.length * itemHeight;
    let realListHeight = Math.min(listHeight, 100000);
    let page = 0;
    let pageHeight = realListHeight / 100;
    let offset = 0;
    let previousScrollTop = 0;
    let jumpCoefficient = (listHeight - realListHeight) / (Math.ceil(listHeight / pageHeight) - 1);
    let wrap = document.querySelector("#wrap");
    let list = document.querySelector("#list");
    let items = { };
    wrap.style.height = wrapHeight + "px";
    wrap.onscroll = onScroll;
    list.style.height = realListHeight + "px";
    onScroll();

    function createArray(size)
    {
        let array = [];
        for (let i = 0; i < size; i++)
            array.push("Элемент " + (i + 1));
        return array;
    }

    function onScroll()
    {
        let scrollTop = wrap.scrollTop;
        if (Math.abs(scrollTop - previousScrollTop) > wrapHeight)
            onJumpScroll();
        else
            onSimpleScroll();
        render();
    }

    function onSimpleScroll()
    {
        let scrollTop = wrap.scrollTop;
        if (scrollTop + offset > (page + 1) * pageHeight)
        {
            page++;
            offset = Math.round(page * jumpCoefficient);
            previousScrollTop = scrollTop - jumpCoefficient;
            wrap.scrollTop = previousScrollTop;
            removeAllItems();
        }
        else if (scrollTop + offset < page * pageHeight)
        {
            page--;
            offset = Math.round(page * jumpCoefficient);
            previousScrollTop = scrollTop + jumpCoefficient;
            wrap.scrollTop = previousScrollTop;
            removeAllItems();
        }
        else
            previousScrollTop = scrollTop;
    }

    function onJumpScroll()
    {
        let scrollTop = wrap.scrollTop;
        page = Math.floor(scrollTop * ((listHeight - wrapHeight) / (realListHeight - wrapHeight)) * (1 / pageHeight));
        offset = Math.round(page * jumpCoefficient);
        previousScrollTop = scrollTop;
        removeAllItems();
    }

    function removeAllItems()
    {
        for (var i in items)
        {
            list.removeChild(items[i]);
            delete items[i];
        }
    }

    function render()
    {
        let scrollTop = wrap.scrollTop + offset;
        let top = Math.max(0, Math.floor((scrollTop - wrapHeight) / itemHeight));
        let bottom = Math.min(listHeight / itemHeight, Math.ceil((scrollTop + wrapHeight * 2) / itemHeight));
        for (let i in items)
            if (i < top || i > bottom)
            {
                list.removeChild(items[i]);
                delete items[i];
            }
        for (let i = top; i <= bottom; i++)
            if (!items[i])
            {
                items[i] = document.createElement("div");
                items[i].className = "item";
                items[i].style.height = itemHeight + "px";
                items[i].style.lineHeight = items[i].style.height;
                items[i].style.top = (itemHeight * i - offset) + "px";
                items[i].innerText = itemsArray[i];
                list.appendChild(items[i]);
            }
    }
}