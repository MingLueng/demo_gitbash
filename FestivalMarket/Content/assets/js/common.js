
function myFunction() {
    var scroll = jQuery(window).scrollTop();
    if(scroll > 120){
        $("#top-head").hide();
        $("header").addClass('header')
    } else{
        $("#top-head").show();
        $("header").removeClass('header')
    }
}

$(document).ready(function() {
    $('.lang-head-content > div').click(function(){
        $('.lang-head-content').each(function(){
            $(this).children().removeClass('active');
        });
        $(this).addClass('active');
    });
    $('.slide-three').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: false,
        dots: true,
        responsive: [
            {
              breakpoint: 768,
              settings: {
                arrows: false,
                centerMode: true,
                slidesToShow: 1
              }
            },
            {
              breakpoint: 416,
              settings: {
                arrows: false,
                centerMode: true,
                slidesToShow: 1
              }
            }
          ]
      });
});