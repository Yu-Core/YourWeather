// 创建超链接，不会被拦截    
export function openBrowserUrl(url, id) {
    let a = document.createElement("a");
    a.setAttribute("href", url);
    a.setAttribute("target", "_blank");
    a.setAttribute("id", id);
    // 防止反复添加      
    if (!document.getElementById(id)) {
        document.body.appendChild(a);
    }
    a.click();
}