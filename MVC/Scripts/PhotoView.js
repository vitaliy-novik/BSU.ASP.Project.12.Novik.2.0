$(document).ready(function () {
    $('.photoLink').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');        
        $('#photoFrame').load(url);
        $('#photoView').show();
    });
    $('#next').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $('#photoFrame').load(url);
    });
    $('#prev').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $('#photoFrame').load(url);
    });
    $('#like').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $('#photoFrame').load(url);
    });
});