
$(document).ready(function () {
    Signer1UserS1Change();
    Signer1UserS2Change();

    var _Station = $("#ParameterCondition_Station").val();
    console.log(_Station)
    if (_Station == 'S5') {
        CheckSignatureReload();
    }
});

function CheckSignatureReload() {
    timer = setInterval(function () {
        console.log("5 seconds are up");

        //var _Station = $("#ParameterCondition_Station").val();
        //if (_Station == 'S7') {
        //    location.reload();
        //}
        //location.reload();
        var _ItemStatusCurr = $("#ParameterCondition_ItemStatusCurr").val();
        var _IdSmctMaster = $("#ParameterCondition_IdSmctMaster").val();

        var _VendorWitnessStatus = $("#VendorWitnessStatus").val();
        var _VendorWitnessCount = parseInt($("#VendorWitnessCount").val());
        var _VendorAuthorityCount = parseInt($("#VendorAuthorityCount").val());


        var _NhsoWitnessStatus = $("#NhsoWitnessStatus").val();
        var _NhsoWitnessCount = parseInt($("#NhsoWitnessCount").val());
        var _NhsoAuthorityCount = parseInt($("#NhsoAuthorityCount").val());

        var _SigningType = $("#ParameterCondition_SigningType").val();

        var _SendmailType = '';

        if (_ItemStatusCurr == 'S51') {
            if (_VendorWitnessCount == 1 && _VendorWitnessStatus == 'W1') {
                _SendmailType = 'SN12';//หน่วยริการ : พยานลงนาม
            }
            if (_VendorAuthorityCount == 1 && _VendorWitnessStatus == 'W2') {
                _SendmailType = 'SN11';//หน่วยริการ : ผู้มีอำนาจลงนาม
            }
        }

        if (_ItemStatusCurr == 'S53' && _SigningType == 'E') {
            if (_NhsoWitnessCount == 1 && _NhsoWitnessStatus == 'W1') {
                _SendmailType = 'SN22';//สปสช. : พยานลงนาม
            }
            if (_NhsoAuthorityCount == 1 && _NhsoWitnessStatus == 'W2') {
                _SendmailType = 'SN21';//สปสช. : ผู้มีอำนาจลงนาม
            }
        }

        if (_ItemStatusCurr == 'S53' && _SigningType == 'P') {
            if (_NhsoWitnessCount == 1 && _NhsoWitnessStatus == 'W1') {
                _SendmailType = 'SN42';//สปสช. : พยานลงนาม(ลงนามจริงในเอกสาร)
            }
            if (_NhsoAuthorityCount == 1 && _NhsoWitnessStatus == 'W2') {
                _SendmailType = 'SN41';//สปสช. : ผู้มีอำนาจลงนาม(ลงนามจริงในเอกสาร)
            }
        }

        //console.log('_ItemStatusCurr', _ItemStatusCurr)
        //console.log("_SendmailType", _SendmailType);
        //console.log("_VendorWitnessStatus", _VendorWitnessStatus);
        //console.log("_VendorWitnessCount", _VendorWitnessCount);
        //console.log("_VendorAuthorityCount", _VendorAuthorityCount);

        if (_SendmailType != '') {
            fetch(`${hostname}/CallData/CheckSignature?` + new URLSearchParams({
                idSmctMaster: _IdSmctMaster,
                SendmailType: _SendmailType
            })).then(function (response) {
                return response.json()
            }).then(function (data) {
                console.log(data);
                if (data.Status) {
                    if (_SendmailType == 'SN12' && data.Result) {
                        location.reload();
                    }
                    if (_SendmailType == 'SN11' && data.Result) {
                        location.reload();
                    }
                    if (_SendmailType == 'SN22' && data.Result) {
                        location.reload();
                    }
                    if (_SendmailType == 'SN21' && data.Result) {
                        location.reload();
                        //window.location.href = `${hostname}/Home/Index`;
                    }
                    if (_SendmailType == 'SN42' && data.Result) {
                        location.reload();
                    }
                    if (_SendmailType == 'SN41' && data.Result) {
                        location.reload();
                    }
                }
            })
        }

    }, 5000);
}

function UserSignerChange() {

    var IsChecked = $(".DecisionMaker:checked").val();
    //console.log(IsChecked)
    $('#VendorSignerTxt').val('');

    if (IsChecked == 'S1') {
        $('#Group_SignerType_S1').show();
        $('#Group_SignerType_S2').hide();
        $('#Group_SignerType_S1').prop('disabled', false);
        $('#Group_SignerType_S2').prop('disabled', true);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2PoaSigner1User').prop('disabled', true);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2PoaSigner1User').selectpicker('refresh');
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer1User').prop('disabled', false);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer1User').selectpicker('refresh');
        Signer1UserS1Change()
    }
    else if (IsChecked == 'S2') {
        $('#Group_SignerType_S1').hide();
        $('#Group_SignerType_S2').show();
        $('#Group_SignerType_S1').prop('disabled', true);
        $('#Group_SignerType_S2').prop('disabled', false);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer1User').prop('disabled', true);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer1User').selectpicker('refresh');
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2PoaSigner1User').prop('disabled', false);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2PoaSigner1User').selectpicker('refresh');
        Signer1UserS2Change()
    } else {
        $('#Group_SignerType_S1').hide();
        $('#Group_SignerType_S2').hide();
        $('#Group_SignerType_S1').prop('disabled', false);
        $('#Group_SignerType_S2').prop('disabled', false);
        $('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2PoaSigner1User').selectpicker('refresh');
    }
}

function Signer1UserS1Change() {
    $("#Signer1DocName").val('');
    $("#Signer1DocNo").val('');
    $("#Signer1DocDateStr").val('');
    $('#VendorSignerTxt').val('');

    //var VendorSignerUserTxt = $(this).text();
    //console.log(VendorSignerUser, VendorSignerUserTxt)

    var VendorSignerUser = '';
    var ContractSignerType = $('#InfoPartnersOfContract_SmctMasterSigner_ContractSignerType:checked').val();
    if (ContractSignerType == 'S1') {
        VendorSignerUser = $('#InfoPartnersOfContract_SmctMasterSigner_SmctMasterSignerDetail1_VendorSignerUser');
    } else {
        VendorSignerUser = $('#InfoPartnersOfContract_SmctMasterSigner_SmctMasterSignerDetail1_VendorSignerUser2');
    }
    if (VendorSignerUser.val() != '') {
        $('#VendorSignerTxt').val(VendorSignerUser.find(":selected").text());
    }

    var UserSmctSigner = UserSmctSignerModelList.find(x => x.IdUserSmct === VendorSignerUser.val());
    if (UserSmctSigner != undefined) {
        $("#Signer1DocName").val(UserSmctSigner.UserSmctSigners.Signer1DocName);
        $("#Signer1DocNo").val(UserSmctSigner.UserSmctSigners.Signer1DocNo);
        $("#Signer1DocDateStr").val(UserSmctSigner.UserSmctSigners.Signer1DocDateStr);
    }
}

function Signer1UserS2Change() {
    $("#Signer2PoaDocNo").val('');
    $("#Signer2PoaDocDateStr").val('');
    $("#Signer2PoaSigner1Name").val('');
    $("#Signer2DocName").val('');
    $("#Signer2DocNo").val('');
    $("#Signer2DocDateStr").val('');
    $("#Signer2StartDateStr").val('');
    $("#Signer2EndDateStr").val('');
    $('#VendorSignerTxt').val('');

    //var _IdUserSmct = $(_this).val();

    var VendorSignerUser = '';
    var ContractSignerType = $('#InfoPartnersOfContract_SmctMasterSigner_ContractSignerType:checked').val();
    //console.log(ContractSignerType.IdUserSmct)
    if (ContractSignerType == 'S1') {
        VendorSignerUser = $('#InfoPartnersOfContract_SmctMasterSigner_SmctMasterSignerDetail1_VendorSignerUser');
    } else {
        VendorSignerUser = $('#InfoPartnersOfContract_SmctMasterSigner_SmctMasterSignerDetail1_VendorSignerUser2');
    }
    if (VendorSignerUser.val() != '') {
        $('#VendorSignerTxt').val(VendorSignerUser.find(":selected").text());
    }

    var UserSmctSigner = UserSmctSignerModelList.find(x => x.IdUserSmct === VendorSignerUser.val());
    if (UserSmctSigner != undefined) {
        /* console.log(UserSmctSigner)*/
        $("#Signer2PoaDocNo").val(UserSmctSigner.UserSmctSigners.Signer2PoaDocNo);
        $("#Signer2PoaDocDateStr").val(UserSmctSigner.UserSmctSigners.Signer2PoaDocDateStr);
        $("#Signer2PoaSigner1Name").val(UserSmctSigner.UserSmctSigners.Signer2PoaSigner1Name);
        $("#Signer2DocName").val(UserSmctSigner.UserSmctSigners.Signer2DocName);
        $("#Signer2DocNo").val(UserSmctSigner.UserSmctSigners.Signer2DocNo);
        $("#Signer2DocDateStr").val(UserSmctSigner.UserSmctSigners.Signer2DocDateStr);
        $("#Signer2StartDateStr").val(UserSmctSigner.UserSmctSigners.Signer2StartDateStr);
        $("#Signer2EndDateStr").val(UserSmctSigner.UserSmctSigners.Signer2EndDateStr);
    }
}