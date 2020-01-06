(function ()
{
    var testTable, historyTable;
})();

$(document).ready(function ()
{
    var chart = $(".horizontal-bar");
    var testId = $("#testid");
    var pageLabel;
    var pagesNumbers = [], pages = []; times = [], backgroundColors = [], borderColors = [];
    var colors;
    var opacity = 0.2;
    testTable = $(".test-table").DataTable({ searching: false, ordering: false, bInfo: false, paging: false });
    historyTable = $(".history-table").DataTable({ columnDefs: [{ targets: [3], orderable: false }], fnDrawCallback: onUpdateTable });
    if (chart.length > 0 && testId.length > 0)
        $.getJSON("/Home/GetTestResultData", { testId: +testId.html() }).done(function (data)
        {
            for (var i = 0; i < data.length; i++)
            {
                pageLabel = "Page " + (i + 1);
                pagesNumbers.push(pageLabel);
                pages.push({ label: pageLabel, address: data[i].PageAddress });
                times.push(data[i].AverageTime);
                colors = data[i].Color.replace("/\s+/g", "").split(";");
                backgroundColors.push("rgba(" + colors[0] + ", " + colors[1] + ", " + colors[2] + ", " + opacity + ")");
                borderColors.push("rgb(" + colors[0] + ", " + colors[1] + ", " + colors[2] + ")");
            }
            new Chart(chart, { type: "horizontalBar", data: { labels: pagesNumbers, datasets: [{ data: times, fill: false, backgroundColor: backgroundColors, borderColor: borderColors, borderWidth: 1 }] }, options: { scales: { xAxes: [{ ticks: { beginAtZero: true } }] }, legend: { display: false }, tooltips: { callbacks: { label: function (tooltipItem) { for (var i = 0; i < pages.length; i++) if (pages[i].label === tooltipItem.yLabel) { return pages[i].address; break; }; } } } } });
        });
    $(".results-table").DataTable({ searching: false, bInfo: false, paging: false });

    $("main form").submit(function (e)
    {
        if ($(this).valid())
        {
            $(".loading-status").css("display", "block");
            $(".error-status").css("display", "none");
            $(".loading-status .loading-status-text").html("Determining sitemap and getting URLs... ");
            $(".start-test").attr("disabled", true);
        }
    });
    onClickRow();
    onDeleteRow();
});

function onClickRow()
{
    $(".history-table tbody tr").click(function (e)
    {
        var testId;
        if (e.target.tagName != "A" && e.target.tagName != "I")
        {
            testId = $(this).find("#item_TestId").val();
            window.location.href = "/Home/TestResult?testId=" + testId;
        }
    });
}

function onDeleteRow()
{
    $(".remove").click(function (e)
    {
        e.preventDefault();
        $.get(this.href, function (data)
        {
            $("#content").html(data);
            $("#dialog").modal("show");
        });
    });
}

function onUpdateTable()
{
    onClickRow();
    onDeleteRow();
}

function onStartTest(data)
{
    var requestsCount = 5;
    var requestNumber = 1;
    var index = 0, millisecondsCount = 1;
    var timerId;
    var testResults = [], requestsValues = [];
    var sum, averageTime, minTime, maxTime;
    var isTestFinished = false;
    if (typeof data != "undefined" && data.length > 0)
    {
        $(".loading-status .loading-status-text").html("Sending requests to sitemap's URLs... ");
        $("main .test").css("visibility", "visible");
        testTable.row.add([data[index], requestNumber, millisecondsCount]).draw(false);
        var timerId = setInterval(function ()
        {
            testTable.cell({ row: index, column: 2 }).data(millisecondsCount).draw(false);
            if (millisecondsCount === 1)
                $.get("/Home/SendRequest", { url: data[index] }).done(function (msdata)
                {
                    testTable.cell({ row: index, column: 2 }).data(msdata).draw(false);
                    requestsValues.push(msdata);
                    millisecondsCount = 1;
                    if (requestNumber === requestsCount)
                    {
                        sum = 0;
                        minTime = maxTime = requestsValues[0];
                        for (var i = 0; i < requestsValues.length; i++)
                        {
                            sum += requestsValues[i];
                            if (requestsValues[i] < minTime)
                                minTime = requestsValues[i];
                            if (requestsValues[i] > maxTime)
                                maxTime = requestsValues[i];
                        }
                        averageTime = Math.floor(sum / requestsValues.length);
                        console.log(requestsValues);
                        console.log(minTime);
                        console.log(maxTime);
                        testResults.push({ pageAddress: data[index], averageTime: averageTime, minTime: minTime, maxTime: maxTime });
                        if (index < data.length - 1)
                        {
                            index++;
                            testTable.row.add([data[index], requestsCount - requestNumber + 1, millisecondsCount]).draw(false);
                            requestsValues = [];
                        }
                        else
                        {
                            clearInterval(timerId);
                            isTestFinished = true;
                            $(".loading-status .loading-status-text").html("Saving test results... ");
                            $.post("/Home/AddTest", { testResults: testResults }).done(function (urldata) { window.location.href = urldata; });
                        }
                    }
                    if (!isTestFinished)
                    {
                        requestNumber = requestNumber < requestsCount ? requestNumber + 1 : 1;
                        testTable.cell({ row: index, column: 1 }).data(requestNumber).draw(false);
                    }
                });
            millisecondsCount++;
        }, 1);
    }
    else
    {
        $(".loading-status").css("display", "none");
        $(".error-status").css("display", "block");
        $(".start-test").prop("disabled", false);
    }
}

function onDeleteTestSuccess(data)
{
    $("#dialog").modal("hide");
    historyTable.row($("#item_TestId[value='" + data.TestId + "']").parents("tr")).remove().draw(false);
}