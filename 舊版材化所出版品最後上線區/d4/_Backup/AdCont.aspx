<%@ Page language="c#" Codebehind="AdCont.aspx.cs" Src="AdCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdCont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AdCont method=post runat="server"><FONT face=�s�ө���>
<TABLE style="WIDTH: 90%" cellSpacing=0 cellPadding=1 width="90%" 
bgColor=#bfcff0 border=0>
  <TR>
    <TD style="WIDTH: 558px" bgColor=#214389 colSpan=2 
      ><FONT size=2><FONT color=white 
      >�t�ӤΫȤ���</FONT></FONT></TD></TR>
  <tr>
    <td>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >���q�W�١G</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxMfrName runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�ԲӸ�ơG</FONT></P></TD>
          <TD width="35%"></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�Ȥ�m�W�G</FONT></P></TD>
          <TD><asp:textbox id=tbxCustName runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�p���q�ܡG</FONT></P></TD>
          <TD><asp:textbox id=tbxCustTel runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�Ȥ�¾�١G</FONT></P></TD>
          <TD><asp:textbox id=tbxCustTitle runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�ԲӸ�ơG</FONT></P></TD>
          <TD></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >�X���Ѱ򥻸��</FONT></FONT></TD></TR>
  <tr>
    <td colSpan=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�X���s���G</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxContNo runat="server" Font-Size="XX-Small" BackColor="Silver" ReadOnly="True" Width="67px" Height="22px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >ñ������G</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxContSignDate runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�X�����O�G</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlContTp runat="server" Font-Size="XX-Small">
<asp:ListItem Value="00" Selected="True">���ƥ@�ɺ�</asp:ListItem></asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            >�Z�n�_���G</FONT></P></TD>
          <TD><asp:textbox id=tbxContSDate runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox><FONT 
            size=2>�� </FONT><asp:textbox id=tbxContEDate runat="server" Font-Size="XX-Small" Width="68px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�Z�n���O�G</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlPubCate runat="server" Font-Size="XX-Small">
<asp:ListItem Value="0">�@��</asp:ListItem>
<asp:ListItem Value="1">���s</asp:ListItem></asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            >ñ���~�ȡG</FONT></P></TD>
          <TD><asp:textbox id=tbxContEmp runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD></TD>
          <TD></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�p���H�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuName runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�p���q�ܡG</FONT></P></TD>
          <TD><asp:textbox id=tbxAuTel runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox><FONT 
            size=2>&nbsp;&nbsp;&nbsp; ����G </FONT><asp:textbox id=tbxAuCell runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�ǯu���X�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuFax runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >email�G</FONT> </P></TD>
          <TD><asp:textbox id=tbxAuEmail runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >�X���ԲӸ��</FONT></FONT></TD></TR>
  <tr>
    <td colSpan=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�Z�n���ơG</FONT></P></TD>
          <TD width="18%"><asp:textbox id=tbxContPubTm runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�ذe���ơG</FONT></P></TD>
          <TD width="17%"><FONT size=2 
            ><asp:textbox id=tbxContFreeTm runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></FONT></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�`��Z���ơG</FONT></P></TD>
          <TD width="17%"><asp:textbox id=tbxContTotTm runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�X�����B�G</FONT></P></TD>
          <TD><asp:textbox id=tbxContTotAmt runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�u�f��ơG</FONT></P></TD>
          <TD><asp:textbox id=tbxContDisc runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�wú���B�G</FONT></P></TD>
          <TD><asp:textbox id=tbxContPaidAmt runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >�o������H���</FONT></FONT></TD></TR>
  <tr>
    <td colSpan=2>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >����H�G</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxIrName runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�q�ܡG</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxIrTel runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox><FONT 
            size=2>&nbsp;&nbsp;&nbsp; ����G <asp:textbox id=tbxIrCell runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></FONT></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�a�}�G</FONT></P></TD>
          <TD><asp:textbox id=tbxIrAddr runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�l���ϸ��G</FONT></P></TD>
          <TD><asp:textbox id=tbxIrZip runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�ǯu���X�G</FONT></P></TD>
          <TD><asp:textbox id=tbxIrFax runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >email�G</FONT></P></TD>
          <TD><asp:textbox id=tbxIrEmail runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD></TR></TABLE></td></tr>
  <TR>
    <TD style="WIDTH: 558px; HEIGHT: 18px" bgColor=#214389 colSpan=2 
    ><FONT size=2><FONT color=white 
      >��L���</FONT></FONT></TD></TR>
  <tr>
    <td>
      <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD width="15%">
            <P align=right><FONT size=2 
            >���s����G</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxCCont runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�j�M�����G</FONT></P></TD>
          <TD width="35%"><asp:textbox id=tbxCsDate runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�s�i�Ƶ��G</FONT></P></TD>
          <TD><asp:textbox id=tbxAdRemark runat="server" Font-Size="XX-Small"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�]�Ƥ���G</FONT></P></TD>
          <TD><asp:textbox id=tbxPdCont runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR></TABLE></td></tr></TABLE>[�o���t�Ӹ��] 
<INPUT style="FONT-SIZE: xx-small" onclick=doOpenInvMfr() type=button value=�s�W name=btnAddIM> 
<asp:button id=btnRefIM runat="server" Font-Size="XX-Small" Text="���s��z���"></asp:button><BR><asp:datalist id=DataList1 runat="server" BackColor="#bfcff0" RepeatColumns="5" RepeatDirection="Horizontal">
<ItemTemplate>
<asp:Label id=lblMfrName runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container.DataItem, "im_nm") %>'></asp:Label>(
<asp:Label id=lblMfrNo runat="server" Font-Size="X-Small" Text='<%# DataBinder.Eval(Container.DataItem, "im_mfrno") %>'></asp:Label>);�@
</ItemTemplate></asp:datalist><BR>[�{�����s����] <INPUT style="FONT-SIZE: xx-small" onclick=doOpenAdr() type=button value=�s�W name=btnAddAdr> 
<asp:button id=btnRefAdr runat="server" Font-Size="XX-Small" Text="���s��z���"></asp:button><BR><asp:datagrid id=DataGrid2 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="Delete" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="adr_date" HeaderText="���X���"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="�s�i����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="�s�i��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" HeaderText="�O��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_adrid" HeaderText="adr_adrid"></asp:BoundColumn>
</Columns></asp:datagrid><BR>[�خѸ��] <INPUT style="FONT-SIZE: xx-small" onclick=doOpenFreeBk() type=button value=�s�W name=btnAddBk Text="���s��z���"> 
<asp:button id=btnRefFreeBk runat="server" Font-Size="XX-Small" Text="���s��z���"></asp:button><BR><asp:datagrid id=DataGrid1 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="�R��" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:ButtonColumn Text="��" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="fbk_fbkid" HeaderText="id"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:BoundColumn DataField="bk_nm" HeaderText="���y"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
</Columns>
</asp:datagrid><BR></FONT><asp:button id=btnSave runat="server" Text="�x�s"></asp:button><asp:button id=btnRefresh runat="server" Text="���s��z"></asp:button>
<INPUT 
id=hidInvMfrCount type=hidden runat="server"></form>
<SCRIPT language=javascript>
function doOpenInvMfr()
{
	//window.open("AddInvMfr.aspx", "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
	window.open("AddInvMfr.aspx?ContNo=" + document.AdCont("tbxContNo").value , "Poping", "toolbar=no,menubar=no,width=800,height=600", false);
}

function doOpenAdr()
{
	if (document.AdCont("hidInvMfrCount").value > 0)
	{
		window.open("AdManagement.aspx?ContNo=" + document.AdCont("tbxContNo").value , "Adr", "toolbar=no,menubar=no,width=800,height=600", false);
	}
	else
	{
		alert("�Х���J�o���t�Ӹ��");
	}
}

function doOpenFreeBk()
{
	window.open("AddFreeBk.aspx?ContNo=" + document.AdCont("tbxContNo").value , "FreeBk", "toolbar=no,menubar=no,width=800,height=600", false);
}

</SCRIPT>


	
  </body>
</HTML>
