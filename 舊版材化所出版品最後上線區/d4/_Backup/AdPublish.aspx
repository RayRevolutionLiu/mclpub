<%@ Page language="c#" Codebehind="AdPublish.aspx.cs" Src="AdPublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdPublish" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AdPublish method=post runat="server" encType="multipart/form-data"><FONT 
face=�s�ө���></FONT><asp:label id=lblStep1 runat="server" Font-Size="X-Small" BackColor="SteelBlue" Width="100%" ForeColor="White">ơ��J�򥻸��</asp:label>
<TABLE cellSpacing=1 cellPadding=1 width="100%" border=1>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�X���s��</FONT> <asp:textbox id=tbxContNo runat="server" Font-Size="XX-Small" BackColor="Silver" size="6"></asp:textbox></TD>
    <TD><FONT size=2>�o���t�� 
<asp:dropdownlist id=ddlInvMfr runat="server"></asp:dropdownlist></FONT></TD>
    <TD colspan=2><FONT size=2>�s�i�s��</FONT> 
<asp:textbox id=tbxNavUrl runat="server" Font-Size="XX-Small"></asp:textbox>
<asp:requiredfieldvalidator id=RequiredFieldValidator2 runat="server" Font-Size="XX-Small" ControlToValidate="tbxNavUrl" ErrorMessage="���i�ť�"></asp:requiredfieldvalidator></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�s�i���� </FONT>
<asp:textbox id=tbxAdAmt runat="server" Width="60px" Font-Size="XX-Small"></asp:textbox></TD>
    <TD><FONT size=2>�o�����B<FONT size=3> 
      </FONT>
<asp:textbox id=tbxInvAmt runat="server" Width="60px" Font-Size="XX-Small"></asp:textbox></FONT></TD>
    <TD colspan=2><FONT face=�s�ө���><FONT 
      size=2>�s�i�лy</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxAltText runat="server" Font-Size="XX-Small"></asp:textbox>
<asp:requiredfieldvalidator id=RequiredFieldValidator1 runat="server" Font-Size="XX-Small" ControlToValidate="tbxAltText" ErrorMessage="���i�ť�"></asp:requiredfieldvalidator></FONT></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�]�p���� </FONT>
<asp:textbox id=tbxDesAmt runat="server" Width="60px" Font-Size="XX-Small"></asp:textbox></TD>
    <TD><FONT size=2>�}�l��� 
<asp:textbox id=tbxBeginDate runat="server" Width="60px" Font-Size="XX-Small"></asp:textbox>
<asp:ImageButton id=imbStartDate runat="server" ImageUrl="show-calendar.gif"></asp:ImageButton></FONT></TD>
    <TD colspan=2 rowspan=4><FONT size=2><asp:calendar id=calSelectAdDate runat="server" Font-Size="9pt" BackColor="LemonChiffon" ForeColor="Black" CellPadding="0" NextPrevFormat="FullMonth" BorderColor="White" Font-Names="Verdana" BorderWidth="1px">
<TodayDayStyle BackColor="PaleGoldenrod">
</TodayDayStyle>

<DayStyle Font-Size="XX-Small">
</DayStyle>

<NextPrevStyle Font-Size="6pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom">
</NextPrevStyle>

<DayHeaderStyle Font-Size="5pt">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="8pt" Font-Bold="True" BorderWidth="3px" ForeColor="#333399" BorderColor="Black" BackColor="Gold">
</TitleStyle>

<WeekendDayStyle Font-Size="XX-Small">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:calendar>
<INPUT id=hidDateTarget type=hidden name=hidDataTarget 
      runat="server"><FONT face=�s�ө���></FONT></FONT></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>���Z�O�� </FONT>
<asp:textbox id=tbxChgAmt runat="server" Width="60px" Font-Size="XX-Small"></asp:textbox></TD>
    <TD><FONT face=�s�ө��� size=2>������� 
<asp:textbox id=tbxEndDate runat="server" Width="60px" Font-Size="XX-Small"></asp:textbox>
<asp:ImageButton id=imbEndDate runat="server" ImageUrl="show-calendar.gif"></asp:ImageButton></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT 
      size=2>��Z���O</FONT><FONT size=3> </FONT>
<asp:dropdownlist id=ddlFgGot runat="server" Font-Size="XX-Small">
<asp:ListItem Value="1" Selected="True">�O</asp:ListItem>
<asp:ListItem Value="0">�_</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT face=�s�ө���></FONT></TD></TR>
  <TR>
    <TD colSpan=2><FONT face=�s�ө��� 
      size=2>�Ƶ�</FONT>
<asp:textbox id=tbxRemark runat="server" Font-Size="XX-Small"></asp:textbox></TD>
    </TR></TABLE><FONT 
size=2><FONT 
color=red><FONT size=2></FONT></FONT></FONT><asp:label id=lblStep2 runat="server" Font-Size="X-Small" BackColor="SteelBlue" Width="100%" ForeColor="White">Ƣ��J�s�i���</asp:label><FONT 
size=2><BR></FONT><FONT size=2>
<TABLE cellSpacing=1 cellPadding=1 width="100%" border=1>
  <TR>
    <TD><FONT face=�s�ө��� size=2>�s�i�d�� 
<asp:dropdownlist id=ddlAdCate runat="server" Font-Size="XX-Small">
<asp:ListItem Value="M">����</asp:ListItem>
<asp:ListItem Value="I">����</asp:ListItem>
<asp:ListItem Value="N">�`��</asp:ListItem>
</asp:dropdownlist></FONT></TD>
    <TD><FONT size=2>�s�i��m 
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
</asp:dropdownlist><IMG 
      style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none" 
      alt="" src="explorer.gif" onclick="doOpenReference()"></FONT></TD></TR>
  <TR>
    <TD><FONT face=�s�ө���><FONT size=2>����覡</FONT> <asp:dropdownlist id=ddlFgFixAd runat="server" Font-Size="XX-Small">
<asp:ListItem Value="0" Selected="True">����</asp:ListItem>
<asp:ListItem Value="1">�w��</asp:ListItem>
</asp:dropdownlist></FONT></TD>
    <TD><FONT face=�s�ө���><FONT size=2>���X���v</FONT> 
<asp:textbox id=tbxImpression runat="server" Font-Size="XX-Small" size="1"></asp:textbox></FONT></TD></TR>
  <TR>
    <TD><FONT face=�s�ө���><FONT size=2>�s�i�����O</FONT> 
<asp:textbox id=tbxDraftType runat="server" Font-Size="XX-Small" size="1"></asp:textbox></FONT></TD>
    <TD><FONT size=2>�s�i����</FONT> 
<INPUT id=fileAdImage 
      style="FONT-SIZE: xx-small" type=file name=fileAdImage 
  runat="server"></TD></TR></TABLE></FONT>
<asp:label id=lblStep3 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">ƣ�x�s�����s�i���X���</asp:label><FONT 
size=2>���T�w�C�Ӹ�Ƴ���g�L�~�A�T�w�N</FONT> 
<asp:button id=btnSave runat="server" Text="�x�s"></asp:button>
<asp:Label id=lblAdDate runat="server"></asp:Label>
<asp:TextBox id=tbxTxtAdCont runat="server"></asp:TextBox></form>
<script language="javascript">
function doOpenReference()
{
	RefWindow = window.open("CountReference.aspx", "RefWindow", "", false);
}
</script>
	
  </body>
</HTML>
