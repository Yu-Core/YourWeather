export function followSystemTheme(dotNet, callbackMethod) {
    window.matchMedia('(prefers-color-scheme:dark)').addEventListener('change', (e) => {
        dotNet.invokeMethodAsync(callbackMethod, e.matches);
    });
}
export function systemIsDarkTheme() {
    return window.matchMedia('(prefers-color-scheme:dark)').matches;
}