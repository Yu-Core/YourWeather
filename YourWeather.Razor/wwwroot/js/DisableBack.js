window.disableBack = function () {
    //添加一个url为当前页面的历史记录，
    history.pushState(null, null, document.URL);
};
window.disableBack();
//浏览器前进或后退时会调用popstate，所以对它添加一个监听事件，后退后再添加一个新的当前页面的历史记录
window.addEventListener('popstate', function () {
    window.disableBack();
});