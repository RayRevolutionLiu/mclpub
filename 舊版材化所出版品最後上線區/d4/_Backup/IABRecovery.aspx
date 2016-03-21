<%@ Page language="c#" Codebehind="IABRecovery.aspx.cs" Src="IABRecovery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IABRecovery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <!-- CSS -->
    <LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
  <body>
	<!-- 頁首 Header -->
	<kw:header id=Header runat="server">
	</kw:header>	
    <form id="IABRecovery" method="post" runat="server">
<p>
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						網路廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單回復(Recovery) - 大批月結</font>
				</td>
			</tr>
		</table><FONT face=新細明體><BR>
<asp:Panel id=pnlQuery runat="server" Width="100%"></asp:Panel>
</p>
<P>請輸入查詢條件<BR>發票開立單 開立年月：
<asp:TextBox id=tbxIaMonth runat="server" Width="80px" MaxLength="7"></asp:TextBox>
<asp:RequiredFieldValidator id=rfvIaMonth runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="請輸入年月" Font-Size="X-Small"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revIaMonth runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="格式錯誤，應為yyyy/MM" Font-Size="X-Small" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator><BR>發票開立單 
開立批號：
<asp:TextBox id=tbxIabNo runat="server" Width="80px" MaxLength="6"></asp:TextBox>
<asp:RequiredFieldValidator id=rfvIabNo runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="請輸入開立批號" Font-Size="X-Small"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revIabNo runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="格式例如：000001" Font-Size="X-Small" ValidationExpression="\d{6}"></asp:RegularExpressionValidator><BR>
<asp:Button id=btnQuery runat="server" Text="查詢"></asp:Button>
<asp:Button id=btnClear runat="server" Text="清除重查"></asp:Button></P></FONT>
     </form>
	<!-- 頁尾 Footer -->
<asp:Panel id=pnlIaList runat="server" Width="100%"><FONT face=新細明體>
<asp:Label id=lblInfo runat="server"></asp:Label>
<asp:DataGrid id=dgdIa runat="server" Font-Size="X-Small" BackColor="#E7EBFF" AutoGenerateColumns="False">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_empno" HeaderText="業務員"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="發票收件人"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="發票廠商"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="廣告序號"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="廣告開始日期"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="廣告結束日期"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="廣告位置"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="機率"></asp:BoundColumn>
<asp:BoundColumn DataField="suminvamt" HeaderText="當月發票金額"></asp:BoundColumn>
</Columns>
</asp:DataGrid><BR></FONT>
<asp:Button id=btnIabRecovery runat="server" Text="發票回復"></asp:Button></asp:Panel>
	<kw:footer id=Footer runat="server">
	</kw:footer>	
  </body>
</HTML>
