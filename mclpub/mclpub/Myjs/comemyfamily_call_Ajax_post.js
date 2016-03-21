function comemyfamily_call_Ajax_post(options) {

    try {
        var xmlHttp;
        if (window.XMLHttpRequest) {
            xmlHttp = new XMLHttpRequest(); // native Fx and IE7
        } else {
            try {
                xmlHttp = new ActiveXObject('MSXML2.XMLHTTP.6.0'); // latest ActiveX
            } catch (e) {
                try {
                    xmlHttp = new ActiveXObject('Microsoft.XMLHTTP'); // older ActiveX
                } catch (e) {
                    xmlHttp = false;
                }
            }
        }

        xmlHttp.onreadystatechange = function () {

            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {

                if (options.type != 'xml') {
                    options.call(xmlHttp.responseText);
                } else {


                    var xmlDoc = null;
                    if (window.ActiveXObject) {
                        //for IE
                        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                        xmlDoc.async = "false";
                        xmlDoc.loadXML(xmlHttp.responseText);

                    } else if (document.implementation && document.implementation.createDocument) {
                        //for Mozila
                        parser = new DOMParser();
                        xmlDoc = parser.parseFromString(xmlHttp.responseText, "text/xml");

                    }

                    options.call(xmlDoc);
                }
            } else {

                if (options.show_alert != null) {
                    if (options.show_alert) {
                        if (xmlHttp.status != 200) {
                            alert(xmlHttp.status);
                        }

                    }
                }
            }


        }


        xmlHttp.open("post", options.url, true);
        //   Http.setRequestHeader('If-Modified-Since', '0');
        xmlHttp.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xmlHttp.send(options.Variable);
        return xmlHttp;
    }
    catch (e) {
        if (options.show_alert) {
            window.alert(e);
        }
    }
}

//var option = {

//    url: 'ashx/ExpLanguage.ashx',   //呼叫哪個 ashx
//    call: RequestXML, //拿到值以後 呼叫哪個 function
//    Variable: '', //傳遞變數
//    type: 'xml', //回傳類型
//    show_alert: false //是不是要秀alert
//}
//comemyfamily_call_Ajax_post(option);

