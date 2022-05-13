
$(function () {
	RegisterTypeChange('P11');
	setDateThai($('#Sp7DateStr'));
	setDateThai($('#UserSmct_UserSmctSigners_Signer1DocDateStr'));
	setDateThai($('#UserSmct_UserSmctSigners_Signer2PoaDocDateStr'));
	setDateThai($('#UserSmct_UserSmctSigners_Signer2DocDateStr'));
	setDateThai($('#UserSmct_UserSmctSigners_Signer2StartDateStr'));
	setDateThai($('#UserSmct_UserSmctSigners_Signer2EndDateStr'));
	UserSignerChange();
	//GetServiceUnits();
	GetMasterVendor();
	RoleCodeChange();
	//ProvinceChange($("#ProvinceIdCatm").val());
	SetLookupCatm();
})


function GetServiceUnits(_nhsoZone = null) {
	console.log(_nhsoZone)
	var urlfull = `${hostname}/CallData/ServiceUnits`;
	//console.log(urlfull)
	AjaxPost(urlfull, true, { nhsoZone: _nhsoZone }, function (response) {
		if (response.Status) {
			if (response.Result != null && response.Result != undefined) {
				var data = response.Result;
				//console.log(data)
				$("#RegisterNhso_Hcode").empty();
				$('#RegisterNhso_Hcode').append('<option value="00000">---เลือก---</option>');
				$('#RegisterNhso_Hcode').append('<option value="99999">---ไม่มี---</option>');
				data.forEach(function (item, idx, array) {
					//console.log(item, idx, array)
					$('#RegisterNhso_Hcode').append(`<option value='${item.Hcode}'>(${item.Hcode}) ${item.VendorName}</option>`);
					if (idx === array.length - 1) {
						var hcode_db = $("#Hcode_db").val();
						if (hcode_db != null && hcode_db != undefined) {
							$("#RegisterNhso_Hcode").val(hcode_db);
							$("#RegisterNhso_Hcode").selectpicker("refresh");
						}
					}
				});
				$("#RegisterNhso_Hcode").selectpicker("refresh");

			}
		} else {
			//SweetAlert2Warning(response.MessagError);
		}
	});
}

function GetMasterVendor() {
	var _hcode = $("#RegisterNhso_Hcode").val();
	var _NhsoZone = $("#NhsoZone").val();
	var urlfull = `${hostname}/CallData/MasterVendor`;
	AjaxPost(urlfull, true, { hcode: _hcode, nhsoZone: _NhsoZone }, function (response) {
		if (response.Status) {
			if (response.Result != null && response.Result != undefined) {
				var data = response.Result;
				//console.log(data)    
				$("#RegisterNhso_VendorId").empty();
				$('#RegisterNhso_VendorId').append('<option value="">---เลือก---</option>');
				$('#RegisterNhso_VendorId').append('<option value="99999">(---ไม่มี---)</option>');
				data.forEach(function (item, idx, array) {
					//console.log(item)
					$('#RegisterNhso_VendorId').append(`<option value='${item.VendorId}'>(${item.VendorId}) ${item.VendorName}</option>`);
					if (idx === array.length - 1) {
						var hcode_db = $("#Hcode_db").val();
						if (hcode_db != null && hcode_db != undefined) {
							$("#RegisterNhso_VendorId").val(hcode_db);
							$("#RegisterNhso_VendorId").selectpicker("refresh");
						}
					}
				});
				$("#RegisterNhso_VendorId").selectpicker("refresh");
			}
		} else {
			//SweetAlert2Warning(response.MessagError);
		}
	});
}

function SetLookupCatm() {

	var provinceId = $("#ProvinceIdCatm").val();
	var amphurId = $("#AmphurId_db").val();
	var districtId = $("#DistrictId_db").val();

	if (provinceId != null && provinceId != undefined) {
		ProvinceChange(provinceId);
		$("#ProvinceIdCatm").val(provinceId);
		$("#ProvinceIdCatm").selectpicker("refresh");
		if (amphurId != null && amphurId != undefined) {
			AmphurChange(amphurId);
			$("#AmphurId").val(amphurId);
			$("#AmphurId").selectpicker("refresh");
			if (districtId != null && districtId != undefined) {
				$("#DistrictId").val(districtId);
				$("#DistrictId").selectpicker("refresh");
			}
		}
	}

	//var hcode_db = $("#Hcode_db").val();
	////if (hcode_db != null && hcode_db != undefined) {
	////    $("#RegisterNhso_Hcode").val(hcode_db);
	////}
	//setTimeout(function () {
	//    console.log(hcode_db)
	//    $("#RegisterNhso_Hcode").val('21795');
	//    $("#RegisterNhso_Hcode").selectpicker("refresh");
	//}, 1000)


}

function ProvinceChange(provinceId) {
	//console.log(provinceId)
	if (provinceId != null && provinceId != undefined) {
		var urlfull = `${hostname}/CallData/LKAmphurs`;
		//console.log(provinceId)
		AjaxPost(urlfull, false, { provinceId: provinceId }, function (response) {
			if (response.Status) {
				$("#DistrictId").empty();
				$("#AmphurId").empty();
				$('#AmphurId').append('<option value="00000">---เลือก---</option>');
				response.Result.forEach(function (item) {
					//console.log(item)
					$('#AmphurId').append(`<option value='${item.AmphurId}'>(${item.AmphurId}) ${item.Name}</option>`);
				});
				$("#DistrictId").selectpicker("refresh");
				$("#AmphurId").selectpicker("refresh");
			} else {
				SweetAlert2Warning(response.MessagError);
			}
		});
	}
}

function AmphurChange(amphurId) {

	var provinceId = $("#ProvinceIdCatm").val().substr(0, 2);

	var _code = `${provinceId}${amphurId}`;

	var urlfull = `${hostname}/CallData/LKDistricts`;
	AjaxPost(urlfull, false, { code: _code }, function (response) {
		//console.log(response)
		if (response.Status) {
			$("#DistrictId").empty();
			$('#DistrictId').append('<option value="00000">---เลือก---</option>');
			response.Result.forEach(function (item) {
				//console.log(item)
				$('#DistrictId').append(`<option value='${item.DistrictId}'>(${item.DistrictId}) ${item.Name}</option>`);
			});
			$("#DistrictId").selectpicker("refresh");
		} else {
			SweetAlert2Warning(response.MessagError);
		}
	});
}

function NhsoZoneChange(nhsoZone) {
	GetServiceUnits(nhsoZone);
}

function HcodeChange(hcode) {
	//console.log(hcode, $('#NhsoZone').val())
	var _hcode = hcode;
	var urlfull = `${hostname}/CallData/MasterVendor`;
	ClearRegisterNhso();

	AjaxPost(urlfull, false, { hcode: _hcode, nhsoZone: $('#NhsoZone').val() }, function (response) {
		if (response.Status) {
			if (response.Result != null && response.Result != undefined) {
				//console.log(response.Result.length)
				if (response.Result.length == 1) {
					var data = response.Result[0];
					//console.log(data)
					if (data.CheckRegister) {
						DisabledCompanyDetails();
						$("#CheckRegister").val(true);
					}
					SetRegisterNhso(data);
				} else {
					$("#CheckRegister").val(false);
				}
				GetMasterVendor();
			}
		} else {
			SweetAlert2Warning(response.MessagError);
		}
	});


	GetAttachSystem(_hcode);

}

function GetAttachSystem(hcode) {
	var _hcode = hcode;
	var urlfull = `${hostname}/CallData/GetAttachSystem`;

	AjaxPost(urlfull, false, { hcode: _hcode }, function (response) {
		$('#AttachfileSystem_Rander').empty();
		if (response.Status) {
			if (response.Result != null && response.Result != undefined) {
				console.log(response.Result)
				if (response.Result.length > 0) {
					response.Result.forEach(function (item, idx, array) {
						//console.log(item)
						$('#AttachfileSystem_Rander').append(
							`<div class="row">
								<label class="col-sm-3 col-form-label ml-5">${item.OriginalFileName}</label>
								<div class="col-sm-4 ">
									<a style="margin-left:5px;" target="_blank" href="${item.Url}">
										<i class="fas fa-file-pdf fa-lg"></i> View
									</a>
								</div>
							</div>`
						);
					});
				} else {
					$('#AttachfileSystem_Rander').append(
						`<div class="row">
							<label class="col-sm-3 col-form-label ml-5">-ไม่มี-</label>
						</div>`
					);					
				}
			}
		} else {
			SweetAlert2Warning(response.MessagError);
		}
	});
}

function SetRegisterNhso(data) {

	$("#RegisterNhso_Building").val(data.Building);
	$("#RegisterNhso_CompanyName").val(data.CompanyName);
	$("#RegisterNhso_RegisterAt").val(data.RegisterAt);
	$("#RegisterNhso_PostCode").val(data.PostCode);
	$("#RegisterNhso_VillageNo").val(data.VillageNo);
	$("#RegisterNhso_Soi").val(data.Soi);
	$("#RegisterNhso_TaxId").val(data.TaxId);
	$("#RegisterNhso_Road").val(data.Road);
	$("#RegisterNhso_Sp7").val(data.Sp7);

	if (data.VendorId != null && data.VendorId != undefined) {
		$("#RegisterNhso_VendorId").val(data.VendorId);
		$("#VendorId").val(data.VendorId);
		$("#RegisterNhso_VendorId").prop('disabled', true);
		$("#RegisterNhso_VendorId").selectpicker("refresh");
	} else {
		$("#RegisterNhso_VendorId").val('');
		$("#VendorId").val('');
		$("#RegisterNhso_VendorId").prop('disabled', false);
		$("#RegisterNhso_VendorId").selectpicker("refresh");
	}
	$("#RegisterNhso_VendorName").val(data.VendorName);

	//จังหวัดที่ตั้ง
	if (data.ProvinceId != null && data.ProvinceId != undefined) {
		var provinceId = data.ProvinceId;
		$("#ProvinceId").val(provinceId);
		$("#ProvinceId").selectpicker("refresh");
	}
	//CATM
	if (data.Catm != null && data.Catm != undefined) {
		var ProvinceIdCatm = data.Catm.substr(0, 2);
		ProvinceChange(ProvinceIdCatm);
		$("#ProvinceIdCatm").val(ProvinceIdCatm);
		$("#ProvinceIdCatm").selectpicker("refresh");
		//console.log(data.Catm)
		if (data.Catm.length >= 4) {
			var amphur = data.Catm.substr(2, 2);
			//console.log('amphur=', amphur)
			AmphurChange(amphur);
			$("#AmphurId").val(amphur);
			$("#AmphurId").selectpicker("refresh");
			if (data.Catm.length >= 6) {
				var district = data.Catm.substr(4, 2);
				//console.log('district=', district)
				$("#DistrictId").val(district);
				$("#DistrictId").selectpicker("refresh");
			}
		}
	}
}

function ClearRegisterNhso(type = '') {
	$('.CompanyDetails').prop('disabled', false);
	$("#RegisterNhso_Building").val('');
	$("#RegisterNhso_CompanyName").val('');
	$("#RegisterNhso_RegisterAt").val('');
	$("#RegisterNhso_PostCode").val('');
	$("#RegisterNhso_VillageNo").val('');
	$("#RegisterNhso_Soi").val('');
	$("#RegisterNhso_TaxId").val('');
	$("#RegisterNhso_Road").val('');
	$("#RegisterNhso_Sp7").val('');

	$("#ProvinceId").val('');
	$("#ProvinceId").prop('disabled', false);
	$("#ProvinceId").selectpicker("refresh");

	//vc=OnChange Vendor
	if (type != 'vc') {
		$("#VendorId").val('');
		$("#RegisterNhso_VendorId").val('');
		$("#RegisterNhso_VendorId").prop('disabled', false);
		$("#RegisterNhso_VendorId").selectpicker("refresh");
	}
	$("#RegisterNhso_VendorName").val('');

	$("#ProvinceIdCatm").val('');
	$("#ProvinceIdCatm").prop('disabled', false);
	$("#ProvinceIdCatm").selectpicker("refresh");
	$("#AmphurId").val('');
	$("#AmphurId").prop('disabled', false);
	$("#AmphurId").selectpicker("refresh");
	$("#DistrictId").val('');
	$("#DistrictId").prop('disabled', false);
	$("#DistrictId").selectpicker("refresh");
}

function DisabledCompanyDetails() {
	$('.CompanyDetails').prop('disabled', true);

	$("#ProvinceId").val('');
	$("#ProvinceId").prop('disabled', true);
	$("#ProvinceId").selectpicker("refresh");

	$("#VendorId").val('');
	$("#RegisterNhso_VendorId").prop('disabled', true);
	$("#RegisterNhso_VendorId").selectpicker("refresh");

	$("#ProvinceIdCatm").prop('disabled', true);
	$("#ProvinceIdCatm").selectpicker("refresh");

	$("#AmphurId").prop('disabled', true);
	$("#AmphurId").selectpicker("refresh");

	$("#DistrictId").prop('disabled', true);
	$("#DistrictId").selectpicker("refresh");

}

function VendorChange(vendorId) {
	console.log(vendorId)
	$("#VendorId").val(vendorId);
	$('input[name="GPType"]').prop('checked', false);
	if (vendorId == "99999") { //ไม่มี
		$("#group_gp").removeClass('d-none');
		$("#group_top_gp").addClass('d-none');
		ClearRegisterNhso('vc')
	} else {
		$("#group_gp").addClass('d-none');
		$("#group_top_gp").removeClass('d-none');

		var urlfull = `${hostname}/CallData/MasterVendor`;
		ClearRegisterNhso();

		AjaxPost(urlfull, false, { vendorId: vendorId }, function (response) {
			console.log(response)
			if (response.Status) {
				if (response.Result.length == 1) {
					var data = response.Result[0];
					DisabledCompanyDetails();
					SetRegisterNhso(data);
					$("#CheckRegister").val(true);
				} else {
					$("#CheckRegister").val(false);
				}
			} else {
				SweetAlert2Warning(response.MessagError);
			}
		});

	}


}

function RegisterTypeChange(value) {
	//console.log(value)
	DisabledCompanyDetails();
	if (value == 'P11') {
		$("#RegisterNhso_VendorId").val('');
		$("#RegisterNhso_VendorId").prop('disabled', true);
		$("#RegisterNhso_VendorId").selectpicker("refresh");

		$("#RegisterNhso_Hcode").val('');
		$("#RegisterNhso_Hcode").prop('disabled', false);
		$("#RegisterNhso_Hcode").selectpicker("refresh");
	} else if (value == 'P21') {
		$("#RegisterNhso_VendorId").val('');
		$("#RegisterNhso_VendorId").prop('disabled', false);
		$("#RegisterNhso_VendorId").selectpicker("refresh");

		$("#RegisterNhso_Hcode").val('');
		$("#RegisterNhso_Hcode").prop('disabled', true);
		$("#RegisterNhso_Hcode").selectpicker("refresh");

	}
}

function RoleCodeChange() {
	var userRoleCode = $("#UserSmct_UserRights_IdUserRole").val();
	var approvetype = $("#Approvetype").val();
	if (approvetype == 'S' || userRoleCode == '95BF9F39536E40AAAAA967B1B402DD85' || userRoleCode == '50CFFEF3D4BB4529B3134E923B1B4B9E') {
		$("#tab_usersmctsigner").prop('hidden', false);
		if (userRoleCode == '95BF9F39536E40AAAAA967B1B402DD85') {
			$("#ele_SignerTypeS1").show();
			$("#ele_SignerTypeS2").hide();
			$("input[name='UserSmct.UserSmctSigners.SignerType'][value='S1']").prop('checked', true);
		} else if (userRoleCode == '50CFFEF3D4BB4529B3134E923B1B4B9E') {
			$("#ele_SignerTypeS2").show();
			$("#ele_SignerTypeS1").hide();
			$("input[name='UserSmct.UserSmctSigners.SignerType'][value='S2']").prop('checked', true);
		}
		UserSignerChange()
	} else {
		$("#tab_usersmctsigner").prop('hidden', true);
		$("#UserSmct_UserSmctSigners_SignerType").prop('checked', true);
	}
}

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
                                name="FileList[${countItems}].FormFile">
                         <input type="hidden" name="FileList[${countItems}].IdRegisterNhsoFile" value="">
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

function insert_row_attachfileSigner() {

	var countItems = $('#AttachfileSigner_Rander .AttachfileSigner_Sub').length;
	//console.log(countItems)
	$('#AttachfileSigner_Rander').append(
		`<div class="AttachfileSigner_Sub form-row col-12 form_create">
                 <div class="form-group form-group-file col-12 col-sm-12 col-md-12 col-lg-12 col-xl-4">
                     <div class="custom-file">
                         <input type="file" class="custom-file-input"
                                name="UserSmct.UserSmctSigners.UserSmctSignerFiles[${countItems}].FormFile">
                         <input type="hidden"
                                name="UserSmct.UserSmctSigners.UserSmctSignerFiles[${countItems}].IdUserSmctSignerFile" value="">
                         <label class="custom-file-label" for="customFile">Choose file</label>
                     </div>
                 </div>
                 <div class="form-group col-12 col-sm-12 col-md-12 col-lg-12 col-xl-3">
                    <input type="image" src="${hostname}/images/icon/close-2x.png"
                            onclick="remove_row_attachfileSigner(this); return false;" class="border-0 mt-2" width="17">
                 </div>
             </div>`
	);
}

function remove_row_attachfileSigner(_this) {
	$(_this).closest(`.AttachfileSigner_Sub`).remove();

	$('#AttachfileSigner_Rander .AttachfileSigner_Sub').each(function (index, val) {
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

function UserSignerChange() {

	var IsChecked = $(".DecisionMaker:checked").val();
	//console.log(IsChecked)

	if (IsChecked == 'S1') {
		//$('#DecisionMaker_Radios2_Deail').hide();
		$('#Group_SignerType_S1').prop('disabled', false);
		$('#Group_SignerType_S2').prop('disabled', true);
		$('#UserSmct_UserSmctSigners_Signer2PoaSigner1User').prop('disabled', true);
		$('#UserSmct_UserSmctSigners_Signer2PoaSigner1User').selectpicker('refresh');
		$('#UserSmct_UserSmctSigners_Signer1User').prop('disabled', false);
		$('#UserSmct_UserSmctSigners_Signer1User').selectpicker('refresh');
	}
	else if (IsChecked == 'S2') {
		//$('#DecisionMaker_Radios2_Deail').show();
		$('#Group_SignerType_S1').prop('disabled', true);
		$('#Group_SignerType_S2').prop('disabled', false);
		$('#UserSmct_UserSmctSigners_Signer1User').prop('disabled', true);
		$('#UserSmct_UserSmctSigners_Signer1User').selectpicker('refresh');
		$('#UserSmct_UserSmctSigners_Signer2PoaSigner1User').prop('disabled', false);
		$('#UserSmct_UserSmctSigners_Signer2PoaSigner1User').selectpicker('refresh');
	} else {
		//$('#DecisionMaker_Radios2_Deail').hide();
		$('#Group_SignerType_S1').prop('disabled', false);
		$('#Group_SignerType_S2').prop('disabled', false);
		$('#UserSmct_UserSmctSigners_Signer2PoaSigner1User').selectpicker('refresh');
	}
}

function ModalDetailShow() {
	$("#ModalDetail").modal('show');
}


onbeginForm = function (xhr) {

	showLoading();
};

completedForm = function (xhr) {
	hideLoading()
	console.log(xhr.responseJSON);
	if (xhr.responseJSON.Status == false && xhr.responseJSON.MessagError != null) {
		SweetAlert2Warning(xhr.responseJSON.MessagError);
	} else {
		SweetAlert2Success(xhr.responseJSON.UrlRedirect);
	}
};

failedForm = function (xhr) {
	console.log(xhr);
	SweetAlert2Warning(`${xhr.status} ${xhr.statusText}\nเกิดข้อผิดพลาดในการบันทึกข้อมูล`);
};
