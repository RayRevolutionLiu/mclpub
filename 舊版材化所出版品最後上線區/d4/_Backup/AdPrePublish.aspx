<%@ Page language="c#" Codebehind="AdPrePublish.aspx.cs" Src="AdPrePublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdPrePublish" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=AdPrePublish method=post runat="server"><FONT 
size=2><asp:panel id=pnlAllAdr 
BorderColor="green" BorderWidth="1px" Width="100%" Runat="server"><FONT 
face=�s�ө���><FONT color=red>�򥻦X�����<BR>
<TABLE borderColor=lightgrey cellSpacing=0 borderColorDark=white cellPadding=0 
width="100%" border=1>
  <TR align=middle bgColor=#bfcff0>
    <TD style="HEIGHT: 19px"><FONT size=2>�X���s��</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�X�����O</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>ñ�����</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�X���_��</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�Z�n<BR>����</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�ذe<BR>����</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�u�f<BR>���</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�`�s���ɽZ<BR>����</FONT></TD>
    <TD style="HEIGHT: 19px"><FONT size=2>�`�ܺ����Z<BR>����</FONT></TD></TR>
  <TR>
    <TD><FONT 
    size=2>
<asp:Label id=lblContNo runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblContTp runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
      size=2>
<asp:Label id=lblSignDate runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblSEDate runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblPubTm runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblFreeTm runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblDisc runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblImgTm runat="server"></asp:Label></FONT></TD>
    <TD><FONT 
    size=2>
<asp:Label id=lblUrlTm runat="server"></asp:Label></FONT></TD></TR></TABLE></FONT></FONT>
<asp:Label id=lblAdr runat="server" ForeColor="Red">�{���s�i���</asp:Label></asp:panel><asp:datagrid id=dgdAdr runat="server" AutoGenerateColumns="False" BackColor="#E7EBFF" Font-Size="X-Small">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" ReadOnly="True" HeaderText="���X�_��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" ReadOnly="True" HeaderText="���X����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="���v"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="�s�i�s��"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="���X�覡">
<ItemTemplate>
<asp:Label id=lblFgFixAdNm runat="server" Text='<%# GetFgFixAdNm(DataBinder.Eval(Container.DataItem, "adr_fgfixad")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="adr_adamt" ReadOnly="True" HeaderText="�s�i����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_desamt" ReadOnly="True" HeaderText="�]�p����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" ReadOnly="True" HeaderText="���Z�O��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" ReadOnly="True" HeaderText="�o�����B"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_drafttp" HeaderText="drafttp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_urltp" HeaderText="urltp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_remark" HeaderText="remark"></asp:BoundColumn>
</Columns>
</asp:datagrid><br><asp:panel id=pnlInputArea runat="server" BorderColor="Green" BorderWidth="1px" 
Width="100%">
<asp:label id=lblStep1 runat="server" Width="100%" ForeColor="White" BackColor="SteelBlue" Font-Size="X-Small">��J�򥻸��</asp:label>
<TABLE cellSpacing=0 cellPadding=1 width="100%" bgColor=lightcyan border=0>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>�X���s��</FONT> 
<asp:textbox id=tbxContNo runat="server" Width="60px" BackColor="Silver" Font-Size="X-Small" ReadOnly="True" size="6"></asp:textbox></TD>
    <TD><FONT size=2>�o���t�� 
<asp:dropdownlist id=ddlInvMfr runat="server" Font-Size="X-Small"></asp:dropdownlist><IMG 
      alt="" src="edit.gif" name=imgAddInvMfr></FONT></TD>
    <TD colSpan=2><FONT size=2>�s�i�s��</FONT> 
<asp:textbox id=tbxNavUrl runat="server" Font-Size="X-Small"></asp:textbox>
<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" Font-Size="XX-Small" ErrorMessage="���i�ť�" ControlToValidate="tbxNavUrl" Display="Dynamic"></asp:RequiredFieldValidator></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>�}�l��� </FONT>
<asp:textbox id=tbxBeginDate runat="server" Width="70px" Font-Size="X-Small"></asp:textbox>
<asp:ImageButton id=imbStartDate runat="server" ImageUrl="show-calendar.gif" CausesValidation="False"></asp:ImageButton>
<asp:RequiredFieldValidator id=RequiredFieldValidator3 runat="server" Font-Size="XX-Small" ErrorMessage="���i�ť�" ControlToValidate="tbxBeginDate" Display="Dynamic"></asp:RequiredFieldValidator></TD>
    <TD><FONT size=2>������� 
<asp:textbox id=tbxEndDate runat="server" Width="70px" Font-Size="X-Small"></asp:textbox>
<asp:ImageButton id=imbEndDate runat="server" ImageUrl="show-calendar.gif" CausesValidation="False"></asp:ImageButton>
<asp:Label id=lblTotDays runat="server"></asp:Label>
<asp:RequiredFieldValidator id=RequiredFieldValidator4 runat="server" Font-Size="XX-Small" ErrorMessage="���i�ť�" ControlToValidate="tbxEndDate" Display="Dynamic"></asp:RequiredFieldValidator></FONT></TD>
    <TD colSpan=2><FONT face=�s�ө���><FONT size=2>�s�i�лy</FONT><FONT size=3> 
</FONT>
<asp:textbox id=tbxAltText runat="server" Font-Size="X-Small"></asp:textbox>
<asp:RequiredFieldValidator id=RequiredFieldValidator2 runat="server" Font-Size="XX-Small" ErrorMessage="���i�ť�" ControlToValidate="tbxAltText" Display="Dynamic"></asp:RequiredFieldValidator></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>�s�i�d�� </FONT>
<asp:dropdownlist id=ddlAdCate runat="server" Font-Size="X-Small" AutoPostBack="True">
<asp:ListItem Value="M">����</asp:ListItem>
<asp:ListItem Value="I">����</asp:ListItem>
<asp:ListItem Value="N">�`��</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT size=2>�s�i��m 
<asp:dropdownlist id=ddlKey runat="server" Font-Size="X-Small">
<asp:ListItem Value="h0">����</asp:ListItem>
<asp:ListItem Value="h1">�k1</asp:ListItem>
<asp:ListItem Value="h2">�k2</asp:ListItem>
<asp:ListItem Value="h3">�k3</asp:ListItem>
<asp:ListItem Value="h4">�k4</asp:ListItem>
<asp:ListItem Value="w1">�k��1</asp:ListItem>
<asp:ListItem Value="w2">�k��2</asp:ListItem>
<asp:ListItem Value="w3">�k��3</asp:ListItem>
<asp:ListItem Value="w4">�k��4</asp:ListItem>
<asp:ListItem Value="w5">�k��5</asp:ListItem>
<asp:ListItem Value="w6">�k��6</asp:ListItem>
</asp:dropdownlist></FONT></TD>
    <TD colSpan=2 rowSpan=5><FONT size=2>
<asp:calendar id=calSelectAdDate runat="server" BorderColor="White" BorderWidth="1px" ForeColor="Black" BackColor="LemonChiffon" Font-Size="9pt" Font-Names="Verdana" NextPrevFormat="FullMonth" CellPadding="0">
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
      runat="server"></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>��Z���O</FONT><FONT size=3> </FONT>
<asp:dropdownlist id=ddlFgGot runat="server" Font-Size="X-Small">
<asp:ListItem Value="1" Selected="True">�O</asp:ListItem>
<asp:ListItem Value="0">�_</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT face=�s�ө��� size=2>����覡<FONT size=3> 
<asp:dropdownlist id=ddlFgFixAd runat="server" Font-Size="X-Small" AutoPostBack="True">
<asp:ListItem Value="0" Selected="True">����</asp:ListItem>
<asp:ListItem Value="1">�w��</asp:ListItem>
</asp:dropdownlist></FONT><FONT size=2>���v</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxImpression runat="server" Width="25px" Font-Size="X-Small" size="1" MaxLength="2">1</asp:textbox>
<asp:RequiredFieldValidator id=RequiredFieldValidator5 runat="server" Font-Size="XX-Small" ErrorMessage="���i�ť�" ControlToValidate="tbxImpression">*</asp:RequiredFieldValidator></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>�Z�����O</FONT></TD>
    <TD><FONT face=�s�ө���>
<asp:RadioButtonList id=rblDraftTp runat="server" Font-Size="X-Small" RepeatLayout="Flow" RepeatDirection="Horizontal">
<asp:ListItem Value="1" Selected="True">�½Z</asp:ListItem>
<asp:ListItem Value="2">�s�Z</asp:ListItem>
<asp:ListItem Value="3">��Z</asp:ListItem>
</asp:RadioButtonList><IMG onclick=doOpenCheck() alt="" src="edit.gif" 
      name=imgCheckImg></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT size=2>URL���O</FONT></TD>
    <TD>
<asp:RadioButtonList id=rblUrlTp runat="server" Font-Size="X-Small" RepeatLayout="Flow" RepeatDirection="Horizontal">
<asp:ListItem Value="1" Selected="True">�½Z</asp:ListItem>
<asp:ListItem Value="2">�s�Z</asp:ListItem>
<asp:ListItem Value="3">��Z</asp:ListItem>
</asp:RadioButtonList><IMG onclick=doOpenCheck() alt="" src="edit.gif" 
      name=imgCheckUrl></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT face=�s�ө��� size=2>�s�i���� 
<asp:textbox id=tbxAdAmt runat="server" Width="60px" Font-Size="X-Small" AutoPostBack="True">0</asp:textbox></FONT></TD>
    <TD><FONT face=�s�ө���><FONT size=2>�]�p���� </FONT>
<asp:textbox id=tbxDesAmt runat="server" Width="60px" Font-Size="X-Small" AutoPostBack="True">0</asp:textbox></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 172px"><FONT face=�s�ө��� size=2>���Z�O�� 
<asp:textbox id=tbxChgAmt runat="server" Width="60px" Font-Size="X-Small" AutoPostBack="True">0</asp:textbox></FONT></TD>
    <TD><FONT size=2>�o�����B</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxInvAmt runat="server" Width="60px" BackColor="#E0E0E0" Font-Size="X-Small" ReadOnly="True">0</asp:textbox></TD></TR>
  <TR>
    <TD colSpan=2><FONT face=�s�ө��� size=2>�Ƶ�</FONT> 
<asp:textbox id=tbxRemark runat="server" Font-Size="X-Small"></asp:textbox></TD></TR></TABLE></asp:panel><asp:label id=lblTitle runat="server" ForeColor="Red">00xx���s�i�Ѿl�Ŷ���</asp:label>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR vAlign=top>
    <TD><asp:datagrid id=DataGrid1 runat="server" BorderColor="Green" AutoGenerateColumns="False" BackColor="LightCyan" Font-Size="XX-Small" Font-Names="Verdana" CellPadding="2" AllowPaging="True" PageSize="15">
<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="SteelBlue">
</HeaderStyle>

<PagerStyle HorizontalAlign="Right" Mode="NumericPages">
</PagerStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="cnt_date" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h0" HeaderText="����">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h1" HeaderText="�k1">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h2" HeaderText="�k2">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h3" HeaderText="�k3">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_h4" HeaderText="�k4">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w1" HeaderText="�k��1">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w2" HeaderText="�k��2">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w3" HeaderText="�k��3">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w4" HeaderText="�k��4">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w5" HeaderText="�k��5">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cnt_w6" HeaderText="�k��6">
<HeaderStyle Width="30px">
</HeaderStyle>
</asp:BoundColumn>
</Columns>
</asp:datagrid></TD>
    <TD width=10><FONT face=�s�ө��� 
      ></FONT></TD>
    <TD><FONT face=�s�ө���>�̦��ѦҸ�Ƥ�� <asp:calendar id=calCntView runat="server" BorderColor="White" BorderWidth="1px" ForeColor="Black" BackColor="LemonChiffon" Font-Size="9pt" Font-Names="Verdana" NextPrevFormat="FullMonth" CellPadding="0">
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
</asp:calendar></FONT></TD></TR></TABLE><BR></FONT><asp:button id=btnSave runat="server" Text="�x�s"></asp:button><asp:button id=btnDoModify runat="server" Text="�x�s�ק�"></asp:button><FONT 
face=�s�ө���>&nbsp;&nbsp;&nbsp; <INPUT id=btnClose onclick='doClose(<% Response.Write("\""+Request.QueryString["Act"]+"\""); %>)' type=button value=�����Ψ��� name=btnClose> 
</FONT><FONT size=2></FONT><INPUT id=hidOldContNo 
type=hidden name=hidOldContNo runat="server"> 
<asp:Literal id=litAlert runat="server"></asp:Literal></FORM>
<SCRIPT language=javascript>
function doOpenAddIM(custno, new_contno, old_contno)
{

	/* ��Ӧbimg�̭���event onclick='doOpenAddIM(<% Response.Write(Request.QueryString["CustNo"]); %>, <% Response.Write(Request.QueryString["NewContNo"]); %>, <% Response.Write(Request.QueryString["OldContNo"]); %>)' */
	window.open("AddInvMfr.aspx?CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,width=800,height=600", false);
}

function doClose(myaction)
{

	if (myaction == "Mod")
	{
		window.opener.ContModify.submit();
	}
	else
	{
		window.opener.NewCont.submit();
	}
	window.close();
	
}

function doOpenCheck()
{
	var contno = document.AdPrePublish.hidOldContNo.value;
	
	if (contno == "" || contno == "undefined" || contno=="0")
	{
		alert("�L�¦X����ƥi�ѰѦ�");
	}
	else
	{
		window.showModalDialog("AdShowOldFile.aspx?ContNo="+contno, "", "dialogHeight:400px;dialogWidth:400px;center:yes;scroll:yes;status:no;help:no;resizable=yes");
	}
}
</SCRIPT>



	
  </body>
</HTML>
