
function PassQRCodeFix() {
    //$('#Email').val('User1');
    //$('#PassWord').val('P@ssword1');
    //$('#PassQRCodeFix').submit();
    window.location.href = '/register/register?email=Ddopa1@nhso.go.th&UserFullname=นายทดสอบ DDOPA1&PositionName=Test D1&Cid=1300000000&BirthdayStr=29/09/2560';
}


onbeginMailPassCode = function (xhr) {
    showLoading();
};

completedMailPassCode = function (xhr) {
    hideLoading()
    console.log(xhr.responseJSON);
    if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
        SweetAlert2Warning(xhr.responseJSON.MessagError);
    } else {

        $("input[name='semail']").val(xhr.responseJSON.Result.semail);
        $('#modalPassCode').modal('show');
    }
};

failedMailPassCode = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};

//modalPassCode
onbeginSpecialCode = function (xhr) {
    showLoading();
};

completedSpecialCode = function (xhr) {
    hideLoading()
    console.log(xhr.responseJSON);
    if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
        SweetAlert2Warning(xhr.responseJSON.MessagError);
    } else {
        RedirectToAction(xhr.responseJSON.UrlRedirect);
        //SweetAlert2Success(xhr.responseJSON.UrlRedirect);
    }
};

failedSpecialCode = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};