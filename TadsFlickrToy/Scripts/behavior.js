$(document).ready(function () {
    $('.refresh').click(function () {
        location.reload();
    });
    $('.scroll-to-top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, "fast");
        location.reload();
    });
});