<%@ Page language="c#" Codebehind="CallerPage.aspx.cs" Src="CallerPage.aspx.cs" AutoEventWireup="false" Inherits="WorkWithXmlDoc.CallerPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<META content="Microsoft Visual Studio 7.0" name=GENERATOR>
<META content=C# name=CODE_LANGUAGE>
<META content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<META content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD> 
  
<BODY>
<FORM id=CallerPage method=post runat="server">
<P><FONT face=新細明體>按這邊呼叫挑選Reciever的子視窗
<IMG alt="" src="images/fp.bmp"  onclick="doGetReceiverXML()"></FONT></P>
<P><FONT face=新細明體>這個只是用來看到底傳回了什麼碗糕：<BR>
<TEXTAREA id="texta" name="texta" rows=20 cols=50></TEXTAREA></FONT></P>
<P><FONT face=新細明體>按這邊儲存整個XML到資料庫 
<asp:Button id=btnSave runat="server" Text="Save"></asp:Button></FONT></P>

</FORM>
<script language="javascript">
//以下這三行設定空白的XMLDocument，在Client端載入
var DSOX = new ActiveXObject("Microsoft.XMLDOM");
DSOX.async = false;
DSOX.load("BlankData.xml");
//取出DataNode02跟他的Children
var xmlOrder = DSOX.selectSingleNode("/Root/DataNode02");

var DSOR = new ActiveXObject("Microsoft.XMLDOM");
DSOR.async = false;
DSOR.load("BlankReceiver.xml");
//取出_1_or這個東西，事實上應該代表一連串的Recievers的資料
var xmlReceivers = DSOR.selectSingleNode("/Root/_1_or");

function doGetReceiverXML()
{
	var oParam = new Object();
	oParam.value = xmlReceivers;
	strFeature = "dialogHeight:550px;dialogWidth:700px;center:yes;scroll:yes;status:yes;help:no;";
	var vReturn = window.showModalDialog("GetReceiverXML.aspx", oParam, strFeature);
	document.CallerPage("texta").value=vReturn;
	
	var retDSO = new ActiveXObject("Microsoft.XMLDOM");
	retDSO.async = false;
	retDSO.load(Return);
}
/*
var objNodes = DSOX.documentElement.childNodes;
document.writeln("<TABLE>");
for(i=0;i<objNodes.length;i++)
{
	document.write("<TR><TD>" + objNodes.item(i).nodeName + "</TD>");
	document.write("<TD>" + objNodes.item(i).text + "</TD></TR>");
}
document.writeln("</TABLE>");
*/
</script>
	
</BODY>
</HTML>
