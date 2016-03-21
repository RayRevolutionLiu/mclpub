<%@ Page language="c#" Codebehind="FreeFM.aspx.cs" src="FreeFM.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.FreeFM" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="FreeFM" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 706px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂單處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0"> 修改訂單</font>
						</td>
					</tr>
				</table>
				<TABLE dataFld="訂單" id="MainTable" style="WIDTH: 706px" dataSrc="#DSO1" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 128px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 192px">
							<span dataFld="訂戶編號" id="Span1" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">&nbsp;&nbsp;
							<input id="hiddenBook" type="hidden" name="hiddenBook" runat="server">
						</TD>
						<TD style="WIDTH: 108px" align="right">
							訂戶姓名：
						</TD>
						<TD style="WIDTH: 192px">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<tr>
						<TD style="WIDTH: 128px" align="right">
							公司名稱：
						</TD>
						<TD style="WIDTH: 192px" colSpan="3">
							<FONT face="新細明體"></FONT>
							<asp:label id="lblCoName" ForeColor="Maroon" Runat="server"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
							<INPUT id="hiddenCoAddress" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoAddress" runat="server">
						</TD>
					</tr>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂單資料</font>
						</td>
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
							<input dataFld="訂購日期" id="tbxOrderDate" style="WIDTH: 76px; HEIGHT: 22px" readOnly type="text" size="7" name="tbxOrderDate" runat="server">&nbsp;&nbsp;
						</td>
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
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">收件人資料</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 128px" align="right" bgColor="#bfcff0">
							收件人：
						</TD>
						<TD style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetRec()" src="images/new.gif" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</TD>
					</TR>
				</TABLE>
				<TABLE dataFld="訂單明細" id="Table1" style="WIDTH: 709px" dataSrc="#DSO1" cellSpacing="0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="明細表" id="tbItems" style="WIDTH: 706px" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 639px" colSpan="10">
											<FONT color="white">訂單明細資料</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0">
										<TD style="WIDTH: 41px; HEIGHT: 6px">
											功能
										</TD>
										<TD style="WIDTH: 32px">
											項次
										</TD>
										<TD style="WIDTH: 91px" align="middle">
											書籍類別
										</TD>
										<TD style="WIDTH: 91px" align="middle">
											計劃代號
										</TD>
										<TD style="WIDTH: 105px" align="middle">
											訂閱起時
										</TD>
										<TD style="WIDTH: 110px" align="middle">
											訂閱訖時
										</TD>
										<TD style="WIDTH: 50px" align="middle">
											總數量
										</TD>
										<TD style="WIDTH: 49px" align="middle">
											收件人
										</TD>
									</TR>
								</THEAD>
								<TR borderColor="#bfcff0" bgColor="#e2eafc">
									<TD style="WIDTH: 41px">
										<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
									</TD>
									<TD style="WIDTH: 32px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 91px">
										<SELECT dataFld="書籍類別" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT>
									</TD>
									<TD style="WIDTH: 91px">
										<INPUT dataFld="計劃代號" id="tbxProj" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="7" name="tt3">
									</TD>
									<TD style="WIDTH: 105px">
										<INPUT dataFld="訂閱起時" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<IMG class="ico" title="日曆" onclick="pick_dateStart(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 110px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<IMG class="ico" title="日曆" onclick="pick_dateEnd(this)" src="../images/calendar01.gif">
									</TD>
									<TD style="WIDTH: 50px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</TD>
									<TD style="WIDTH: 49px">
										<IMG class="ico" title="收件人詳細資料" onclick="doSelectRec(this)" src="images/edit.gif" border="0">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server"> <input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單"><input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="取消回首頁">&nbsp;
			</center>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
DSO1.XMLDocument.async = false; 
DSO2.XMLDocument.async = false; 
DSOX.XMLDocument.async = false; 
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.loadXML(document.all("hiddenXML").value);
var xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
//xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text=document.all("hiddenCoName").value;
var xmlRecItem = xmlDoc1.selectSingleNode("/root/投遞資料");
var xmlItems = xmlDoc1.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc1.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc1.selectSingleNode("/root");
var xmlEmptyItem = DSO2.XMLDocument;
xmlEmptyItem.load("空白項目一.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("hiddenBook").value);
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
	var idx = obj.recordNumber-1;
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
function doGetRec()
{
    var myObject = new Object();
	    myObject.flag=true;
		myObject.prexmldata=xmlReceivers.xml;
    myObject.CoName=document.all("hiddenCoName").value;
    myObject.CoAddress=document.all("hiddenCoAddress").value;
    myObject.xmldata=xmlReceivers.xml;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
	if(vreturn){
		xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
		strbuf="";
		for(i=0; i<xmlReceivers.childNodes.length; i++){
			strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
		}
		document.all("lblRec").innerText=strbuf;
	}
}
function doSelectRec(obj)
{
	var idx = obj.recordNumber-1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;"); 
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
	var idx = obj.recordNumber-1;
	BookType=xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
	for(i=0; i<ItemBook.childNodes.length; i++){
		if((ItemBook.childNodes.item(i).selectSingleNode("obtp_otp1cd").text==document.all("hiddenType1").value)&&(ItemBook.childNodes.item(i).selectSingleNode("fgitri").text=="")
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

function pick_dateStart(obj){
	var idx = obj.recordNumber-1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱起時").text=vreturn;
	return true;
}
function pick_dateEnd(obj){
	var idx = obj.recordNumber-1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text=vreturn;
	return true;
}
function doSubmit()
{
	var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
	xmlHTTP.Open("post", "ModifyOrder.aspx", false);
//	document.all("textarea1").value=xmlDoc1.xml;
	xmlHTTP.Send(xmlDoc1);
//	alert(xmlHTTP.responseText);
	if(xmlHTTP.statusText=="OK"){
//		alert("新增訂單成功");
			window.location.href="http://140.96.18.18/mrlpub/d1/SaveMessage.aspx?str=modify";
	}
	else
		alert(xmlHTTP.responseText);
	var xmlHTTP = null;
}
		</script>
	</body>
</HTML>
