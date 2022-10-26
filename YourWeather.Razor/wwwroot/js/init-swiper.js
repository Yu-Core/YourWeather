function initSwiper() {

    console.log('Entered initSwiper!');

    window.swiper = new Swiper('.swiper', {
        spaceBetween: 12,
        observer: true,
        observeParents: true,
        autoHeight: true,
        on: {
            slideChangeTransitionEnd: function () {
                DotNet.invokeMethodAsync('YourWeather.Razor', 'ChangeDotNetIndex', this.activeIndex);
                //alert(this.activeIndex);//�л�����ʱ�������������ǵڼ���slide
            },
        },
        breakpoints: {
            600: {  
                direction: 'vertical',
                spaceBetween: 0
            }
        }
    });
}

function changeSwiperIndex(index) {
    swiper.slideTo(index);
}
