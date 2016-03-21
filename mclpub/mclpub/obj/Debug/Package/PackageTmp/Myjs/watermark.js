window.offsetX = document.body.scrollWidth - 100;
window.offsetY = 0;
window.onload = window.onscroll = window.onresize = watermark;
function doWindowScroll() {
    watermark(document.body.scrollLeft, document.body.scrollTop);
}
function watermark() {
    document.all.tempMsg.innerText = "X: " + document.all.fMenu.style.pixelLeft + ", Y:" + document.all.fMenu.style.pixelTop;

    document.all.fMenu.style.posLeft = document.body.scrollLeft + window.offsetX;
    document.all.fMenu.style.posTop = document.body.scrollTop + window.offsetY;

    document.all.helpMsg.style.posLeft = document.body.scrollWidth - 200;
    document.all.helpMsg.style.posTop = document.body.scrollTop;
}
function doPickMenu() {
    document.body.attachEvent("onmousemove", doMoveMenu)
    fMenu.offsetX = event.offsetX;
    fMenu.offsetY = event.offsetY;
}
function doPutMenu() {
    document.body.detachEvent("onmousemove", doMoveMenu)
    window.offsetX = fMenu.style.posLeft - document.body.scrollLeft;
    window.offsetY = fMenu.style.posTop - document.body.scrollTop;
}
function doMoveMenu() {
    document.all.fMenu.style.posLeft = event.clientX - 4 - fMenu.offsetX + document.body.scrollLeft;
    document.all.fMenu.style.posTop = event.clientY - 4 - fMenu.offsetY + document.body.scrollTop;
}
