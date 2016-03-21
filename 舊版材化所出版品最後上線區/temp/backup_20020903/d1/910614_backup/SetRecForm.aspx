<%@ Page language="c#" Codebehind="SetRecForm.aspx.cs" src="SetRecForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SetRecForm" %>
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
		<OBJECT id="DSO3" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
	</HEAD>
	<body>
		<form id="SetRecForm" method="post" runat="server">
			<asp:Label id="Label1" runat="server" ForeColor="#0000C0" Font-Size="X-Small">收件人資料</asp:Label>
			<TABLE id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR borderColor="#bfcff0" bgColor="#bfcff0">
						<TH style="WIDTH: 2px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">選取</font>
						</TH>
						<TH style="WIDTH: 12px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">序號</font>
						</TH>
						<TH style="WIDTH: 51px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">姓名</font>
						</TH>
						<TH style="WIDTH: 163px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">公司名稱</font>
						</TH>
						<TH style="WIDTH: 44px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">職稱</font>
						</TH>
						<TH style="WIDTH: 98px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">地址</font>
						</TH>
						<TH style="WIDTH: 32px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">郵遞區號</font>
						</TH>
						<TH style="WIDTH: 73px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small">電話</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD style="WIDTH: 2px">
							<IMG class="ico" title="加入收件人" onclick="doCopy(this)" height="14" src="images/copy.gif" border="0">
						</TD>
						<TD style="WIDTH: 12px">
							<span dataFld="序號"></span>
						</TD>
						<TD style="WIDTH: 51px">
							<span dataFld="姓名" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 163px">
							<span dataFld="公司名稱" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 44px">
							<div dataFld="職稱" noWrap>
								<FONT face="新細明體"></FONT>
							</div>
						</TD>
						<TD style="WIDTH: 98px">
							<div dataFld="地址">
								<FONT face="新細明體"></FONT>
							</div>
						</TD>
						<TD style="WIDTH: 32px">
							<div dataFld="郵遞區號" noWrap>
							</div>
						</TD>
						<TD style="WIDTH: 73px">
							<div dataFld="電話" noWrap>
								<FONT face="新細明體"></FONT>
							</div>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<asp:Label id="Label2" runat="server" ForeColor="#C00000" Font-Size="X-Small">請選取需要的收件人,然後填上數量及郵寄類別</asp:Label>
			<TABLE id="table2" style="WIDTH: 499px" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="1">
				<THEAD>
					<TR borderColor="#4a3c8c" bgColor="#4a3c8c">
						<TH style="WIDTH: 15px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">刪除</font>
						</TH>
						<TH style="WIDTH: 16px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">序號</font>
						</TH>
						<TH style="WIDTH: 89px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">姓名</font>
						</TH>
						<TH style="WIDTH: 163px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">公司名稱</font>
						</TH>
						<TH style="WIDTH: 37px; HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">郵寄數量</font>
						</TH>
						<TH style="HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">郵寄地區</font>
						</TH>
						<TH style="HEIGHT: 36px">
							<font style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">郵寄類別</font>
						</TH>
					</TR>
				</THEAD>
				<tbody>
					<TR borderColor="#bfcff0" bgColor="#e2eafc">
						<TD style="WIDTH: 15px">
							<IMG class="ico" title="刪除資料" onclick="doDelete(this)" height="14" src="images/cut.gif" width="9" border="0">
						</TD>
						<TD style="WIDTH: 16px">
							<span dataFld="序號"></span>
						</TD>
						<TD style="WIDTH: 89px">
							<span dataFld="姓名" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 163px">
							<span dataFld="公司名稱" dataFormatAs="html"></span>
						</TD>
						<TD style="WIDTH: 37px">
							<input dataFld="郵寄數量" id="tt1" style="WIDTH: 35px; HEIGHT: 22px" type="text" size="1" name="tt5">
						</TD>
						<TD>
							<select datafld="海外郵寄" name="ddl1" disabled>
								<option value="0" selected>
									國內</option><option value="1">國外</option>
							</select>
						</TD>
						<TD>
							<SELECT dataFld="郵寄類別" id="ddlSendType" name="ddlSendType" runat="server">
								<OPTION selected>
								</OPTION>
							</SELECT>
						</TD>
					</TR>
				</tbody>
			</TABLE>
			<input onclick="SelectOK()" type="button" value="新增完畢回前頁"> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;
		</form>
		<SCRIPT language="javascript">
var oMyObject = window.dialogArguments;
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.async = false; 
xmlDoc1.load("RecAddr.xml");
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

function doDelete(obj){
	var idx = obj.recordNumber-1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length <= 1)
	{
		var newNode = xmlNewItems.cloneNode(true);
		xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	}
	oldNode.parentNode.removeChild(oldNode);
}
function doCopy(obj){
	var idx = obj.recordNumber-1;
//	alert("xmlItems3"+xmlItems3.childNodes.item(idx).xml);
	if(xmlItems3.childNodes.item(idx).selectSingleNode("海外郵寄")!=null){
		if(xmlItems3.childNodes.item(idx).selectSingleNode("海外郵寄").text=="0")
			xmlItems3.childNodes.item(idx).selectSingleNode("郵寄類別").text="11";
		else
			xmlItems3.childNodes.item(idx).selectSingleNode("郵寄類別").text="21";
	}
	var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
	if(xmlItems.firstChild.childNodes.item(1).text=="")
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
	var idx = obj.recordNumber-1;
}
		</SCRIPT>
	</body>
</HTML>
