

$(function () {
    SetStation();
    setDateThai($(`input[name='InfoConDetail.ContractDetail02.P1']`));

    CB_G_P12();
    IsP21_25_Change();
    IsP34_28_Change();
    CB_P12_Type3_Specialty();
    CB_321_24_G_1();
    CB_321_24_G_2();
    CB_322_24_G_1();
    CB_322_24_G_2();
    CB_323_24_G_1();
    CB_323_24_G_2();
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

    if (_Station == 'S5' || _Station == 'S6' || _Station == 'S7') {
        $('.fa-plus-circle').hide();
        $('.fa-minus-circle').hide();
    }
}

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

$('.cb_group_p12').on('change', function () {
    $('.cb_group_p12').not(this).prop('checked', false);
    CB_G_P12();
});

function CB_G_P12() {
    //หน่วยบริการที่รับการส่งต่อ
    var isCheckP12_CB_3 = $('#P12_CB_3').is(":checked");
    if (isCheckP12_CB_3) {
        $(".cb_group_p12_level1").prop('disabled', false);
    } else {
        $(".cb_group_p12_level1").prop('checked', false);
        $(".cb_group_p12_level1").prop('disabled', true);
        CB_P12_Type3_Specialty();
        IsP21_25_Change();
    }
    //หน่วยที่ร่วมบริการ
    var isCheckP12_CB_4 = $('#P12_CB_4').is(":checked");
    if (isCheckP12_CB_4) {
        $(".cb_group_JoinService").prop('disabled', false);
    } else {
        $(".cb_group_JoinService").prop('checked', false);
        $(".cb_group_JoinService").prop('disabled', true);
        IsP34_28_Change();
    }
}

//CheckBox หน่วยบริการที่รับการส่งต่อ --> เฉพาะทาง
function CB_P12_Type3_Specialty() {
    var isP17 = $('#InfoConDetail_ContractDetail02_P17').is(":checked");
    if (isP17) {
        $(".cb_group_p12_level2").prop('disabled', false);
    } else {
        $(".cb_group_p12_level2").prop('checked', false);
        $(".cb_group_p12_level2").prop('disabled', true);

        $('#InfoConDetail_ContractDetail02_P21').val('');
        for (var i = 1; i <= 4; i++) {
            Render_Specialty_Remove(i);
        }
        IsP21_25_Change();
    }
}

//CheckBox หน่วยบริการที่รับการส่งต่อ --> เฉพาะทาง อื่นๆ ++
function IsP21_25_Change() {
    var isP21_25 = $('#InfoConDetail_ContractDetail02_IsP21_25').is(":checked");
    if (isP21_25) {
        $('#AddRemove_GroupSpecialty').removeClass('d-none');
    } else {
        $('#AddRemove_GroupSpecialty').addClass('d-none');
        $('#InfoConDetail_ContractDetail02_P21').val('');
        for (var i = 1; i <= 4; i++) {
            Render_Specialty_Remove(i);
        }
    }
}

//3.1 หน่วยบริการที่รับการส่งต่อ --> เฉพาะทาง --> อื่นๆ ---------------------------------------------
function AddRemove_Specialty(type) {
    var countItems = $('#Render_Specialty .Render_Specialty_sub.show').length;
    if (type == 'A') Render_Specialty_Add(countItems + 1);
    if (type == 'D') Render_Specialty_Remove(countItems);
}

function Render_Specialty_Add(val) {
    $(`#Specialty_${val}`).removeClass('d-none').addClass('show');
}

function Render_Specialty_Remove(val) {
    $(`#Specialty_${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}


//CheckBox หน่วยที่ร่วมบริการ อื่นๆ++
function IsP34_28_Change() {
    var isP34_28 = $('#InfoConDetail_ContractDetail02_IsP34_28').is(":checked");
    if (isP34_28) {
        $('#AddRemove_GroupJoinService').removeClass('d-none');
    } else {
        $('#AddRemove_GroupJoinService').addClass('d-none');
        $('#InfoConDetail_ContractDetail02_P34').val('');
        for (var i = 1; i <= 4; i++) {
            Render_JoinService_Remove(i);
        }
    }
}

//3.1 หน่วยที่ร่วมบริการ ---------------------------------------------
function AddRemove_JoinService(type) {
    var countItems = $('#Render_JoinService .Render_JoinService_sub.show').length;
    if (type == 'A') Render_JoinService_Add(countItems + 1);
    if (type == 'D') Render_JoinService_Remove(countItems);
}

function Render_JoinService_Add(val) {
    $(`#JoinService_${val}`).removeClass('d-none').addClass('show');
}

function Render_JoinService_Remove(val) {
    $(`#JoinService_${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}

//3.1 หน่วยบริการที่รับการส่งต่อคือ ---------------------------------------------
function AddRemove_GetForward(type) {
    var countItems = $('#Render_GetForward .Render_GetForward_sub.show').length;
    if (type == 'A') Render_GetForward_Add(countItems + 1);
    if (type == 'D') Render_GetForward_Remove(countItems);
}

function Render_GetForward_Add(val) {
    $(`#GetForward_${val}`).removeClass('d-none').addClass('show');
}

function Render_GetForward_Remove(val) {
    $(`#GetForward_${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}

//3.2.1 กรณีหน่วยบริการประจำและหรือปฐมภูมิ
function CB_321_24_G_1() {
    var isCheckP47 = $('#InfoConDetail_ContractDetail02_IsP47').is(":checked");
    if (isCheckP47) {
        $("#InfoConDetail_ContractDetail02_P48").val('').prop('disabled', true);
        $("#InfoConDetail_ContractDetail02_P49").val('').prop('disabled', true);
    } else {
        $("#InfoConDetail_ContractDetail02_P48").prop('disabled', false);
        $("#InfoConDetail_ContractDetail02_P49").prop('disabled', false);
    }
}
function CB_321_24_G_2() {
    var isCheckP50 = $('#InfoConDetail_ContractDetail02_IsP50').is(":checked");
    if (isCheckP50) {
        $("#InfoConDetail_ContractDetail02_P51").val('').prop('disabled', true);
        $("#InfoConDetail_ContractDetail02_P52").val('').prop('disabled', true);
    } else {
        $("#InfoConDetail_ContractDetail02_P51").prop('disabled', false);
        $("#InfoConDetail_ContractDetail02_P52").prop('disabled', false);
    }
}
//3.2.2 กรณีหน่วยบริการที่รับส่งต่อทั่วไปและหรือเฉพาะด้าน
function CB_322_24_G_1() {
    var isCheckP53 = $('#InfoConDetail_ContractDetail02_IsP53').is(":checked");
    if (isCheckP53) {
        $("#InfoConDetail_ContractDetail02_P54").val('').prop('disabled', true);
        $("#InfoConDetail_ContractDetail02_P55").val('').prop('disabled', true);
    } else {
        $("#InfoConDetail_ContractDetail02_P54").prop('disabled', false);
        $("#InfoConDetail_ContractDetail02_P55").prop('disabled', false);
    }
}
function CB_322_24_G_2() {
    var isCheckP56 = $('#InfoConDetail_ContractDetail02_IsP56').is(":checked");
    if (isCheckP56) {
        $("#InfoConDetail_ContractDetail02_P57").val('').prop('disabled', true);
        $("#InfoConDetail_ContractDetail02_P58").val('').prop('disabled', true);
    } else {
        $("#InfoConDetail_ContractDetail02_P57").prop('disabled', false);
        $("#InfoConDetail_ContractDetail02_P58").prop('disabled', false);
    }
}
//3.2.3 กรณีหน่วยบริการร่วมให้บริการ
function CB_323_24_G_1() {
    var isCheckP60 = $('#InfoConDetail_ContractDetail02_IsP60').is(":checked");
    if (isCheckP60) {
        $("#InfoConDetail_ContractDetail02_P61").val('').prop('disabled', true);
        $("#InfoConDetail_ContractDetail02_P62").val('').prop('disabled', true);
    } else {
        $("#InfoConDetail_ContractDetail02_P61").prop('disabled', false);
        $("#InfoConDetail_ContractDetail02_P62").prop('disabled', false);
    }
}
function CB_323_24_G_2() {
    var isCheckP63 = $('#InfoConDetail_ContractDetail02_IsP63').is(":checked");
    if (isCheckP63) {
        $("#InfoConDetail_ContractDetail02_P64").val('').prop('disabled', true);
        $("#InfoConDetail_ContractDetail02_P65").val('').prop('disabled', true);
    } else {
        $("#InfoConDetail_ContractDetail02_P64").prop('disabled', false);
        $("#InfoConDetail_ContractDetail02_P65").prop('disabled', false);
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
