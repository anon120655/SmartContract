
$('.select_approve_req').on('change', function () {
    $('.select_approve_req').not(this).prop('checked', false);
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
        if ($('#ApproveReq_Approve').is(":checked")) {
            try {
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

            }
            catch (err) {
                console.log(err);
            }
        }

        try {
            console.log('GEN FM หนังสือขออนุมัติ')
            fetch(`${hostname}/RenderPDF/FM_APPROVAL_REQ?` + new URLSearchParams({
                fmtype: 'FM_APPROVAL_REQ',
                Style: ParameterCon.Style,
                IsPDF: true,
                ContractTypeId: ParameterCon.ContractTypeId,
                VendorIdCurr: ParameterCon.VendorIdCurr,
                DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
                IdSmctMaster: ParameterCon.IdSmctMaster,
                SigningTypeEn: ParameterCon.SigningTypeEn,
                RefId: ParameterCon.RefId,
                UserNameCA: ApproveProposal.UserNameCA,
                PasswordCA: ApproveProposal.PasswordCA,
                CadCA: ParameterCon.CadCA,
                StationReq: 'S4'
            }))
                .then(response => response.json())
                .then(data => {
                    console.log('renderpdf :', data);
                    console.log('GEN FM FileFTPCA')
                    fetch(`${hostname}/Files/FileFTPCA?` + new URLSearchParams({
                        Style: ParameterCon.Style,
                        ContractTypeId: ParameterCon.ContractTypeId,
                        VendorIdCurr: ParameterCon.VendorIdCurr,
                        DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
                        IdSmctMaster: ParameterCon.IdSmctMaster,
                        SigningType: ParameterCon.SigningType,
                        SigningTypeEn: ParameterCon.SigningTypeEn,
                        IsPDFSignByCA: true,
                        RefId: ParameterCon.RefId,
                        UserNameCA: ApproveProposal.UserNameCA,
                        PasswordCA: ApproveProposal.PasswordCA,
                        SendmailType: ParameterCon.SendmailType,
                        PeriodType: ParameterCon.PeriodType
                    }))
                        .then(response => response.json())
                        .then(data => {
                            console.log('GEN FM FileFTPCA :', data);
                        })
                        .catch((error) => {
                            console.error('GEN FM FileFTPCA Error:', error);
                        });
                })
                .catch((error) => {
                    console.error('renderpdf Error:', error);
                });
        }
        catch (err) {
            console.log(err);
        }

        location.reload();
    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};