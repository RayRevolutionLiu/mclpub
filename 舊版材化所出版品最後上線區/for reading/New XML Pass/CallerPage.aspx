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
<P><FONT face=�s�ө���>���o��I�s�D��Reciever���l����
<IMG alt="" src="images/fp.bmp"  onclick="doGetReceiverXML()"></FONT></P>
<P><FONT face=�s�ө���>�o�ӥu�O�ΨӬݨ쩳�Ǧ^�F����J�|�G<BR>
<TEXTAREA id="texta" name="texta" rows=20 cols=50></TEXTAREA></FONT></P>
<P><FONT face=�s�ө���>���o���x�s���XML���Ʈw 
<asp:Button id=btnSave runat="server" Text="Save"></asp:Button></FONT></P>

</FORM>
<script language="javascript">
//�H�U�o�T��]�w�ťժ�XMLDocument�A�bClient�ݸ��J
var DSOX = new ActiveXObject("Microsoft.XMLDOM");
DSOX.async = false;
DSOX.load("BlankData.xml");
//���XDataNode02��L��Children
var xmlOrder = DSOX.selectSingleNode("/Root/DataNode02");

var DSOR = new ActiveXObject("Microsoft.XMLDOM");
DSOR.async = false;
DSOR.load("BlankReceiver.xml");
//���X_1_or�o�ӪF��A�ƹ�W���ӥN��@�s�ꪺRecievers�����
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
