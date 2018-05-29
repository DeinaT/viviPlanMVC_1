jQuery.noConflict()(function ($) {
    "use strict";
    $(".about-container table").css(
    {
        width: '600px',
        height: '3px',
        margin: '15px auto 20px auto'
    });

    $('body').on('click', 'tr', function () {
        //get cell values, instead of the header text.
        /*$("td").each(function () {
            item_name = $(this).text();
            //var Item = { ID: $(tdlist[0]).html(), Name: $(tdlist[1]).html() };
            //itemlist.push(Item);
        })*/
        /*
        $.ajax({
            url: '/Home/Index2', //
            dataType: "json",
            data: JSON.stringify({ item_name: $(this).text() }),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            /* success: function (result) {
                 alert("success");
             },
             error: function (xhr) {
                 alert("error");
             }*/
        //});

        $.ajax({
            url: '/Home/Task', //
            dataType: "json",
            data: JSON.stringify({ stt: $(this).html() /*.text()*/ }),
            type: "POST",           
            contentType: "application/json; charset=utf-8",
            /* success: function (result) {
                 alert("success");
             },
             error: function (xhr) {
                 alert("error");
             }*/
        });
        
    })
});