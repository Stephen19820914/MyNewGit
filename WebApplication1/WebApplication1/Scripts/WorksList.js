$(function () {
    $('[name="Create"]').click(function () {
        AddView();
    });
    $('[name="Edit"]').click(function () {
        EditView($(this).data('customerid'));
    });
    $('[name="Delete"]').click(function () {
        DeleteView($(this).data('customerid'));
    });
    $('[name="pageRows"]').change(function () {
        location.href = '/Works/List?pageCnt=1&pageRows=' + $('[name="pageRows"]').val();
    });
    $('[name="pageCnt"]').change(function () {
        location.href = '/Works/List?pageCnt=' + $('[name="pageCnt"] option:selected').text() + '&pageRows=' + $('[name="pageRows"]').val();
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

function DeleteView(_CustomerID) {
    $.ajax({
        type: "post",
        url: "/Works/Delete/",
        data: { CustomerID: _CustomerID },
        dataType: "text",
        async: false,
        cache: false, //防止ie8一直取到舊資料的話，請設定為false
        success: function (result) {
            switch (result) {
                case "true":
                    alert("刪除成功");
                    $('[name="PartialView"]').html('');

                    break;
                case "false":
                    alert("刪除失敗");
                    break;
                default:
                    alert(result);
                    break;
            }
        }
    });
}
