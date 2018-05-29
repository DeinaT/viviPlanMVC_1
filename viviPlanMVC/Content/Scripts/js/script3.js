
$(document).ready(function() {






// drag & drop

	$( ".col" ).sortable({
		connectWith: ".col",
		placeholder: "sticker-placeholder",
        items: ".sticker:not(.new, .title)",
		cancel: ".sticker.full"
	});


// menu button

	$(".cmn-toggle-switch").click(function() {
		$(this).toggleClass("active");
		$(".dark-bg").toggleClass("active");
	});

// open panel

	$('.panel-label').click(function () {
		if($(this).hasClass('open')) {
			$(".panel").animate({right: '-20%'}, 500);
			$(".panel-label").animate({right: '0'}, 500);
			$(".panel-label").removeClass('open');
		}else{
			$(".panel").animate({right: '0'}, 500);
			$(".panel-label").animate({right: '20%'}, 500);
			$(".panel-label").addClass('open');
		}
	});

    $('.col, .main').click(function() {
        if($('.panel-label').hasClass('open')) {
            $(".panel").animate({right: '-20%'}, 500);
            $(".panel-label").animate({right: '0'}, 500);
            $(".panel-label").removeClass('open');
            $('.cmn-toggle-switch').toggleClass("active");
            $(".dark-bg").toggleClass("active");
        }
    });

// change form

	$('.tab-name:first-child').click(function () {
		if($(this).hasClass('inactive')) {
			$(".loginForm:nth-child(1)").show();
			$(".loginForm:nth-child(2)").hide();
			$(".tab-name:first-child").removeClass('inactive');
			$(".tab-name:nth-child(2)").addClass('inactive');
		}
	});

	$('.tab-name:nth-child(2)').click(function () {
		if($(this).hasClass('inactive')) {
			$(".loginForm:nth-child(2)").show();
			$(".loginForm:nth-child(1)").hide();
			$(".tab-name:nth-child(2)").removeClass('inactive');
			$(".tab-name:first-child").addClass('inactive');
		}
	});

// confirm

	$('a#forgot').click(function() {
		$(".confirm").show();
		$(".overlay2").css({'opacity': 1, 'visibility': 'visible'});
	});

	$('div.overlay2, #close, .close img').click(function() {
		$(".confirm").hide();
		$(".overlay2").css({'opacity': 0, 'visibility': 'hidden'});
		return false;

	});

// filter panel

	$('.filter-link').click(function() {
		$('.panel.filter').show();
	});

    $('.close-cross').click(function() {
        $('.panel.filter').hide();
    });

// labels panel

	$('.labels-link').click(function() {
		$('.panel.labels').show();
	});

	$('.close-cross').click(function() {
		$('.panel.labels').hide();
	});

// create sticker

	$('.sticker.new').click(function() {
		$('.create-sticker').show();
		$(".overlay2").css({'opacity': 1, 'visibility': 'visible'});
	});

	$('.close, .overlay2').click(function() {
		$(".create-sticker").hide();
		$(".overlay2").css({'opacity': 0, 'visibility': 'hidden'});
	});
    /*
// new label

	$('.line.new').click(function() {
		$('.newlabel').show();
		return false;
	});

	$('.newlabel .button').click(function() {
		$('.newlabel').hide();
	});

// select label
	$('.chooselabel.pink').click(function() {
		$('.chooselabel.pink img').toggle();
	});

	$('.chooselabel.blue').click(function() {
		$('.chooselabel.blue img').toggle();
	});

	$('.chooselabel.orange').click(function() {
		$('.chooselabel.orange img').toggle();
	});

	$('.chooselabel.red').click(function() {
		$('.chooselabel.red img').toggle();
	});

	$('.chooselabel.indigo').click(function() {
		$('.chooselabel.indigo img').toggle();
	});

	$('.chooselabel.lime').click(function() {
		$('.chooselabel.lime img').toggle();
	});

	$('.chooselabel.cyan').click(function() {
		$('.chooselabel.cyan img').toggle();
	});

	$('.chooselabel.amber').click(function() {
		$('.chooselabel.amber img').toggle();
	});

	$('.chooselabel.bluegrey').click(function() {
		$('.chooselabel.bluegrey img').toggle();
	});*/

// create board

	$('.board.new').click(function() {
		$('.create-sticker').show();
		$(".overlay2").css({'opacity': 1, 'visibility': 'visible'});
		return false;
	});

	$('.close img, .overlay2, button').click(function() {
		$(".create-sticker").hide();
		$(".overlay2").css({'opacity': 0, 'visibility': 'hidden'});
	});

// add label

	$('.label.add').click( function() {
		$('.block-labels.add').toggle();
	});

	//sticker

	$('.sticker:not(.new)').click(function() {
		$(this).addClass("full");
		$(".overlay").css({'opacity': 1, 'visibility': 'visible'});
		var b1 = document.querySelector('.sticker.full .title');//блок перед которым ставим
		var b2 = document.querySelector('.sticker.full .members');//блок который передвигаем
		b1.parentNode.insertBefore(b2, b1);
		return false;
	});

	$('.close, .overlay, .close img').click(function() {

	//	var b1 = document.querySelector('.sticker.full .attachments');//блок перед которым ставим
	//	var b2 = document.querySelector('.sticker.full .members');//блок который передвигаем
	//	b2.parentNode.insertBefore(b2, b1);
		$(".sticker").removeClass("full");
		$(".overlay").css({'opacity': 0, 'visibility': 'hidden'});
		return false;

	});
});

function doS()
{
    var dfyu = "werwerwerwerw";
    
    $.ajax({
        //UpdateTargetId = "stN", HttpMethod = "Post"
        url: '/Home/stAdd',
        method: 'POST'

        });
}
/*window.onload = function(){
 var b1 = document.getElementById("title");//блок перед которым ставим
 var b2 = document.getElementById("members");//блок который передвигаем
 b1.parentNode.insertBefore(b2, b1);

 $('.draggable').draggable();

 }*/















