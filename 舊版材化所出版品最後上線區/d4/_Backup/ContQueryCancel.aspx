<%@ Page language="c#" Codebehind="ContQueryCancel.aspx.cs" Src="ContQueryCancel.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ContQueryCancel" %>
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
  <body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
    <form id="ContQueryCancel" method="post" runat="server">
<TABLE dataFld=items id=tbItems style="WIDTH: 739px; HEIGHT: 24px">
  <TR>
    <TD style="WIDTH: 100%" align=left><FONT color=#333333 size=2><IMG 
      height=10 src="../images/header/right02.gif" width=10 border=0> 
      &nbsp;網路廣告次系統 <IMG height=10 src="../images/header/right02.gif" width=10 
      border=0> 合約處理 <IMG height=10 src="../images/header/right02.gif" width=10 
      border=0>&nbsp;已註銷合約處理</FONT> </TD></TR></TABLE>
<asp:Label id=lblInfo runat="server" ForeColor="Maroon">已註銷合約列表</asp:Label>
<asp:datagrid id=dgdCont runat="server" AutoGenerateColumns="False" CellPadding="1" BackColor="#ECEBFF" BorderWidth="1px" BorderStyle="None" Font-Size="X-Small">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:ButtonColumn Text="回復" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_aunm" HeaderText="聯絡人姓名"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_autel" HeaderText="聯絡人電話"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付清註記"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案註記"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
</Columns>
</asp:datagrid>


     </form>
	<!-- 頁尾 Footer --><FONT 
face=新細明體></FONT>
	<kw:footer id="Footer" runat="server">
	</kw:footer>		
  </body>
</HTML>
