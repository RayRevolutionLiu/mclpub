<%@ Page Language="c#" CodeBehind="adpub.aspx.cs" Src="adpub.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub" %>
<%@ Register TagPrefix="kw" TagName="header" Src="UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="UserControl/footer.ascx" %>

<HTML>
  <HEAD>
		<title>�s�i����</title>
<META content="Jean Chen" name=Programmer>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
		<!-- CSS --><LINK title=Style href="../UserControl/mrlpub.css" type=text/css rel=stylesheet ><LINK href="../UserControl/adpub.css" type=text/css rel=stylesheet >
  </HEAD>
<BODY ondblclick=doReOrder() bottomMargin=0 leftMargin=0 topMargin=0 
rightMargin=0>

	<!-- DataIsland --><xml id=DSO1></xml><xml id=DSOT></xml>
<form id=form1 name=form1 runat="server">
<center>
	
	<!-- ���� Header --><kw:header id=Header runat="server"></kw:header>
	
	<!-- Hidden Value Filed -->
	<input id=hidData type=hidden runat="server">
	

	
	<!-- Initial Client Side Script -->
<SCRIPT language=javascript>
var xmlDoc1 = DSO1.XMLDocument;
xmlDoc1.async = false; 
xmlDoc1.load("adpubdata.xml");

//�o�q�i�Hwork...�u���L�S����ơA�u�V�|...
var xmldoct = DSOT.XMLDocument;
xmldoct.async = false;
xmldoct.loadXML(document.form1("hidData").value);

</SCRIPT>



<!-- �ثe�Ҧb��m -->
<table dataFld=items id=tbItems align=left>
  <tr>
    <td align=left><font color=#333333 size=2 
      ><IMG height=10 src="../images/header/right02.gif" width=10 border=0 > �����s�i���t�� <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > �����B�z <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > �s�i����</font> 
</td></tr></table><br>


<!-- ���D --><b><FONT color=darkblue size=5>�s�i���� - 
�u��</FONT></b><br>

<!-- ����Z�n������t�Φ~�� -->
<DIV style="WIDTH: 520px" align=right>�Z�n����G<b> <font color=red><asp:label id=lbl_thismonth runat="server"></asp:label></font></b></DIV>
<!-- ������ƲM�� -->
<table id=tb1 dataSrc=#DSO1 align=center border=1>
  <TBODY>
  <thead align=middle>
  <tr style="COLOR: white; Size: 4" bgColor=#214389>
    <td align=middle colSpan=6><font color=#ffffff size=4 
      >��������</font> </td></tr>
  <tr bgColor=#bfcff0>
    <td noWrap>���� </td>
    <td noWrap>�y�z </td>
    <td noWrap>��m </td>
    <td noWrap>�g�T </td>
    <td noWrap>���� </td>
    <td noWrap>������ </td></tr></thead>
  <tbody onmousemove=doMouseMove()>
  <tr align=middle>
    <td class=cssOrder><span dataFld=���� id=pageorder 
      ></span></td>
    <td class=cssDetail align=left><span dataFld=�y�z 
      id=idDescript onclick=doClick(document.all.DSO1) 
      ></span></td>
    <td class=cssColor><span dataFld=��m 
      ></span></td>
    <td class=cssPagesize><span dataFld=�g�T 
      ></span></td>
    <td class=cssPageLayout><span dataFld=���� 
      ></span></td>
    <td class=cssPageLayout2><input dataFld=����2 
      id=pagelayout2 type=text size=1> </td></tr></tbody>
  <tfoot>
  <tr>
    <td align=right colSpan=5></td></tr></tfoot></table>

<!-- ������ƲM�� -->

<!-- Mouse click �᪺��ƶ}�l -->
<DIV class=srcData id=ico 
style="DISPLAY: none; Z-INDEX: 100; POSITION: absolute"></DIV>
<DIV id=fMenu>
<DIV class=fixMenu onclick=doReOrder()>���ƭ��� </DIV>
<DIV class=fixMenu onclick=doHelp1();>�ާ@���� </DIV>
<DIV class=fixMenu onclick="window.location.href='/mrlpub/'">�^���� </DIV>
<DIV class=fixMenu id=tempMsg></DIV></DIV>
<!-- �\����� -->


<script language=javascript>
function doHelp1()
{
	if(document.all.helpMsg.style.display.toLowerCase() == 'none')
	{
		document.all.helpMsg.style.display = "";
		event.srcElement.innerText = "���þާ@����"; 
	}
	else
	{
		document.all.helpMsg.style.display = "none";
		event.srcElement.innerText = "�ާ@����"; 
	}
}
//	window.onload = ggg();
</script>

<script language=javascript src="UserControl/watermark.js"></script>

<script language=javascript>
// page layout maintain 
function doClick(theDSO)
{
	if(btnPressed)
	{
		if(srcDSO == theDSO)
		{
			doPut();
			btnPressed = false;
			var gg = false;
			for(var i=0; i<document.getElementsByTagName("tb1").length; i++)
			{
//				if(event.srcElement.readyState=="complete")
			}
			doReOrder();

		}
	}
	else
	{
		srcDSO = theDSO;
		doPick();
		btnPressed = true;
	}
}

function doMouseMove()
{
//	document.all("ico").value="Coords: (" + event.clientX + ", " + event.clientY + ")";
   document.all.ico.style.posLeft = event.clientX + document.body.scrollLeft;
   document.all.ico.style.posTop = event.clientY + document.body.scrollTop;
//		event.returnValue = false;
//		event.cancelBubble = true;
/*
*/
}

function doPick()
{
	srcObj = event.srcElement;
	srcObj.style.color="red";
	srcObj.style.cursor="hand";
	document.all.ico.style.display="";
	document.all.ico.innerText=srcObj.innerText;
	segOffset = srcObj.parentElement.parentElement.rowIndex-2;
	var xmlDoc = srcDSO.XMLDocument;
	srcNode = xmlDoc.documentElement.childNodes.item(segOffset);
	return !btnPressed;
}

function doPut()
{
	var obj = event.srcElement;
	var idx = obj.parentElement.parentElement.rowIndex-2;
	var xmlDoc = srcDSO.XMLDocument;

	//�o��n���O�_��ƪ����P�w
	//�o�q�u��w��n�Q�������B�z�A���O�᭱�����e���J�٬O�|�v�T....-_-
	
	//targetNode�O�n��u�w�D��`�I�v��b���᭱���u�ؼи`�I�v
	//srcNode�O�u�w�D��`�I�v
	var targetNode = xmlDoc.documentElement.childNodes.item(idx);
	if (idx!=segOffset && targetNode.selectSingleNode("�T�w����").text != "1" && srcNode.selectSingleNode("�T�w����").text != "1")
	{
		//�ƻs�@��srcNode�PtargetNode
		var srcNodeCopy = srcNode.cloneNode(true);
		var targetNodeCopy = targetNode.cloneNode(true);
		
		xmlDoc.documentElement.replaceChild(srcNodeCopy, targetNode);
		xmlDoc.documentElement.replaceChild(targetNodeCopy, srcNode);
		
		var srcidx = segOffset;
		//OLD ��srcNode��copy���targetNode����m
		//OLD xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);
		//OLD ��targetNode�h��srcNode����m
		//Old xmlDoc.documentElement.insertBefore(targetNode, xmlDoc.documentElement.childNodes.item(srcidx).nextSibling);
		srcNodeCopy = null;
		targetNodeCpoy = null;
	}

	srcObj.style.color="";
	srcObj.style.cursor="";
	srcObj = null;
	document.all.ico.style.display="none";
	//doRePublish();
	return !btnPressed;
}

function doReOrder()
{
	var pp = 0;
	for(var i=0; i< document.all.pageorder.length; i++)
	{
		pp = pp + (document.all.pagelayout2[i].value/8);
		document.all.pageorder[i].innerText = Math.ceil(pp);
	}
}


//���s�ƪ��A����
function doRePublish()
{

}

var srcDSO = new Object();
var btnPressed=false;
var srcObj = new Object();
var srcNode = new Object();
var segIdx = 0;
var segOffset = 0
</script>

<!-- idDescript �� OnMouseOver ����C�� -->
<script language=javascript event=onmouseover for=idDescript>
style.backgroundColor='Gold';
style.cursor="hand";
</script>

<!-- idDescript �� OnMouseOut ����C�� -->
<script language=javascript event=onmouseout for=idDescript>
style.backgroundColor='';
style.cursor="default";
</script>

<!--  -->
<!-- fMenu �� OnMouseOver ����C��  -->
<script language=javascript event=onmouseover for=fMenu>
event.srcElement.style.backgroundColor='Gold';
event.srcElement.style.cursor="hand";
</script>

<!-- fMenu �� OnMouseOut ����C��  -->
<script language=javascript event=onmouseout for=fMenu>
event.srcElement.style.backgroundColor='';
event.srcElement.style.cursor="";
</script>

<!-- fMenu �� helpMsg ����C��  -->
<DIV class=help1 id=helpMsg style="DISPLAY: none">
<OL>
  <LI>�в��� Mouse �ܭn���ʪ��y�z�����@�U Mouse �k��, �o�ɷ|�X�{�@�Ӵy�z��쪺��ƽƻs���. 
  <LI>���� Mouse �ܭn��m���y�z���A���@�U Mouse �k��Y�i���s�ƦC. 
  <LI>���i�վ㤣�P���O��������m. </LI></OL></DIV>
<P>��: <B>�q������:</B> �S�O����, �m�⤺��(��), 
�M�⤺��(��), �M�⤺��(�b) <BR>��: <B>�u������:</B> 
�S�O����, �m�⤺��(��), �M�⤺��(��), �¥դ���(��), �¥դ���(�b) </P>

<!-- ���� Footer -->
<kw:footer id=Footer runat="server"></kw:footer>
</center>
</form>
</BODY>
</HTML>
