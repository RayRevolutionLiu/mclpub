<%@ Page language="c#" Codebehind="AddFreeBk.aspx.cs" Src="AddFreeBk.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.AddFreeBk" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body vLink=blue aLink=blue>
<form id=AddFreeBk method=post runat="server"><FONT 
face=�s�ө���></FONT><FONT face=�s�ө���><asp:panel id=Panel1 
runat="server"><FONT color=#ff4500 size=2>[���v�X�����x����H���]<BR></FONT>
<asp:datagrid id=dgdOldOr runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<SelectedItemStyle BackColor="YellowGreen">
</SelectedItemStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="or_orid" HeaderText="id"></asp:BoundColumn>
<asp:ButtonColumn Text="���J" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="��~">
<ItemTemplate>
<asp:Label id=lblOldOrfgMoSea runat="server" Font-Size="X-Small" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="or_fgmosea" HeaderText="��~"></asp:BoundColumn>
</Columns>
</asp:datagrid><BR>
<TABLE style="WIDTH: 627px; HEIGHT: 79px" cellSpacing=1 cellPadding=1 
width="100%" bgColor=#bfcff0 border=1>
  <TR bgColor=#214389>
    <TD style="WIDTH: 64px"><FONT color=white size=2>�Ǹ�</FONT></TD>
    <TD style="WIDTH: 64px"><FONT color=#ffffff size=2>�m�W </FONT></TD>
    <TD style="WIDTH: 36px"><FONT color=#ffffff size=2>�ٿ� </FONT></TD>
    <TD style="WIDTH: 36px"><FONT color=#ffffff size=2>�l��<BR>�ϸ�</FONT></TD>
    <TD style="WIDTH: 168px"><FONT color=#ffffff size=2>�a�} </FONT></TD>
    <TD style="WIDTH: 54px"><FONT color=#ffffff size=2>�q��</FONT></TD>
    <TD style="WIDTH: 43px"><FONT color=#ffffff size=2>�ǯu</FONT></TD>
    <TD style="WIDTH: 44px"><FONT color=#ffffff size=2>���</FONT></TD>
    <TD style="WIDTH: 86px"><FONT color=#ffffff size=2>Email</FONT></TD>
    <TD><FONT color=#ffffff size=2>�ꤺ�~<BR>���O</FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 64px">
<asp:textbox id=tbxOrSeq runat="server" Font-Size="XX-Small" BackColor="#E0E0E0" Width="30px" Height="24px" ReadOnly="True"></asp:textbox></TD>
    <TD style="WIDTH: 64px">
<asp:textbox id=tbxOrNm runat="server" Font-Size="XX-Small" Width="63px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 36px">
<asp:textbox id=tbxOrJbti runat="server" Font-Size="XX-Small" Width="41px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 36px">
<asp:textbox id=tbxOrZip runat="server" Font-Size="XX-Small" Width="35px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 168px">
<asp:textbox id=tbxOrAddr runat="server" Font-Size="XX-Small" Width="178px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 54px">
<asp:textbox id=tbxOrTel runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 43px">
<asp:textbox id=tbxOrFax runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 44px">
<asp:textbox id=tbxOrCell runat="server" Font-Size="XX-Small" Width="65px" Height="24px"></asp:textbox></TD>
    <TD style="WIDTH: 86px">
<asp:textbox id=tbxOrEmail runat="server" Font-Size="XX-Small" Width="115px" Height="24px"></asp:textbox></TD>
    <TD>
<asp:dropdownlist id=ddlOrMoSea runat="server" Font-Size="XX-Small">
<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
<asp:ListItem Value="1">��~</asp:ListItem>
</asp:dropdownlist></TD></TR></TABLE>
<asp:button id=btnAddOr runat="server" CausesValidation="False" Text="�s�W����H���"></asp:button>
<asp:Button id=btnUpdateOr runat="server" CausesValidation="False" Text="�ק怜��H���"></asp:Button><BR>
<asp:Label id=lblOrMsg runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
<asp:datagrid id=dgdNewOr runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="or_orid" HeaderText="id"></asp:BoundColumn>
<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="��~">
<ItemTemplate>
<asp:Label id="Label1" runat="server" Font-Size="X-Small" Text='<%# GetYNCh(DataBinder.Eval(Container.DataItem, "or_fgmosea")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="or_fgmosea" HeaderText="��~"></asp:BoundColumn>
</Columns>
</asp:datagrid></asp:panel><hr width="100%" color="orange" SIZE=1><asp:panel id=Panel2 
runat="server"><FONT color=#ff4500 
size=2>[�خѰѦҸ��]<BR></FONT>
<asp:datagrid id=dgdOldFreeBk runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="fbk_fbkid" HeaderText="id"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fc_nm" HeaderText="���y"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="�l�H���O">
<ItemTemplate>
<asp:Label id="lblOldMtpNm" runat="server" Font-Size="X-Small" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
</asp:datagrid><BR>
<TABLE style="WIDTH: 700px; HEIGHT: 72px" cellSpacing=1 cellPadding=1 
width="100%" bgColor=#bfcff0 border=1>
  <TR bgColor=#214389>
    <TD style="WIDTH: 73px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>�خѰ_��<BR><FONT color=red>(yyyy/MM)</FONT> </FONT></TD>
    <TD style="WIDTH: 73px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>�خѨ���<BR><FONT color=red>(yyyy/MM)</FONT> </FONT></TD>
    <TD style="WIDTH: 71px; HEIGHT: 28px"><FONT color=#ffffff 
    size=2>���y</FONT></TD>
    <TD style="WIDTH: 106px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>�l�H���O</FONT></TD>
    <TD style="WIDTH: 73px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>�Z�n���<BR>���� </FONT></TD>
    <TD style="WIDTH: 86px; HEIGHT: 28px"><FONT color=#ffffff 
      size=2>���Z�n���<BR>���� </FONT></TD>
    <TD style="HEIGHT: 28px"><FONT color=#ffffff size=2>����H</FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 73px">
<asp:textbox id=tbxFbkSdate runat="server" Font-Size="XX-Small" BackColor="White" Width="63px" Height="24px"></asp:textbox>
<asp:RequiredFieldValidator id=rfvSDate runat="server" Font-Size="XX-Small" ControlToValidate="tbxFbkSdate" Display="Dynamic" ErrorMessage="���i�ť�"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revSDate runat="server" Font-Size="XX-Small" ControlToValidate="tbxFbkSdate" Display="Dynamic" ErrorMessage="�榡���~" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></TD>
    <TD style="WIDTH: 73px">
<asp:textbox id=tbxFbkEdate runat="server" Font-Size="XX-Small" BackColor="White" Width="63px" Height="24px"></asp:textbox>
<asp:RequiredFieldValidator id=rfcEDate runat="server" Font-Size="XX-Small" ControlToValidate="tbxFbkEdate" Display="Dynamic" ErrorMessage="���i�ť�"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=RegularExpressionValidator1 runat="server" Font-Size="XX-Small" ControlToValidate="tbxFbkEdate" Display="Dynamic" ErrorMessage="�榡���~" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></TD>
    <TD style="WIDTH: 71px">
<asp:dropdownlist id=ddlFbkBkCd runat="server" Font-Size="XX-Small">
<asp:ListItem Value="01" Selected="True">�u��</asp:ListItem>
<asp:ListItem Value="02">�q��</asp:ListItem>
</asp:dropdownlist></TD>
    <TD style="WIDTH: 106px">
<asp:DropDownList id=ddlMtpCd runat="server" Font-Size="XX-Small"></asp:DropDownList></TD>
    <TD style="WIDTH: 73px">
<asp:TextBox id=tbxPubMnt runat="server" Font-Size="XX-Small" Width="63px" Height="24px"></asp:TextBox></TD>
    <TD style="WIDTH: 86px">
<asp:TextBox id=tbxUnPubMnt runat="server" Font-Size="XX-Small" Width="63px" Height="24px"></asp:TextBox></TD>
    <TD>
<asp:DropDownList id=ddlOrSeq runat="server" Font-Size="XX-Small"></asp:DropDownList></TD></TR></TABLE><FONT 
face=�s�ө���>
<asp:button id=btnAdd runat="server" Text="�s�W�خѸ��"></asp:button>
<asp:Button id=btnUpdateFreeBk runat="server" CausesValidation="False" Text="�ק��خѸ��"></asp:Button><BR>
<asp:Label id=lblFreeBkMsg runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>
<asp:DataGrid id=dgdNewFreeBk runat="server" Font-Size="X-Small" BackColor="#BFCFF0" AutoGenerateColumns="False">
<HeaderStyle ForeColor="White" BackColor="#214389">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="fbk_fbkid" HeaderText="fbkid"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ma_raid" HeaderText="raid"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="fc_fccd" HeaderText="bkcd"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ma_mtpcd" HeaderText="mtpcd"></asp:BoundColumn>
<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fc_nm" HeaderText="���y"></asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="�l�H���O">
<ItemTemplate>
<asp:Label id=lblMtpNm runat="server" Font-Size="X-Small" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></asp:panel><BR>
<INPUT type=button value=���� name=btnClose onclick='doClose(<% Response.Write("\""+Request.QueryString["Act"]+"\""); %>)'>
<asp:Literal id=litAlert runat="server"></asp:Literal></FONT></form>
<script language=javascript>
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
</script>
<script language=javascript>
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField)
		{
			// ñ�����
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			
			var vreturn1YYYY = vreturn.substring(0, 4);
			var vreturn1MM = vreturn.substring(5, 7);
			vreturn1MM = parseInt(vreturn1MM) + 1;
			if(vreturn1MM < 10)
				vreturn1MM = "0" + vreturn1MM;
			else
				vreturn1MM = vreturn1MM;
			var vreturn1 = vreturn1YYYY + "/" + vreturn1MM;	
					
			window.document.all(theField).value=vreturn1;
			return true;
		}
		//-->
		</script>








	
  </body>
</HTML>
