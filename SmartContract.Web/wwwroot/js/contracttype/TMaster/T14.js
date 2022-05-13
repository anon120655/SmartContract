

$(function () {

    setDateThai($(`input[name='InfoConDetail.ContractDetail14.P17']`));
    setDateThai($(`input[name='InfoConDetail.ContractDetail14.P18']`));

    var _StationReq = $('#ParameterCondition_StationReq').val();
    //console.log(_StationReq)
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

    var _Menu = $(`#ParameterCondition_Menu`).val();
    var StationStatusCurr = $("#StationStatusCurr").val();
    if (StationStatusCurr == 'S5' || StationStatusCurr == 'S6' || StationStatusCurr == 'S7' && _Menu != 'T1') {

        $('#collapseDetailT03_5 .selectpicker').prop('disabled', true);
        $('#collapseDetailT03_5 .selectpicker').selectpicker('refresh');
    }
    if (StationStatusCurr != undefined) {
        SetLookupCatmDetail();
    }
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

function SetLookupCatmDetail() {

    var provinceId = $("#InfoConDetail_ContractDetail14_P6_ProvinceId_Catm").val().substr(0, 2);
    var amphurId = $("#AmphurId_db").val();
    var districtId = $("#DistrictId_db").val();
    console.log(provinceId, amphurId, districtId)

    if (provinceId != null && provinceId != undefined && provinceId != '00') {
        ProvinceDetailChange(provinceId);
        $("#InfoConDetail_ContractDetail14_P6_ProvinceId_Catm").val(provinceId);
        $("#InfoConDetail_ContractDetail14_P6_ProvinceId_Catm").selectpicker("refresh");
        if (amphurId != null && amphurId != undefined && amphurId != '00') {
            AmphurDetailChange(amphurId);
            $("#InfoConDetail_ContractDetail14_P6_AmphurId_Catm").val(amphurId);
            $("#InfoConDetail_ContractDetail14_P6_AmphurId_Catm").selectpicker("refresh");
            if (districtId != null && districtId != undefined && districtId != '00') {
                $("#InfoConDetail_ContractDetail14_P6_DistrictId_Catm").val(districtId);
                $("#InfoConDetail_ContractDetail14_P6_DistrictId_Catm").selectpicker("refresh");
            }
        }
    }
}

//ผู้รับผิดชอบโครงการ
function ProjectResponsibleChange(_this) {

}

//ผู้เห็นชอบโครงการ
function ProjectAgreeChange(_this) {
    $("#InfoConDetail_ContractDetail14_P29").val('');
    $("#InfoConDetail_ContractDetail14_P31").val('');
    var empId = $(_this).val();
    var NhsoSigner = NhsoSignerListModelList.find(x => x.EmpId === empId);
    if (NhsoSigner != undefined) {
        $("#InfoConDetail_ContractDetail14_P29").val(NhsoSigner.SignerFullname);
        $("#InfoConDetail_ContractDetail14_P31").val(NhsoSigner.SignerPosition);
    }
}

//ผู้อนุมัติโครงการ
function ProjectApprovalChange(_this) {
    $("#InfoConDetail_ContractDetail14_P34").val('');
    $("#InfoConDetail_ContractDetail14_P36").val('');
    var empId = $(_this).val();
    var NhsoSigner = NhsoSignerListModelList.find(x => x.EmpId === empId);
    if (NhsoSigner != undefined) {
        $("#InfoConDetail_ContractDetail14_P34").val(NhsoSigner.SignerFullname);
        $("#InfoConDetail_ContractDetail14_P36").val(NhsoSigner.SignerPosition);
    }
}

function ProvinceDetailChange(provinceId) {

    if (provinceId != null && provinceId != undefined) {
        var urlfull = `${hostname}/CallData/LKAmphurs`;
        //console.log(provinceId)
        AjaxPost(urlfull, false, { provinceId: provinceId }, function (response) {
            if (response.Status) {
                $("#InfoConDetail_ContractDetail14_P6_DistrictId_Catm").empty();
                $("#InfoConDetail_ContractDetail14_P6_AmphurId_Catm").empty();
                $('#InfoConDetail_ContractDetail14_P6_AmphurId_Catm').append('<option value="00000">---เลือก---</option>');
                response.Result.forEach(function (item) {
                    //console.log(item)
                    $('#InfoConDetail_ContractDetail14_P6_AmphurId_Catm').append(`<option value='${item.AmphurId}'>(${item.AmphurId}) ${item.Name}</option>`);
                });
                $("#InfoConDetail_ContractDetail14_P6_DistrictId_Catm").selectpicker("refresh");
                $("#InfoConDetail_ContractDetail14_P6_AmphurId_Catm").selectpicker("refresh");
            } else {
                SweetAlert2Warning(response.MessagError);
            }
        });
    }
}

function AmphurDetailChange(amphurId) {

    var provinceId = $("#InfoConDetail_ContractDetail14_P6_ProvinceId_Catm").val().substr(0, 2);

    var _code = `${provinceId}${amphurId}`;
    console.log(provinceId, amphurId)

    var urlfull = `${hostname}/CallData/LKDistricts`;
    AjaxPost(urlfull, false, { code: _code }, function (response) {
        //console.log(response)
        if (response.Status) {
            $("#InfoConDetail_ContractDetail14_P6_DistrictId_Catm").empty();
            $('#InfoConDetail_ContractDetail14_P6_DistrictId_Catm').append('<option value="00000">---เลือก---</option>');
            response.Result.forEach(function (item) {
                //console.log(item)
                $('#InfoConDetail_ContractDetail14_P6_DistrictId_Catm').append(`<option value='${item.DistrictId}'>(${item.DistrictId}) ${item.Name}</option>`);
            });
            $("#InfoConDetail_ContractDetail14_P6_DistrictId_Catm").selectpicker("refresh");
        } else {
            SweetAlert2Warning(response.MessagError);
        }
    });
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

        if (xhr.responseJSON.Result != undefined) {
            var ApprovalReqStation = xhr.responseJSON.Result.ApprovalReqStation;
            var ParameterCon = xhr.responseJSON.Result.ParameterCondition;
           
            //GEN FM นิติกรรมสัญญา
            if (ApprovalReqStation != undefined && ParameterCon != undefined) {
                if ((ParameterCon.Station == 'S6' && ParameterCon.ItemStatusCurr == 'S61')
                    || (ParameterCon.Station == 'S5' && ParameterCon.ItemStatusCurr == 'S51')
                    || (ParameterCon.Station == 'S7' && ParameterCon.Menu == 'E')) {

                    //ไม่มีนิติกรรมสัญญา ผู้ใช้จะไปทำข้างนอก และเข้ามาแนบไฟล์เข้ามาในระบบ                   

                    GenFM_APPROVAL_REQ_ONLY(ParameterCon, ApprovalReqStation);

                    //เงื่อนไขการจ่ายเงิน
                    console.log('GEN FM เงื่อนไขการจ่ายเงิน')
                    fetch(`${hostname}/RenderPDF/FM_PAY_${ParameterCon.PeriodType}?` + new URLSearchParams({
                        fmtype: `FM_PAY_${ParameterCon.PeriodType}`,
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
            }
        }

        if (ApprovalReqStation.StationStatusCurr == 'S2' && ApprovalReqStation.StatusCheckMail == 'M11') {
            SentMailApprovalReq(ParameterCon, ApprovalReqStation);
        }

    }
};

failedForm = function (xhr) {
    console.log(xhr);
    SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};
