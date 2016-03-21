<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1CheckList.aspx.cs" Src="IA1CheckList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IA1CheckList" %>
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
		<!-- 頁首 Header --><kw:header id=Header runat="server">
		</kw:header>
		<!-- 目前所在位置 -->
<table dataFld=items id=tbItems style="WIDTH: 739px">
  <tr>
    <td style="WIDTH: 100%" align=left><font 
      color=#333333 size=2><IMG height=10 src="../images/header/right02.gif" width=10 border=0 > &nbsp;網路廣告次系統 <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > 發票處理 <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > 預覽 發票開立檢核表 
      -&nbsp;當月一次付款</font> </td></tr></table>
<form id=IA1CheckList method=post runat="server"><asp:panel 
id=pnlQuery runat="server" Width="100%">
<asp:label id=lblBkcd runat="server">書籍類別：</asp:label>
<asp:dropdownlist id=ddlAdCate runat="server">
<asp:ListItem Value="M" Selected="True">首頁</asp:ListItem>
<asp:ListItem Value="I">內頁</asp:ListItem>
<asp:ListItem Value="N">奈米</asp:ListItem>
</asp:dropdownlist><BR>
<asp:label id=lblYYYYMM runat="server">刊登年月：</asp:label>
<asp:textbox id=tbxAdMonth runat="server" Width="60px" MaxLength="7"></asp:textbox>&nbsp; 
<asp:RequiredFieldValidator id=rfvAdMonth runat="server" Font-Size="X-Small" ControlToValidate="tbxAdMonth" Display="Dynamic" ErrorMessage="請輸入年月"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revAdMonth runat="server" Font-Size="X-Small" ControlToValidate="tbxAdMonth" Display="Dynamic" ErrorMessage="格式錯誤，應為yyyy/MM" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator><BR>
<asp:button id=btnQuery runat="server" Text="查詢"></asp:button>&nbsp; 
<asp:button id=btnClear runat="server" Text="清除重查"></asp:button><BR>
<asp:label id=lblMessage runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label></asp:panel><asp:panel 
id=pnlIaList runat="server" Width="100%">
<asp:label id=lblMessage2 runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
<asp:datagrid id=dgdIaList runat="server" Font-Size="8pt" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="Lavender">
</AlternatingItemStyle>

<ItemStyle ForeColor="Navy" BackColor="White">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_rjbti" HeaderText="稱謂"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_raddr" HeaderText="發票郵寄地址">
<HeaderStyle Wrap="False">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ia_rzip" HeaderText="郵遞區號"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_rtel" HeaderText="電話"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_iaditem" HeaderText="發票開立單明細序號"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_fk2" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_fk3" HeaderText="刊登年月"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_fk4" HeaderText="落版序號"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_desc" HeaderText="品名"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_projno" HeaderText="計劃代號"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_costctr" HeaderText="成本中心"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_qty" HeaderText="數量"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_amt" HeaderText="金額"></asp:BoundColumn>
</Columns>
</asp:datagrid>
<asp:button id=btnPrintList runat="server" Text="列印檢核表"></asp:button></asp:panel></form><kw:footer id=Footer runat="server">
	</kw:footer>	
  </body>
</HTML>
