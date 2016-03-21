<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecForm.aspx.cs" Inherits="mclpub.Order.RecForm" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd Xhtml 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html>
	<HEAD runat="server">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO2" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		<OBJECT id="DSO3" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221" VIEWASTEXT>
		</OBJECT>
		
	</HEAD>
	<body>
		<form id="RecForm" method="post" runat="server">
		<span class="stripeMe">
			<label >[收件人參考資料]</label>
			<table id="table1" dataSrc="#DSO3" cellSpacing="0" cellPadding="4"  border="1" class="font_blacklink font_size13" width="100%">
				<thEAD>
					<tr>
						<th>
							選取
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
						<th>
							傳真
						</th>
						<th>
							手機
						</th>
						<th>
							Email
						</th>
						<th>
							海外郵寄
						</th>
					</tr>
				</thEAD>
				<tbody>
					<tr>
						<td>
							<IMG class="ico" title="加入收件人" onclick="doCopy(this)" src="<%=ResolveUrl("~/Art/images/btn_view.gif")%>" border="0">
						</td>
						<td>
							<span dataFld="姓名" dataFormatAs="html"></span>
						</td>
						<td>
							<span dataFld="公司名稱" dataFormatAs="html"></span>
						</td>
						<td>
							<div dataFld="職稱" noWrap>
							</div>
						</td>
						<td>
							<div dataFld="地址">
							</div>
						</td>
						<td>
							<div dataFld="郵遞區號" noWrap>
							</div>
						</td>
						<td>
							<div dataFld="電話" noWrap>
							</div>
						</td>
						<td>
							<div dataFld="傳真" noWrap>
							</div>
						</td>
						<td>
							<div dataFld="手機" noWrap>
							</div>
						</td>
						<td>
							<div dataFld="Email">
							</div>
						</td>
						<td>
							<div dataFld="海外郵寄">
							</div>
						</td>
					</tr>
				</tbody>
			</table>
			<input onclick="doAddNew()" type="button" value="新增收件人" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
			<table id="table2" dataSrc="#DSO2" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
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
						<th>
							傳真
						</th>
						<th>
							手機
						</th>
						<th>
							Email
						</th>
						<th>
							郵寄地區
						</th>
					</tr>
				</thEAD>
				<tbody>
					<tr>
						<td>
							<IMG class="ico" title="刪除資料" onclick="doDelete(this)" src="<%=ResolveUrl("~/Art/images/cut.gif")%>" border="0">
						</td>
						<td>
							<label dataFld="序號" id="tt0"></label>
						</td>
						<td>
							<input dataFld="姓名" id="tt1" type="text" maxLength="30" size="8" name="tt1">
						</td>
						<td>
							<input dataFld="公司名稱" id="tt"  type="text" maxLength="50" size="15" name="tt">
						</td>
						<td>
							<input dataFld="職稱" id="tt2" type="text" maxLength="6" size="7" name="tt2">
						</td>
						<td>
							<textarea dataFld="地址" id="tta" rows="3" cols="15" size="20"></textarea>
						</td>
						<td style="WIDth: 43px">
							<input dataFld="郵遞區號" id="tt4" type="text" maxLength="5" size="3" name="tt4">
						</td>
						<td>
							<input dataFld="電話" id="tt6" type="text" size="5" name="tt6" maxLength="30">
						</td>
						<td>
							<input dataFld="傳真" id="tt7" type="text" size="5" name="tt7">
						</td>
						<td>
							<input dataFld="手機" id="tt8"  type="text" size="6" name="tt8">
						</td>
						<td>
							<input dataFld="Email" id="tt9" type="text" size="9" name="tt9">
						</td>
						<td>
							<SELECT dataFld="海外郵寄" id="ddl1" name="ddl1" runat="server">
								<OPTION value="0" selected>
									國內</OPTION>
								<OPTION value="1">
									國外</OPTION>
							</SELECT>
						</td>
					</tr>
				</tbody>
			</table>
			<input onclick="SelectOK()" type="button" value="新增完畢回前頁" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"> <INPUT id="hidden_xml" type="hidden" name="hidden_xml" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;
			<br />
			&nbsp;			
			<asp:Label id="Label1" runat="server" ForeColor="#C04000">註:<br />姓名欄位限制:15個中文 或 30個英文<br />公司名稱欄位限制:25個中文 或 50個英文</asp:Label>
			</span>
            <input id="RecAddr" type="hidden" runat="server" />
		</form>
<script language="javascript">
var oMyObject = window.dialogArguments;
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.async = false; 
xmlDoc1.loadXML(document.getElementById("<% =RecAddr.ClientID %>").value);
var xmlNewItems = xmlDoc1.documentElement.selectSingleNode("收件人明細");
//alert(xmlNewItems.xml);
xmlNewItems.selectSingleNode("公司名稱").text=oMyObject.CoName;
xmlNewItems.selectSingleNode("地址").text=oMyObject.Address;
//alert(oMyObject.CoName);
var xmlDoc3 = DSO3.XMLDocument;
xmlDoc3.async = false;
if(oMyObject.flag)
	xmlDoc3.loadXML(oMyObject.prexmldata);
else{
	document.all("table1").style.visibility="hidden";
}
var xmlItems3 = xmlDoc3.selectSingleNode("收件人資料");
var xmlDoc2 = DSO2.XMLDocument;
xmlDoc2.async = false;
//alert(oMyObject.xmldata);
xmlDoc2.loadXML(oMyObject.xmldata);
var xmlItems = xmlDoc2.selectSingleNode("收件人資料");
//alert(xmlItems.xml);
if(oMyObject.flag){
    if((xmlItems.childNodes.item(0).selectSingleNode("姓名").text=="")&&(xmlItems.childNodes.item(0).selectSingleNode("公司名稱").text=="")){
	xmlItems.childNodes.item(0).selectSingleNode("姓名").text=oMyObject.Name;
	xmlItems.childNodes.item(0).selectSingleNode("地址").text=oMyObject.Address;
	xmlItems.childNodes.item(0).selectSingleNode("職稱").text=oMyObject.Job;
	xmlItems.childNodes.item(0).selectSingleNode("郵遞區號").text=oMyObject.PostCode;
	xmlItems.childNodes.item(0).selectSingleNode("電話").text=oMyObject.Tel;
    }
}
else{
	xmlItems.childNodes.item(0).selectSingleNode("姓名").text=oMyObject.Name;
	xmlItems.childNodes.item(0).selectSingleNode("地址").text=oMyObject.Address;
	xmlItems.childNodes.item(0).selectSingleNode("職稱").text=oMyObject.Job;
	xmlItems.childNodes.item(0).selectSingleNode("郵遞區號").text=oMyObject.PostCode;
	xmlItems.childNodes.item(0).selectSingleNode("電話").text=oMyObject.Tel;
}


function doAddNew(){
	var idx = xmlItems.childNodes.length;
	var newNode = xmlNewItems.cloneNode(true);
	xmlItems.appendChild(newNode);
	var	j1=String(idx+1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx).selectSingleNode("序號").text=j1;
	}
	else
		xmlItems.childNodes.item(idx).selectSingleNode("序號").text=idx+1;
}
function doDelete(obj){
	var idx = obj.recordNumber-1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length <= 1)
	{
		var newNode = xmlNewItems.cloneNode(true);
		xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
	}
	oldNode.parentNode.removeChild(oldNode);
	for(i=0; i<xmlItems.childNodes.length;i++){
		j1=String(i+1);
		if(j1.length==1){
			j1="0"+j1;
			xmlItems.childNodes.item(i).selectSingleNode("序號").text=j1;
		}
		else
			xmlItems.childNodes.item(i).selectSingleNode("序號").text=i+1;
	}
}
function doCopy(obj){
	var idx = obj.recordNumber-1;
	var newNode = xmlItems3.childNodes.item(idx).cloneNode(true);
	if(xmlItems.firstChild.childNodes.item(1).text=="")
		xmlItems.replaceChild(newNode, xmlItems.firstChild);
	else
		xmlItems.appendChild(newNode);
	var idx1 = xmlItems.childNodes.length;
//	alert(idx1);
//	alert(xmlItems.childNodes.item(0).selectSingleNode("序號").text);
	var	j1=String(idx1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx1-1).selectSingleNode("序號").text=j1;
	}
	else
		xmlItems.childNodes.item(idx1-1).selectSingleNode("序號").text=idx1;
}
function SelectOK(obj) {
    oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
    window.returnValue = true;
    window.close();
}
</script>
	</body>
</html>
