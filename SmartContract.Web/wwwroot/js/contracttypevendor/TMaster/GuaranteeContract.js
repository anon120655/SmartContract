

var bankinfosList = ``;

$(document).ready(function () {
	InitialGuarantee();
	PerformanceBond1opt();
	P4SelectBank();
});

function InitialGuarantee() {

	setTimeout(function () {
		var countItems = $('#CashierCheck_Render').length + 1;
		//console.log(countItems)
		for (var i = 0; i <= countItems; i++) {
			setDateThai($(`input[name='InfoGuaranteeContract.CashierChequeDesc[${i}].DateStr']`));
		}
	}, 500);

	setTimeout(function () {
		var countItems = $('#BookGuarantee_Render').length + 1;
		console.log(countItems)
		for (var i = 0; i <= countItems; i++) {
			var BankCode = $(`select[name='InfoGuaranteeContract.BookGuaranteeDesc[${i}].BankCode']`).val();
			BookGuaranteeChange(BankCode, i, false);
			//setDateThai($(`input[name='InfoGuaranteeContract.BookGuaranteeDesc[${i}].StartDateStr']`));
			//setDateThai($(`input[name='InfoGuaranteeContract.BookGuaranteeDesc[${i}].EndDateStr']`));
		}
	}, 500);

	$.each(bankinfosModelList, function (index, val) {
		if (index == 0) {
			bankinfosList += `<option value=''>---เลือก---</option>`;
		}
		bankinfosList += `<option value='${val.BankId}'>(${val.BankId})${val.BankName}</option>`;
	});

}


//$(document).on('click', '.PerformanceBondOpt', function () {
//    $('.PerformanceBondOpt').not(this).prop('checked', false);
//});

$(".PerformanceBondOptGuaranteeType4").change(function () {
	if ($("input[name='InfoGuaranteeContract.GuaranteeType4']").is(":checked")) {
		$("input[name='InfoGuaranteeContract.GuaranteeType1']").prop('checked', false);
		$("input[name='InfoGuaranteeContract.GuaranteeType2']").prop('checked', false);
		$("input[name='InfoGuaranteeContract.GuaranteeType3']").prop('checked', false);
	} else {
		$("input[name='InfoGuaranteeContract.DeductedAmountMoney']").attr('readonly', true);
	}
	PerformanceBond1opt();
});

$(".PerformanceBondOpt").change(function () {
	PerformanceBond1opt();
});


$("#P4SelectBank").change(function () {
	P4SelectBank();
});


function P4SelectBank() {
	if ($("#P4SelectBank").val() == "01") {
		$('#P4labelDateStart').show();
		$('#P4labelDateEnd').show();
		$('#P4DateStart').hide();
		$('#P4DateEnd').hide();
	} else {
		$('#P4labelDateStart').hide();
		$('#P4labelDateEnd').hide();
		$('#P4DateStart').show();
		$('#P4DateEnd').show();
	}
}

function PerformanceBond1opt() {

	if ($("input[name='InfoGuaranteeContract.GuaranteeType4']").is(":checked")) {
		$("input[name='InfoGuaranteeContract.DeductedAmountMoney']").attr('readonly', false);
	} else {
		$("input[name='InfoGuaranteeContract.DeductedAmountMoney']").attr('readonly', true);
	}

	if ($("input[name='InfoGuaranteeContract.GuaranteeType1']").is(":checked")) {
		$("input[name='InfoGuaranteeContract.GuaranteeType4']").prop('checked', false);
		$("input[name='InfoGuaranteeContract.AmountMoney']").attr('readonly', false);

	} else {
		$("input[name='InfoGuaranteeContract.AmountMoney']").attr('readonly', true);
	}

	if ($("input[name='InfoGuaranteeContract.GuaranteeType2']").is(":checked")) {
		$("input[name='InfoGuaranteeContract.GuaranteeType4']").prop('checked', false);
		$('.Group_CashierCheck').prop('disabled', false);
		$('.Group_CashierCheck .selectpicker').prop('disabled', false);
		$('.Group_CashierCheck .selectpicker').selectpicker('refresh');
		$('.Group_CashierCheck').find("button").removeClass("btn-light");
		$('.CashierCheque_PlusMins').show();
	} else {
		$('.Group_CashierCheck').prop('disabled', true);
		$('.Group_CashierCheck .selectpicker').prop('disabled', true);
		$('.Group_CashierCheck .selectpicker').selectpicker('refresh');
		$('.CashierCheque_PlusMins').hide();
	}

	if ($("input[name='InfoGuaranteeContract.GuaranteeType3']").is(":checked")) {
		$("input[name='InfoGuaranteeContract.GuaranteeType4']").prop('checked', false);
		$('.Group_BookGuarantee').prop('disabled', false);
		$('.Group_BookGuarantee .selectpicker').prop('disabled', false);
		$('.Group_BookGuarantee .selectpicker').selectpicker('refresh');
		$('.Group_BookGuarantee').find("button").removeClass("btn-light");
		$('.BookGuarantee_PlusMins').show();

	} else {
		$('.Group_BookGuarantee').prop('disabled', true);
		$('.Group_BookGuarantee .selectpicker').prop('disabled', true);
		$('.Group_BookGuarantee .selectpicker').selectpicker('refresh');
		$('.BookGuarantee_PlusMins').hide();
	}

}

//แคชเชียร์เช็ค
function insert_row_CashierCheck() {
	var countItems = $('#CashierCheck_Render .Cashiercheck_Sub').length + 1;
	var content_html = `<div class="Cashiercheck_Sub Cashiercheck_Sub_${countItems}">
                                    <div class="form-group row">
                                        <div class="col-sm-3"></div>
                                        <label class="col-sm-1 col-form-label text-sm-right">ธนาคาร :</label>
                                        <div class="col-sm-3">
                                            <select class="form-control bg-focus selectpicker" data-live-search="true"
                                                    name="InfoGuaranteeContract.CashierChequeDesc[${countItems}].BankCode">
                                                ${bankinfosList}
                                            </select>
                                        </div>
                                        <label class="col-sm-1 col-form-label text-sm-right">เลขที่เช็ค :</label>
                                        <div class="col-sm-2 ">
                                            <input type="text" class="form-control bg-focus"
                                                   name="InfoGuaranteeContract.CashierChequeDesc[${countItems}].CheckNumber"
                                                   value="" placeholder="">
                                        </div>
                                        <div class="col-sm-2">
                                            <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer CashierCheque_PlusMins" onclick="remove_row_CashierCheck(this)"></i>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-4 col-form-label text-sm-right">วันที่ :</label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control bg-focus input_icon_calendar datepicker"
                                                   name="InfoGuaranteeContract.CashierChequeDesc[${countItems}].DateStr"
                                                   value=""
                                                   placeholder="วว/ดด/ปปปป" autocomplete="off">
                                        </div>
                                        <label class="col-sm-1 col-form-label text-sm-right">จำนวนเงิน :</label>
                                        <div class="col-sm-2 ">
                                            <input type="text" class="form-control bg-focus moneyformat"
                                                   name="InfoGuaranteeContract.CashierChequeDesc[${countItems}].AmountMoney"
                                                   value=""
                                                   placeholder="0.00">
                                        </div>
                                        <label class="col-sm-1 col-form-label">บาท</label>
                                    </div>
                                    <hr class="mt-2 mb-3 width_75" />
                                </div>`;

	$('#CashierCheck_Render').append(content_html);
	setSettingDate($('.datepicker'));
	$('.selectpicker').selectpicker('refresh');
}

function remove_row_CashierCheck(_this) {
	$(_this).closest(`.Cashiercheck_Sub`).remove();
	//จัดลำดับ index กรณีลบข้ามงวด
	$('#CashierCheck_Render .Cashiercheck_Sub').each(function (index, val) {
		index++
		//console.log(index)
		$(this).attr("class", `Cashiercheck_Sub Cashiercheck_Sub_${index}`)
		$(this).find('input,select').each(function (index_input) {
			var inputName = $(this).attr("name");
			if (inputName != undefined) {
				$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
			}
		});
	});
}

//หนังสือค้ำประกัน
function insert_row_BookGuarantee() {
	var countItems = $('#BookGuarantee_Render .BookGuarantee_Sub').length + 1;
	var content_html = `<div class="BookGuarantee_Sub BookGuarantee_Sub_${countItems}">
                           <div class="form-group row">
                                <div class="col-sm-3"></div>
                                <label class="col-sm-1 col-form-label text-sm-right">ธนาคาร :</label>
                                <fieldset class="col-sm-3 Group_BookGuarantee">
                                    <select class="bankcode_${countItems} form-control bg-focus selectpicker" data-live-search="true" onchange="BookGuaranteeChange(this,${countItems})"
                                            name="InfoGuaranteeContract.BookGuaranteeDesc[${countItems}].BankCode">
                                            ${bankinfosList}
                                    </select>
                                </fieldset>
                                <label class="col-sm-1 col-form-label text-sm-right pl-sm-0">เลขที่หนังสือ :</label>
                                <fieldset class="col-sm-2 Group_BookGuarantee">
                                    <input type="text" class="form-control bg-focus"
                                           name="InfoGuaranteeContract.BookGuaranteeDesc[${countItems}].BookNumber" onkeyup="BookNumberChange(this,${countItems})"
                                           value=""
                                           placeholder="">
                                </fieldset>
                                <div class="col-sm-2 BookGuarantee_PlusMins">
                                    <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer" onclick="remove_row_BookGuarantee(this)"></i>
                                </div>
                            </div>
                            <fieldset class="Group_BookGuarantee">
                                <div class="form-group row">
                                    <label class="col-sm-4 col-form-label text-sm-right">วันที่เริ่มต้น :</label>
                                    <div class="col-sm-3">
                                        <input type="text" class="startdatestr_${countItems} form-control bg-focus input_icon_calendar datepicker"
                                               name="InfoGuaranteeContract.BookGuaranteeDesc[${countItems}].StartDateStr"
                                               value=""
                                               placeholder="วว/ดด/ปปปป" autocomplete="off">
                                    </div>
                                    <label class="col-sm-1 col-form-label text-sm-right">วันที่สิ้นสุด :</label>
                                    <div class="col-sm-2 ">
                                        <input type="text" class="enddatestr_${countItems} form-control bg-focus input_icon_calendar datepicker"
                                               name="InfoGuaranteeContract.BookGuaranteeDesc[${countItems}].EndDateStr"
                                               value=""
                                               placeholder="วว/ดด/ปปปป" autocomplete="off">
                                    </div>
                                    <label class="col-sm-1 col-form-label">บาท</label>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-4 col-form-label text-sm-right">จำนวนเงิน :</label>
                                    <div class="col-sm-6 ">
                                        <input type="text" class="amountmoney_${countItems} form-control bg-focus moneyformat"
                                               name="InfoGuaranteeContract.BookGuaranteeDesc[${countItems}].AmountMoney"
                                               value=""
                                               placeholder="0.00">
                                    </div>
                                    <label class="col-sm-1 col-form-label">บาท</label>
                                </div>
                            </fieldset>
                            <hr class="mt-2 mb-3 width_75" />
                        </div>`;

	$('#BookGuarantee_Render').append(content_html);
	setSettingDate($('.datepicker'));
	$('.selectpicker').selectpicker('refresh');
}

function remove_row_BookGuarantee(_this) {
	$(_this).closest(`.BookGuarantee_Sub`).remove();
	//จัดลำดับ index กรณีลบข้ามงวด
	$('#BookGuarantee_Render .BookGuarantee_Sub').each(function (index, val) {
		index++
		//console.log(index)
		$(this).attr("class", `BookGuarantee_Sub BookGuarantee_Sub_${index}`)
		$(this).find('input,select').each(function (index_input) {
			var inputName = $(this).attr("name");
			if (inputName != undefined) {
				$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
			}
		});
	});
}

function BookGuaranteeChange(_this, index, clear_val = true) {
	//console.log(_this, index, clear_val)
	if (clear_val) {
		$(`.startdatestr_${index}`).val('');
		$(`.enddatestr_${index}`).val('');
		$(`.amountmoney_${index}`).val('');
	}

	if (_this == '06') {
		//console.log(_this.value, index)
		$(`.startdatestr_${index}`).datepicker('destroy');
		$(`.startdatestr_${index}`).attr('readonly', true);

		$(`.enddatestr_${index}`).datepicker('destroy');
		$(`.enddatestr_${index}`).attr('readonly', true);

		$(`.amountmoney_${index}`).prop("readonly", true);
	} else {
		$(`.startdatestr_${index}`).attr('readonly', false);
		setSettingDate($(`.startdatestr_${index}`));
		setDateThai($(`.startdatestr_${index}`));

		$(`.enddatestr_${index}`).attr('readonly', false);
		setSettingDate($(`.enddatestr_${index}`));
		setDateThai($(`.enddatestr_${index}`));

		$(`.amountmoney_${index}`).prop("readonly", false);
	}
}

var timeoutDocBook;
function BookNumberChange(_this, index) {
	clearTimeout(timeoutDocBook) // clear the request from the previous event
	timeoutDocBook = setTimeout(function () {
		console.log(index)
		console.log($(`.bankcode_${index} :selected`).val())
		if ($(`.bankcode_${index} :selected`).val() == '06') {
			console.log(_this.value, _this.value.length, index)
			$(`.startdatestr_${index}`).val('');
			$(`.enddatestr_${index}`).val('');
			$(`.amountmoney_${index}`).val('');
			if (_this.value.length > 3) {
				AjaxPost(`${hostname}/CallData/eLGDocumentSearch`, true, { lgNumber: _this.value }, function (response_data) {
					//console.log(response_data)
					if (response_data.Status) {
						if (response_data.Result != null && response_data.Result.status == '200' && response_data.Result.message == 'Success') {
							if (response_data.Result.result.length == 1) {
								var data = response_data.Result.result[0];
								console.log(data)
								$(`.startdatestr_${index}`).val(`${SetFormatDateBook(data.effectiveDateStart)}`);
								$(`.enddatestr_${index}`).val(`${SetFormatDateBook(data.effectiveDateEnd)}`);
								$(`.amountmoney_${index}`).val(`${data.lgAmount}`);
							}
						}
					}
				});
			}
		}
	}, 1000);
}

function SetFormatDateBook(value, index) {

	if (value.length == 10) {
		//console.log(value)
		var DateYear = parseInt(value.substring(0, 4));
		var DateMonth = parseInt(value.substring(5, 7));
		var DateDay = parseInt(value.substring(8, 10));
		if (DateYear < 2500) {
			DateYear += 543;
		}
		if (DateMonth < 10) {
			DateMonth = '0' + DateMonth;
		}
		if (DateDay < 10) {
			DateDay = '0' + DateDay;
		}
		var NewDate = `${DateDay}/${DateMonth}/${DateYear}`;
		console.log(NewDate)
		return NewDate;
	}
}