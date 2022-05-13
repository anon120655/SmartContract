
$(function () {

    var _Station = $('#ParameterCondition_Station').val();
    console.log(_Station)
    var index_tab = 0;
    index_tab=  _Station == 'S2' ? 1
              : _Station == 'S3' ? 2
              : _Station == 'S4' ? 2
              : _Station == 'S5' ? 4
              : _Station == 'S6' ? 3
              : _Station == 'S7' ? 5
              : _Station == 'S8' ? 6
              : _Station == 'S9' ? 7
              : 0;         

    setTimeout(function () {
        for (var i = 0; i <= index_tab; i++) {
            $(`#progressbar_tab1 li:eq(${i})`).addClass('proposal2_tab_background');
        }
    }, 100);


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
        SweetAlert2Success(xhr.responseJSON.UrlRedirect);
    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};
