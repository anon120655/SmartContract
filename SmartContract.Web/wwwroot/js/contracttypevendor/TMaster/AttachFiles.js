$(document).ready(function () {
    //InitialAttachFiles();
});

function InitialAttachFiles() {
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
                                name="InfoAttachDraftContract.SmctMasterFile[${countItems}].FormFile">
                         <input type="hidden" name="InfoAttachDraftContract.SmctMasterFile[${countItems}].IdSmctMasterFile" value="">
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
