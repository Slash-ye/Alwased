$(function () {
    'use strict';

    // Adjust Slider Height
    var winH    = $(window).height(),
        upperH  = $('.upper-bar').innerHeight(),
        navbarH = $('.navbar').innerHeight();
    $('.slider, .carousel-item').height(winH - (upperH + navbarH));

    // Featured-Work shuffle
    $('.featured-work ul li').on('click', function() {
        $(this).addClass('active').siblings().removeClass('active');
        if ($(this).data('class') === 'all') {

            $('.featured-work .imgs .row > div').css('opacity', 1);

        } else {

            $('.featured-work .imgs .row > div').css('opacity', '0.08');
            $($(this).data('class')).parent().css('opacity', 1);

        }
    });

    // fit text

    $('h1, .my-h2').fitText(0.7, {
        minFontSize : "30px",
        maxFontSize : "50px",
    });

    $('.choose-us img').innerHeight($('.choose-us .col-lg-6:last-child').innerHeight());

});




//Carousal code
$(document).ready(function () {

    $('#server').owlCarousel({
        rtl: true,
        items: 4,
        loop: true,
        center:true

    });
    
    $('#product').owlCarousel({
        rtl: true,
        items: 1,
        loop: false,
        URLhashListener: true,
        autoplayHoverPause: true,
        startPosition: 'URLHash',
        dots: false

    });
    $('#thum').owlCarousel({
        rtl: true,
        items: 4,
        loop: false,
        margin: 5,
        responsive: {
            0: {
                items: 2
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }

    });
});

/*
$('#send').click(function () {
    var data = $('#from').serialize();
    $.ajax({
        type: "Post",
        url: "ContactMessage",
        data: data,
        success: function (r) {
           if (r == true) {
            alert("تم ارسال الرساله");

                window.location.href = "Contact";
                }
            //   $('#myModel').modal("hide");
            if (r == false) {
                alert("لم يتم ارسال الرساله");
            }
            
           
        }
    })
});

*/