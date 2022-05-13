

$(function () {
    SetStation();
})

function SetStation() {
    var _Station = $('#ParameterCondition_Station').val();
    //console.log(_Station)
    var index_tab = 0;
    index_tab = _Station == 'S4' ? 1
        : _Station == 'S5' ? 3
            : _Station == 'S6' ? 2
                : _Station == 'S7' ? 4
                    : _Station == 'S8' ? 5
                        : 0;

    setTimeout(function () {
        for (var i = 0; i <= index_tab; i++) {
            $(`#progressbar_tab1 li:eq(${i})`).addClass('proposal2_tab_background');
        }
    }, 100);

    var _Menu = $(`#ParameterCondition_Menu`).val();
    if (_Station == 'S5' || _Station == 'S6' || _Station == 'S7' && _Menu != 'T1') {

        $('.fa-plus-circle').hide();
        $('.fa-minus-circle').hide();
    }
}

onbeginForm = function (xhr) {
    showLoading();
};

completedForm = function (xhr) {
    hideLoading()
    //console.log(xhr.responseJSON);
    if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
        SweetAlert2Warning(xhr.responseJSON.MessagError);
    } else {
        SweetAlert2Success(xhr.responseJSON.UrlRedirect);

        var ParameterCon = xhr.responseJSON.Result.ParameterCondition;
        console.log(ParameterCon)
        //GEN FM นิติกรรมสัญญา
        if (ParameterCon != undefined) {
            if ((ParameterCon.Station == 'S6' && ParameterCon.ItemStatusCurr == 'S61')
                || (ParameterCon.Station == 'S5' && ParameterCon.ItemStatusCurr == 'S51')
                || (ParameterCon.Station == 'S7' && ParameterCon.Menu == 'E')) {
                console.log('GEN FM นิติกรรมสัญญา')
                fetch(`${hostname}/RenderPDF/FM_CONTRACT_T${ParameterCon.ContractTypeId}?` + new URLSearchParams({
                    fmtype: `FM_CONTRACT_T${ParameterCon.ContractTypeId}`,
                    Style: ParameterCon.Style,
                    ContractTypeId: ParameterCon.ContractTypeId,
                    VendorIdCurr: ParameterCon.VendorIdCurr,
                    DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
                    IdSmctMaster: ParameterCon.IdSmctMaster,
                    SigningTypeEn: ParameterCon.SigningTypeEn,
                    RefId: ParameterCon.RefId
                }))
                    .then(response => response.json())
                    .then(data => {
                        console.log('renderpdf :', data);
                    })
                    .catch((error) => {
                        console.error('renderpdf Error:', error);
                    });
            }
        }

        if (ParameterCon.Station == 'S5' && ParameterCon.ItemStatusCurr == 'S51') {
            SentMailSigner(ParameterCon);
        }
    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};
