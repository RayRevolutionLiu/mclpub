//WindowOpen
function doDetail(win_width, win_height, URL) {
var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",menubar=no, scrollbars=yes,location=no,status=no";
        var vReturn = window.open(URL, "new", features);
    }