
var committeeList = '';
var budgetcodeList = '';
var nhsosignerlist = '';
var userSmctSignerList = '';
var vNhsoEmployeeAllList = '';
var contractTypeId = '';

$(document).ready(function () {
	InitialNhso();

	$("#ModalHistory").on('show.bs.modal', function (e) {
		var _ChecklistId = $(e.relatedTarget).data('checklistid');
		var _IdContractType = $('#ParameterCondition_IdContractType').val();
		$('#Render_CheckListHistory').html('');
		$('#LoaddingHistory').removeClass('d-none');
		var urlfull = `${hostname}/CallData/CheckListHistory`;
		AjaxPost(urlfull, true, { ChecklistId: _ChecklistId, IdContractType: _IdContractType }, function (response) {
			if (response.Status) {
				if (response.Result != null && response.Result != undefined) {
					$('#CheckListNoHeader').text(response.Result.ChecklistId);
					if (response.Result.ContractSbbCklDetails != null && response.Result.ContractSbbCklDetails.length > 0) {
						var content_html = ``;
						$.each(response.Result.ContractSbbCklDetails, function (index, val) {
							content_html += `<tr>
                                                <td>${val.DetailItem}</td>
                                                <td class="text-center">
                                                    <div class="${val.FCb == 'N' ? 'd-none' : ''}">
                                                        <div class="mb-1">
                                                            <div class="form-check form-check-inline pl-2 pr-2">
                                                                <input class="form-check-input" type="checkbox" ${val.C1 ? 'checked' : ''} onclick="return false">
                                                                <label class="form-check-label" for="inlineCheckbox1">มี/ถูกต้อง</label>
                                                            </div>
                                                            <div class="form-check form-check-inline pl-2 pr-2">
                                                                <input class="form-check-input" type="checkbox"  ${val.C2 ? 'checked' : ''} onclick="return false">
                                                                <label class="form-check-label" for="inlineCheckbox2">ไม่มี/ไม่ถูกต้อง</label>
                                                            </div>
                                                            <div class="form-check form-check-inline pl-2 pr-2">
                                                                <input class="form-check-input" type="checkbox"  ${val.C3 ? 'checked' : ''} onclick="return false">
                                                                <label class="form-check-label" for="inlineCheckbox2">ยกเว้น</label>
                                                            </div>
                                                        </div>
                                                        <div class="${val.CDetail == null ? 'd-none' : ''}">
                                                              <input type="text" readonly class="form-control-plaintext text-primary"
                                                                                       value="${val.CDetail != null ? val.CDetail : ''}">
                                                        </div>
                                                    </div>
                                               </td>
                                            </tr>`;
							if (index == response.Result.ContractSbbCklDetails.length - 1) {
								$('#LoaddingHistory').addClass('d-none');
								$('#Render_CheckListHistory').append(content_html);
							}
						});
					}
				}
			} else {
				SweetAlert2Warning(response.MessagError);
			}
		});
	});

});

function InitialNhso() {
	setDateThai($(`#InfoContract_StartDateStr`));
	//setDateThai($(`#InfoContract_EndDateStr`));
	setDateThai($(`#InfoContractNhso_NhsoContractDateStr`));

	contractTypeId = $(`#ParameterCondition_ContractTypeId`).val();

	$.each(CommitteeListModelList, function (index, val) {
		if (index == 0) {
			committeeList += `<option value=''>---เลือก---</option>`;
		}
		if (val.BoradType == 'B') {
			committeeList += `<option value='${val.EmpId}'>${val.BoradFullname}</option>`;
		}

	});
	$.each(BudgetcodeListModelList, function (index, val) {
		if (index == 0) {
			budgetcodeList += `<option value=''>---เลือก---</option>`;
		}
		budgetcodeList += `<option value='${val.Budgetcode}'>${val.Budgetcode}</option>`;
	});
	$.each(NhsoSignerListModelList, function (index, val) {
		if (index == 0) {
			nhsosignerlist += `<option value=''>---เลือก---</option>`;
		}
		nhsosignerlist += `<option value='${val.EmpId}'>${val.SignerFullname}</option>`;
	});

	$.each(UserSmctSignerModelList, function (index, val) {
		if (index == 0) {
			userSmctSignerList += `<option value=''>---เลือก---</option>`;
		}
		userSmctSignerList += `<option value='${val.IdUserSmct}'>${val.UserFullname}</option>`;
	});
}

$('.cb_group_approval_binding').on('change', function () {
	$('.cb_group_approval_binding').not(this).prop('checked', false);
});

$('.cb_group_checklist').on('change', function () {
	$('.cb_group_checklist').not(this).prop('checked', false);
});

function CBCheckListChange(index, _this) {
	//console.log(index)
	$(`.cb_group_checklist_${index}`).not(_this).prop('checked', false);
}

$(document).on('click', '.PayVendorType', function () {
	$('.PayVendorType').not(this).prop('checked', false);
});


$(document).on("change", ".custom-file-input", function () {
	//console.log('change file input')
	var fileName = $(this).val().split("\\").pop();
	var fileNameNew = WappText(fileName, 25);
	$(this).attr("title", fileName);
	$(this).siblings(".custom-file-label").addClass("selected").html(fileNameNew);
});

function insert_row_attachfile() {

	var countItems = $('#Attachfile_Rander .Attachfile_Sub').length;
	//console.log(countItems)
	$('#Attachfile_Rander').append(
		`<div class="Attachfile_Sub form-row col-12 form_create">
                 <div class="form-group form-group-file col-12 col-sm-12 col-md-12 col-lg-12 col-xl-4">
                     <div class="custom-file">
                         <input type="file" class="custom-file-input"
                                name="InfoAttachDraftContractAppReq.SmctMasterFile[${countItems}].FormFile">
                         <input type="hidden" name="InfoAttachDraftContractAppReq.SmctMasterFile[${countItems}].IdSmctMasterFile" value="">
                         <label class="custom-file-label" for="customFile">Choose file</label>
                     </div>
                 </div>
                 <div class="form-group col-12 col-sm-12 col-md-12 col-lg-12 col-xl-3">
                    <input type="image" src="${hostname}/images/icon/close-2x.png"
                            onclick="remove_row_attachfile(this); return false;" class="border-0 mt-2" width="17">
                 </div>
             </div>`
	);
}

function remove_row_attachfile(_this) {
	$(_this).closest(`.Attachfile_Sub`).remove();

	$('#Attachfile_Rander .Attachfile_Sub').each(function (index, val) {
		$(this).find('.form-group-file').each(function (index_sub) {
			$(this).find('.custom-file input,.custom-file select').each(function (index_input) {
				var inputName = $(this).attr("name");
				if (inputName != undefined) {
					$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
				}
			});
		});
	});
}

//งบประมาณ
function insert_row_budgetcode() {
	var countItems = $('#Budgetcode_Render .Budgetcode_Sub').length + 1;
	var content_html = `<div class="Budgetcode_Sub Budgetcode_Sub_${countItems} ">
                            <div class="form-group row">
                                <label class="col-sm-3 col-form-label text-sm-right"></label>
                                <div class="col-sm-5">
                                    <select class="form-control bg-focus selectpicker Select_Budgetcode" data-live-search="true"
                                        name="InfoContract.Budgetcodes[${countItems}].Budgetcode">
                                         ${budgetcodeList}
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer" onclick="remove_row_budgetcode(this)"></i>
                                </div>
                            </div>
                        </div>`;

	$('#Budgetcode_Render').append(content_html);
	$('.selectpicker').selectpicker('refresh');

	//T10 อปท.
	if (contractTypeId == '10') {
		ClearTabPayment();
	}
}

function remove_row_budgetcode(_this) {
	$(_this).closest(`.Budgetcode_Sub`).remove();
	$('#Budgetcode_Render .Budgetcode_Sub').each(function (index, val) {
		index++
		//console.log(index)
		$(this).attr("class", `Budgetcode_Sub Budgetcode_Sub_${index}`)
		$(this).find('input,select').each(function (index_input) {
			var inputName = $(this).attr("name");
			if (inputName != undefined) {
				$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
			}
		});
	});
	//T10 อปท.
	if (contractTypeId == '10') {
		ClearTabPayment();
	}
}

//ใช้กับ T10 อปท.
function ClearTabPayment() {
	$('input[name="InfoConditionPayment.PeriodType"]').prop('checked', false);
	$('#Payment1').hide();
	$('#Payment2').hide();
	Payment_InsertPayPeriod(0);
	$('#InfoConditionPayment_PaymentSelect').val('0');
}


//กรณีเลือก Budgetcode tab ข้อมูลนิติกรรม แล้วมาเลือกใหม่ T10
$(document).on('change', '.Select_Budgetcode', function () {
	//console.log('change Select_Budgetcode')
	if (contractTypeId == '10') {
		ClearTabPayment();
	}

	var Budgetcode0 = $('select[name^="InfoContract.Budgetcodes[0].Budgetcode"]').find(':selected').val();
	//console.log(Budgetcode0)
	budgetcodeSelectLeagl = '';
	budgetcodeSelectLeagl = `<option value=''>---เลือก---</option>`;
	budgetcodeSelectLeagl += `<option value='${Budgetcode0}'>${Budgetcode0}</option>`;

	$('#Budgetcode_Render .Budgetcode_Sub').each(function (index, val) {
		var budgetcode = $(this).find('.Select_Budgetcode').find(':selected').val();
		//console.log(index, budgetcode)      
		budgetcodeSelectLeagl += `<option value='${budgetcode}'>${budgetcode}</option>`;
	});
});

//คณะกรรมการ
function insert_row_committee() {
	var countItems = $('#Committee_Render .Committee_Sub').length + 1;
	var content_html = `<div class="Committee_Sub Committee_Sub_${countItems}">
                            <div class="form-group row">
                                <label class="col-sm-3 col-form-label text-sm-right"></label>
                                <div class="col-sm-4">
                                        <select class="form-control bg-focus selectpicker" data-live-search="true"
                                            name="InfoRequestForApproval.Committees[${countItems}].EmpId">
                                             ${committeeList}
                                        </select>
                                </div>
                                <div class="col-sm-2">
                                    <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer" onclick="remove_row_committee(this)"></i>
                                </div>
                            </div>
                        </div>`;

	$('#Committee_Render').append(content_html);
	$('.selectpicker').selectpicker('refresh');
}

function remove_row_committee(_this) {
	$(_this).closest(`.Committee_Sub`).remove();
	$('#Committee_Render .Committee_Sub').each(function (index, val) {
		index++
		$(this).attr("class", `Committee_Sub Committee_Sub_${index}`)
		$(this).find('input,select').each(function (index_input) {
			var inputName = $(this).attr("name");
			if (inputName != undefined) {
				$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
			}
		});
	});
}

function NhsoSignerChange(_this) {
	$("#SignerPosition").val('');
	$("#SignerEmail").val('');
	var empId = $(_this).val();
	var NhsoSigner = NhsoSignerListModelList.find(x => x.EmpId === empId);
	if (NhsoSigner != undefined) {
		$("#NhsoSignerUser").val(NhsoSigner.SignerFullname);
		$("#InfoContractNhso_SignerPosition").val(NhsoSigner.SignerPosition);
		$("#InfoContractNhso_SignerEmail").val(NhsoSigner.SignerEmail);
	}
}

function ApprovalReqUserChange(_this) {
	$("#InfoRequestForApproval_ApprovalReqUserPos").val('');
	var empId = $(_this).val();
	var VNhsoEmployee = VNhsoEmployeeAllListModelList.find(x => x.EmpId === empId);
	if (VNhsoEmployee != undefined) {
		$("#InfoRequestForApproval_ApprovalReqUserPos").val(VNhsoEmployee.EmpPosition);
	}
}

//Foot Note (ฝ่ายสำนักงาน)
function insert_row_footnoteNhso() {
	var countItems = $('#FootNoteNhso_Render .FootNote_Sub').length;
	countItems = countItems == 0 ? 1 : (countItems + 1);
	var content_html = `<div class="FootNote_Sub FootNote_Sub_${countItems}">
                            <div class="form-group row">
                                <label class="col-sm-3 col-form-label text-sm-right"></label>
                                <div class="col-sm-4">
                                        <select class="form-control bg-focus selectpicker" data-live-search="true"
                                            name="InfoSignerPartnersOfContract.FootNotesNhso[${countItems}].EmpId">
                                             ${nhsosignerlist}
                                        </select>
                                </div>
                                <div class="col-sm-2">
                                    <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer" onclick="remove_row_footnoteNhso(this)"></i>
                                </div>
                            </div>
                        </div>`;

	$('#FootNoteNhso_Render').append(content_html);
	setSettingDate($('.datepicker'));
	$('.selectpicker').selectpicker('refresh');
}

function remove_row_footnoteNhso(_this) {
	$(_this).closest(`.FootNote_Sub`).remove();
	//จัดลำดับ index กรณีลบข้ามงวด
	$('#FootNoteNhso_Render .FootNote_Sub').each(function (index, val) {
		index++
		//console.log(index)
		$(this).attr("class", `FootNote_Sub FootNote_Sub${index}`)
		$(this).find('input,select').each(function (index_input) {
			var inputName = $(this).attr("name");
			if (inputName != undefined) {
				$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
			}
		});
	});
}

//แนบไฟล์แสกน นิติกรรมสัญญา(ฉบับจริง)
function insert_row_attachfileReal() {

	var countItems = $('#AttachfileReal_Rander .Attachfile_Sub').length;
	//console.log(countItems)
	$('#AttachfileReal_Rander').append(
		`<div class="Attachfile_Sub form-row col-12 form_create">
                 <div class="form-group form-group-file col-12 col-sm-12 col-md-12 col-lg-12 col-xl-4">
                     <div class="custom-file">
                         <input type="file" class="custom-file-input"
                                name="InfoAttachFileRealVersion.SmctMasterFile[${countItems}].FormFile">
                         <input type="hidden" name="InfoAttachFileRealVersion.SmctMasterFile[${countItems}].IdSmctMasterFile" value="">
                         <label class="custom-file-label" for="customFile">Choose file</label>
                     </div>
                 </div>
                 <div class="form-group col-12 col-sm-12 col-md-12 col-lg-12 col-xl-3">
                    <input type="image" src="${hostname}/images/icon/close-2x.png"
                            onclick="remove_row_attachfileReal(this); return false;" class="border-0 mt-2" width="17">
                 </div>
             </div>`
	);
}

function remove_row_attachfileReal(_this) {
	$(_this).closest(`.Attachfile_Sub`).remove();

	$('#AttachfileReal_Rander .Attachfile_Sub').each(function (index, val) {
		$(this).find('.form-group-file').each(function (index_sub) {
			$(this).find('.custom-file input,.custom-file select').each(function (index_input) {
				var inputName = $(this).attr("name");
				if (inputName != undefined) {
					$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
				}
			});
		});
	});
}

function GenFM_APPROVAL_REQ_ONLY(ParameterCon, ApproveProposal = null) {
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
}

function SentMailApprovalReq(ParameterCon, ApproveProposal = null) {
	try {
		console.log('SentMail SentMailApprovalReq....')
		fetch(`${hostname}/ContractType/SentMailApprovalReq?` + new URLSearchParams({
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
				console.log('SentMail :', data);
			})
			.catch((error) => {
				console.error('SentMail Error:', error);
			});
	}
	catch (err) {
		console.log(err);
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
			CadCA: ParameterCon.CadCA
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

function SentMailSigner(ParameterCon) {
	try {
		console.log('SentMail SentMailSigner....')
		fetch(`${hostname}/ContractType/SentMailSigner?` + new URLSearchParams({
			StationReq: ParameterCon.StationReq,
			Style: ParameterCon.Style,
			ContractTypeId: ParameterCon.ContractTypeId,
			ContractTypeIdEn: ParameterCon.ContractTypeIdEn,
			VendorIdCurr: ParameterCon.VendorIdCurr,
			DepartmentCodeCurr: ParameterCon.DepartmentCodeCurr,
			IdSmctMaster: ParameterCon.IdSmctMaster,
			SigningTypeEn: ParameterCon.SigningTypeEn,
			RefId: ParameterCon.RefId,
			IsSentMail: true
		}))
			.then(response => response.json())
			.then(data => {
				console.log('SentMail :', data);
			})
			.catch((error) => {
				console.error('SentMail Error:', error);
			});
	}
	catch (err) {
		console.log(err);
	}
}

//1.ที่เลือก คือ วันเริ่ม
//2.defualf วันสิ้นสุด 31/08/6x  โดยเช็คจากวันเริ่มที่เลือก
//3.ถ้าเลือกวันเริ่ม ต.ค -ธ.ค ให้วันสิ้นสุด 31/08/(ปีของวันเริ่ม + 1)
function CalEndDateChange() {
	const _StartDate = $('#InfoContract_StartDateStr').val();
	if (_StartDate != '') {
		var _StartDateMonth = parseInt(_StartDate.substring(3, 5));
		var _StartDateYear = _StartDate.substring(6);
		var _AddYear = null;
		if (_StartDateMonth >= 10) {
			_AddYear = 1;
		}
		//console.log(_StartDateMonth, _StartDateYear)
		var _StartDateToDate = stringToDate(`31/08/${_StartDateYear}`, "dd/MM/yyyy", "/", _AddYear);
		console.log(_StartDateToDate)
		$('#InfoContract_EndDateStr').val(DateToStringFormatThai(_StartDateToDate));
	}

}


//ให้ระบบ defualt 30/09/256X ของปีงบประมาณ และล็อคห้ามแก้ไขวันที่สิ้นสุด
//1.ที่เลือก คือ วันเริ่ม และห้ามเลือกย้อนหลังวันที่ปัจจุบัน
//2.defualf วันสิ้นสุด 30/09/256X โดยเช็คจากวันเริ่มที่เลือก
//3.ถ้าเลือกวันเริ่ม ต.ค-ธ.ค ให้วันสิ้นสุด 30/09/(ปีของวันเริ่ม + 1)
$('#InfoContract_StartDateStr').on('change', function () {
	console.log(`StartDate change...${this.value.length} ${this.value}`)
	if (this.value != '') {
		if (this.value.length == 10) {
			var endDateMonth = parseInt(this.value.substring(3, 5));
			var endDateYear = parseInt(this.value.substring(6));
			//console.log(endDateDay, endDateMonth, endDateYear)
			if (endDateMonth >= 10) {
				endDateYear++;
				console.log(`ปีงบประมาณใหม่ ${endDateYear}`)
				setTimeout(function () {
					$('#InfoContract_EndDateStr').val(`30/09/${endDateYear}`);
				}, 100);
			}

		}
	}
});