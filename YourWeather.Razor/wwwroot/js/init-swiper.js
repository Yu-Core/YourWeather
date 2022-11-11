function initSwiper() {
    console.log('Entered initSwiper!');

    window.swiper = new Swiper('.main-swiper', {
        spaceBetween: 12,
        observer: true,
        observeParents: true,
        observeSlideChildren: true,
        autoHeight: true,
        noSwipingClass: 'swiper-forecast-hours',
        on: {
            slideChangeTransitionEnd: function () {
                DotNet.invokeMethodAsync('YourWeather.Razor', 'ChangeDotNetIndex', this.activeIndex);
                //alert(this.activeIndex);//切换结束时，告诉我现在是第几个slide
            },
        },
        //breakpoints: {
        //    600: {  
        //        direction: 'vertical',
        //        spaceBetween: 0
        //    }
        //}
    });
}

function changeSwiperIndex(index) {
    swiper.slideTo(index);
}

function initSwiperForecastHours() {
    window.forecastHoursSwiper = new Swiper('.swiper-forecast-hours', {
        slidesPerView: 'auto',
        touchAngle: 90,
        freeMode: {
            enabled: true,
            momentumRatio: 2,
            momentumVelocityRatio: 2,
        },
    });
}

function updateSwiper() {
    window.swiper.update();
}
