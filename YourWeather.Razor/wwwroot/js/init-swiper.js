function initSwiper() {
    setTimeout(() => {
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
                    //alert(this.activeIndex);//�л�����ʱ�������������ǵڼ���slide
                },
            },
            //breakpoints: {
            //    600: {  
            //        direction: 'vertical',
            //        spaceBetween: 0
            //    }
            //}
        });
    },2000);
}

function changeSwiperIndex(index) {
    swiper.slideTo(index);
}

function initSwiperForecastHours() {
    setTimeout(() => {
        var forecastHoursSwiper = new Swiper('.swiper-forecast-hours', {
            slidesPerView: 'auto',
        });
    },2000);
}
