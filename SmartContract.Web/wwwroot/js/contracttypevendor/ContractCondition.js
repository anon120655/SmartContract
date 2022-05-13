

onbeginContractCondition = function (xhr) {
    showLoading();
};

completedContractCondition = function (xhr) {
    hideLoading()
    console.log(xhr.responseJSON);
    if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
        SweetAlert2Warning(xhr.responseJSON.MessagError);
    } else {
        RedirectToAction(xhr.responseJSON.UrlRedirect);
    }
};

failedContractCondition = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};


$(document).on('click', '.cb_group_signing', function () {
    $('.cb_group_signing').not(this).prop('checked', false);
});

$(document).on('click', '.cb_group_counterpartycode', function () {
    $('.cb_group_counterpartycode').not(this).prop('checked', false);
});