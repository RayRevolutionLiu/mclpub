<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1QueryInv.aspx.cs" Src="IA1QueryInv.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IA1QueryInv" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    	<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
<form id=IA1QueryInv method=post runat="server"><FONT 
face=�s�ө���></FONT><FONT face=�s�ө���><asp:panel id=pnlQueryIM 
runat="server" Width="100%">�o���t�Ӧ���H�m�W�G 
<asp:TextBox id=tbxIMNm runat="server"></asp:TextBox>
<asp:Button id=btnQueryIm runat="server" Text="�d��"></asp:Button><BR>
<asp:Label id=lblContMsg runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>
<asp:DataGrid id=dgdImCont runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<SelectedItemStyle BackColor="DarkSeaGreen">
</SelectedItemStyle>

<Columns>
<asp:ButtonColumn Text="���" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="im_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="�o�t�W��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_empno" HeaderText="ñ���~��"></asp:BoundColumn>
</Columns>
</asp:DataGrid></asp:panel><asp:panel id=pnlAdr 
runat="server" Width="100%">
<HR width="100%" color=orange SIZE=1>
<asp:Label id=lblAdrMsg runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>
<asp:DataGrid id=dgdAdr runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:TemplateColumn>
<ItemTemplate>
<asp:CheckBox id=cbxSelAdr runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="adr_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="�s�i�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="�_�l���"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="�������"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" HeaderText="�o�����B"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_fggot" HeaderText="��Z"></asp:BoundColumn>
</Columns>
</asp:DataGrid>
<asp:Button id=btnGoIA runat="server" Text="�T�w���"></asp:Button></asp:panel><asp:panel id=pnlVerify 
runat="server" Width="100%">
<HR width="100%" color=orange SIZE=1>
<asp:Label id=lblTotalMsg runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>
<asp:Button id=btnGoGenIA runat="server" Text="���͵o��"></asp:Button></asp:panel></FONT></form>
	
  </body>
	<!-- ���� Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>  
</HTML>
