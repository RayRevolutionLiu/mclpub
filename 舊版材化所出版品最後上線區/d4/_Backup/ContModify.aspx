<%@ Page language="c#" Codebehind="ContModify.aspx.cs" Src="ContModify.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ContModify" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    	<!-- CSS --><LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
		<!-- ���� Header --><kw:header id=Header runat="server">
		</kw:header>
<form id=ContModify method=post runat="server"><FONT 
face=�s�ө���>
<DIV align=center>
<TABLE cellSpacing=0 cellPadding=2 width="90%" align=center bgColor=#bfcff0 
border=0>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >�t�ӤΫȤ���</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >���q�W��(�νs)�G</FONT></P></TD>
          <TD width="30%">
            <P align=left><asp:label id=lblMfrData runat="server" Font-Size="X-Small">���q�W��</asp:label><FONT 
            size=2>( <asp:label id=lblMfrNo runat="server">00000000</asp:label>)</FONT></P></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�ԲӸ�ơG</FONT></P></TD>
          <TD width="30%">
            <P align=left><IMG onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt=�t�ӸԲӸ�� src="edit.gif" name=imgMfrDetail ></P></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >���q�t�d�H�m�W(¾��)�G</FONT></P></TD>
          <TD>
            <P align=left><asp:label id=lblRespData runat="server" Font-Size="X-Small">�t�d�H(¾��)</asp:label></P></TD>
          <TD>
            <P align=right><FONT size=2 
            >���q�q��(�ǯu)�G</FONT></P></TD>
          <TD>
            <P align=left><asp:label id=lblMfrTel runat="server" Font-Size="X-Small">00-00000000(Fax: 00-00000000)</asp:label></P></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�Ȥ�m�W(�s��)�G</FONT></P></TD>
          <TD><asp:label id=lblCustData runat="server" Font-Size="X-Small">�Ȥ�m�W</asp:label><FONT 
            size=2>( <asp:label id=lblCustNo runat="server">000000</asp:label>)</FONT></TD>
          <TD>
            <P align=right><FONT size=2 
            >�ԲӸ�ơG</FONT></P></TD>
          <TD><IMG onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt=�Ȥ�ԲӸ�� src="edit.gif" name=imgCustDetail ></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >�X���Ѱ򥻸��</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >ñ������G</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxSignDate runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><IMG onclick='javascript:pick_date("tbxSignDate", "tbxSDate", "tbxEDate");return false;' alt="" src="calendar01.gif" name=imgSignDate ></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�X���s���G</FONT></P></TD>
          <TD width="30%"><asp:label id=lblContNo runat="server" Font-Size="X-Small">000000</asp:label></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�X�����O�G</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlContTp runat="server" Font-Size="XX-Small">
<asp:ListItem Value="01" Selected="True">�@��X��</asp:ListItem>
<asp:ListItem Value="09">���s�X��</asp:ListItem>
</asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            ></FONT>&nbsp;</P></TD>
          <TD></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�X���_����G</FONT></P></TD>
          <TD><asp:textbox id=tbxSDate runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox>�� 
<asp:textbox id=tbxEDate runat="server" Font-Size="XX-Small" Width="80px" AutoPostBack="True"></asp:textbox><asp:label id=lblDayCount runat="server" Font-Size="X-Small"></asp:label></TD>
          <TD>
            <P align=right><FONT size=2 
            >�ӿ�~�ȭ��G</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlEmpData runat="server" Font-Size="XX-Small"></asp:dropdownlist></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�@���I�M���O�G</FONT></P></TD>
          <TD><asp:radiobuttonlist id=rblPayOnce runat="server" Font-Size="XX-Small" RepeatDirection="Horizontal">
<asp:ListItem Value="1">�O</asp:ListItem>
<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
</asp:radiobuttonlist></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�X���Ƶ��G</FONT></P></TD>
          <TD><asp:textbox id=tbxAdRemark runat="server" Font-Size="XX-Small" Width="250px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�S�O���O�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAdSpRemark runat="server" Font-Size="XX-Small" Width="250px"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >�X���ѲӸ`</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >�Z�n���ơG</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxPubTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            size=2>�Ѿl�G </FONT><asp:label id=lblUnPubTm runat="server" Font-Size="X-Small"></asp:label></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�X���`���B�G</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxTotAmt runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD></TR>
        <TR>
          <TD><FONT size=2>
            <P align=right><FONT size=2 
            >�ذe���ơG</FONT></P></FONT></TD>
          <TD><asp:textbox id=tbxFreeTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�u�f��ơG</FONT></P></TD>
          <TD><asp:textbox id=tbxDisc runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            color=red size=2>(��: 0.8��ܤK��)</FONT></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�`���ɻs�Z���ơG</FONT></P></TD>
          <TD><asp:textbox id=tbxTotImgTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            size=2>�Ѿl�G <asp:label id=lblUnImgTm runat="server"></asp:label></FONT></TD>
          <TD>
            <P align=right><FONT size=2 
            >�w�}�ߵo�����B�G</FONT></P></TD>
          <TD><FONT size=2><asp:label id=lblInvedAmt runat="server"></asp:label>&nbsp; 
            �Ѿl�G <asp:label id=lblUnInvedAmt runat="server"></asp:label></FONT></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�`�s�����Z���ơG</FONT></P></TD>
          <TD><asp:textbox id=tbxTotUrlTm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox><FONT 
            size=2>�Ѿl�G <asp:label id=lblUnUrlTm runat="server"></asp:label></FONT></TD>
          <TD>
            <P align=right><FONT size=2 
            >�Hú�ڪ��B�G</FONT></P></TD>
          <TD><FONT size=2><asp:label id=lblPaidAmt runat="server"></asp:label></FONT></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >�s�i�p���H���</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%">
            <P align=right><FONT size=2 
            >�s�i�p���H�m�W�G</FONT></P></TD>
          <TD width="30%"><asp:textbox id=tbxAuNm runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            ></FONT>&nbsp;</P></TD>
          <TD width="30%"></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�q�ܡG</FONT></P></TD>
          <TD><asp:textbox id=tbxAuTel runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�ǯu�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuFax runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >����G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuCell runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >Email�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuEmail runat="server" Font-Size="XX-Small" Width="150px"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD style="HEIGHT: 24px" bgColor=#214389><table><tr><td><FONT 
      color=white size=2>��L���</FONT></td><td>
<asp:Panel id=pnlMisc runat="server"><IMG id=imgMisc onclick='doOpenMisc(<% Response.Write("\""+lblContNo.Text+"\""); %>)' alt=�s�W src="new.gif" name=imgMisc> <asp:imagebutton id=imgRefMisc runat="server" ImageUrl="refresh.gif" CausesValidation="False"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="25%" colSpan=4><FONT color=red 
            size=2 
            >�Ѧ���J�s�i���s����B�����B���~�]�Ƥ���B���ƯS�ʡB���β��~���������</FONT></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><table><tr><td><FONT color=white size=2 
      >�o���t�Ӧ���H���</FONT></td><td>
<asp:Panel id=pnlIM runat="server"><IMG id=imgAddIM  alt="" src="new.gif" name=imgAddIM onclick='doOpenInvMfr(<% Response.Write("\""+hidCustNo.Value+"\""); %> , <% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\""+hidOldContNo.Value+"\""); %>)'><asp:imagebutton id=imbRefIM runat="server" ImageUrl="refresh.gif" CausesValidation="False"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD><asp:datagrid id=DataGridIM runat="server" Font-Size="X-Small" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
<asp:BoundColumn DataField="im_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
</Columns>
</asp:datagrid></TD></TR>
  <TR>
    <TD bgColor=#214389><table><tr><td><FONT color=white size=2 
      >���x����H���خѸ��</FONT></td><td>
<asp:Panel id=pnlFreebk runat="server"><IMG id=imgAddFreeBk alt="" src="new.gif" name=imgAddFreeBk onclick='doOpenFreeBk(<% Response.Write("\""+hidCustNo.Value+"\""); %>, <% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\""+hidOldContNo.Value+"\""); %>)'><asp:imagebutton id=imbRefFreeBk runat="server" ImageUrl="refresh.gif" CausesValidation="False"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD><asp:datagrid id=DataGridFreeBk runat="server" Font-Size="X-Small" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fc_nm" HeaderText="���y"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="�l�H���O">
<ItemTemplate>
<asp:Label id=lblMtpNm runat="server" Font-Size="X-Small" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
</Columns>
</asp:datagrid></TD></TR>
  <TR>
    <TD bgColor=#214389><table><tr><td><FONT color=white size=2 
      >�����s�i���</FONT></td><td>
<asp:Panel id=pblAdr runat="server"><IMG id=imgAddAdr onclick='doOpenAdr(<% Response.Write("\""+lblContNo.Text+"\""); %>)' alt="" src="new.gif" name=imgAddAdr> <asp:imagebutton id=imbRefAdr runat="server" ImageUrl="refresh.gif"></asp:imagebutton></asp:Panel>
</td></tr></table>
</TD></TR>
  <TR>
    <TD><asp:datagrid id=dgdAdr runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#BFCFF0">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="adr_seq" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="���X�_��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="���X����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="���v"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="�s�i�s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_fgfixad" HeaderText="���X�覡"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adamt" HeaderText="�s�i����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_desamt" HeaderText="�]�p����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" HeaderText="���Z�O��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" HeaderText="�o�����B"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_drafttp" HeaderText="drafttp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_urltp" HeaderText="urltp"></asp:BoundColumn>
</Columns>
</asp:datagrid></TD></TR></TABLE></DIV></FONT>
<P align=center><asp:button id=btnSaveCont runat="server" Text="�x�s�ק�"></asp:button><asp:button id=btnDiscardCont runat="server" BackColor="Red" Text="���P�X��" ForeColor="White" Font-Bold="True"></asp:button><asp:button id=btnCloseCont runat="server" BackColor="Blue" Text="�X������" ForeColor="White" Font-Bold="True"></asp:button><asp:button id=btnBack runat="server" Text="�����^����"></asp:button><INPUT 
id=hidOldContNo type=hidden name=hidOldContNo 
runat="server"> <INPUT id=hidCustNo type=hidden name=hidCustNo runat="server"> <input id=hidIMCount type=hidden 
name=hidIMCount runat="server"></P></form>
<script language=javascript>
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField, theField1, theField2)
		{
			// ñ�����
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			//alert("vreturn= " + vreturn);
			
			// �X���_��
			
			var vreturn1 = vreturn;
			//alert("vreturn1= " + vreturn1);
			
			// �X������

			//var vreturn2 = vreturn;
			//alert("vreturn2= " + vreturn2);
			
			window.document.all(theField).value=vreturn;
			window.document.all(theField1).value=vreturn1;
			//window.document.all(theField2).value=vreturn2;
			//return true;
		}
		//-->
		</script>

<SCRIPT language=javascript>
function doOpenInvMfr(custno, new_contno, old_contno)
{
	//window.open("AddInvMfr.aspx", "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
	window.open("AddInvMfr.aspx?Act=Mod&CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,width=800,scrollbars=yes,resizable=yes,height=600", false);
}

function doOpenAdr(new_contno)
{
	var strQS = "Act=Mod&NewContNo=" + new_contno+ "&OldContNo=" + document.all("hidOldContNo").value;
	strQS += "&ContTp=" + document.all("ddlContTp").value;
	strQS += "&SignDate=" + document.all("tbxSignDate").value;
	strQS += "&SDate=" + document.all("tbxSDate").value;
	strQS += "&EDate=" + document.all("tbxEDate").value;
	strQS += "&PubTm=" + document.all("tbxPubTm").value;
	strQS += "&FreeTm=" + document.all("tbxFreeTm").value;
	strQS += "&Disc=" + document.all("tbxDisc").value;
	strQS += "&ImgTm=" + document.all("tbxTotImgTm").value;
	strQS += "&UrlTm=" + document.all("tbxTotUrlTm").value;
	//alert(strQS);
	//alert(document.all("hidIMCount").value);		
	if (document.all("hidIMCount").value > "0")
	{
		window.open("AdPrePublish.aspx?" + strQS, "Adr", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
		//window.showModalDialog("AdPrePublish.aspx?" + strQS, "", "dialogHeight:640px;dialogWidth:480px;center:yes;scroll:yes;status:no;help:no;resizable=yes");		
	}
	else if (document.all("ddlContTp").options(document.all("ddlContTp").selectedIndex).value=="09")
	{
		//���s�X��
		window.open("AdPrePublish.aspx?" + strQS, "Adr", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
	}	
	else
	{
		alert("�Х���J�o���t�Ӹ��");
	}
}

function doOpenFreeBk(custno, new_contno, old_contno)
{
	window.open("AddFreeBk.aspx?Act=Mod&CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}

function doOpenMisc(new_contno)
{
	//window.showModalDialog("ContMisc.aspx", "", "dialogHeight:480px;dialogWidth:640px;center:yes;scroll:yes;status:no;help:no;resizable=yes");
	window.open("ContMisc.aspx?ContNo="+new_contno, "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}

</SCRIPT>


	<!-- ���� Footer --><kw:footer id=Footer runat="server">
	</kw:footer>

  </body>
</HTML>
