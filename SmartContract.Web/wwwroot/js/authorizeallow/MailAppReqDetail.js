

$('.select_approve_proposal').on('change', function () {
    $('.select_approve_proposal').not(this).prop('checked', false);
    var _UserNameCA = $('#ApproveProposal_UserNameCA').val();
    var _PasswordCA = $('#ApproveProposal_PasswordCA').val();
    console.log(_UserNameCA, _PasswordCA)
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

        var ParameterCon = xhr.responseJSON.Result.ParameterCondition;
        var ApproveProposal = xhr.responseJSON.Result.ApproveProposal;
        console.log(ParameterCon)
        console.log(ApproveProposal)

        //อนุมัติ
        if ($('#ApproveProposal_Approve').is(":checked")) {
            try {
                console.log('SentMail SentMainToConsider....')
                fetch(`${hostname}/AuthorizeAllow/SentMainToConsider?` + new URLSearchParams({
                    StationReq: ParameterCon.StationReq,
                    Style: ParameterCon.Style,
                    ContractTypeId: ParameterCon.ContractTypeId,
                    ContractTypeIdEn: ParameterCon.ContractTypeIdEn,
                    VendorIdCurr: ParameterCon.VendorIdCurr,
                    DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
                    IdSmctMaster: ParameterCon.IdSmctMaster,
                    SigningTypeEn: ParameterCon.SigningTypeEn,
                    RefId: ParameterCon.RefId
                }))
                    .then(response => response.json())
                    .then(data => {
                        console.log('SentMail SentMainToConsider :', data);
                    })
                    .catch((error) => {
                        console.error('SentMail SentMainToConsider Error:', error);
                    });
            }
            catch (err) {
                console.log(err);
            }

        }

        location.reload();
    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};
