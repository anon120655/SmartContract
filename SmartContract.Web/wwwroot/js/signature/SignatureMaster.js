
$(function () {

	var ItemStatusCurr = $('#ParameterCondition_ItemStatusCurr').val();
	var SendmailType = $('#ParameterCondition_SendmailType').val();
	var VendorWitnessStatus = $('#ParameterCondition_VendorWitnessStatus').val();
	console.log(ItemStatusCurr, SendmailType, VendorWitnessStatus)
	if ((ItemStatusCurr == 'S51' && SendmailType == 'SN12' && VendorWitnessStatus == 'W1') || (ItemStatusCurr == 'S51' && SendmailType == 'SN11' && VendorWitnessStatus == 'W2')) {
		$('#SignatureForm').prop('hidden', false);
		$('#SignatureSuccess').addClass('hidden');
	} else {
		$('#SignatureForm').prop('hidden', true);
		$('#SignatureSuccess').removeAttr('hidden');
	}


})

function SubmitSign() {
	var dataURL = signaturePad.toDataURL();
	$('#ParameterCondition_SignatureData').val(dataURL);
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
		var ParameterCon = xhr.responseJSON.Result.ParameterCondition;
		var ApproveProposal = xhr.responseJSON.Result.ApproveProposal;

		console.log(ParameterCon)
		try {
			//Gen ครั้งเดียวตอน ผู้มีอำนาจนาจลงนาม(หน่วยบริการ)
			if (ParameterCon.SigningType == 'E' && ParameterCon.ItemStatusCurr == 'S53' && ParameterCon.SendmailType == 'SN11') {
				console.log('GEN FM นิติกรรม')
				fetch(`${hostname}/RenderPDF/FM_CONTRACT_T${ParameterCon.ContractTypeId}?` + new URLSearchParams({
					fmtype: `FM_CONTRACT_T${ParameterCon.ContractTypeId}`,
					Style: ParameterCon.Style,
					ContractTypeId: ParameterCon.ContractTypeId,
					VendorIdCurr: ParameterCon.VendorIdCurr,
					DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
					IdSmctMaster: ParameterCon.IdSmctMaster,
					SigningTypeEn: ParameterCon.SigningTypeEn,
					IsPDFSignByCA: true,
					RefId: ParameterCon.RefId,
					UserNameCA: ApproveProposal.UserNameCA,
					PasswordCA: ApproveProposal.PasswordCA
				}))
					.then(response => response.json())
					.then(data => {
						console.log('renderpdf :', data);
					})
					.catch((error) => {
						console.error('renderpdf Error:', error);
					});

			}

			if (ParameterCon.SigningType == 'P' || (ParameterCon.SendmailType == 'SN22' || ParameterCon.SendmailType == 'SN21')) {
				console.log('GEN FM นิติกรรม')
				fetch(`${hostname}/RenderPDF/FM_CONTRACT_T${ParameterCon.ContractTypeId}?` + new URLSearchParams({
					fmtype: `FM_CONTRACT_T${ParameterCon.ContractTypeId}`,
					Style: ParameterCon.Style,
					ContractTypeId: ParameterCon.ContractTypeId,
					VendorIdCurr: ParameterCon.VendorIdCurr,
					DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
					IdSmctMaster: ParameterCon.IdSmctMaster,
					SigningTypeEn: ParameterCon.SigningTypeEn,
					IsPDFSignByCA: true,
					RefId: ParameterCon.RefId,
					UserNameCA: ApproveProposal.UserNameCA,
					PasswordCA: ApproveProposal.PasswordCA
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
