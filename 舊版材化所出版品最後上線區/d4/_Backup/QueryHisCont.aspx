<%@ Page language="c#" Codebehind="QueryHisCont.aspx.cs" Src="QueryHisCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.QueryHisCont" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body >
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
    <form id="QueryHisCont" method="post" runat="server">
<P><FONT face=�s�ө���>
<TABLE dataFld=items id=tbItems style="WIDTH: 739px; HEIGHT: 24px">
  <TR>
    <TD style="WIDTH: 100%" align=left><FONT color=#333333 size=2><IMG 
      height=10 src="../images/header/right02.gif" width=10 border=0> &nbsp;�����s�i���t�� 
      <IMG height=10 src="../images/header/right02.gif" width=10 border=0> �X���B�z 
      <IMG height=10 src="../images/header/right02.gif" width=10 border=0> �s�W�X���� 
      �B�J�G: �D�X�ӫȤ᪺���v�X���Ѹ��</FONT> 
</TD></TR></TABLE><!-- Run at Server Form -->
<A id=goback 
href="QueryCont.aspx?conttp=01">�^�d�ߵe��</A>&nbsp;&nbsp; 
<asp:Label id=lblMessage runat="server" ForeColor="Red"></asp:Label>&nbsp;&nbsp; 
<asp:button id=btnNew runat="server" Text="�s�W�ťզX����" Visible="False"></asp:button><BR>
<asp:Label id=lblCaption runat="server" Font-Size="X-Small" ForeColor="#C00000"></asp:Label>
<asp:datagrid id=dgdCont runat="server" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AllowPaging="True">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_aunm" HeaderText="�s�i�p���H�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_autel" HeaderText="�s�i�p���H�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="�@���I�M���O"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgclosed" HeaderText="���׵��O"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_disc" HeaderText="�u�f���"></asp:BoundColumn>
<asp:ButtonColumn Text="��ܦX�����v" CommandName="Detail"></asp:ButtonColumn>
<asp:ButtonColumn Text="�T�w�s�W" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
</Columns>
				</asp:datagrid>
<asp:Label id=lblRemark runat="server" ForeColor="#004040">&nbsp;</asp:Label>
<asp:literal id=literal1 runat="server"></asp:literal></form></FONT></P>
	<!-- ���� Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>
  </body>
</HTML>
