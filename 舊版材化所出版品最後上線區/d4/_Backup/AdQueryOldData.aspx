<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="AdQueryOldData.aspx.cs" Src="AdQueryOldData.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdQueryOldData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    	<!-- CSS --><LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<body vLink=blue>
		<!-- ���� Header --><kw:header id=Header runat="server">
		</kw:header>
<form id=AdQueryOldData method=post runat="server">
<TABLE cellSpacing=0 cellPadding=0 width=500 border=0>
  <TR>
    <TD width=100><asp:checkbox id=cbxCusrNm runat="server"></asp:checkbox>�Ȥ�W�١G</TD>
    <TD><asp:textbox id=tbxCustNm runat="server" Width="100px"></asp:textbox></TD></TR>
  <TR>
    <TD><asp:checkbox id=cbxMfrNm runat="server"></asp:checkbox>�t�ӦW�١G</TD>
    <TD><asp:textbox id=tbxMfrNm runat="server" Width="100px"></asp:textbox></TD></TR>
  <TR>
    <TD><asp:button id=btnQuery runat="server" Text="�d��"></asp:button></TD>
    <TD></TD></TR></TABLE></FONT><FONT face=�s�ө���><asp:image id=imgAdFile runat="server"></asp:image><BR><asp:datagrid id=dgdAdrData runat="server" Font-Size="X-Small" BackColor="#ECEBFF" AutoGenerateColumns="False">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="�s�i�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:ButtonColumn DataTextField="adr_imgurl" HeaderText="���ɦW��" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="�s������"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="�s�i�_��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="�s�i����"></asp:BoundColumn>
</Columns>
</asp:datagrid>
<asp:HyperLink id=hylBack runat="server" Font-Size="X-Small" NavigateUrl="../Default.aspx">�^����</asp:HyperLink></FORM>
	<!-- ���� Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer></FONT>  	
  </body>
</HTML>
