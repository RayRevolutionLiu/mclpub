<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetRecForm.aspx.cs" Inherits="mclpub.Order.SetRecForm" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<HTML>
	<HEAD runat="server">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO3" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
	</HEAD>
	<body>
		<form id="SetrecForm" method="post" runat="server">
		<span class="stripeMe">
			<asp:Label id="Label1" runat="server" Font-Size="X-Small">收件人資料</asp:Label>
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
				<thEAD>
					<tr>
						<th>
							選取
						</th>
						<th>
							序號
						</th>
						<th>
							姓名
						</th>
						<th>
							公司名稱
						</th>
						<th>
							職稱
						</th>
						<th>
							地址
						</th>
						<th>
							郵遞區號
						</th>
						<th>
							電話
						</th>
					</tr>
				</thEAD>
				<tbody>
					<tr>
						<td>
							<IMG class="ico" title="加入收件人" onclick="doCopy(this)" src="<%=ResolveUrl("~/Art/images/btn_view.gif")%>" border="0">
						</td>
						<td>
							<span dataFld="序號"></span>
						</td>
						<td>
							<span dataFld="姓名" dataFormatAs="html"></span>
						</td>
						<td>
							<span dataFld="公司名稱" dataFormatAs="html"></span>
						</td>
						<td>
							<div dataFld="職稱" noWrap>
								<FONT face="新細明體"></FONT>
							</div>
						</td>
						<td>
							<div dataFld="地址">
								<FONT face="新細明體"></FONT>
							</div>
						</td>
						<td>
							<div dataFld="郵遞區號" noWrap>
							</div>
						</td>
						<td>
							<div dataFld="電話" noWrap>
								<FONT face="新細明體"></FONT>
							</div>
						</td>
					</tr>
				</tbody>
			</TABLE>
			<asp:Label id="Label2" runat="server" ForeColor="#C00000">請選取需要的收件人,然後填上數量及郵寄類別</asp:Label>
			<TABLE id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
				<thEAD>
					<tr>
						<th>
							刪除
						</th>
						<th>
							序號
						</th>
						<th>
							姓名
						</th>
						<th>
							公司名稱
						</th>
						<th>
							郵寄數量
						</th>
						<th>
							郵寄地區
						</th>
						<th>
							郵寄類別
						</th>
					</tr>
				</thEAD>
				<tbody>
					<tr borderColor="#bfcff0" bgColor="#e2eafc">
						<td style="WIDth: 15px">
							<IMG class="ico" title="刪除資料" onclick="doDelete(this)" src="<%=ResolveUrl("~/Art/images/cut.gif")%>" border="0">
						</td>
						<td style="WIDth: 16px">
							<span dataFld="序號"></span>
						</td>
						<td style="WIDth: 89px">
							<span dataFld="姓名" dataFormatAs="html"></span>
						</td>
						<td style="WIDth: 163px">
							<span dataFld="公司名稱" dataFormatAs="html"></span>
						</td>
						<td style="WIDth: 37px">
							<input dataFld="郵寄數量" id="tt1" style="WIDth: 35px; HEIGHT: 22px" type="text" size="1" name="tt5">
						</td>
						<td>
							<select datafld="海外郵寄" name="ddl1" disabled>
								<option value="0" selected>
									國內</option><option value="1">國外</option>
							</select>
						</td>
						<td>
							<SELECT dataFld="郵寄類別" id="ddlSendType" name="ddlSendType" runat="server">
								<OPTION selected>
								</OPTION>
							</SELECT>
						</td>
					</tr>
				</tbody>
			</TABLE>
			<input onclick="SelectOK()" type="button" value="新增完畢回前頁"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" /> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;
			</span>
             <input id="RecAddr" type="hidden" runat="server" />
		</form>
		<SCRIPT language="javascript">
var oMyObject = window.dialogArguments;
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.async = false;
xmlDoc1.loadXML(document.getElementById("<% =RecAddr.ClientID %>").value);
var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("收件人明細");
//xmlNewItems.selectSingleNode("公司名稱").text=oMyObject.CoName;
var xmlDoc3 = DSO3.XMLDocument;
xmlDoc3.async = false;
xmlDoc3.loadXML(oMyObject.prexmldata.xml);
//alert(oMyObject.prexmldata.xml);
var xmlItems3 = xmlDoc3.selectSingleNode("收件人資料");
var xmlDoc2 = DSO2.XMLDocument;
xmlDoc2.async = false;
xmlDoc2.loadXML(oMyObject.xmldata.xml);
var xmlItems = xmlDoc2.selectSingleNode("投遞資料");
//	alert("xmlItems.xml"+xmlItems.xml);

function doDelete(obj) {
    var trType = obj.parentNode.parentNode;
    trType.setAttribute('custom', 'del');
    var parentNodetrType = trType.parentNode.parentNode.getElementsByTagName('tr');
    var i = 0;
    for (i = 0; i < parentNodetrType.length; i++) {
        if (parentNodetrType[i].getAttribute('custom') == 'del') {
            break;
        }
    }
    i--; //因為parentNodetrType會連表頭的tr都抓到 所以要減一
    //var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.innerHTML;
    //var idx = parseInt(idxtmp) - 1;
    var oldNode = xmlItems.childNodes.item(i);
    if (xmlItems.childNodes.length <= 1) {
        var newNode = xmlNewItems.cloneNode(true);
        xmlItems.insertBefore(newNode, xmlItems.childNodes.item(i).nextSibling);
    }
    oldNode.parentNode.removeChild(oldNode);
}

function doCopy(obj) {
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.innerHTML;
    var idx = parseInt(idxtmp,10) - 1;

//	alert("xmlItems3"+xmlItems3.childNodes.item(idx).xml);
	if(xmlItems3.childNodes.item(idx).selectSingleNode("海外郵寄")!=null){
		if(xmlItems3.childNodes.item(idx).selectSingleNode("海外郵寄").text=="0")
			xmlItems3.childNodes.item(idx).selectSingleNode("郵寄類別").text="11";
		else
			xmlItems3.childNodes.item(idx).selectSingleNode("郵寄類別").text="21";
	}
	var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
	if (xmlItems.firstChild.childNodes.item(0).text == "")
		xmlItems.replaceChild(newNode, xmlItems.firstChild);
	else
		xmlItems.appendChild(newNode);
	xmlItems = xmlDoc2.selectSingleNode("投遞資料");
}
function SelectOK(obj){
		oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
		window.returnValue = true;
		window.close();
}
function doSendType(obj)
{
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.innerHTML;
    var idx = parseInt(idxtmp) - 1;
}
		</SCRIPT>
	</body>
</HTML>
