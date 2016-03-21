<%@ Page language="c#" Codebehind="IABCheckList.aspx.cs" Src="IABCheckList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IABCheckList" %>
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
		<!-- 頁首 Header --><kw:header id=Header runat="server">
		</kw:header>
<table dataFld=items id=tbItems style="WIDTH: 739px">
  <tr>
    <td style="WIDTH: 100%" align=left><font 
      color=#333333 size=2><IMG height=10 src="../images/header/right02.gif" width=10 border=0 > &nbsp;網路廣告次系統 <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > 發票處理 <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > 預覽 發票開立檢核表 
      -&nbsp;當月大批月結</font> </td></tr></table>		
		<!-- 目前所在位置 -->
<form id=IABCheckList method=post runat="server"><FONT 
face=新細明體>
<asp:Panel id=pnlQuery runat="server" Width="100%">
<asp:label id=lblAdCate runat="server">刊登頁面：</asp:label>
<asp:dropdownlist id=ddlAdCate runat="server">
<asp:ListItem Value="M" Selected="True">首頁</asp:ListItem>
<asp:ListItem Value="I">內頁</asp:ListItem>
<asp:ListItem Value="N">奈米</asp:ListItem>
</asp:dropdownlist><BR>
<asp:label id=lblYYYYMM runat="server">刊登年月：</asp:label>
<asp:textbox id=tbxAdMonth runat="server" Width="60px" MaxLength="7"></asp:textbox>
<asp:RequiredFieldValidator id=rfvAdMonth runat="server" Font-Size="X-Small" ErrorMessage="請輸入年月" Display="Dynamic" ControlToValidate="tbxAdMonth"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revAdMonth runat="server" Font-Size="X-Small" ErrorMessage="格式錯誤，應為yyyy/MM" Display="Dynamic" ControlToValidate="tbxAdMonth" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator><BR>
<asp:label id=lblOrderByFilter runat="server">排序條件：</asp:label>
<asp:dropdownlist id=ddlOrderByFilter runat="server">
					<asp:ListItem Value="1" Selected="True">合約編號+落版序號</asp:ListItem>
					<asp:ListItem Value="2">業務員</asp:ListItem>
				</asp:dropdownlist><BR>
<asp:Label id=lblIabSeq runat="server">＊發票開立單批號：</asp:Label>
<asp:TextBox id=tbxIabseq runat="server" Width="60px" MaxLength="6">000001</asp:TextBox>&nbsp; 
<FONT color=darkred size=2>(請輸入正確值，如 000001)</FONT>&nbsp;&nbsp; 
<asp:button id=btnQuery runat="server" Text="查詢"></asp:button>&nbsp; 
<asp:button id=btnClear runat="server" Text="清除重查"></asp:button>
</asp:Panel>
<asp:Panel id=pnlIaList runat="server" Width="100%">
<asp:datagrid id=dgdIaList runat="server" Font-Size="8pt" BackColor="White" AutoGenerateColumns="False" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
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
<asp:button id=btnPrintList runat="server" Text="列印檢核表"></asp:button></asp:Panel>
</FONT></form>
<kw:footer id=Footer runat="server"></kw:footer>	
  </body>
</HTML>
