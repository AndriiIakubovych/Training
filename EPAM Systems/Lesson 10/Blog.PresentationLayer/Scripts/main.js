$(document).ready(function ()
{
    $("main .right-sidebar .poll-view").click(function (e)
    {
        if ($("main .right-sidebar form .actions").css("display") === "block")
        {
            $("main .right-sidebar form .actions").css("display", "none");
            $("main .right-sidebar form .results").css("display", "block");
            $(this).text("View voting");
        }
        else
        {
            $("main .right-sidebar form .actions").css("display", "block");
            $("main .right-sidebar form .results").css("display", "none");
            $(this).text("View results");
        }
    });
    $(".admin-panel .admin-main form .tags .new-tags .add-tag .add").click(function (e)
    {
        var tagName = $(".admin-panel .admin-main form .tags .new-tags .add-tag input[type='text']").val();
        $("[name=newtags]").append(new Option(tagName, tagName));
        $(".admin-panel .admin-main form .tags .new-tags .add-tag input[type='text']").val("");
    });
    $(".scroll").click(function ()
    {
        $("html, body").animate({ scrollTop: 0 }, 1000);
        return false;
    });
});

function onSuccess(data)
{
    $("main .right-sidebar form .actions").css("display", "none");
    $("main .right-sidebar form .results").css("display", "block");
    $("main .right-sidebar .poll-view").css("display", "none");
    $("main .right-sidebar form .results .total span").text(data.Count);
    $("main .right-sidebar form .results .poll-answers .asus-answer .line").css("width", data.AsusVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .asus-answer span").text(data.AsusVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .msi-answer .line").css("width", data.MSIVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .msi-answer span").text(data.MSIVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .evga-answer .line").css("width", data.EVGAVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .evga-answer span").text(data.EVGAVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .gigabyte-answer .line").css("width", data.GigabyteVotesPercent + "%");
    $("main .right-sidebar form .results .poll-answers .gigabyte-answer span").text(data.GigabyteVotesPercent + "%");
}