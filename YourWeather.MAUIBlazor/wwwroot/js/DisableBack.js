window.disableBack = function () {
    //���һ��urlΪ��ǰҳ�����ʷ��¼��
    history.pushState(null, null, document.URL);
};
window.disableBack();
//�����ǰ�������ʱ�����popstate�����Զ������һ�������¼������˺������һ���µĵ�ǰҳ�����ʷ��¼
window.addEventListener('popstate', function () {
    window.disableBack();
});