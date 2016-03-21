<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="QueryUnclosedCont.aspx.cs" Src="QueryUnclosedCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.QueryUnclosedCont" %>
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
  <body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
	
    <form id="QueryUnclosedCont" method="post" runat="server">
<P><FONT face=新細明體>
<TABLE dataFld=items id=tbItems style="WIDTH: 739px; HEIGHT: 24px">
  <TR>
    <TD style="WIDTH: 100%" align=left><FONT color=#333333 size=2><IMG 
      height=10 src="../images/header/right02.gif" width=10 border=0> &nbsp;網路廣告次系統 
      <IMG height=10 src="../images/header/right02.gif" width=10 border=0> 合約處理 <IMG height=10 
      src="../images/header/right02.gif" width=10 border=0> 合約書 
      <IMG height=10 src="../images/header/right02.gif" width=10 border=0> 維護合約書 
      步驟二: 挑出該客戶的未結案合約書資料</FONT> 
</TD></TR></TABLE><!-- Run at Server Form -->
<A id=goback 
href="QueryCust.aspx">回查詢畫面</A>&nbsp;&nbsp; 
<asp:Label id=lblMessage runat="server" ForeColor="Red"></asp:Label>&nbsp;&nbsp;<BR>
<asp:Label id=lblCaption runat="server" Font-Size="X-Small" ForeColor="#C00000"></asp:Label>
<asp:datagrid id=dgdCont runat="server" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AllowPaging="True">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_aunm" HeaderText="廣告聯絡人姓名"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_autel" HeaderText="廣告聯絡人電話"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付清註記"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案註記"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_disc" HeaderText="優惠折數"></asp:BoundColumn>
<asp:ButtonColumn Text="顯示合約歷史" CommandName="Detail"></asp:ButtonColumn>
<asp:ButtonColumn Text="確定維護" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
<asp:BoundColumn Visible="False" DataField="cont_custno" HeaderText="cont_custno"></asp:BoundColumn>
</Columns>
				</asp:datagrid>
<asp:Label id=lblRemark runat="server" ForeColor="#004040">&nbsp;</asp:Label>
<asp:literal id=literal1 runat="server"></asp:literal></form></FONT></P>
				<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>	
  </body>
</HTML>
