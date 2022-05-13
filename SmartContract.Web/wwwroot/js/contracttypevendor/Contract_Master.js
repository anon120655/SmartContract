
var userSmctSignerList = '';

$(document).ready(function () {
    InitialVendor();
    UserSignerChange();
    //setDateThai($('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer1DocDateStr'));
    //setDateThai($('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2PoaDocDateStr'));
    //setDateThai($('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2DocDateStr'));
    //setDateThai($('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2StartDateStr'));
    //setDateThai($('#InfoPartnersOfContract_UserSmct_UserSmctSigners_Signer2EndDateStr'));
});

function InitialVendor() {
    setDateThai($(`input[name='InfoPartnersOfContract.BookAuthorityDateStr']`));
    setDateThai($(`input[name='InfoPartnersOfContract.AccordingBookDateStr']`));
    //console.log(UserSmctSignerModelList)
    $.each(UserSmctSignerModelList, function (index, val) {
        if (index == 0) {
            userSmctSignerList += `<option value=''>---เลือก---</option>`;
        }
        userSmctSignerList += `<option value='${val.IdUserSmct}'>${val.UserFullname}</option>`;
    });

}



//Foot Note (ฝ่ายคู่สัญญา)
function insert_row_footnote() {
    var countItems = $('#FootNote_Render .FootNote_Sub').length;
    countItems = countItems == 0 ? 1 : (countItems + 1);
    var content_html = `<div class="FootNote_Sub FootNote_Sub_${countItems}">
                            <div class="form-group row">
                                <label class="col-sm-3 col-form-label text-sm-right"></label>
                                <div class="col-sm-4">
                                        <select class="form-control bg-focus selectpicker" data-live-search="true"
                                            name="InfoSignerPartnersOfContract.FootNotes[${countItems}].IdUserSmct">
                                             ${userSmctSignerList}
                                        </select>
                                </div>
                                <div class="col-sm-2">
                                    <i class="fa fa-minus-circle fa-2x mr-1 cursor-pointer" onclick="remove_row_footnote(this)"></i>
                                </div>
                            </div>
                        </div>`;

    $('#FootNote_Render').append(content_html);
    setSettingDate($('.datepicker'));
    $('.selectpicker').selectpicker('refresh');
}

function remove_row_footnote(_this) {
    $(_this).closest(`.FootNote_Sub`).remove();
    //จัดลำดับ index กรณีลบข้ามงวด
    $('#FootNote_Render .FootNote_Sub').each(function (index, val) {
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
