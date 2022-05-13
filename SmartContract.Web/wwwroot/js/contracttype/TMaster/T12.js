

$(function () {

    var _StationReq = $('#ParameterCondition_StationReq').val();
    console.log(_StationReq)
    var index_tabReq = 0;
    index_tabReq = _StationReq == 'S2' ? 1
        : _StationReq == 'S3' ? 2
            : _StationReq == 'S4' ? 3
                : _StationReq == 'S5' ? 4
                    : 0;

    setTimeout(function () {
        for (var i = 0; i <= index_tabReq; i++) {
            $(`#progressbar_ReqApp li:eq(${i})`).addClass('proposal2_tab_background');
        }
    }, 100);

    var _Station = $('#ParameterCondition_Station').val();
    //console.log(_Station)
    var index_tab = 0;
    index_tab = _Station == 'S2' ? 1
        : _Station == 'S3' ? 2
            : _Station == 'S4' ? 2
                : _Station == 'S5' ? 4
                    : _Station == 'S6' ? 3
                        : _Station == 'S7' ? 5
                            : _Station == 'S8' ? 6
                                : 0;

    setTimeout(function () {
        for (var i = 0; i <= index_tab; i++) {
            $(`#progressbar_tab1 li:eq(${i})`).addClass('proposal2_tab_background');
        }
    }, 100);

})

$('.select_approve_proposal').on('change', function () {
    $('.select_approve_proposal').not(this).prop('checked', false);
});

$('.select_approve_req').on('change', function () {
    $('.select_approve_req').not(this).prop('checked', false);
});

$('.cb_group_approval_nsho_dept').on('change', function () {
    $('.cb_group_approval_nsho_dept').not(this).prop('checked', false);
});

$('.cb_group_approval_gencontract').on('change', function () {
    $('.cb_group_approval_gencontract').not(this).prop('checked', false);
});



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

        if (xhr.responseJSON.Result != undefined) {
            var ApprovalReqStation = xhr.responseJSON.Result.ApprovalReqStation;
            var ParameterCon = xhr.responseJSON.Result.ParameterCondition;
          
            //GEN FM นิติกรรมสัญญา
            if (ApprovalReqStation != undefined && ParameterCon != undefined) {
                if ((ParameterCon.Station == 'S6' && ParameterCon.ItemStatusCurr == 'S61')
                    || (ParameterCon.Station == 'S5' && ParameterCon.ItemStatusCurr == 'S51')
                    || (ParameterCon.Station == 'S7' && ParameterCon.Menu == 'E')) {

                    GenFM_APPROVAL_REQ_ONLY(ParameterCon, ApprovalReqStation);

                    console.log('GEN FM นิติกรรมสัญญา')                   
                    fetch(`${hostname}/RenderPDF/FM_CONTRACT_T${ParameterCon.ContractTypeId}?` + new URLSearchParams({
                        fmtype: `FM_CONTRACT_T${ParameterCon.ContractTypeId}`,
                        Style: ParameterCon.Style,
                        ContractTypeId: ParameterCon.ContractTypeId,
                        VendorIdCurr: ParameterCon.VendorIdCurr,
                        DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
                        IdSmctMaster: ParameterCon.IdSmctMaster,
                        SigningTypeEn: ParameterCon.SigningTypeEn,
                        RefId: ParameterCon.RefId,
                        IsPDF: true
                    }))
                        .then(response => response.json())
                        .then(data => {
                            console.log('renderpdf :', data);
                        })
                        .catch((error) => {
                            console.error('renderpdf Error:', error);
                        });

                    //เงื่อนไขการจ่ายเงิน
                    console.log('GEN FM เงื่อนไขการจ่ายเงิน')
                    //fetch(`${hostname}/Files/RenderPdf?` + new URLSearchParams({
                    //    fmtype: `FM_PAY_${ParameterCon.PeriodType}`,
                    //    Style: ParameterCon.Style,
                    //    ContractTypeId: ParameterCon.ContractTypeId,
                    //    VendorIdCurr: ParameterCon.VendorIdCurr,
                    //    DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
                    //    IdSmctMaster: ParameterCon.IdSmctMaster,
                    //    SigningTypeEn: ParameterCon.SigningTypeEn,
                    //    RefId: ParameterCon.RefId
                    //}))
                    //    .then(response => response.json())
                    //    .then(data => {
                    //        console.log('renderpdf :', data);
                    //    })
                    //    .catch((error) => {
                    //        console.error('renderpdf Error:', error);
                    //    });
                    fetch(`${hostname}/RenderPDF/FM_PAY_${ParameterCon.PeriodType}?` + new URLSearchParams({
                        fmtype: `FM_PAY_${ParameterCon.PeriodType}`,
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
        }

        if (ApprovalReqStation.StationStatusCurr == 'S2' && ApprovalReqStation.StatusCheckMail == 'M11') {
            SentMailApprovalReq(ParameterCon, ApprovalReqStation);
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
