<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowOrder.aspx.cs" Inherits="mclpub.Order.ShowOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>檢視訂單資料</title>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
</head>
<body>
<form id="ShowOrder" method="post" runat="server">
<div align="center">
<input id="b1" onclick="javascript:window.close();" type="button" value="關閉視窗" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
</div>
<span class="stripeMe">				
				<table dataFld="訂單" id="Maintable" dataSrc="#DSO1" cellSpacing="0" cellPadding="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<th colSpan="4">
							訂戶資料
						</th>
					</tr>
					<tr>
						<td align="right">
							訂戶編號：
						</td>
						<td colSpan="3">
							<span id="Span1" dataFld="訂戶編號" style="COLOR: maroon" runat="server"></span><input id="hiddenID" type="hidden" name="hiddenID" runat="server">&nbsp;&nbsp;
						</td>
					</tr>
					<tr>
						<th colSpan="4">
							訂單及發票資料
						</th>
					</tr>
					<tr>
						<td align="right" width="20%">
							訂單流水號：
						</td>
						<td style="WIDTH: 235px">
							<span id="Span2" dataFld="訂單流水號" style="COLOR: maroon" runat="server"></span><input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td align="right" width="20%">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							<SELECT dataFld="訂單來源" id="ddlOrderRes" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td align="right">
							訂購日期：
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="訂購日期" id="tbxOrderDate" style="WIDTH: 87px; HEIGHT: 22px" type="text" size="9" name="tbxOrderDate" runat="server" readonly>&nbsp;&nbsp;
						</td>
						<td align="right">
							訂購類別：
						</td>
						<td style="WIDTH: 257px">
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly Width="38px"></asp:textbox>
							<SELECT dataFld="訂購類別二" id="ddlOrderType2" name="Select1" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td align="right">
							發票類別：
						</td>
						<td style="WIDTH: 235px">
							<input dataFld="發票類別" type="radio" value="2" name="rblInvcd">二聯 <input dataFld="發票類別" type="radio" value="3" name="rblInvcd">三聯
							<input dataFld="發票類別" type="radio" value="4" name="rblInvcd">其他
						</td>
						<td align="right">
							課稅別：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票課稅別" type="radio" value="1" name="rblTaxtp">應稅5% <input dataFld="發票課稅別" type="radio" value="2" name="rblTaxtp">零稅
							<input dataFld="發票課稅別" type="radio" value="3" name="rblTaxtp">免稅
						</td>
					</tr>
					<tr>
						<td  align="right">
							付款方式：
						</td>
						<td colSpan="3">
							<SELECT dataFld="付款方式" id="ddlPayType" name="ddlPayType" runat="server" disabled></SELECT>
						</td>
					</tr>
					<tr>
						<td align="right">
							統一編號：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="統一編號" id="tbxMfrno" runat="server" readonly>
						</td>
						<td align="right">
							電話：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人電話" id="tbxTel" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td align="right">
							發票收件人姓名：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="發票收件人姓名" id="tbxInvoiceName" runat="server" readonly>
						</td>
						<td align="right">
							傳真：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人傳真" id="tbxFax" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td align="right">
							發票收件人職稱：
						</td>
						<td style="WIDTH: 192px">
							<input dataFld="發票收件人職稱" id="tbxInvoiceJob" runat="server" readonly>
						</td>
						<td align="right">
							手機：
						</td>
						<td style="WIDTH: 257px">
							<input dataFld="發票收件人手機" id="tbxCell" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td align="right">
							發票收件人Email：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人Email" id="tbxEmail" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td align="right">
							郵遞區號：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人郵遞區號" id="tbxPostCode" style="WIDTH: 39px; HEIGHT: 22px" size="1" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<td align="right">
							發票郵寄地址：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<input dataFld="發票收件人地址" id="tbxAddress" style="WIDTH: 421px; HEIGHT: 22px" size="64" runat="server" readonly>
						</td>
					</tr>
					<tr>
						<th colSpan="4">
							收件人資料
						</th>
					</tr>
					<tr>
						<td align="right">
							收件人：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetrec('400px','800px')" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</td>
					</tr>
				</table>
				<table dataFld="訂單明細" id="table1" dataSrc="#DSO1" cellSpacing="0" border="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<td>
							<table dataFld="明細表" id="tbItems" dataSrc="#DSO1" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
								<THEAD>
									<tr>
										<th colSpan="10">
											訂單明細資料
										</th>
									</tr>
									<tr>
										<td style="WIDTH: 37px">
											項次
										</td>
										<td style="WIDTH: 98px" align="middle">
											書籍類別
										</td>
										<td style="WIDTH: 70px" align="middle">
											訂戶別
										</td>
										<td style="WIDTH: 96px" align="middle">
											計劃代號
										</td>
										<td style="WIDTH: 75px" align="middle">
											訂閱起時
										</td>
										<td style="WIDTH: 72px" align="middle">
											訂閱訖時
										</td>
										<td style="WIDTH: 41px" align="middle">
											金額
										</td>
										<td style="WIDTH: 50px" align="middle">
											總數量
										</td>
										<td style="WIDTH: 49px" align="middle">
											收件人
										</td>
									</tr>
								</THEAD>
								<tr>
									<td style="WIDTH: 37px">
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</td>
									<td style="WIDTH: 98px">
										<SELECT dataFld="書籍類別" id="ddlBookType" name="ddlBookType" runat="server" disabled>
											<OPTION selected>
											</OPTION>
										</SELECT>
									</td>
									<td style="WIDTH: 70px">
										<SPAN dataFld="新舊訂戶" id="tbxCust"></SPAN>
									</td>
									<td style="WIDTH: 96px">
										<INPUT dataFld="計劃代號" id="tbxProj" style="WIDTH: 100px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="7" name="tt3">
									</td>
									<td style="WIDTH: 75px">
										<INPUT dataFld="訂閱起時" id="tbxStartdate" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="6" name="tt4">
									</td>
									<td style="WIDTH: 72px">
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="6" name="tt5">
									</td>
									<td style="WIDTH: 41px">
										<INPUT dataFld="金額" id="tbxAmt" style="WIDTH: 41px; HEIGHT: 22px" readOnly type="text" maxLength="6" size="1" name="tt6">
									</td>
									<td style="WIDTH: 50px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</td>
									<td style="WIDTH: 49px">
										<IMG class="ico" title="收件人詳細資料" onclick="doSelectrec(this,'500px','750px')" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">
    </span>
    </form>
</body>
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
    function doGetrec(win_height, win_width) {
        var myObject = new Object();
        myObject.flag = true;
        myObject.prexmldata = xmlReceivers.xml;
        myObject.xmldata = xmlReceivers.xml;
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        vreturn = window.showModalDialog("RecForm.aspx", myObject, "dialogLeft:" + iLeft + ";dialogTop:" + iTop + ";dialogHeight:" + win_height + ";dialogWidth:" + win_width + ";center:yes;scroll:yes;status:no;help:no;");
    }
    function doSelectrec(obj, win_height, win_width) {
        var idx = obj.recordNumber - 1;
        var myObject = new Object();
        var Items = xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
        myObject.prexmldata = xmlReceivers;
        myObject.xmldata = xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        vreturn = window.showModalDialog("SetrecForm.aspx", myObject, "dialogLeft:" + iLeft + ";dialogTop:" + iTop + ";dialogHeight:" + win_height + ";dialogWidth:" + win_width + ";");
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
</html>
