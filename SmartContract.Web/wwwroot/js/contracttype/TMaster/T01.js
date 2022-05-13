

$(function () {
	SetStation();
	CB_G_P19();
	CB_G_P26();
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

	var _Menu = $(`#ParameterCondition_Menu`).val();
	if (_Station == 'S5' || _Station == 'S6' || _Station == 'S7' && _Menu != 'T1') {

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

$('.cb_group_p19').on('change', function () {
	$('.cb_group_p19').not(this).prop('checked', false);
	CB_G_P19();
});

$('.cb_group_p26').on('change', function () {
	$('.cb_group_p26').not(this).prop('checked', false);
	CB_G_P26();
});

//
function CB_G_P26() {
	var isCheckP26_CB_1 = $('#P26_CB_1').is(":checked");
	if (isCheckP26_CB_1) {

	} else {

	}
	//หน่วยบริการที่รับการส่งต่อ --> เฉพาะทาง
	var isCheckP26_CB_2 = $('#P26_CB_2').is(":checked");
	if (isCheckP26_CB_2) {
		$('#AddRemoveP19_G_2').removeClass('d-none');
	} else {
		$('#AddRemoveP19_G_2').addClass('d-none');
		$('#InfoConDetail_ContractDetail01_P27').val('');
		for (var i = 1; i <= 4; i++) {
			Render_3_1_G_2_Remove(i);
		}
	}
}
function CB_G_P19() {
	//หน่วยบริการประจำ
	var isCheckP19_CB_1 = $('#P19_CB_1').is(":checked");
	if (isCheckP19_CB_1) {
		$('#AddRemoveP19_G_1').removeClass('d-none');
	} else {
		$('#AddRemoveP19_G_1').addClass('d-none');
		$('#InfoConDetail_ContractDetail01_P20').val('');
		for (var i = 1; i <= 4; i++) {
			Render_3_1_G_1_Remove(i);
		}
	}
	//หน่วยบริการที่รับการส่งต่อ
	var isCheckP19_CB_3 = $('#P19_CB_3').is(":checked");
	if (isCheckP19_CB_3) {
		$("input[name='InfoConDetail.ContractDetail01.P26']").prop('disabled', false);
	} else {
		$('#AddRemoveP19_G_2').addClass('d-none');
		$("input[name='InfoConDetail.ContractDetail01.P26']").prop('disabled', true);
		$("input[name='InfoConDetail.ContractDetail01.P26']").not(this).prop('checked', false);
		$('#InfoConDetail_ContractDetail01_P27').val('');
		for (var i = 1; i <= 4; i++) {
			Render_3_1_G_2_Remove(i);
		}
	}
	//หน่วยที่ร่วมบริการ
	var isCheckP19_CB_4 = $('#P19_CB_4').is(":checked");
	if (isCheckP19_CB_4) {
		$('#AddRemoveP19_G_3').removeClass('d-none');
	} else {
		$('#AddRemoveP19_G_3').addClass('d-none');
		$('#InfoConDetail_ContractDetail01_P32').val('');
		for (var i = 1; i <= 4; i++) {
			Render_3_1_G_3_Remove(i);
		}
	}
}

//2.5 ผนวก 5 ----------------------------------------------
function AddRemove_P2_5(type) {
	var countItems = $('#Render_2_5 .Render_2_5_Sub.show').length;
	if (type == 'A') Render_2_5_Add(countItems + 1);
	if (type == 'D') Render_2_5_Remove(countItems);
}

function Render_2_5_Add(val) {
	$(`#25${val}`).removeClass('d-none').addClass('show');
}

function Render_2_5_Remove(val) {
	$(`#25${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}

//3.1 หน่วยบริการประจำ --------------------------------------
function AddRemove_P3_1_G_1(type) {
	var countItems = $('#Render_3_1_G_1 .Render_3_1_G_1_sub.show').length;
	if (type == 'A') Render_3_1_G_1_Add(countItems + 1);
	if (type == 'D') Render_3_1_G_1_Remove(countItems);
}

function Render_3_1_G_1_Add(val) {
	$(`#31G1_${val}`).removeClass('d-none').addClass('show');
}

function Render_3_1_G_1_Remove(val) {
	$(`#31G1_${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}

//3.1 หน่วยบริการที่รับการส่งต่อ --> เฉพาะทาง ---------------------------------------------
function AddRemove_P3_1_G_2(type) {
	var countItems = $('#Render_3_1_G_2 .Render_3_1_G_2_sub.show').length;
	if (type == 'A') Render_3_1_G_2_Add(countItems + 1);
	if (type == 'D') Render_3_1_G_2_Remove(countItems);
}

function Render_3_1_G_2_Add(val) {
	$(`#31G2_${val}`).removeClass('d-none').addClass('show');
}

function Render_3_1_G_2_Remove(val) {
	$(`#31G2_${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}

//3.1 หน่วยที่ร่วมบริการ ---------------------------------------------
function AddRemove_P3_1_G_3(type) {
	var countItems = $('#Render_3_1_G_3 .Render_3_1_G_3_sub.show').length;
	if (type == 'A') Render_3_1_G_3_Add(countItems + 1);
	if (type == 'D') Render_3_1_G_3_Remove(countItems);
}

function Render_3_1_G_3_Add(val) {
	$(`#31G3_${val}`).removeClass('d-none').addClass('show');
}

function Render_3_1_G_3_Remove(val) {
	$(`#31G3_${val}`).removeClass('show').addClass('d-none').find(':input').val('');
}

//3.2.1 กรณีหน่วยบริการประจำและหรือปฐมภูมิ
function CB_321_24_G_1() {
	var isCheckP37 = $('#InfoConDetail_ContractDetail01_IsP37').is(":checked");
	if (isCheckP37) {
		$("#InfoConDetail_ContractDetail01_P38").val('').prop('disabled', true);
		$("#InfoConDetail_ContractDetail01_P39").val('').prop('disabled', true);
	} else {
		$("#InfoConDetail_ContractDetail01_P38").prop('disabled', false);
		$("#InfoConDetail_ContractDetail01_P39").prop('disabled', false);
	}
}
function CB_321_24_G_2() {
	var isCheckP40 = $('#InfoConDetail_ContractDetail01_IsP40').is(":checked");
	if (isCheckP40) {
		$("#InfoConDetail_ContractDetail01_P41").val('').prop('disabled', true);
		$("#InfoConDetail_ContractDetail01_P42").val('').prop('disabled', true);
	} else {
		$("#InfoConDetail_ContractDetail01_P41").prop('disabled', false);
		$("#InfoConDetail_ContractDetail01_P42").prop('disabled', false);
	}
}
//3.2.2 กรณีหน่วยบริการที่รับส่งต่อทั่วไปและหรือเฉพาะด้าน
function CB_322_24_G_1() {
	var isCheckP43 = $('#InfoConDetail_ContractDetail01_IsP43').is(":checked");
	if (isCheckP43) {
		$("#InfoConDetail_ContractDetail01_P44").val('').prop('disabled', true);
		$("#InfoConDetail_ContractDetail01_P45").val('').prop('disabled', true);
	} else {
		$("#InfoConDetail_ContractDetail01_P44").prop('disabled', false);
		$("#InfoConDetail_ContractDetail01_P45").prop('disabled', false);
	}
}
function CB_322_24_G_2() {
	var isCheckP46 = $('#InfoConDetail_ContractDetail01_IsP46').is(":checked");
	if (isCheckP46) {
		$("#InfoConDetail_ContractDetail01_P47").val('').prop('disabled', true);
		$("#InfoConDetail_ContractDetail01_P48").val('').prop('disabled', true);
	} else {
		$("#InfoConDetail_ContractDetail01_P47").prop('disabled', false);
		$("#InfoConDetail_ContractDetail01_P48").prop('disabled', false);
	}
}
//3.2.3 กรณีหน่วยบริการร่วมให้บริการ
function CB_323_24_G_1() {
	var isCheckP50 = $('#InfoConDetail_ContractDetail01_IsP50').is(":checked");
	if (isCheckP50) {
		$("#InfoConDetail_ContractDetail01_P51").val('').prop('disabled', true);
		$("#InfoConDetail_ContractDetail01_P52").val('').prop('disabled', true);
	} else {
		$("#InfoConDetail_ContractDetail01_P51").prop('disabled', false);
		$("#InfoConDetail_ContractDetail01_P52").prop('disabled', false);
	}
}
function CB_323_24_G_2() {
	var isCheckP53 = $('#InfoConDetail_ContractDetail01_IsP53').is(":checked");
	if (isCheckP53) {
		$("#InfoConDetail_ContractDetail01_P54").val('').prop('disabled', true);
		$("#InfoConDetail_ContractDetail01_P55").val('').prop('disabled', true);
	} else {
		$("#InfoConDetail_ContractDetail01_P54").prop('disabled', false);
		$("#InfoConDetail_ContractDetail01_P55").prop('disabled', false);
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
		console.log(ParameterCon.Station, ParameterCon.ItemStatusCurr)
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
