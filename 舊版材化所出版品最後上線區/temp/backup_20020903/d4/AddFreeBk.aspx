<%@ Page language="c#" Codebehind="AddFreeBk.aspx.cs" Src="AddFreeBk.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AddFreeBk" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AddFreeBk method=post runat="server"><FONT 
face=�s�ө���></FONT><FONT face=�s�ө���><FONT 
color=orangered size=2><FONT color=orangered>[���x����H���]<BR></FONT></FONT><asp:datagrid id=DataGrid1 runat="server" AutoGenerateColumns="False" BackColor="#BFCFF0" Font-Size="X-Small">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<SelectedItemStyle BackColor="YellowGreen">
</SelectedItemStyle>

<Columns>
<asp:ButtonColumn Text="�R��" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:ButtonColumn Text="��" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn Visible="False" DataField="or_orid" HeaderText="id"></asp:BoundColumn>
<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
<asp:BoundColumn DataField="or_fgmosea" HeaderText="��~"></asp:BoundColumn>
</Columns>
</asp:datagrid><BR>
<TABLE style="WIDTH: 627px; HEIGHT: 79px" cellSpacing=1 cellPadding=1 
width="100%" bgColor=#bfcff0 border=1>
  <TR bgColor=#214389>
    <TD style="WIDTH: 64px"><FONT color=#ffffff size=2 
      >�m�W</FONT></TD>
    <TD style="WIDTH: 36px"><FONT color=#ffffff size=2 
      >�ٿ�</FONT></TD>
    <TD style="WIDTH: 36px"><FONT color=#ffffff size=2 
      >�l��<BR>�ϸ�</FONT></TD>
    <TD style="WIDTH: 168px"><FONT color=#ffffff size=2 
      >�a�}</FONT></TD>
    <TD style="WIDTH: 54px"><FONT color=#ffffff size=2 
      >�q��</FONT></TD>
    <TD style="WIDTH: 43px"><FONT color=#ffffff size=2 
      >�ǯu</FONT></TD>
    <TD style="WIDTH: 44px"><FONT color=#ffffff size=2 
      >���</FONT></TD>
    <TD style="WIDTH: 86px"><FONT color=#ffffff size=2 
      >Email</FONT></TD>
    <TD><FONT color=#ffffff size=2 
      >�ꤺ�~<BR>���O</FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 64px"><asp:textbox id=tbxOrNm runat="server" Font-Size="XX-Small" Height="24px" Width="63px"></asp:textbox></TD>
    <TD style="WIDTH: 36px"><asp:textbox id=tbxOrJbti runat="server" Font-Size="XX-Small" Height="24px" Width="41px"></asp:textbox></TD>
    <TD style="WIDTH: 36px"><asp:textbox id=tbxOrZip runat="server" Font-Size="XX-Small" Height="24px" Width="35px"></asp:textbox></TD>
    <TD style="WIDTH: 168px"><asp:textbox id=tbxOrAddr runat="server" Font-Size="XX-Small" Height="24px" Width="178px"></asp:textbox></TD>
    <TD style="WIDTH: 54px"><asp:textbox id=tbxOrTel runat="server" Font-Size="XX-Small" Height="24px" Width="65px"></asp:textbox></TD>
    <TD style="WIDTH: 43px"><asp:textbox id=tbxOrFax runat="server" Font-Size="XX-Small" Height="24px" Width="65px"></asp:textbox></TD>
    <TD style="WIDTH: 44px"><asp:textbox id=tbxOrCell runat="server" Font-Size="XX-Small" Height="24px" Width="65px"></asp:textbox></TD>
    <TD style="WIDTH: 86px"><asp:textbox id=tbxOrEmail runat="server" Font-Size="XX-Small" Height="24px" Width="115px"></asp:textbox></TD>
    <TD><asp:dropdownlist id=ddlOrMoSea runat="server" Font-Size="XX-Small">
<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
<asp:ListItem Value="1">��~</asp:ListItem>
</asp:dropdownlist></TD></TR></TABLE><asp:button id=btnAddOr runat="server" Text="�s�W����H���"></asp:button><BR><BR><FONT size=2><FONT color=orangered>[�خѰѦҸ��]</FONT><BR></FONT><asp:datagrid id=DataGrid2 runat="server" AutoGenerateColumns="False" BackColor="#BFCFF0" Font-Size="X-Small">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="�R��" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:ButtonColumn Text="��" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="fbk_fbkid" HeaderText="id"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:BoundColumn DataField="bk_nm" HeaderText="���y"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
</Columns></asp:datagrid><FONT color=orangered><BR></FONT>
<TABLE style="WIDTH: 700px; HEIGHT: 72px" cellSpacing=1 cellPadding=1 width="100%" 
bgColor=#bfcff0 border=1>
  <TR bgColor=#214389>
    <TD style="WIDTH: 73px; HEIGHT: 28px"><FONT 
      color=#ffffff size=2>�ؾ\�_��</FONT></TD>
    <TD style="WIDTH: 73px; HEIGHT: 28px"><FONT 
      color=#ffffff size=2>�ؾ\����</FONT></TD>
    <TD style="WIDTH: 71px; HEIGHT: 28px"><FONT 
      color=#ffffff size=2>���y</FONT></TD>
    <TD style="WIDTH: 106px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>�l�H���O</FONT></TD>
    <TD style="WIDTH: 73px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>�Z�n���<BR>����</FONT></TD>
    <TD style="WIDTH: 86px; HEIGHT: 28px"><FONT color=#ffffff 
  size=2>���Z�n���<BR>����</FONT></TD>
    <TD style="HEIGHT: 28px"><FONT color=#ffffff size=2>����H</FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 73px"><asp:textbox id=tbxFbkSdate runat="server" Font-Size="XX-Small" Height="24px" Width="63px" BackColor="White" ></asp:textbox></TD>
    <TD style="WIDTH: 73px"><asp:textbox id=tbxFbkEdate runat="server" Font-Size="XX-Small" Height="24px" Width="63px" BackColor="White" ></asp:textbox></TD>
    <TD style="WIDTH: 71px"><asp:dropdownlist id=ddlFbkBkCd runat="server" Font-Size="XX-Small">
<asp:ListItem Value="01" Selected="True">�u��</asp:ListItem>
<asp:ListItem Value="02">�q��</asp:ListItem>
</asp:dropdownlist></TD>
    <TD style="WIDTH: 106px">
<asp:DropDownList id=ddlMtpCd runat="server" Font-Size="XX-Small"></asp:DropDownList></TD>
    <TD style="WIDTH: 73px">
<asp:TextBox id=tbxPubMnt runat="server" Font-Size="XX-Small" Height="24px" Width="63px"></asp:TextBox></TD>
    <TD style="WIDTH: 86px">
<asp:TextBox id=tbxUnPubMnt runat="server" Font-Size="XX-Small" Height="24px" Width="63px"></asp:TextBox></TD>
    <TD>
<asp:DropDownList id=ddlOrSeq runat="server" Font-Size="XX-Small"></asp:DropDownList></TD></TR></TABLE></FONT><FONT 
face=�s�ө���><asp:button id=btnAdd runat="server" Text="�s�W�خѸ��"></asp:button><BR><BR></FONT><asp:button id=btnDone runat="server" Text="����"></asp:button></form>
<script language=javascript>
function doSubmit()
{
	window.opener.AdCont.submit();
	window.close();
}
</script>

	
  </body>
</HTML>
