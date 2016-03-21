<%@ Page language="c#" Codebehind="IABQueryInv.aspx.cs" Src="IABQueryInv.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IABQueryInv" %>
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
<form id=IABQueryInv method=post runat="server"><asp:panel 
id=pnlQuery runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD style="WIDTH: 103px"><FONT face=新細明體>廣告頁面：</FONT></TD>
    <TD>
<asp:DropDownList id=ddlAdCate runat="server">
<asp:ListItem Value="M" Selected="True">首頁</asp:ListItem>
<asp:ListItem Value="I">內頁</asp:ListItem>
<asp:ListItem Value="N">奈米</asp:ListItem>
</asp:DropDownList></TD></TR>
  <TR>
    <TD style="WIDTH: 103px"><FONT face=新細明體>刊登月份：</FONT></TD>
    <TD>
<asp:TextBox id=tbxAdMonth runat="server" Width="85px" MaxLength="8"></asp:TextBox><FONT 
      face=新細明體>&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ControlToValidate="tbxAdMonth" Display="Dynamic" ErrorMessage="請輸入年月" Font-Size="X-Small"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=RegularExpressionValidator1 runat="server" ControlToValidate="tbxAdMonth" Display="Dynamic" ErrorMessage="格式錯誤，應為yyyy/MM" Font-Size="X-Small" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 103px"><FONT face=新細明體>排序條件：</FONT></TD>
    <TD>
<asp:DropDownList id=ddlSort runat="server">
<asp:ListItem Value="0" Selected="True">合約編號+廣告序號</asp:ListItem>
<asp:ListItem Value="1">業務員</asp:ListItem>
</asp:DropDownList><FONT face=新細明體>&nbsp; 
<asp:Button id=BtnQuery1 runat="server" Text="查詢"></asp:Button></FONT></TD></TR></TABLE></asp:panel><asp:panel 
id=pnlStep1 runat="server" Width="100%">
<HR width="100%" color=orangered SIZE=1>
<asp:Label id=lblInfo1 runat="server" ForeColor="OrangeRed"></asp:Label><FONT 
face=新細明體><BR>
<asp:Button id=btnStep1SelAll runat="server" Text="全選"></asp:Button>
<asp:Button id=btnStep1SelNone runat="server" Text="清選"></asp:Button></FONT><BR>
<asp:DataGrid id=dgdStep1 runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:TemplateColumn>
<ItemTemplate>
<asp:CheckBox id=cbxSelContAdr runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
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
</asp:DataGrid><FONT face=新細明體>
<asp:Button id=btnStep1Go runat="server" Text="檢核資料"></asp:Button></FONT></asp:panel><asp:panel 
id=pnlStep2 runat="server" Width="100%"><FONT face=新細明體>
<HR width="100%" color=orangered SIZE=1>
<asp:Label id=lblInfo2 runat="server" ForeColor="OrangeRed"></asp:Label><BR></FONT><FONT 
face=新細明體>
<asp:DataGrid id=dgdStep2 runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
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
</asp:DataGrid><BR></FONT><FONT face=新細明體>
<asp:Label id=lblTotAmt runat="server" ForeColor="OrangeRed"></asp:Label><BR>
<asp:Button id=btnGoInv runat="server" Text="產生發票資料"></asp:Button>
<asp:Button id=btnGoStep1 runat="server" Text="回到上一步"></asp:Button></FONT></asp:panel></form>
		<!-- 頁尾 Footer --><kw:footer id=Footer runat="server">
		</kw:footer>
	
  </body>
</HTML>
