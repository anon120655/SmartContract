
var budgetcodeSelectLeagl = '';
var masterVendorsList = '';

$(document).ready(function () {
    PaymentRadios_checked();
    P1BudgetInput();

    $('.Select_Budgetcode').each(function (index, val) {
        var budgetcode = $(this).val();
        if (index == 0) {
            budgetcodeSelectLeagl += `<option value=''>---เลือก---</option>`;
        }
        budgetcodeSelectLeagl += `<option value='${budgetcode}'>${budgetcode}</option>`;
    });
    $.each(MasterVendorsModelList, function (index, val) {
        if (index == 0) {
            masterVendorsList += `<option value=''>---เลือก---</option>`;
        }
        masterVendorsList += `<option value='${val.VendorId}'>${val.VendorId}</option>`;
    });

    var _Menu = $(`#ParameterCondition_Menu`).val();
    var StationStatusCurr = $("#StationStatusCurr").val();
    var _ContractSuccessStatus = $('#InfoRequestBinding_ContractSuccessStatus').val();
    //console.log(_Menu)
    //console.log(StationStatusCurr)
    if (StationStatusCurr == 'S5' || StationStatusCurr == 'S6' || StationStatusCurr == 'S7' && _Menu != 'T1' && _Menu != 'T3') {
        ReadOnlyPayment();
    }
    if (_Menu == 'T3' && _ContractSuccessStatus != 'S1') {
        ReadOnlyPayment();
    }
});

function ReadOnlyPayment() {
    $('.fa-plus-circle').hide();
    $('.fa-minus-circle').hide();
    $('#PaymentPeriod_Render .selectpicker').prop('disabled', true);
    $('#PaymentPeriod_Render .selectpicker').selectpicker('refresh');
}

$(".PaymentRadios").change(function () {

    contractTypeId = $(`#ParameterCondition_ContractTypeId`).val();
    //console.log(contractTypeId)
    //T10 อปท.
    if (contractTypeId == '10') {
        var Budgetcode0 = $('select[name^="InfoContract.Budgetcodes[0].Budgetcode"]').find(':selected').val();
        //console.log(Budgetcode0)
        if (Budgetcode0 == '' || Budgetcode0 == undefined) {
            SweetAlert2Warning('รหัสงบประมาณ ไม่ถูกต้อง');
            ClearTabPayment();
        }
        $('#Budgetcode_Render .Budgetcode_Sub').each(function (index, val) {
            index++
            var selected_code = $(this).find('select').find(':selected').val();
            console.log(index, selected_code)
            if (selected_code == "" || selected_code == null || selected_code == undefined) {
                SweetAlert2Warning('รหัสงบประมาณ ไม่ถูกต้อง');
                ClearTabPayment();
                return false; // breaks
            }
        });
    }

    PaymentRadios_checked();
});
$('#InfoConditionPayment_PaymentSelect').change(function () {
    Payment_InsertPayPeriod($(this).val());
});

function PaymentRadios_checked() {
    if ($("#PaymentRadios1").is(":checked")) {
        $('#Payment1').show();
        $('#Payment2').hide();
    }
    else if ($("#PaymentRadios2").is(":checked")) {
        $('#Payment1').hide();
        $('#Payment2').show();
        //Payment_AddPay();
    }
    else {
        $('#Payment1').hide();
        $('#Payment2').hide();
    }
}

function P1BudgetInput() {
    var p1Budgetcode_Render = $(`#P1Budgetcode_Render`).html();
    /*console.log(p1Budgetcode_Render)*/
    if (p1Budgetcode_Render != undefined) {
        if (p1Budgetcode_Render.trim() == '') {
            var budgetcodeCount = $('input[name^="BudgetcodeSelectLeagl"]').length;
            if (budgetcodeCount > 1) {
                $('input[name^="BudgetcodeSelectLeagl"]').each(function (index, val) {
                    var budgetcode = $(this).val();
                    var content_html = `<div class="form-group row">
                                        <label class="col-sm-3 col-form-label text-sm-right">${index == 0 ? "รหัสงบประมาณ" : ""} :</label>
                                        <div class="col-sm-2">
                                            <input type="text" readonly class="form-control-plaintext"
                                                   name="InfoConditionPayment.P1Budgetcode[${index}].PeriodBudgetcode" value="${budgetcode}">
                                        </div>
                                        <div class="col-sm-2">
                                            <input type="text" class="form-control moneyformat"
                                                   name="InfoConditionPayment.P1Budgetcode[${index}].PeriodPercent" value="">
                                        </div>
                                        <label class="col-sm-3 col-form-label text-sm-left">ระบุยอดเงิน</label>
                                    </div>`;


                    $(`#P1Budgetcode_Render`).append(content_html);
                });
            }
        }
    }
}

///รหัสงบประมาณ
function Payment_InsertPayPeriod(PeriodCount) {

    //var countItems = $('#PaymentPeriod_Render .PaymentPeriod_Sub').length;
    var content_html = ``;
    var Period = 0;
    $('#PaymentPeriod_Render').empty();
    for (var i = 0; i < PeriodCount; i++) {
        Period++;
        //console.log(Period)
        content_html += `<fieldset class="PaymentPeriod_Sub form-group border p-3" id="Period_${Period}" style="background-color:rgba(50, 255, 50, 0.1);">
                            <input type="hidden" name="InfoConditionPayment.PeriodList[${i}].PeriodNo" value="${Period}" />
                            <legend class="col-auto px-2 h6">งวดที่ ${Period}</legend>
                            <table class="table table-bordered table-sm">
                                <thead class="thead-dark">
                                    <tr>
                                        <th style="width:5%" class="text-center align-middle">#</th>
                                        <th style="width:50%" class="align-middle">รหัสงบประมาณ</th>
                                        <th style="width:20%" class="align-middle">วงเงินในงวด</th>
                                        <th style="width:15%" class="align-middle">รหัสคู่สัญญา</th>
                                        <th style="width:10%" class="text-center align-middle">
                                            <i class="fa fa-plus-circle fa-2x cursor-pointer" onclick="InsertBudgetCode(${Period},${i})"></i>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="BudgetCode_Render_${Period}" class="bg-light">
                                    <tr class="BudgetCode_Sub">
                                        <td class="text-center align-middle">1</td>
                                        <td class="align-middle">
                                            <select class="form-control bg-focus selectpicker PeriodBudgetcode" data-live-search="true"
                                                    name="InfoConditionPayment.PeriodList[${i}].ContractPeriod[0].PeriodBudgetcode">
                                                    ${budgetcodeSelectLeagl}
                                            </select>
                                        </td>
                                        <td class="align-middle">
                                            <input type="text" class="form-control moneyformat periodpercent" autocomplete="off" onkeyup="keyupCalTotalPeriodPercent(${Period})"
                                                    name="InfoConditionPayment.PeriodList[${i}].ContractPeriod[0].PeriodPercent">
                                        </td>
                                        <td class="align-middle">
                                            <select class="form-control bg-focus selectpicker" data-live-search="true"
                                                    name="InfoConditionPayment.PeriodList[${i}].ContractPeriod[0].PeriodVendorId">
                                                    ${masterVendorsList}
                                            </select>
                                        </td>
                                        <td class="text-center align-middle">
                                            <i class="fa fa-minus-circle fa-2x cursor-pointer" onclick="RemoveBudgetCode(this,${Period})"></i>
                                        </td>
                                    </tr>
                                </tbody>
                                <tfoot class="table-secondary">
                                    <tr>
                                        <td></td>
                                        <td class="text-right align-middle">รวม</td>
                                        <td>
                                            <input readonly id="TotalPeriodPercent_${Period}" type="text" class="form-control " value="">
                                        </td>
                                        <td class="align-middle">บาท</td>
                                        <td></td>
                                    </tr>
                                </tfoot>
                            </table>
                            <div id="PeriodDetail_Render_${Period}">
                               <div class="PeriodDetail_Sub form-group row">
                                   <label class="col-sm-3 col-form-label text-sm-right">ผลการดำเนินงานที่ส่งมอบ :</label>
                                   <div class="col-sm-7">
                                       <input type="text" class="form-control bg-focus" autocomplete="off"
                                                       name="InfoConditionPayment.PeriodList[${i}].ContractPeriodDetail[0].ContractPeriodDetail1">
                                   </div>
                                   <div class="col-sm-2">
                                       <i class="fa fa-plus-circle fa-2x mr-1 cursor-pointer" onclick="InsertPeriodDetail(${Period},${i})"></i>
                                   </div>
                               </div>
                            </div>
                        </fieldset>`;
    }

    $('#PaymentPeriod_Render').append(content_html);
    $('.selectpicker').selectpicker('refresh');
}

function InsertBudgetCode(Period, IndexPeriod) {

    var countBudgetCode = $(`#Period_${Period} #BudgetCode_Render_${Period} .BudgetCode_Sub`).length;
    //console.log(countBudgetCode)
    var content_html = `<tr class="BudgetCode_Sub">
                             <td class="text-center align-middle">${countBudgetCode + 1}</td>
                             <td class="align-middle">
                                 <select class="form-control bg-focus selectpicker" data-live-search="true"
                                         name="InfoConditionPayment.PeriodList[${IndexPeriod}].ContractPeriod[${countBudgetCode}].PeriodBudgetcode">
                                     ${budgetcodeSelectLeagl}
                                 </select>
                             </td>
                             <td class="align-middle">
                                 <input type="text" class="form-control moneyformat periodpercent" autocomplete="off" onkeyup="keyupCalTotalPeriodPercent(${Period})"
                                         name="InfoConditionPayment.PeriodList[${IndexPeriod}].ContractPeriod[${countBudgetCode}].PeriodPercent">
                             </td>
                             <td class="align-middle">
                                 <select class="form-control bg-focus selectpicker" data-live-search="true"
                                         name="InfoConditionPayment.PeriodList[${IndexPeriod}].ContractPeriod[${countBudgetCode}].PeriodVendorId">
                                     ${masterVendorsList}
                                 </select>
                             </td>
                             <td class="text-center align-middle">
                                 <i class="fa fa-minus-circle fa-2x cursor-pointer" onclick="RemoveBudgetCode(this,${Period})"></i>
                             </td>
                         </tr>`;


    $(`#BudgetCode_Render_${Period}`).append(content_html);
    $('.selectpicker').selectpicker('refresh');
}

function RemoveBudgetCode(_this, Period) {
    $(_this).closest(`.BudgetCode_Sub`).remove();
    //จัดลำดับ index กรณีลบข้ามงวด
    $(`#BudgetCode_Render_${Period} .BudgetCode_Sub`).each(function (index, val) {
        //console.log(index)
        //$(this).attr("class", `BudgetCode_Sub BudgetCode_Sub_${index}`)
        $(this).find('input,select').each(function (index_input) {
            var inputName = $(this).attr("name");
            if (inputName != undefined) {
                //console.log(inputName)
                var strPosStart = inputName.lastIndexOf("[") + 1;//49
                var strPoslast = inputName.lastIndexOf("]");//51....n
                var nameNew = ChangeIndexArray(inputName, index, strPosStart, strPoslast);
                $(this).attr("name", nameNew);
            }
        });

        index++
        $(this).find('td:eq(0)').text(index);
    });
}

function keyupCalTotalPeriodPercent(Period) {
    var totalPeriodPercent = 0.00;
    var countBudgetCode = $(`#BudgetCode_Render_${Period} .BudgetCode_Sub`).length;
    //console.log(countBudgetCode)
    if (countBudgetCode > 0) {
        $(`#BudgetCode_Render_${Period} .BudgetCode_Sub`).each(function (index, val) {
            var input_periodpercent = $(this).find(".periodpercent").val();
            //console.log(input_periodpercent)
            if (input_periodpercent != undefined && input_periodpercent != null && input_periodpercent != '') {
                var inputVal = input_periodpercent.replace(/,/g, '');
                totalPeriodPercent += parseFloat(inputVal);
            }
        });
        //console.log(totalPeriodPercent)
        if (!isNaN(totalPeriodPercent)) {
            setTimeout(function () {
                $(`#TotalPeriodPercent_${Period}`).val(numberWithCommas(totalPeriodPercent.toFixed(2)));
            }, 200);
        }
    }
}

///ผลการดำเนินงานที่ส่งมอบ
function InsertPeriodDetail(Period, IndexPeriod) {

    //var countBudgetCode   = $(`#Period_${Period} #BudgetCode_Render_${Period} .BudgetCode_Sub`).length;
    var countPeriodDetail = $(`#Period_${Period} #PeriodDetail_Render_${Period} .PeriodDetail_Sub`).length;
    console.log(countPeriodDetail)
    var content_html = `<div class="PeriodDetail_Sub form-group row">
                            <label class="col-sm-3 col-form-label text-sm-right"></label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control bg-focus"  autocomplete="off"
                                                   name="InfoConditionPayment.PeriodList[${IndexPeriod}].ContractPeriodDetail[${countPeriodDetail}].ContractPeriodDetail1">
                            </div>
                            <div class="col-sm-2">
                                <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer" onclick="RemovePeriodDetail(this,${Period})"></i>
                            </div>
                        </div>`;


    $(`#PeriodDetail_Render_${Period}`).append(content_html);
    $('.selectpicker').selectpicker('refresh');
}

function RemovePeriodDetail(_this, Period) {
    $(_this).closest(`.PeriodDetail_Sub`).remove();
    //จัดลำดับ index กรณีลบข้ามงวด
    $(`#PeriodDetail_Render_${Period} .PeriodDetail_Sub`).each(function (index, val) {
        //console.log(index)
        //$(this).attr("class", `BudgetCode_Sub BudgetCode_Sub_${index}`)
        $(this).find('input,select').each(function (index_input) {
            var inputName = $(this).attr("name");
            //console.log(inputName)
            if (inputName != undefined) {
                var strPosStart = inputName.lastIndexOf("[") + 1;//49
                var strPoslast = inputName.lastIndexOf("]");//51....n
                var nameNew = ChangeIndexArray(inputName, index, strPosStart, strPoslast);
                $(this).attr("name", nameNew);
                //$(this).attr("name", inputName.replace(/\[(.*?)\]/g, `[${index}]`))
            }
        });
        index++
    });
}


