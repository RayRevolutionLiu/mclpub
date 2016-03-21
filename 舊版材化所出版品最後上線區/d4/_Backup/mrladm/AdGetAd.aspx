<%@ Page language="c#" Codebehind="AdGetAd.aspx.cs" Src="AdGetAd.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mrladm.AdGetAd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body>
	
    <form id="AdGetAd" method="post" runat="server">
<P><FONT face=新細明體>
<TABLE cellSpacing=0 cellPadding=0 border=0 bgcolor=#bfcff0>
  <TR bgcolor=#214398>
    <TD style="WIDTH: 14px"></TD>
    <TD style="WIDTH: 103px">
      <P align=left><FONT size=2 color=white>查詢條件</FONT></P></TD>
    <TD style="WIDTH: 163px"></TD></TR>
  <TR>
    <TD style="WIDTH: 14px; HEIGHT: 20px"></TD>
    <TD style="WIDTH: 103px; HEIGHT: 20px">
      <P align=left><FONT size=2>廣告頁面</FONT></P></TD>
    <TD style="WIDTH: 163px; HEIGHT: 20px">
<asp:DropDownList id=ddlAdCate runat="server">
<asp:ListItem Value="M" Selected="True">首頁</asp:ListItem>
<asp:ListItem Value="I">內頁</asp:ListItem>
<asp:ListItem Value="N">奈米</asp:ListItem>
</asp:DropDownList></TD></TR>
  <TR>
    <TD style="WIDTH: 14px"></TD>
    <TD style="WIDTH: 103px">
      <P align=left><FONT size=2>催稿日期<BR></FONT></P></TD>
    <TD style="WIDTH: 163px">
<asp:TextBox id=tbxAdDate runat="server" Width="90px" Font-Size="X-Small"></asp:TextBox><IMG onclick='javascript:pick_date("tbxAdDate");return false;'
      alt="" src="../calendar01.gif"><FONT size=2><BR></FONT><FONT 
      color=tomato size=2>例：2002/12/31</FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 14px">
<asp:CheckBox id=cbxEmpNo runat="server" Text=" "></asp:CheckBox></TD>
    <TD style="WIDTH: 103px">
      <P align=left><FONT size=2>承辦業務員</FONT></P></TD>
    <TD style="WIDTH: 163px">
<asp:DropDownList id=ddlEmpNo runat="server"></asp:DropDownList></TD></TR>
  <TR>
    <TD style="WIDTH: 14px"></TD>
    <TD style="WIDTH: 103px"><FONT size=2>
      <P 
      align=left>
<asp:Button id=btnGo runat="server" Text="查詢"></asp:Button></P></FONT></TD>
    <TD style="WIDTH: 163px"></TD></TR></TABLE>
<asp:RegularExpressionValidator id=revAdDate runat="server" Font-Size="X-Small" ErrorMessage="日期格式錯誤，請重新輸入！" Display="Dynamic" ControlToValidate="tbxAdDate" ValidationExpression="[2]\d{3}/[0-2][0-9]/[0-3][0-9]"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator id=rfvAdDate runat="server" Font-Size="X-Small" ErrorMessage="請輸入日期" Display="Dynamic" ControlToValidate="tbxAdDate"></asp:RequiredFieldValidator></FONT></P>

     </form>
	
  </body>
</HTML>
