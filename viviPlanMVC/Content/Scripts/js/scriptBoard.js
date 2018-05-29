//window.onload = function () {
$(document).ready(function() {
    // create board

    $('.board.new').click(function () {
        $('.create-sticker').show();
        $(".overlay2").css({ 'opacity': 1, 'visibility': 'visible' });
        return false;
    });

    $('.close img, .overlay2, button').click(function () {
        $(".create-sticker").hide();
        $(".overlay2").css({ 'opacity': 0, 'visibility': 'hidden' });
    });

    $('.board:not(.new)').click(function () {
        $(this).addClass("full");
        $(".overlay2").css({ 'opacity': 1, 'visibility': 'visible' });
        //var b1 = document.querySelector('.sticker.full .title');//блок перед которым ставим
     //   var b2 = document.querySelector('.sticker.full .members');//блок который передвигаем
      //  b1.parentNode.insertBefore(b2, b1);
        return false;
    });
    $('.close img, .overlay2, button').click(function () {
        $(".board").removeClass("full");
        $(".overlay2").css({ 'opacity': 0, 'visibility': 'hidden' });
    });

})

