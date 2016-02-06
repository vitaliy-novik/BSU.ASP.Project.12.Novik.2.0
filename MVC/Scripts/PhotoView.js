$(document).ready(function () {
/*    $('.photoLink').click(function (e) {
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
    */

    $('.like').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $('.lb-likes').load(url);
    });
    $('#edit').click(function (e) {
        e.preventDefault();
        $('#edit-form').show;
    });
    $('.more').click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $(this).hide();
        $("#loading").show();
        $.get(url, function (response) {
            $("#loading").hide();
            $('.user-list').append(response);
            var a = parseInt($(".more").attr("page"));
            a = a + 1;
            if (a <= $(".more").attr("maxPage")) {
                $(".more").show();
                $(".more").attr("page", a);
                var href = $(".more").attr("href");
                href = href.split("=", 2)[0] + "=" + a;
                $(".more").attr("href", href);
            }            
        });
    });
});