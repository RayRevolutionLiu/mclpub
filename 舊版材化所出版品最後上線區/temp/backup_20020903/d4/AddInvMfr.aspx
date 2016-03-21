<%@ Page language="c#" Codebehind="AddInvMfr.aspx.cs" Src="AddInvMfr.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AddInvMfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AddInvMfr method=post runat="server"><FONT 
face=新細明體><asp:datagrid id=DataGrid1 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle Wrap="False" ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="im_imseq" HeaderText="im_imseq"></asp:BoundColumn>
<asp:ButtonColumn Text="刪除" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商編號"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="姓名"></asp:BoundColumn>
<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
<asp:BoundColumn DataField="im_email" HeaderText="電子郵件信箱"></asp:BoundColumn>
</Columns></asp:datagrid><BR>
<TABLE cellSpacing=1 cellPadding=1 bgColor=#bfcff0 border=1>
  <TR bgColor=#214389>
    <TD><FONT color=#ffffff size=2 
      >廠商統編</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >姓名</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >職稱</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >郵遞<BR>區號</FONT></TD>
    <TD style="WIDTH: 98px"><FONT color=#ffffff size=2 
      >地址</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >聯絡<BR>電話</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >傳真<BR>號碼</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >手機<BR>號碼</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >Email</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >發票<BR>類別</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >稅別</FONT></TD>
    <TD><FONT color=white size=2 
      >註記</FONT></TD></TR>
  <TR>
    <TD><asp:textbox id=tbxMfrNo runat="server" Font-Size="XX-Small" Width="69px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxNm runat="server" Font-Size="XX-Small" Width="55px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxJbti runat="server" Font-Size="XX-Small" Width="40px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxZip runat="server" Font-Size="XX-Small" Width="34px"></asp:textbox></TD>
    <TD style="WIDTH: 98px"><asp:textbox id=tbxAddr runat="server" Font-Size="XX-Small" Width="85px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxTel runat="server" Font-Size="XX-Small" Width="65px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxFax runat="server" Font-Size="XX-Small" Width="65px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxCell runat="server" Font-Size="XX-Small" Width="65px"></asp:textbox></TD>
    <TD><asp:textbox id=tbxEmail runat="server" Font-Size="XX-Small" Width="69px"></asp:textbox></TD>
    <TD><asp:dropdownlist id=ddlInvCd runat="server" Font-Size="XX-Small">
<asp:ListItem Value="2">二聯</asp:ListItem>
<asp:ListItem Value="3" Selected="True">三聯</asp:ListItem>
<asp:ListItem Value="4">其他</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><asp:dropdownlist id=ddlTaxTp runat="server" Font-Size="XX-Small">
<asp:ListItem Value="1" Selected="True">應稅5%</asp:ListItem>
<asp:ListItem Value="2">零稅</asp:ListItem>
<asp:ListItem Value="3">免稅</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><asp:dropdownlist id=ddlFgItri runat="server" Font-Size="XX-Small">
<asp:ListItem Value="00" Selected="True">否</asp:ListItem>
<asp:ListItem Value="06">所內</asp:ListItem>
<asp:ListItem Value="07">院內</asp:ListItem>
</asp:dropdownlist></TD></TR></TABLE><BR></FONT><asp:button id=btnAdd runat="server" Text="加入"></asp:button><FONT 
face=新細明體><BR></FONT><FONT face=新細明體><BR></FONT><asp:button id=btnDone runat="server" Text="關閉"></asp:button></FORM>
<script language=javascript>
function doSubmit()
{
	window.opener.AdCont.submit();
	window.close();
}
</script>


	
  </body>
</HTML>
