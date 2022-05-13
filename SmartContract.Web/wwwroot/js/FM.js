
$(function () {

    var hostname = window.location.hostname;
    console.log(hostname)
    if (hostname != 'localhost') {
        $('.para').css('color', 'black');
    }

})