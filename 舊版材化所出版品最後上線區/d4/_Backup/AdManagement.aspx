<%@ Page language="c#" Codebehind="AdManagement.aspx.cs" Src="AdManagement.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdManagement" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body bgColor=skyblue>
<form id=AdManagement method=post encType="multipart/form-data" runat="server">
<P><FONT face=�s�ө���>
<asp:Label id=lblStep1 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">ơ��J�򥻸��</asp:Label><BR><FONT size=2>
<TABLE cellSpacing=1 cellPadding=1 width="100%" border=1>
  <TR>
    <TD><FONT size=2>�X���s��</FONT> 
<asp:textbox id=tbxContNo runat="server" Font-Size="XX-Small" BackColor="Silver" size="6"></asp:textbox></TD>
    <TD><FONT size=2>�s�i����
<asp:textbox id=tbxAdAmt runat="server" Font-Size="XX-Small"></asp:textbox></FONT></TD>
    <TD><FONT size=2>�s�i�O��</FONT>
<asp:textbox id=tbxInvAmt runat="server" Font-Size="XX-Small"></asp:textbox></TD></TR>
  <TR>
    <TD><FONT size=2>�s�i�лy</FONT> 
<asp:textbox id=tbxAltText runat="server" Font-Size="XX-Small"></asp:textbox></TD>
    <TD><FONT size=2>�]�p����
<asp:textbox id=tbxDesAmt runat="server" Font-Size="XX-Small"></asp:textbox></FONT></TD>
    <TD><FONT size=2>��Z���O</FONT>
<asp:DropDownList id=ddlFgGot runat="server" Font-Size="XX-Small">
<asp:ListItem Value="1" Selected="True">�O</asp:ListItem>
<asp:ListItem Value="0">�_</asp:ListItem>
</asp:DropDownList></TD></TR>
  <TR>
    <TD><FONT size=2>�s�i�s��</FONT> 
<asp:textbox id=tbxNavUrl runat="server" Font-Size="XX-Small"></asp:textbox></TD>
    <TD><FONT size=2>���Z�O��
<asp:textbox id=tbxChgAmt runat="server" Font-Size="XX-Small"></asp:textbox></FONT></TD>
    <TD><FONT size=2>�Ƶ�
<asp:TextBox id=tbxRemark runat="server" Font-Size="XX-Small"></asp:TextBox></FONT></TD></TR>
  <TR>
    <TD><FONT size=2>�o���t�� </FONT>
<asp:DropDownList id=ddlInvMfr runat="server"></asp:DropDownList></TD>
    <TD></TD>
    <TD></TD></TR></TABLE></FONT></FONT><FONT face=�s�ө���>
<HR width="100%" SIZE=1 color=white>
<asp:Label id=lblStep2 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">Ƣ�D�］�X���</asp:Label><BR><FONT size=2>��ܼ��X������G</FONT>

<asp:label id=lblAdDate runat="server" Font-Size="X-Small"></asp:label><FONT 
color=red><FONT size=2>�ثe�H��������</FONT><BR></FONT>
<asp:calendar id=calSelectAdDate runat="server" BorderWidth="1px" BackColor="LemonChiffon" Width="309px" ForeColor="Black" Height="140px" Font-Size="9pt" Font-Names="Verdana" BorderColor="White" NextPrevFormat="FullMonth" CellPadding="0">
<TodayDayStyle BackColor="PaleGoldenrod">
</TodayDayStyle>

<DayStyle Font-Size="XX-Small">
</DayStyle>

<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom">
</NextPrevStyle>

<DayHeaderStyle Font-Size="6pt">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="X-Small" Font-Bold="True" BorderWidth="4px" ForeColor="#333399" BorderColor="Black" BackColor="Gold">
</TitleStyle>

<WeekendDayStyle Font-Size="XX-Small">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:calendar><HR width="100%" SIZE=1 color=white>
<asp:Label id=lblStep3 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">ƣ��J�ϧΩΤ�r�s�i��ơ]�G��@�^</asp:Label><BR></FONT><FONT face=�s�ө���>
<TABLE borderColor=crimson cellSpacing=1 borderColorDark=firebrick cellPadding=1 
width="100%" border=1>
  <TR>
    <TD align=middle><FONT size=2>�ϧμs�i�]H1��H5�^</FONT></TD>
    <TD align=middle><FONT 
size=2>��r�s�i�]W1��W6�^</FONT></TD></TR>
  <TR vAlign=top>
    <TD><FONT size=2>�s�i����</FONT>
<INPUT id=fileAdImage type=file name=fileAdImage 
      runat="server" style="FONT-SIZE: xx-small"><BR><FONT size=2>�s�i�����O</FONT> 
<asp:textbox id=tbxDraftType runat="server" size="1" Font-Size="XX-Small"></asp:textbox></TD>
    <TD><FONT size=2>��r�s�i�r��</FONT>
<asp:textbox id=tbxTxtAdCont runat="server" size="20" Font-Size="XX-Small"></asp:textbox></TD></TR>
  <TR>
    <TD align=middle colSpan=2><FONT size=2>�s�i�d��</FONT>
<asp:DropDownList id=ddlAdCate runat="server" Font-Size="XX-Small">
<asp:ListItem Value="M">����</asp:ListItem>
<asp:ListItem Value="I">����</asp:ListItem>
<asp:ListItem Value="N">�`��</asp:ListItem>
</asp:DropDownList>�@�@<FONT size=2>�s�i��m</FONT> 
<asp:dropdownlist id=ddlKey runat="server" Font-Size="XX-Small">
<asp:ListItem Value="H1">H1</asp:ListItem>
<asp:ListItem Value="H2" Selected="True">H2</asp:ListItem>
<asp:ListItem Value="H3">H3</asp:ListItem>
<asp:ListItem Value="H4">H4</asp:ListItem>
<asp:ListItem Value="H5">H5</asp:ListItem>
<asp:ListItem Value="W1">W1</asp:ListItem>
<asp:ListItem Value="W2">W2</asp:ListItem>
<asp:ListItem Value="W3">W3</asp:ListItem>
<asp:ListItem Value="W4">W4</asp:ListItem>
<asp:ListItem Value="W5">W5</asp:ListItem>
<asp:ListItem Value="W6">W6</asp:ListItem>
</asp:dropdownlist>�@�@<FONT size=2>���X���v</FONT> 
<asp:textbox id=tbxImpression runat="server" size="1" Font-Size="XX-Small"></asp:textbox>�@�@<FONT 
      size=2>����覡</FONT> 
<asp:dropdownlist id=ddlFgFixAd runat="server" Font-Size="XX-Small">
<asp:ListItem Value="0" Selected="True">����</asp:ListItem>
<asp:ListItem Value="1">�w��</asp:ListItem>
</asp:dropdownlist></TD></TR></TABLE>
<HR width="100%" color=white SIZE=1></FONT><FONT face=�s�ө���>
<asp:Label id=Label1 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">Ƥ�x�s�����s�i���X���</asp:Label><BR><FONT size=2>���T�w�C�Ӹ�Ƴ���g�L�~�A�T�w�N</FONT>
<asp:Button id=btnSave runat="server" Text="�x�s"></asp:Button><A 
href="http://03212-900103/Beta2/MRLPub.d4/Contents.aspx"><FONT size=2>�^����</FONT></A></FONT></form>
<script language=javascript>
function doSubmit()
{
	window.opener.AdCont.submit();
	window.close();
}
</script>
	
  </body>
</HTML>
