<%@ Page language="c#" Codebehind="ShowOldCont.aspx.cs" Src="ShowOldCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ShowOldCont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=ShowOldCont method=post runat="server"><FONT 
face=�s�ө���></FONT>
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
          <TD width="30%"><asp:textbox id=tbxSignDate runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            >�X���s���G</FONT></P></TD>
          <TD width="30%"><asp:label id=lblContNo runat="server" Font-Size="X-Small">000000</asp:label></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�X�����O�G</FONT></P></TD>
          <TD><asp:dropdownlist id=ddlContTp runat="server" Font-Size="XX-Small" Enabled="False">
<asp:ListItem Value="01" Selected="True">�@��X��</asp:ListItem>
<asp:ListItem Value="09">���s�X��</asp:ListItem>
</asp:dropdownlist></TD>
          <TD>
            <P align=right><FONT size=2 
            ></FONT>&nbsp;</P></TD>
          <TD></TD></TR>
        <TR>
          <TD style="HEIGHT: 29px">
            <P align=right><FONT size=2 
            >�X���_����G</FONT></P></TD>
          <TD style="HEIGHT: 29px"><asp:textbox id=tbxSDate runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox>�� 
<asp:textbox id=tbxEDate runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD style="HEIGHT: 29px">
            <P align=right><FONT size=2 
            >�ӿ�~�ȭ��G</FONT></P></TD>
          <TD style="HEIGHT: 29px"><asp:dropdownlist id=ddlEmpData runat="server" Font-Size="XX-Small" EnableViewState="False" Enabled="False"></asp:dropdownlist></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�@���I�M���O�G</FONT></P></TD>
          <TD><asp:radiobuttonlist id=rblPayOnce runat="server" Font-Size="XX-Small" EnableViewState="False" RepeatDirection="Horizontal">
<asp:ListItem Value="1">�O</asp:ListItem>
<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
</asp:radiobuttonlist></TD>
          <TD></TD>
          <TD></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >�X���ѲӸ`</FONT></TD></TR>
  <TR>
    <TD>
      <TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD style="HEIGHT: 26px" width="25%">
            <P align=right><FONT size=2 
            >�Z�n���ơG</FONT></P></TD>
          <TD style="HEIGHT: 26px" width="30%"><asp:textbox id=tbxPubTm runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD style="HEIGHT: 26px" width="15%">
            <P align=right><FONT size=2 
            >�X���`���B�G</FONT></P></TD>
          <TD style="HEIGHT: 26px" width="30%"><asp:textbox id=tbxTotAmt runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD></TR>
        <TR>
          <TD><FONT size=2>
            <P align=right><FONT size=2 
            >�ذe���ơG</FONT></P></FONT></TD>
          <TD><asp:textbox id=tbxFreeTm runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�u�f��ơG</FONT></P></TD>
          <TD><asp:textbox id=tbxDisc runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�`�s�Z���ơG</FONT></P></TD>
          <TD><asp:textbox id=tbxTotTm runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR></TABLE></TD></TR>
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
          <TD width="30%"><asp:textbox id=tbxAuNm runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD width="15%">
            <P align=right><FONT size=2 
            ></FONT>&nbsp;</P></TD>
          <TD width="30%"></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >�q�ܡG</FONT></P></TD>
          <TD><asp:textbox id=tbxAuTel runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >�ǯu�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuFax runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD></TR>
        <TR>
          <TD>
            <P align=right><FONT size=2 
            >����G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuCell runat="server" Font-Size="XX-Small" ReadOnly="True" Width="80px" BackColor="#E0E0E0"></asp:textbox></TD>
          <TD>
            <P align=right><FONT size=2 
            >Email�G</FONT></P></TD>
          <TD><asp:textbox id=tbxAuEmail runat="server" Font-Size="XX-Small" ReadOnly="True" Width="150px" BackColor="#E0E0E0"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD bgColor=#214389><FONT color=white size=2 
      >�o���t�Ӧ���H���</FONT></TD></TR>
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
    <TD bgColor=#214389><FONT color=white size=2 
      >���x����H���خѸ��</FONT></TD></TR>
  <TR>
    <TD><asp:datagrid id=DataGridFreeBk runat="server" Font-Size="X-Small" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="SlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:BoundColumn DataField="bk_nm" HeaderText="���y"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
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
    <TD bgColor=#214389><FONT face=�s�ө���><FONT color=white size=2>�����s�i���</FONT></FONT></TD></TR>
  <TR>
    <TD><FONT face=�s�ө���>
<asp:DataGrid id=dgdAdr runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
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
</Columns>
</asp:DataGrid></FONT></TD></TR></TABLE></form>
	
  </body>
</HTML>
