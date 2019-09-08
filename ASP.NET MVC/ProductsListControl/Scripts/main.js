var table, productId, dataUpdated = false, hasDescription = false;

$(document).ready(function ()
{
    var columnsCount = 7, minWidth = 1200, width;
    $(this).click(function (e)
    {
        if (e.target.className != "user-welcome")
            $(".user-popup-menu").css("display", "none");
    });
    $(".user-welcome").click(function (e)
    {
        $(".user-popup-menu").css("display", "none");
        $(".user-popup-menu").slideToggle();
    });
    $(".user-welcome .fa-angle-down").click(function (e)
    {
        $(".user-popup-menu").css("display", "none");
        $(".user-popup-menu").slideToggle();
    });
    if ($(".table-content").length > 0)
        $.get("/Home/GetSettings").done(function (data)
        {
            table = $(".table").DataTable({ columnDefs: [{ targets: [4], visible: data.HasDescription, orderable: false }, { targets: [5], visible: data.HasWarranty, orderable: false }, { targets: [6], visible: data.HasDiscount, orderable: false }, { targets: [7], visible: data.HasWarehouseAvailability, orderable: false }, { targets: [8], visible: data.HasPhoto, orderable: false }], paging: true, language: { lengthMenu: "Показывать _MENU_ записей", search: "Поиск:", zeroRecords: "Не найдено ни одной соответствующей записи", info: "Отображение с _START_ по _END_ из _TOTAL_ записей", infoEmpty: "Нет ни одной доступной записи", infoFiltered: "(отфильтровано из _MAX_ записей)", paginate: { previous: "Назад", next: "Вперёд" } }, fnDrawCallback: onUpdateTable });
            hasDescription = data.HasDescription;
            $(".table-content").css("display", "block");
            $("body").css("min-width", minWidth + "px");
            if ($(".table-content table thead tr th").length > columnsCount)
            {
                width = minWidth + ($(".table-content table thead tr th").length - columnsCount) * 150;
                $("body").css("min-width", width + "px");
            }
        });
    $(".show-add-product-dialog").click(function (e)
    {
        e.preventDefault();
        $.get(this.href, function (data)
        {
            $("#add-product-dialog-content").html(data);
            $("#add-product-dialog").modal("show");
            $("#add-manufacture-date").datepicker();
            $.validator.methods.date = function (value, element) { return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid(); }
        });
    });
    $(".show-edit-product-dialog").click(function (e)
    {
        e.preventDefault();
        $.get(this.href + "?productId=" + productId, function (data)
        {
            $("#edit-product-dialog-content").html(data);
            $("#edit-product-dialog").modal("show");
            $("#edit-manufacture-date").datepicker();
            $.validator.methods.date = function (value, element) { return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid(); }
        });
    });
    $(".show-delete-product-dialog").click(function (e)
    {
        e.preventDefault();
        $.get(this.href + "?productId=" + productId, function (data)
        {
            $("#delete-product-dialog-content").html(data);
            $("#delete-product-dialog").modal("show");
        });
    });
    $("main .table-content tbody tr").click(onRowClick);
    $(".small-photo").click(function ()
    {
        $("#photo-modal").css("display", "block");
        $("#big-photo").attr("src", this.src);
    });
    $(".close-image").click(function ()
    {
        $("#photo-modal").css("display", "none");
    });
    $(".default-settings").click(function ()
    {
        $(".has-description").prop("checked", true);
        $(".has-warranty").prop("checked", false);
        $(".has-discount").prop("checked", false);
        $(".has-warehouse-availability").prop("checked", true);
        $(".has-photo").prop("checked", true);
    });
});

(function (factory)
{
    if (typeof define === "function" && define.amd)
        define(["../widgets/datepicker"], factory);
    else
        factory($.datepicker);
}

(function (datepicker)
{
    datepicker.regional.ru = { closeText: "Закрыть", prevText: "&#x3C;Пред", nextText: "След&#x3E;", currentText: "Сегодня", monthNames: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"], monthNamesShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн", "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"], dayNames: ["воскресенье", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота"], dayNamesShort: ["вск", "пнд", "втр", "срд", "чтв", "птн", "сбт"], dayNamesMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"], weekHeader: "Нед", dateFormat: "dd.mm.yy", firstDay: 1, isRTL: false, showMonthAfterYear: false, yearSuffix: "" };
    datepicker.setDefaults(datepicker.regional.ru);
    return datepicker.regional.ru;
}));

function onRowClick()
{
    $("main .table-caption .operations a").removeClass("disabled");
    $("main .table-content tr").removeClass("selected");
    $(this).addClass("selected");
    productId = $(this).find("#item_ProductId").val();
}

function onUpdateTable()
{
    $("main .table-content tbody tr").click(onRowClick);
    if (!dataUpdated)
    {
        $("main .table-content tr").removeClass("selected");
        $("main .table-caption .operations .show-edit-product-dialog").addClass("disabled");
        $("main .table-caption .operations .show-delete-product-dialog").addClass("disabled");
    }
    if (hasDescription)
        $("table tr td:nth-child(5)").addClass("description");
    $(".small-photo").click(function ()
    {
        $("#photo-modal").css("display", "block");
        $("#big-photo").attr("src", this.src);
    });
    dataUpdated = false;
}

function showAlert()
{
    $(".alert").css("bottom", "0");
    setTimeout(function () { $(".alert").css("bottom", "-100px"); }, 2000);
}

function onAddProductSuccess(data)
{
    $("#add-product-dialog").modal("hide");
    table.row.add(["<input id='item_ProductId' name='item.ProductId' type='hidden' value='" + data.ProductId + "'>", data.ProductName, moment(data.ManufactureDate).format("DD.MM.YYYY"), data.Price, data.Description, data.Warranty, data.Discount, data.WarehouseAvailability ? "Есть" : "Нет", data.Photo != null ? "<img class='small-photo' src='../../Content/images/" + data.Photo + "' alt='Фото'/>" : ""]).draw(false);
    $("main .table-caption .operations a").removeClass("disabled");
    $("main .table-content tr").removeClass("selected");
    $("#item_ProductId[value='" + data.ProductId + "']").parents("tr").addClass("selected");
    $("main .table-content tbody tr").click(onRowClick);
    if (hasDescription)
        $("table tr td:nth-child(5)").addClass("description");
    $(".small-photo").click(function ()
    {
        $("#photo-modal").css("display", "block");
        $("#big-photo").attr("src", this.src);
    });
    productId = data.ProductId;
    showAlert();
}

function onEditProductSuccess(data)
{
    $("#edit-product-dialog").modal("hide");
    dataUpdated = true;
    table.row($("#item_ProductId[value='" + data.ProductId + "']").parents("tr")).data(["<input id='item_ProductId' name='item.ProductId' type='hidden' value='" + data.ProductId + "'>", data.ProductName, moment(data.ManufactureDate).format("DD.MM.YYYY"), data.Price, data.Description, data.Warranty, data.Discount, data.WarehouseAvailability ? "Есть" : "Нет", data.Photo != null ? "<img class='small-photo' src='../../Content/images/" + data.Photo + "' alt='Фото'/>" : ""]).draw(false);
    $(".small-photo").click(function ()
    {
        $("#photo-modal").css("display", "block");
        $("#big-photo").attr("src", this.src);
    });
    showAlert();
}

function onDeleteProductSuccess(data)
{
    var id;
    $("#delete-product-dialog").modal("hide");
    dataUpdated = true;
    table.row($("#item_ProductId[value='" + data.ProductId + "']").parents("tr")).remove().draw(false);
    if ($("main .table-content tbody tr").length > 0)
    {
        id = $("#item_ProductId[value='" + (+data.ProductId + 1) + "']");
        if (id.length > 0)
        {
            id.parents("tr").addClass("selected");
            productId = id.val();
        }
        else
        {
            id = $("#item_ProductId[value='" + (+data.ProductId - 1) + "']");
            if (id.length > 0)
            {
                id.parents("tr").addClass("selected");
                productId = id.val();
            }
            else
            {
                $("main .table-caption .operations .show-edit-product-dialog").addClass("disabled");
                $("main .table-caption .operations .show-delete-product-dialog").addClass("disabled");
            }
        }
    }
    else
    {
        $("main .table-caption .operations .show-edit-product-dialog").addClass("disabled");
        $("main .table-caption .operations .show-delete-product-dialog").addClass("disabled");
    }
    showAlert();
}

function onChangeSettingSuccess(data)
{
    showAlert();
}