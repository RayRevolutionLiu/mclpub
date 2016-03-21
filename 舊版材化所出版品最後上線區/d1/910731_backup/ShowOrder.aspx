<%@ Page language="c#" Codebehind="ShowOrder.aspx.cs" src="ShowOrder.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.ShowOrder" %>
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
	</HEAD>
	<body>
		<form id="ShowOrder" method="post" runat="server">
			<center>
				<input id="b1" onclick="javascript:window.close();" type="button" value="關閉視窗">&nbsp;
				<TABLE dataFld="訂單" id="MainTable" style="WIDTH: 655px" dataSrc="#DSO1" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂戶資料</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 124px" align="right">
							訂戶編號：
						</TD>
						<TD style="WIDTH: 192px" colSpan="3">
							<span dataFld="訂戶編號" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">&nbsp;&nbsp;
						</TD>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 702px" colSpan="4">
							<font color="white">訂單及發票資料</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							訂單流水號：
						</td>
						<td style="WIDTH: 235px">
							<span dataFld="訂單流水號" style="COLOR: maroon" runat="server"></span><input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							<SELECT dataFld="訂單來源" id="ddlOrderRes" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							訂購日期：
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="訂購日期" id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" name="tbxOrderDate" runat="server" readonly>&nbsp;&nbsp;
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂購類別：
						</td>
						<td style="WIDTH: 257px">
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly Width="38px"></asp:textbox>
							<SELECT dataFld="訂購類別二" id="ddlOrderType2" name="Select1" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							發票類別：
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="發票類別" type="radio" value="2" name="rblInvcd">二聯 <input dataFld="發票類別" type="radio" value="3" name="rblInvcd">三聯
							<input dataFld="發票類別" type="radio" value="4" name="rblInvcd">其他
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							課稅別：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票課稅別" type="radio" value="1" name="rblTaxtp">應稅5% <input dataFld="發票課稅別" type="radio" value="2" name="rblTaxtp">零稅
							<input dataFld="發票課稅別" type="radio" value="3" name="rblTaxtp">免稅
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							付款方式：
						</td>
						<td colSpan="3">
							<SELECT dataFld="付款方式" id="ddlPayType" name="ddlPayType" runat="server" disabled></SELECT>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							統一編號：
						</TD>
						<TD style="WIDTH: 192px">
							<input dataFld="統一編號" id="tbxMfrno" runat="server" readonly>
						</TD>
						<TD style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							電話：
						</TD>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人電話" id="tbxTel" runat="server" readonly>
						</td>
					</TR>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							發票收件人姓名：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="發票收件人姓名" id="tbxInvoiceName" runat="server" readonly>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							傳真：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人傳真" id="tbxFax" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							發票收件人職稱：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="發票收件人職稱" id="tbxInvoiceJob" runat="server" readonly>
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							手機：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人手機" id="tbxCell" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							發票收件人Email：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人Email" id="tbxEmail" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							郵遞區號：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人郵遞區號" id="tbxPostCode" style="WIDTH: 39px; HEIGHT: 22px" size="1" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							發票郵寄地址：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人地址" id="tbxAddress" style="WIDTH: 421px; HEIGHT: 22px" size="64" runat="server" readonly>
						</td>
					</tr>
					<TR bgColor="#214389">
						<TD style="WIDTH: 702px" colSpan="4">
							<FONT color="white">收件人資料</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 124px" align="right" bgColor="#bfcff0">
							收件人：
						</TD>
						<TD style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetRec()" src="images/new.gif" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</TD>
					</TR>
				</TABLE>
				<TABLE dataFld="訂單明細" id="Table1" dataSrc="#DSO1" cellSpacing="0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="明細表" id="tbItems" style="WIDTH: 655px" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 639px" colSpan="10">
											<FONT color="white">訂單明細資料</FONT>
										</TD>
									</TR>
									<TR borderColor="#bfcff0" bgColor="#bfcff0">
										<TD style="WIDTH: 37px">
											項次
										</TD>
										<TD style="WIDTH: 98px" align="middle">
											書籍類別
										</TD>
										<TD style="WIDTH: 70px" align="middle">
											訂戶別
										</TD>
										<TD style="WIDTH: 96px" align="middle">
											計劃代號
										</TD>
										<TD style="WIDTH: 75px" align="middle">
											訂閱起時
										</TD>
										<TD style="WIDTH: 72px" align="middle">
											訂閱訖時
										</TD>
										<TD style="WIDTH: 41px" align="middle">
											金額
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
									<TD style="WIDTH: 37px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</TD>
									<TD style="WIDTH: 98px">
										<SELECT dataFld="書籍類別" id="ddlBookType" name="ddlBookType" runat="server" disabled>
											<OPTION selected>
											</OPTION>
										</SELECT>
									</TD>
									<TD style="WIDTH: 70px">
										<SPAN dataFld="新舊訂戶" id="tbxCust"></SPAN>
									</TD>
									<TD style="WIDTH: 96px">
										<INPUT dataFld="計劃代號" id="tbxProj" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="7" name="tt3">
									</TD>
									<TD style="WIDTH: 75px">
										<INPUT dataFld="訂閱起時" id="tbxStartDate" style="WIDTH: 70px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="6" name="tt4">
									</TD>
									<TD style="WIDTH: 72px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 72px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="6" name="tt5">
									</TD>
									<TD style="WIDTH: 41px">
										<INPUT dataFld="金額" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px" readOnly type="text" maxLength="6" size="1" name="tt6">
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
				<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">
			</center>
		</form>
		<script language="javascript">
DSO1.XMLDocument.async = false; 
DSO2.XMLDocument.async = false; 
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.loadXML(document.all("hiddenXML").value);
var xmlReceivers = xmlDoc1.selectSingleNode("/root/收件人資料");
var xmlRecItem = xmlDoc1.selectSingleNode("/root/投遞資料");
var xmlItems = xmlDoc1.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc1.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc1.selectSingleNode("/root");
//document.all("textarea1").value=xmlHeader.xml;

		</script>
		<script language="javascript">
function doGetRec()
{
    var myObject = new Object();
	    myObject.flag=true;
		myObject.prexmldata=xmlReceivers.xml;
    myObject.xmldata=xmlReceivers.xml;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
}
function doSelectRec(obj)
{
	var idx = obj.recordNumber-1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
    vreturn=window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;"); 
//	Items.parentNode.replaceChild(myObject.result, Items);
//    Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
//	var	amt=0;
//	for(i=0; i<Items.childNodes.length; i++){
//		amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text);	//<姓名>為第二欄
//	}
//	xmlItems.childNodes.item(idx).selectSingleNode("總數量").text=String(amt);
//	document.all("textarea1").value=xmlItems.xml;
}
		</script>
	</body>
</HTML>
