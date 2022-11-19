window.initPulltorefresh = (dotNetObj, dotNetMethod) => {
    PullToRefresh.init({
        mainElement: '#pullToRefresh',
        instructionsPullToRefresh: '下拉刷新',
        instructionsReleaseToRefresh: '释放以刷新',
        instructionsRefreshing :'刷新中',
        onRefresh: function () {
            dotNetObj.invokeMethodAsync(dotNetMethod);
        }
    });
}