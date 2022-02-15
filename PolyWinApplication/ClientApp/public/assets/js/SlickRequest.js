$(document).ready(function () {

    $('.items').slick({
        dots: false,
        infinite: true,
        speed: 1000,
        autoplay: true,
        autoplaySpeed: 2000,
        slidesToShow: 4,
        slidesToScroll: 1,
        cssEase: 'linear',
        //arrows: true,
        prevArrow: "<a class='carousel-control-prev' href='#carouselExample2' role='button' data-slide='prev'><span class= 'carousel-control-prev-icon' aria-hidden='true'></span><span class='sr-only'>Previous</span></a>",
        nextArrow: "<a class='carousel-control-next' href='#carouselExample2' role='button' data-slide='next'><span class= 'carousel-control-next-icon' aria-hidden='true'></span ><span class='sr-only'>Next</span></a>",
        //pauseOnFocus: false,
        //pauseOnHover: false,
        //prevArrow: '<div class="slick-prev"><i class="fa fa-angle-left" aria-hidden="true"></i></div>',
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }

        ]
    });

});
