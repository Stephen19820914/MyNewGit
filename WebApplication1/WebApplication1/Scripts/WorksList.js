$(function () {
    $('[name="Create"]').click(function () {
        AddView();
    });
    $('[name="Edit"]').click(function () {
        EditView($(this).data('customerid'));
    });
});
function AddView()
{
    $.ajax({
        type: "post",
        url: "/Works/Add/",
        data: {},
        dataType: "html",
        async: false,
        cache: false, //防止ie8一直取到舊資料的話，請設定為false
        success: function (result) {
            $('[name="PartialView"]').html(result);
        }
    });
}

function EditView(_CustomerID) {
    $.ajax({
        type: "post",
        url: "/Works/Edit/",
        data: { CustomerID: _CustomerID},
        dataType: "html",
        async: false,
        cache: false, //防止ie8一直取到舊資料的話，請設定為false
        success: function (result) {
            $('[name="PartialView"]').html(result);
        }
    });
}
