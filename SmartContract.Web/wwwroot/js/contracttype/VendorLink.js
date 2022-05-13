
$(function () {
    SetStation();
})

function SetStation() {
    var _Station = $('#ParameterCondition_Station').val();
    //console.log(_Station)
    //var index_tab = 0;
    //index_tab = _Station == 'S4' ? 1
    //    : _Station == 'S5' ? 3
    //        : _Station == 'S6' ? 2
    //            : _Station == 'S7' ? 4
    //                : _Station == 'S8' ? 5
    //                    : 0;

    //setTimeout(function () {
    //    for (var i = 0; i <= index_tab; i++) {
    //        $(`#progressbar_vendorLink li:eq(${i})`).addClass('proposal2_tab_background');
    //    }
    //}, 100);
    $(`#progressbar_vendorLink li:eq(${0})`).addClass('proposal2_tab_background');
    $(`#progressbar_vendorLink li:eq(${1})`).addClass('proposal2_tab_background');
}

onbeginForm = function (xhr) {
    showLoading();
};

completedForm = function (xhr) {
    hideLoading()
    console.log(xhr.responseJSON);
    if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
        SweetAlert2Warning(xhr.responseJSON.MessagError);
    } else {
        SweetAlert2Success(xhr.responseJSON.UrlRedirect);
    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};