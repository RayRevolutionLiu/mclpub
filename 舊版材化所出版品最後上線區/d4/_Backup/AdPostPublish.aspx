<%@ Page language="c#" Codebehind="AdPostPublish.aspx.cs" Src="AdPostPublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AdPostPublish" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    	<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body vLink=blue aLink=blue>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
	
    <form id="AdPostPublish" method="post" runat="server" enctype="multipart/form-data">
<FONT 
face=�s�ө���></FONT><FONT face=�s�ө���>
<asp:label id=lblStep0 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">�D��X�����n�������s�i</asp:label><BR>
<asp:DataGrid id=dgdAdrIm runat="server" BackColor="#E7EBFF" Font-Size="X-Small" Font-Names="Times New Roman" AutoGenerateColumns="False" CellPadding="1">
<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<SelectedItemStyle BackColor="DarkSeaGreen">
</SelectedItemStyle>

<Columns>
<asp:ButtonColumn Text="���" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="���X�_��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="���X����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="���X���v"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="���X�覡">
<ItemTemplate>
<FONT face=�s�ө���>
<asp:Label id=lblFgFixAdNm runat="server" Font-Size="X-Small" Text='<%# GetFgFixAdNm(DataBinder.Eval(Container.DataItem, "adr_fgfixad")) %>'></asp:Label></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="�o���t��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" HeaderText="�o�����B"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="�w����">
<ItemTemplate>
<FONT face=�s�ө���>
<asp:Label id=lblFgGotNm runat="server" Text='<%# GetFgGotNm(DataBinder.Eval(Container.DataItem, "adr_fggot")) %>'></asp:Label></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="adr_adamt" HeaderText="�s�i����"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_desamt" HeaderText="�]�p����"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_chgamt" HeaderText="���Z�O��"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_navurl" HeaderText="�s�i�s��"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_remark" HeaderText="�Ƶ�"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_imseq" HeaderText="adr_imseq"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_fgfixad" HeaderText="adr_fgfixad"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_fggot" HeaderText="adr_fggot"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_drafttp" HeaderText="adr_drafttp"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_urltp" HeaderText="adr_urltp"></asp:BoundColumn>
</Columns>
</asp:DataGrid><BR></FONT><asp:label id=lblStep1 runat="server" Font-Size="X-Small" BackColor="SteelBlue" Width="100%" ForeColor="White">�ѦҰ򥻸��</asp:label>
<TABLE cellSpacing=0 cellPadding=1 width="100%" border=0 bgColor=lightcyan>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�X���s��</FONT> <asp:textbox id=tbxContNo runat="server" Font-Size="XX-Small" BackColor="Silver" size="6" ReadOnly="True"></asp:textbox></TD>
    <TD><FONT size=2>�o���t�� 
<asp:dropdownlist id=ddlInvMfr runat="server" Enabled="False" Font-Size="X-Small"></asp:dropdownlist></FONT></TD>
    <TD colspan=2><FONT size=2>�s�i�s��</FONT> 
<asp:textbox id=tbxNavUrl runat="server" Font-Size="X-Small">http://</asp:textbox>
<asp:requiredfieldvalidator id=RequiredFieldValidator2 runat="server" Font-Size="XX-Small" ControlToValidate="tbxNavUrl" ErrorMessage="���i�ť�"></asp:requiredfieldvalidator></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�s�i���� </FONT>
<asp:textbox id=tbxAdAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></TD>
    <TD><FONT size=2>�o�����B<FONT size=3> 
      </FONT>
<asp:textbox id=tbxInvAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></FONT></TD>
    <TD colspan=2><FONT face=�s�ө���><FONT 
      size=2>�s�i�лy</FONT><FONT size=3> </FONT>
<asp:textbox id=tbxAltText runat="server" Font-Size="X-Small"></asp:textbox>
<asp:requiredfieldvalidator id=RequiredFieldValidator1 runat="server" Font-Size="XX-Small" ControlToValidate="tbxAltText" ErrorMessage="���i�ť�"></asp:requiredfieldvalidator></FONT></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�]�p���� </FONT>
<asp:textbox id=tbxDesAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></TD>
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
    <TD colspan=2 rowspan=5><FONT size=2><FONT face=�s�ө���>�d�߫Ȥ��¼s�i���</FONT><IMG onclick="doOpenCheck()" alt="" src="edit.gif" 
  name=imgCheckUrl></FONT></TD>
    </TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>���Z�O�� </FONT>
<asp:textbox id=tbxChgAmt runat="server" Width="60px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></TD>
    <TD><FONT face=�s�ө��� size=2>�}�l��� 
<asp:textbox id=tbxBeginDate runat="server" Width="70px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT 
      size=2>��Z���O</FONT><FONT size=3> </FONT>
<asp:dropdownlist id=ddlFgGot runat="server" Font-Size="X-Small" Enabled="False">
<asp:ListItem Value="1" Selected="True">�O</asp:ListItem>
<asp:ListItem Value="0">�_</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT face=�s�ө���><FONT 
      size=2>������� </FONT>
<asp:textbox id=tbxEndDate runat="server" Width="70px" Font-Size="X-Small" ReadOnly="True" BackColor="Silver"></asp:textbox></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT size=2>�s�i�d�� </FONT>
<asp:dropdownlist id=ddlAdCate runat="server" Font-Size="X-Small" AutoPostBack="True" Enabled="False">
<asp:ListItem Value="M">����</asp:ListItem>
<asp:ListItem Value="I">����</asp:ListItem>
<asp:ListItem Value="N">�`��</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><FONT size=2>����覡</FONT> 
<asp:dropdownlist id=ddlFgFixAd runat="server" Font-Size="X-Small" Enabled="False">
<asp:ListItem Value="0" Selected="True">����</asp:ListItem>
<asp:ListItem Value="1">�w��</asp:ListItem>
</asp:dropdownlist><FONT size=2>���v</FONT> 
<asp:textbox id=tbxImpression runat="server" Font-Size="X-Small" size="1" ReadOnly="True" BackColor="Silver"></asp:textbox></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT face=�s�ө��� size=2>�Z�����O</FONT></TD>
    <TD><FONT face=�s�ө���>
<asp:RadioButtonList id=rblDraftTp runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow">
<asp:ListItem Value="1" Selected="True">�½Z</asp:ListItem>
<asp:ListItem Value="2">�s�Z</asp:ListItem>
<asp:ListItem Value="3">��Z</asp:ListItem>
</asp:RadioButtonList></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 147px"><FONT face=�s�ө��� size=2>URL���O</FONT></TD>
    <TD>
<asp:RadioButtonList id=rblUrlTp runat="server" Font-Size="X-Small" RepeatDirection="Horizontal" RepeatLayout="Flow">
<asp:ListItem Value="1" Selected="True">�½Z</asp:ListItem>
<asp:ListItem Value="2">�s�Z</asp:ListItem>
<asp:ListItem Value="3">��Z</asp:ListItem>
</asp:RadioButtonList></TD></TR>
  <TR>
    <TD colSpan=2><FONT face=�s�ө��� 
      size=2>�Ƶ�</FONT>
<asp:textbox id=tbxRemark runat="server" Font-Size="X-Small"></asp:textbox></TD>
    </TR></TABLE><FONT 
size=2><FONT 
color=red><FONT size=2></FONT></FONT></FONT><FONT 
size=2>
<asp:label id=lblStep2 runat="server" ForeColor="White" Width="100%" BackColor="SteelBlue" Font-Size="X-Small">�W�ǹ���</asp:label><BR>
<input type=file runat=server id=fileAdImage NAME="fileAdImage"><BR></FONT><FONT 
size=2 color=#ff0000>�Х��T�w�C�Ӹ�Ƴ���g�L�~<BR></FONT> 
<asp:button id=btnSave runat="server" Text="�x�s����"></asp:button><input type=hidden id=hidOldContNo name=hidOldContNo runat=server>
<INPUT id=hidDateTarget type=hidden name=hidDataTarget 
      runat="server"> 
<INPUT id=hidCustNo type=hidden 
name=hidCustNo runat="server">
     </form>
	<!-- ���� Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>
<script language=javascript>
function doOpenCheck()
{
	var custno = document.AdPostPublish.hidCustNo.value;
	
	if (custno == "" || custno == "undefined" || custno == "0")
	{
		alert("�L�ӫȤ��¦X����ƥi�ѰѦ�");
	}
	else
	{
		window.open("AdQueryOldData.aspx?CustNo="+custno, "", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
	}
}
</script>
	
  </body>
</HTML>
