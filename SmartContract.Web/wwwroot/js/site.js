
$(function () {

    var hostname = window.location.hostname;
    //console.log(hostname)
    var _usercount = "/usercount";
    if (hostname == 'devweb049.nhso.go.th') {
        _usercount = '/usercount';
    }

    var connection = new signalR.HubConnectionBuilder().withUrl(_usercount).build();

    connection.start().then(function () {
        //console.log('start updateCount');

    }).catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("updateCount", function (count) {
        $("#countUser").html(count);
    });

    if ($('.datepicker').val() != undefined) {
        setSettingDate($('.datepicker'));
    }
})

$(document).on("change click keyup input paste", ".moneyformat", function () {
    $(this).val(function (index, value) {
        return value.replace(/(?!\.)\D/g, "").replace(/(?<=\..*)\./g, "").replace(/(?<=\.\d\d).*/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    });
});

function WappText(text, cutNo) {
    var textlenght = text.length;
    var textNew = text;
    if (textlenght > cutNo) {
        textNew = text.substring(0, cutNo);
    }
    return textNew;
}

//function ChangeIndexArray(origString, replaceChar, index) {
//    let newStringArray = origString.split("");

//    newStringArray[index] = replaceChar;

//    let newString = newStringArray.join("");

//    return newString;
//}

function ChangeIndexArray(origString, replaceChar, index, index_end) {
    let firstPart = origString.substr(0, index);
    let lastPart = origString.substr(index_end);

    let newString = firstPart + replaceChar + lastPart;
    return newString;
}

function setSettingDate(date) {
    return date.datepicker({
        format: 'dd/mm/yyyy',
        todayBtn: false,
        language: 'th', //เปลี่ยน label ต่างของ ปฏิทิน ให้เป็น ภาษาไทย   (ต้องใช้ไฟล์ bootstrap-datepicker.th.min.js นี้ด้วย)
        autoclose: true,
        todayHighlight: true,
        clearBtn: true,
        thaiyear: true,
    });
}

function setDateNew(date, newdate) {
    var result = date.datepicker("setDate", newdate);
    return result;
}

function setDateThai(date) {
    if (date.val() != null && date.val() != undefined) {
        var dateAr = date.val().split('/');
        if (dateAr[2] != undefined && dateAr[2].length == 4) {
            setSettingDate(date);
            var newDateStart = dateAr[0] + '/' + dateAr[1] + '/' + (parseInt(dateAr[2]) - 543);
            setDateNew(date, newDateStart);
        }

        date.on('keyup', function (response) {
            //console.log(response.keyCode)
            if (response.keyCode != 8) {
                var dateAr = $(this).val().split('/');
                if (dateAr[2] != undefined && dateAr[2].length == 4) {
                    setSettingDate(date);
                    var newDateStart = dateAr[0] + '/' + dateAr[1] + '/' + (parseInt(dateAr[2]) - 543);
                    setDateNew(date, newDateStart);
                }
            }
        });
    }

    return date;

}

function stringToDate(_date, _format, _delimiter, addyear = null) {
    var formatLowerCase = _format.toLowerCase();
    var formatItems = formatLowerCase.split(_delimiter);
    var dateItems = _date.split(_delimiter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    month -= 1;

    var yearfull = parseInt(dateItems[yearIndex]);
    //console.log('yearfull ', yearfull)
    if (yearfull > 2500) {
        yearfull = (yearfull - 543);
    }

    if (addyear != null) {
        yearfull = (yearfull + addyear);
    }

    var formatedDate = new Date(yearfull, month, dateItems[dayIndex]);
    return formatedDate;
}

function DateToStringFormatThai(d = new Date) {
    if (isValidDate(d)) {
        let month = String(d.getMonth() + 1);
        let day = String(d.getDate());
        const year = String(d.getFullYear());

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        var _year = parseInt(year);
        if (_year < 2500) {
            _year = (_year + 543);
        }

        return `${day}/${month}/${String(_year)}`;
    }
    return '';
}

function isValidDate(d) {
    return d instanceof Date && !isNaN(d);
}

function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function currencyFormat(num) {
    return num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}

function showLoading() {
    //setTimeout(function () {
    $("div#divLoading").addClass('show');
    //}, 5000);
}

function hideLoading() {
    $("div#divLoading").removeClass('show');
}

function goBack() {
    window.history.back()
}

function ShowMessageError(resource) {
    //console.log(resource)
    $('#modalMessage').find('#modal-body').text(resource);
    $('#modalMessage').modal('show');
}

function RedirectToAction(pathRedirect) {
    console.log(pathRedirect)
    window.location.href = pathRedirect;
}


// create the back to top button
$('body').prepend('<a href="#" class="back-to-top">Back to Top</a>');

var amountScrolled = 300;

$(window).scroll(function () {
    if ($(window).scrollTop() > amountScrolled) {
        $('a.back-to-top').fadeIn('slow');
    } else {
        $('a.back-to-top').fadeOut('slow');
    }
});

$('a.back-to-top, a.simple-back-to-top').click(function () {
    $('html, body').animate({
        scrollTop: 0
    }, 700);
    return false;
});

function GetSetupInput(status) {
    //showLoading();
    if (status == "True") {
        $("#DisabledForm :input").attr("disabled", true);
    }
}

function OpenFormInput() {
    $("#DisabledForm :input").attr("disabled", false);
}

function isNumber(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    //console.log(charCode);
    if (charCode != 46 && charCode != 45 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function SweetAlert2Confirm(text) {
    swal({
        title: 'Are you sure?',
        text: 'You will not be able to recover this imaginary file!',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel plx!',
        confirmButtonClass: 'confirm-class',
        cancelButtonClass: 'cancel-class',
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                return true;
            } else {
                return false;
            }
        });

    //swal({
    //    title: 'Are you sure?',
    //    text: "You won't be able to revert this!",
    //    icon: 'warning',
    //    showCancelButton: true,
    //    confirmButtonColor: '#3085d6',
    //    cancelButtonColor: '#d33',
    //    confirmButtonText: 'Yes, delete it!'
    //}).then((result) => {
    //    if (result.isConfirmed) {
    //        swal(
    //            'Deleted!',
    //            'Your file has been deleted.',
    //            'success'
    //        )
    //        return true;
    //    }
    //})


    //swal({
    //    title: 'Are you sure?',
    //    text: 'You will not be able to recover this imaginary file!',
    //    type: 'warning',
    //    showCancelButton: true,
    //    confirmButtonColor: '#3085d6',
    //    cancelButtonColor: '#d33',
    //    confirmButtonText: 'Yes, delete it!',
    //    cancelButtonText: 'No, cancel plx!',
    //    confirmButtonClass: 'confirm-class',
    //    cancelButtonClass: 'cancel-class',
    //    closeOnConfirm: false,
    //    closeOnCancel: false
    //},
    //    function (isConfirm) {
    //        if (isConfirm) {
    //            swal(
    //                'Deleted!',
    //                'Your file has been deleted.',
    //                'success'
    //            );
    //        } else {
    //            swal(
    //                'Cancelled',
    //                'Your imaginary file is safe :)',
    //                'error'
    //            );
    //        }
    //    });
}

function SweetAlert2Warning(text) {
    Swal.fire({
        title: text,
        text: "ทำรายการไม่สำเร็จ",
        icon: 'warning',
        confirmButtonColor: '#dc3545',
        confirmButtonText: 'ตกลง',
        closeOnConfirm: false
    }).then((result) => {
        hideLoading();
        swal.close();
    })
}

function SweetAlert2Success(path, text = "บันทึกข้อมูลสำเร็จ", closetab = false, title = "บันทึกสำเร็จ", isNewpath = false) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'success',
        //confirmButtonClass: 'btn-success',
        confirmButtonColor: '#28a745',
        confirmButtonText: 'ตกลง',
        closeOnConfirm: false
    }).then((result) => {
        if (closetab == false) {
            RedirectToAction(path, isNewpath);
        } else {
            window.close();
        }
    })
}

function SweetAlert2Success2(path) {
    swal({
        title: "บันทึกข้อมูลสำเร็จ",
        text: "ระบบทำการบันทึกข้อมูลเรียบร้อยแล้ว",
        type: "success",
        showCancelButton: false,
        confirmButtonClass: "btn-success",
        confirmButtonText: "ตกลง",
        closeOnConfirm: false
    },
        function () {
            window.location.href = path;
        });
}

function AjaxPost(url, async, data, callBack) {
    $.ajax({
        type: "POST",
        dataType: "json",
        beforeSend: function (jqXHR, settings) {
            // loading....
        },
        url: url,
        crossDomain: true,
        data: data,
        //contentType: "application/json; charset=utf-8",
        contentType: 'application/x-www-form-urlencoded',
        async: async,
        success: function (msg) {
            return callBack(msg);
        }
        , error: function (jqXHR, textStatus, errorThrown) {

        }
        , complete: function (jqXHR, textStatus) {

        }
    });
}

function AjaxPostNotType(url, data, callBack) {
    $.ajax({
        type: "POST",
        dataType: "json",
        beforeSend: function (jqXHR, settings) {
            // loading....
        },
        url: url,
        data: data,
        processData: false,
        contentType: false,
        success: function (msg) {
            return callBack(msg);
        }
        , error: function (jqXHR, textStatus, errorThrown) {

        }
        , complete: function (jqXHR, textStatus) {

        }
    });
}







