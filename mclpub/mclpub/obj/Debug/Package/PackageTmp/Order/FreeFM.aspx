<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreeFM.aspx.cs" Inherits="mclpub.Order.FreeFM" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="stripeMe">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / 雜誌叢書訂單處理 / <asp:Label ID="lblTitle" runat="server"></asp:Label> / 步驟三:修改訂單</span> 
				<TABLE dataFld="訂單" id="MainTable" dataSrc="#DSO1" cellSpacing="0" cellPadding="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<th colSpan="4">訂戶資料</th>
					</tr>
					<tr>
						<td style="WIDTH: 128px" align="right">
							訂戶編號：
						</td>
						<td style="WIDTH: 192px">
							<span dataFld="訂戶編號" id="Span1" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">&nbsp;&nbsp;
							<input id="hiddenBook" type="hidden" name="hiddenBook" runat="server">
						</td>
						<td style="WIDTH: 108px" align="right">
							訂戶姓名：
						</td>
						<td style="WIDTH: 192px">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblName" ForeColor="Maroon" Runat="server"></asp:label>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 128px" align="right">
							公司名稱：
						</td>
						<td style="WIDTH: 192px" colSpan="3">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblCoName" ForeColor="Maroon" Runat="server"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
							<INPUT id="hiddenCoAddress" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoAddress" runat="server">
						</td>
					</tr>
					</tr>
					<tr>
						<th colSpan="4">訂單資料</th>
					</tr>
					<tr>
						<td style="WIDTH: 128px" align="right" bgColor="#bfcff0">
							訂單流水號：
						</td>
						<td style="WIDTH: 235px">
							<span dataFld="訂單流水號" id="Span2" style="COLOR: maroon" runat="server"></span><input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							<SELECT dataFld="訂單來源" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 128px" align="right" bgColor="#bfcff0">
							訂購日期：
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="訂購日期" id="tbxOrderDate" readOnly type="text" size="7" name="tbxOrderDate" runat="server" onclick="Selectdates(this)" style="width:80px"></td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂購類別：
						</td>
						<td style="WIDTH: 257px">
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly Width="38px"></asp:textbox>
							<SELECT dataFld="訂購類別二" id="ddlOrderType2" name="Select1" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hiddenType1" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							承辦業務員：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<SELECT dataFld="承辦人員" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<tr bgColor="#214389">
						<th colSpan="4">
							收件人資料
						</th>
					</tr>
					<tr>
						<td style="WIDTH: 128px" align="right" bgColor="#bfcff0">
							收件人：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetrec()"  src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</td>
					</tr>
				</TABLE>
				<TABLE dataFld="訂單明細" id="Table1" dataSrc="#DSO1" cellSpacing="0" border="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<td>
							<TABLE dataFld="明細表" id="tbItems" dataSrc="#DSO1" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
								<THEAD>
									<tr>
										<th colSpan="10">
											訂單明細資料
										</th>
									</tr>
									<tr>
										<td style="WIDTH: 45px; HEIGHT: 6px">
											功能
										</td>
										<td style="WIDTH: 32px">
											項次
										</td>
										<td style="WIDTH: 91px">
											書籍類別
										</td>
										<td style="WIDTH: 91px">
											計劃代號
										</td>
										<td style="WIDTH: 105px">
											訂閱起時
										</td>
										<td style="WIDTH: 120px">
											訂閱訖時
										</td>
										<td style="WIDTH: 50px">
											總數量
										</td>
										<td style="WIDTH: 49px">
											收件人
										</td>
									</tr>
								</THEAD>
								<tr>
									<td>
											<img border="0" class="ico" onclick="doAddNew(this)" src='<%=ResolveUrl("~/Art/images/btn_search.gif")%>' title="新增資料" /> 
                                            <img border="0" class="ico" onclick="doDelete(this)" src='<%=ResolveUrl("~/Art/images/cut.gif")%>' title="刪除資料" />&nbsp;
									</td>
									<td style="WIDTH: 32px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</td>
									<td style="WIDTH: 91px">
										<SELECT dataFld="書籍類別" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT>
									</td>
									<td style="WIDTH: 91px">
										<INPUT dataFld="計劃代號" id="tbxProj" style="WIDTH:85px" readOnly type="text" maxLength="10" size="7" name="tt3">
									</td>
									<td style="WIDTH: 115px">
										<INPUT dataFld="訂閱起時" id="tbxStartdate" style="WIDTH: 85px" type="text" maxLength="10" size="6" name="tt4">
										<img class="ico" onclick="pick_dateStart(this)" 
                                            src='<%=ResolveUrl("~/jquery/development-bundle/demos/datepicker/images/calendar.gif")%>' 
                                            title="日曆" />
									</td>
									<td style="WIDTH: 120px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 85px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<img class="ico" onclick="pick_dateEnd(this)" src='<%=ResolveUrl("~/jquery/development-bundle/demos/datepicker/images/calendar.gif")%>' title="日曆" />
									</td>
									<td style="WIDTH: 50px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</td>
									<td style="WIDTH: 49px">
										<IMG class="ico" title="收件人詳細資料" onclick="doSelectrec(this)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
				</TABLE>
				<div width="100%" align="center">
                <input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">
                <input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
                <input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="取消回首頁" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">&nbsp;
				</div>
</span>

<script>
    function Selectdates(selfTBx) {
        $(function() {
            $("#<% =tbxOrderDate.ClientID%>").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
        });
        if (a == true) {
            window.document.getElementById("<% =tbxOrderType1.ClientID%>").focus();
            window.document.getElementById(selfTBx.id.toString()).focus();
            a = false;
        }
    }
</script>


		<script language="javascript">
		    var a = true; //For IE9
DSO1.XMLDocument.async = false; 
DSO2.XMLDocument.async = false; 
DSOX.XMLDocument.async = false;
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.loadXML(document.getElementById("<% =hiddenXML.ClientID%>").value);
var xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
//xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text=document.all("hiddenCoName").value;
var xmlRecItem = xmlDoc1.selectSingleNode("/root/投遞資料");
var xmlItems = xmlDoc1.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc1.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc1.selectSingleNode("/root");
var xmlEmptyItem = DSO2.XMLDocument;
xmlEmptyItem.load("EmptyList.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.getElementById("<% =hiddenBook.ClientID%>").value);
var ItemBook=xmlDocX.selectSingleNode("書籍資料");
//document.all("textarea1").value=xmlHeader.xml;
strbuf="";
for(i=0; i<xmlReceivers.childNodes.length; i++){
	strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
}
document.all("lblRec").innerText=strbuf;

		</script>
		<script language="javascript">
function doAddNew(obj)
{
//	var idx=obj.parentElement.parentElement.rowIndex-1;
//	var idx = obj.recordNumber-1;
	var idx = xmlItems.childNodes.length;
//	xmlEmptyItem.documentElement.childNodes.item(0).text=idx;
	var newNode = xmlEmptyItem.documentElement.cloneNode(true);
//	newNode.selectSingleNode("項次").text=idx;
//	xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	xmlItems.appendChild(newNode);
	var	j1=String(idx+1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx).selectSingleNode("項次").text=j1;
	}
	else
		xmlItems.childNodes.item(idx).selectSingleNode("項次").text=idx+1;
}
function doDelete(obj){
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length > 1){
		oldNode.parentNode.removeChild(oldNode);
		for(i=0; i<xmlItems.childNodes.length;i++){
			j1=String(i+1);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(i).selectSingleNode("項次").text=j1;
			}
			else
				xmlItems.childNodes.item(i).selectSingleNode("項次").text=i+1;
		}
	}
}
function doGetrec()
{
    var myObject = new Object();
	    myObject.flag=true;
	    myObject.prexmldata = xmlReceivers.xml;
		myObject.CoName = document.getElementById("<% =hiddenCoName.ClientID%>").value;
		myObject.CoAddress = document.getElementById("<% =hiddenCoAddress.ClientID%>").value;
    myObject.xmldata=xmlReceivers.xml;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:450px;dialogWidth:800px;center:yes;scroll:yes;status:no;help:no;"); 
	if(vreturn){
		xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
		strbuf="";
		for(i=0; i<xmlReceivers.childNodes.length; i++){
			strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
}
		document.getElementById("lblRec").innerText=strbuf;
	}
}
function doSelectrec(obj)
{
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
    vreturn=window.showModalDialog("SetrecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;"); 
	if(vreturn){
		Items.parentNode.replaceChild(myObject.result, Items);
	   Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
		var	amt=0;
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text);	//<姓名>為第二欄
		}
		xmlItems.childNodes.item(idx).selectSingleNode("總數量").text=String(amt);
	}
//	document.all("textarea1").value=xmlItems.xml;
}
function doSelectBook(obj)
{
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	BookType=xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
	for(i=0; i<ItemBook.childNodes.length; i++){
	    if ((ItemBook.childNodes.item(i).selectSingleNode("obtp_otp1cd").text == document.all("<% =hiddenType1.ClientID%>").value) && (ItemBook.childNodes.item(i).selectSingleNode("fgitri").text.replace(/(^\s*)|(\s*$)/g, "") == "")
			&&(ItemBook.childNodes.item(i).selectSingleNode("obtp_obtpcd").text==BookType)){
			strbuf=ItemBook.childNodes.item(i).selectSingleNode("nostr").text;
			break;
		}
	}
//	strbuf = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
//	xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text=strbuf.substr(0, 2);
	xmlItems.childNodes.item(idx).selectSingleNode("計劃代號").text=strbuf.substr(2, 10);
	xmlItems.childNodes.item(idx).selectSingleNode("成本中心").text=strbuf.substr(12, 7);

}

function pick_dateStart(obj) {
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("Calendar.htm", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱起時").text=vreturn;
	return true;
}
function pick_dateEnd(obj){
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("Calendar.htm", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text=vreturn;
	return true;
}
function doSubmit() {
    var OrderFlag = false;
    if (window.document.getElementById("<% =hiddenType1.ClientID%>").value == "01") {
        for (i = 0; i < xmlItems.childNodes.length; i++) {
            booktype = xmlItems.childNodes.item(i).selectSingleNode("書籍類別").text;
            if ((booktype == "01") || (booktype == "02")) {
                OrderFlag = true;
            }
        }
        if (!OrderFlag) {
            alert("沒有訂閱明細, 此為純零售訂單, 請至零售訂單新增資料.");
            return;
        }
    }

    var XmlString = xmlDoc1.xml ? xmlDoc1.xml : (new XMLSerializer()).serializeToString(xmlDoc1);
    //var XmlStringAdd = "<version='1.0' encoding='utf-8'>" + XmlString;
    // 更新 hidData 值 - 將新的 xmlDoc 寫入 document.form1("hidData").value 值
    var option = {
        url: 'ModifyOrder.aspx',   //呼叫哪個 ashx
        call: RequestXML, //拿到值以後 呼叫哪個 function
        Variable: 'transValueXml=' + encodeURIComponent(XmlString), //傳遞變數
        type: '', //回傳類型
        show_alert: false //是不是要秀alert
    }
    comemyfamily_call_Ajax_post(option);

    function RequestXML(e) {
        alert("修改訂單成功");
        var typehref = window.document.getElementById("<% =hiddenType1.ClientID%>").value;
        window.location.href = "SearchCustOrder.aspx?type=" + typehref;
    }

    //var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
    //xmlHTTP.Open("post", "ModifyOrder.aspx", false);
    //xmlHTTP.Send(xmlDoc1);
    //	alert(xmlHTTP.responseText);
    //if(xmlHTTP.statusText=="OK"){
    //alert("修改訂單成功");
    //var typehref = window.document.getElementById("<% =hiddenType1.ClientID%>").value;
    //window.location.href = "SearchCustOrder.aspx?type=" + typehref;
    //window.location.href="SaveMessage.aspx?str=modify";
    //}
    //else
    //	alert(xmlHTTP.responseText);
    //var xmlHTTP = null;
}
		</script>
</asp:Content>