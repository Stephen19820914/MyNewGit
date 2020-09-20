$(function () {
    $('[name="AddSend"]').click(function () {
        AddValidate();
    });
});
function AddValidate()
{
    let reg = /^\s/;
    let ErrorMsg = '';
    if (reg.test($('[name="CustomerID"]').val()))
    {
        ErrorMsg += '未填客戶ID, ';
    }
    if (reg.test($('[name="CompanyName"]').val())) {
        ErrorMsg += '未填公司名稱, ';
    }
    if (reg.test($('[name="ContactName"]').val())) {
        ErrorMsg += '未填聯絡人, ';
    }
    if (reg.test($('[name="ContactTitle"]').val())) {
        ErrorMsg += '未填聯絡人職稱, ';
    }
    if (reg.test($('[name="Address"]').val())) {
        ErrorMsg += '未填地址, ';
    }
    if (reg.test($('[name="City"]').val())) {
        ErrorMsg += '未填城市, ';
    }
    if (reg.test($('[name="Region"]').val())) {
        ErrorMsg += '未填地區, ';
    }
    if (reg.test($('[name="PostalCode"]').val())) {
        ErrorMsg += '未填郵遞區號, ';
    }
    if (reg.test($('[name="Country"]').val())) {
        ErrorMsg += '未填國家, ';
    }
    if (reg.test($('[name="Phone"]').val())) {
        ErrorMsg += '未填電話, ';
    }
    if (reg.test($('[name="Fax"]').val())) {
        ErrorMsg += '未填傳真, ';
    }
    if (ErrorMsg == '') {
        AddData();
    }
    else
    {
        alert(ErrorMsg);
    }
}
function AddData()
{
    let obj = new Object();
    obj.CustomerID = $('[name="CustomerID"]').val();
    obj.CompanyName = $('[name="CompanyName"]').val();
    obj.ContactName = $('[name="ContactName"]').val();
    obj.ContactTitle = $('[name="ContactTitle"]').val();
    obj.Address = $('[name="Address"]').val();
    obj.City = $('[name="City"]').val();
    obj.Region = $('[name="Region"]').val();
    obj.PostalCode = $('[name="PostalCode"]').val();
    obj.Country = $('[name="Country"]').val();
    obj.Phone = $('[name="Phone"]').val();
    obj.Fax = $('[name="Fax"]').val(); debugger;
    $.ajax({
        type: "post",
        url: "/Works/Insert/",
        data: obj ,
        dataType: "text",
        async: false,
        cache: false, //防止ie8一直取到舊資料的話，請設定為false
        success: function (result) {
            switch (result)
            {
                case "true":
                    alert("儲存成功");
                    $('[name="PartialView"]').html('');
                    location.reload();
                    break;
                case "false":
                    alert("儲存失敗");
                    break;
                default:
                    alert(result);
                    break;
            }
        }
    });
}