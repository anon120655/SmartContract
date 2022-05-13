var wrapper = document.getElementById("signature-pad");

var canvas = wrapper.querySelector("canvas");
var signaturePad = new SignaturePad(canvas, {
    backgroundColor: 'rgb(255, 255, 255)'
});

function resizeCanvas() {
    var ratio = Math.max(window.devicePixelRatio || 1, 1);

    canvas.width = canvas.scrollWidth;
    canvas.height = canvas.scrollHeight;
    window.addEventListener('resize', function () {
        canvas.width = canvas.scrollWidth;
        canvas.height = canvas.scrollHeight;
    });


    signaturePad.clear();
}

// On mobile devices it might make more sense to listen to orientation change,
// rather than window resize events.
window.onresize = resizeCanvas;
resizeCanvas();

function download(dataURL, filename) {
    if (navigator.userAgent.indexOf("Safari") > -1 && navigator.userAgent.indexOf("Chrome") === -1) {
        window.open(dataURL);
    } else {
        var blob = dataURLToBlob(dataURL);
        var url = window.URL.createObjectURL(blob);

        var a = document.createElement("a");
        a.style = "display: none";
        a.href = url;
        a.download = filename;

        document.body.appendChild(a);
        a.click();

        window.URL.revokeObjectURL(url);
    }
}

function dataURLToBlob(dataURL) {
    // Code taken from https://github.com/ebidel/filer.js
    var parts = dataURL.split(';base64,');
    var contentType = parts[0].split(":")[1];
    var raw = window.atob(parts[1]);
    var rawLength = raw.length;
    var uInt8Array = new Uint8Array(rawLength);

    for (var i = 0; i < rawLength; ++i) {
        uInt8Array[i] = raw.charCodeAt(i);
    }

    return new Blob([uInt8Array], { type: contentType });
}

function ClearSignature() {
    signaturePad.clear();
}

$("#ElectronSign").submit(function (event) {
    //event.preventDefault(); //prevent default action 
    //console.log('--> SaveSignature')
    //if (signaturePad.isEmpty()) {
    //    SweetAlert2Warning("Please a electronic signature.");
    //} else {
    //    var dataURL = signaturePad.toDataURL();
    //console.log(dataURL)
    //try {
    //    var urlfull = `${hostname}/ElectronicSignature/Signature`;
    //    var _IdSmctMaster = $('#ParameterCondition_IdSmctMaster').val();
    //    var _Style = $('#ParameterCondition_Style').val();
    //    var _SigningType = $('#ParameterCondition_SigningType').val();
    //    var _SigningTypeEn = $('#ParameterCondition_SigningTypeEn').val();
    //    var _Station = $('#ParameterCondition_Station').val();
    //    var _ContractTypeId = $('#ParameterCondition_ContractTypeId').val();
    //    var _SendmailType = $('#ParameterCondition_SendmailType').val();
    //    var _RefId = $('#ParameterCondition_RefId').val();

    //    var parameterCon = {
    //        IdSmctMaster: _IdSmctMaster,
    //        SignatureData: dataURL,
    //        Style: _Style,
    //        SigningType: _SigningType,
    //        SigningTypeEn: _SigningTypeEn,
    //        Station: _Station,
    //        ContractTypeId: _ContractTypeId,
    //        SendmailType: _SendmailType,
    //        RefId: _RefId
    //    };

    //    var postData = {
    //        ParameterCondition: parameterCon
    //    };
    //    console.log(postData)
    //    AjaxPost(urlfull, true, { indata: postData }, function (response) {
    //        console.log(response.Status);
    //        if (response.Status) {
    //            hideLoading();
    //            $('#SignatureForm').prop('hidden', true);
    //            $('#SignatureSuccess').removeAttr('hidden');
    //        }
    //    });
    //}
    //catch (err) {
    //    console.log(err);
    //}
    //}
});

function InsertSign() {
    console.log('InsertSign')
    $('.group_sing_pad').removeAttr('style');
}

