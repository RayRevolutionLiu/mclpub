<%@ Page language="c#" Codebehind="QueryCont.aspx.cs" Src="QueryCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.QueryCont" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">    
  </HEAD>
  <body >

    <form id="QueryCont" method="post" runat="server">
    <!-- ���� Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
<FONT face=�s�ө���>
<TABLE style="WIDTH: 90%; HEIGHT: 128px" cellSpacing=0 cellPadding=1 width="90%" 
bgColor=#bfcff0 border=0>
  <TR>
    <TD style="WIDTH: 558px" bgColor=#214389><FONT size=2><FONT 
      color=white>�d�߱���</FONT>&nbsp; <FONT color=#ffffff>&nbsp;&nbsp; <SPAN 
      id=lblContTypeCode>(�@��X����)</SPAN> </FONT></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 558px"><FONT size=2>���q�W�١G</FONT>
<asp:TextBox id=tbxMfrName runat="server" Font-Size="XX-Small"></asp:TextBox><BR><FONT 
      size=2>�Τ@�s���G</FONT>
<asp:TextBox id=tbxMfrNo runat="server" Font-Size="XX-Small"></asp:TextBox><BR><FONT 
      size=2>�Ȥ�s���G</FONT>
<asp:TextBox id=tbxCustNo runat="server" Font-Size="XX-Small"></asp:TextBox><BR><FONT 
      size=2>�Ȥ�m�W�G</FONT>
<asp:TextBox id=tbxCustName runat="server" Font-Size="XX-Small"></asp:TextBox><FONT 
      size=2>&nbsp; 
<asp:LinkButton id=lnbQuery runat="server">�d��</asp:LinkButton>&nbsp; 
<asp:LinkButton id=lnbAddMfr runat="server">�s�W�t�Ӹ��</asp:LinkButton>&nbsp; 
<asp:LinkButton id=lnbAddCust runat="server">�s�W�Ȥ���</asp:LinkButton></FONT></TD></TR></TABLE></FONT>
<asp:DataGrid id=DataGrid1 runat="server" Font-Size="XX-Small" Font-Names="Verdana" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="2" AutoGenerateColumns="False">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle Font-Bold="True" Wrap="False" ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�Τ@�s��">
<HeaderStyle Wrap="False">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��">
<HeaderStyle Wrap="False">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��">
<HeaderStyle Wrap="False">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W">
<HeaderStyle Wrap="False">
</HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:DataGrid>
			<!-- Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:Footer>
     </form>
	
  </body>
</HTML>
