
$(function () {
    setDateThai($('#UserSmct_BirthdayStr'));
})

onbeginForm = function (xhr) {
    showLoading();
};

completedForm = function (xhr) {
    hideLoading()
    console.log(xhr.responseJSON);
    if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
        SweetAlert2Warning(xhr.responseJSON.MessagError);
    } else {
        SweetAlert2Success(xhr.responseJSON.UrlRedirect, 'ตรวจสอบข้อมูลสำเร็จ', false, 'ตรวจสอบข้อมูล');
    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};
