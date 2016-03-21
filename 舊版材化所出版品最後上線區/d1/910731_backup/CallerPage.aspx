<%@ Page language="c#" Codebehind="CallerPage.aspx.cs" src="CallerPage.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CallerPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="CallerPage" method="post" runat="server">
			<P>
				<IMG alt="PickMailTo" src="images/files.bmp" onclick="doMailTo()">
			</P>
			<P>
				<INPUT type="hidden" runat="server" id="HiddenData">
				<asp:Button id="btnSave" runat="server" Text="儲存訂單"></asp:Button>
			</P>
		</form>
		<Script language="javascript">
function doMailTo()
{
	var oParam = new Object();
	//oParam.value = xmlReceivers;
	strFeature = "";
	strFeature += "dialogHeight:550px;dialogWidth:700px;center:yes;scroll:yes;status:yes;help:no;";
	var vReturn = window.showModalDialog("PickRecievers.aspx", oParam, strFeature);
	//小賴的方法
	//xmlReceivers.parentNode.replaceChild(oParam.result, xmlReceivers);
	//xmlReceivers = xmlDoc0.selectSingleNode("/root/投遞資料");
	//alert(vReturn);
	
	//document.write(vReturn);
	document.CallerPage("HiddenData").value = vReturn;
	//alert(document.CallerPage("HiddenData").value);
}
		</Script>
	</body>
</HTML>
