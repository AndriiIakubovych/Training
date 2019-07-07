function makeBuffer()
{
    var buffer = "";
    function getOrSetBuffer(text)
    {
        if (text)
            buffer += text;
        else
            return buffer;
    }
    getOrSetBuffer.clean = function ()
    {
        buffer = "";
    }
    return getOrSetBuffer;
}

var buffer = makeBuffer();