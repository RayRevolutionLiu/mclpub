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
face=�s�ө���><asp:datagrid id=DataGrid1 runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle Wrap="False" ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="im_imseq" HeaderText="im_imseq"></asp:BoundColumn>
<asp:ButtonColumn Text="�R��" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�ӽs��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="im_email" HeaderText="�q�l�l��H�c"></asp:BoundColumn>
</Columns></asp:datagrid><BR>
<TABLE cellSpacing=1 cellPadding=1 bgColor=#bfcff0 border=1>
  <TR bgColor=#214389>
    <TD><FONT color=#ffffff size=2 
      >�t�Ӳνs</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�m�W</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >¾��</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�l��<BR>�ϸ�</FONT></TD>
    <TD style="WIDTH: 98px"><FONT color=#ffffff size=2 
      >�a�}</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�p��<BR>�q��</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�ǯu<BR>���X</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >���<BR>���X</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >Email</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�o��<BR>���O</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�|�O</FONT></TD>
    <TD><FONT color=white size=2 
      >���O</FONT></TD></TR>
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
<asp:ListItem Value="2">�G�p</asp:ListItem>
<asp:ListItem Value="3" Selected="True">�T�p</asp:ListItem>
<asp:ListItem Value="4">��L</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><asp:dropdownlist id=ddlTaxTp runat="server" Font-Size="XX-Small">
<asp:ListItem Value="1" Selected="True">���|5%</asp:ListItem>
<asp:ListItem Value="2">�s�|</asp:ListItem>
<asp:ListItem Value="3">�K�|</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><asp:dropdownlist id=ddlFgItri runat="server" Font-Size="XX-Small">
<asp:ListItem Value="00" Selected="True">�_</asp:ListItem>
<asp:ListItem Value="06">�Ҥ�</asp:ListItem>
<asp:ListItem Value="07">�|��</asp:ListItem>
</asp:dropdownlist></TD></TR></TABLE><BR></FONT><asp:button id=btnAdd runat="server" Text="�[�J"></asp:button><FONT 
face=�s�ө���><BR></FONT><FONT face=�s�ө���><BR></FONT><asp:button id=btnDone runat="server" Text="����"></asp:button></FORM>
<script language=javascript>
function doSubmit()
{
	window.opener.AdCont.submit();
	window.close();
}
</script>


	
  </body>
</HTML>
