<%@ Page language="c#" Codebehind="ContCheckList.aspx.cs" Src="ContCheckList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ContCheckList" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<script language=javascript>
		function pick_date(theField){
		var oParam = new Object();
		strFeature = "";
		strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
		var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
		if(vreturn)
			window.document.all(theField).value=vreturn;
		return true;
		}
		
		function doClose()
		{
			window.close();
		}
	</script>
    		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
<body bgColor=white>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>	
<form id=ContCheckList method=post runat="server"><FONT 
size=2><asp:panel id=pnlQuery 
Width="100%" Runat="server"><FONT face=�s�ө���>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD>
<asp:CheckBox id=cbxSignDate runat="server"></asp:CheckBox><FONT 
      size=2>ñ������d�ߡG</FONT> 
<asp:TextBox id=tbxFrom runat="server" Width="80px"></asp:TextBox><FONT 
      size=2><IMG class=ico title=��� onclick='pick_date("tbxFrom")' 
      src="../images/calendar01.gif">�� </FONT>
<asp:TextBox id=tbxTo runat="server" Width="80px"></asp:TextBox><FONT 
      size=2><IMG class=ico title=��� onclick='pick_date("tbxTo")' 
      src="../images/calendar01.gif"> </FONT></TD></TR>
  <TR>
    <TD>
<asp:CheckBox id=cbxContDate runat="server"></asp:CheckBox><FONT 
      size=2>�X���_���϶��F</FONT> 
<asp:TextBox id=tbxMinDate runat="server" Width="80px"></asp:TextBox><FONT 
      size=2><IMG class=ico title=��� onclick='pick_date("tbxMinDate")' 
      src="../images/calendar01.gif">�� </FONT>
<asp:TextBox id=tbxMaxDate runat="server" Width="80px"></asp:TextBox><FONT 
      size=2><IMG class=ico title=��� onclick='pick_date("tbxMaxDate")' 
      src="../images/calendar01.gif"> </FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 300px">
<asp:CheckBox id=cbxFgClosed runat="server"></asp:CheckBox><FONT 
      size=2>�w���סG</FONT> 
<asp:RadioButtonList id=rblFgClosed runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" Font-Size="X-Small">
<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
<asp:ListItem Value="1">�O</asp:ListItem>
</asp:RadioButtonList></TD></TR>
  <TR>
    <TD>
<asp:CheckBox id=cbxEmpNo runat="server"></asp:CheckBox><FONT 
      size=2>�ӿ�~�ȭ��G 
<asp:DropDownList id=ddlEmpNo runat="server"></asp:DropDownList></FONT></TD></TR>
  <TR>
    <TD>
<asp:CheckBox id=cbxContNo runat="server"></asp:CheckBox><FONT 
      size=2>�X���ѽs���G 
<asp:TextBox id=tbxContNo runat="server" Width="80px"></asp:TextBox></FONT></TD></TR>
  <TR>
    <TD>
<asp:CheckBox id=cbxMfrNm runat="server"></asp:CheckBox><FONT 
      size=2>�t�ӦW�١G 
<asp:TextBox id=tbxMfrNm runat="server" Width="80px"></asp:TextBox></FONT></TD></TR>
  <TR>
    <TD>
<asp:Button id=btnGo runat="server" Text="�d��"></asp:Button>
<asp:Button id=btnHome runat="server" Text="�^����"></asp:Button></TD></TR></TABLE></FONT></asp:panel><asp:datalist id=DataList1 runat="server" Width="100%" BackColor="#FFFFFF">
<ItemTemplate>
<FONT size=2>
<TABLE borderColor=#000000 cellSpacing=1 cellPadding=1 width="100%" bgColor=#e7ebff border=0>
<TR align=middle bgColor=#bfcff0>
<TD style="WIDTH: 59px; HEIGHT: 43px" width=59><FONT face=�s�ө��� color=white size=2>�X���ѽs��</FONT></TD>
<TD style="WIDTH: 150px; HEIGHT: 43px">
<P><FONT size=2><FONT face=�s�ө��� color=white>�t�ӦW��<BR>(�νs)</FONT></FONT></P></TD>
<TD style="WIDTH: 80px; HEIGHT: 43px"><FONT size=2><FONT face=�s�ө��� color=white>�Ȥ�W��<BR>(�s��)</FONT></FONT></TD>
<TD style="WIDTH: 73px; HEIGHT: 43px"><FONT size=2><FONT face=�s�ө��� color=white>ñ�����</FONT></FONT></TD>
<TD style="WIDTH: 36px; HEIGHT: 43px"><FONT size=2><FONT color=white size=2>�X��<BR>���O</FONT></FONT></TD>
<TD style="WIDTH: 102px; HEIGHT: 43px"><FONT color=white size=2>�X���_��</FONT></TD>
<TD style="WIDTH: 60px; HEIGHT: 43px"><FONT face=�s�ө��� color=white size=2>�ӿ�<BR>�~�ȭ�/<BR>�ק��</FONT></TD>
<TD style="WIDTH: 38px; HEIGHT: 43px"><FONT size=2><FONT face=�s�ө��� color=white>�@��<BR>�I��</FONT></FONT></TD>
<TD style="WIDTH: 39px; HEIGHT: 43px"><FONT face=�s�ө��� color=white size=2>����</FONT></TD>
<TD style="WIDTH: 109px; HEIGHT: 43px"><FONT color=white size=2>���ɤ��/<BR>�ק���</FONT></TD></TR>
<TR>
<TD style="WIDTH: 59px; HEIGHT: 74px"><FONT face=�s�ө��� size=2>
<asp:Label id=lblContNo runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_contno") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 122px; HEIGHT: 74px"><FONT size=2><FONT face=�s�ө���>
<asp:Label id=lblMfrNm runat="server" Text='<%# GetCustMfrField(GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_custno"), "mfr_inm") %>'></asp:Label>( 
<asp:Label id=lblMfrNo runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_mfrno") %>'></asp:Label>&nbsp;)</FONT></FONT></TD>
<TD style="WIDTH: 75px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblCustNm runat="server" Text='<%# GetCustMfrField(GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_custno"), "cust_nm") %>'></asp:Label><FONT face=�s�ө���><BR></FONT><FONT face=�s�ө���>( 
<asp:Label id=lblCustNo runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_custno") %>'></asp:Label>&nbsp;)</FONT></FONT></TD>
<TD style="WIDTH: 73px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblSignDate runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_signdate") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 36px; HEIGHT: 74px"><FONT size=2><FONT size=2>
<asp:Label id=lblComtTp runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_conttp") %>'></asp:Label></FONT></FONT></TD>
<TD style="WIDTH: 102px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblSDate runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_sdate") %>'></asp:Label><FONT face=�s�ө���>~ 
<asp:Label id=lblEDate runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_edate") %>'></asp:Label></FONT></FONT></TD>
<TD style="WIDTH: 60px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblEmpNm runat="server" Text='<%# GetSrspnField(GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_empno"), "srspn_cname") %>'></asp:Label><FONT face=�s�ө���>/<BR>
<asp:Label id=lblEmpNo runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_empno") %>'></asp:Label></FONT></FONT></TD>
<TD style="WIDTH: 38px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblFgPayOnce runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_fgpayonce") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 39px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblFgClosed runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_fgclosed") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 109px; HEIGHT: 74px"><FONT size=2>
<asp:Label id=lblCreDate runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_credate") %>'></asp:Label><FONT face=�s�ө���>/<BR>
<asp:Label id=lblModDate runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_moddate") %>'></asp:Label></FONT></FONT></TD></TR>
<TR>
<TD style="WIDTH: 59px"><FONT size=2><FONT face=�s�ө���></FONT></FONT></TD>
<TD style="WIDTH: 677px" colSpan=9>
<TABLE borderColor=#000000 cellSpacing=1 cellPadding=1 width=680 bgColor=#e7ebff border=0>
<TR align=middle bgColor=#bfcff0>
<TD style="WIDTH: 70px"><FONT size=2><FONT face=�s�ө��� color=white>�Z�n����</FONT></FONT></TD>
<TD style="WIDTH: 73px"><FONT color=white size=2>�ذe����</FONT></TD>
<TD style="WIDTH: 110px"><FONT color=white size=2>�`�s�Z��</FONT></TD>
<TD style="WIDTH: 87px"><FONT color=white size=2>�p���H�m�W</FONT></TD>
<TD style="WIDTH: 73px"><FONT color=white size=2>�q��</FONT></TD>
<TD style="WIDTH: 76px"><FONT color=white size=2>�ǯu</FONT></TD>
<TD style="WIDTH: 63px"><FONT color=white size=2>���</FONT></TD>
<TD><FONT size=2><FONT color=white size=2>Email</FONT></FONT></TD></TR>
<TR>
<TD style="WIDTH: 70px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblPubTm runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_pubtm") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 73px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblFreeTm runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_freetm") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 110px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblTotTm runat="server" Text='<%# "��:"+GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_totimgtm")+"/����:"+GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_toturltm") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 87px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuNm runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_aunm") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 73px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuTel runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_aucell") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 76px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuFax runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_aufax") %>'></asp:Label></FONT></TD>
<TD style="WIDTH: 63px; HEIGHT: 22px"><FONT size=2>
<asp:Label id=lblAuCell runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_aucell") %>'></asp:Label></FONT></TD>
<TD style="HEIGHT: 22px"><FONT size=2><FONT size=2><FONT face=�s�ө���>
<asp:Label id=lblAuEmail runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_auemail") %>'></asp:Label></FONT></FONT></FONT></TD></TR>
<TR align=middle bgColor=#bfcff0>
<TD style="WIDTH: 70px"><FONT face=�s�ө��� color=white size=2>�X�����B</FONT></TD>
<TD style="WIDTH: 73px"><FONT color=white size=2>�wú���B</FONT></TD>
<TD style="WIDTH: 69px"><FONT color=white size=2>�Ѿl���B</FONT></TD>
<TD style="WIDTH: 87px"><FONT color=#000000 size=2></FONT></TD>
<TD style="WIDTH: 73px"><FONT color=#000000 size=2></FONT></TD>
<TD style="WIDTH: 76px"><FONT color=#000000 size=2></FONT></TD>
<TD style="WIDTH: 63px"><FONT color=#000000 size=2></FONT></TD>
<TD><FONT size=2><FONT color=white size=2>�Ƶ�</FONT></FONT></TD></TR>
<TR>
<TD style="WIDTH: 70px"><FONT size=2><FONT size=2><FONT face=�s�ө���>
<asp:Label id=lblTotAmt runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_totamt") %>'></asp:Label></FONT></FONT></FONT></TD>
<TD style="WIDTH: 73px"><FONT size=2><FONT size=2>
<asp:Label id=lblPaidAmt runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_paidamt") %>'></asp:Label></FONT></FONT></TD>
<TD style="WIDTH: 69px"><FONT size=2><FONT size=2>
<asp:Label id=lblResAmt runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_totamt") %>'></asp:Label></FONT></FONT></TD>
<TD style="WIDTH: 87px"><FONT size=2><FONT size=2></FONT></FONT></TD>
<TD style="WIDTH: 73px"><FONT size=2></FONT></TD>
<TD style="WIDTH: 76px"><FONT size=2></FONT></TD>
<TD style="WIDTH: 63px"><FONT size=2></FONT></TD>
<TD><FONT size=2><FONT size=2><FONT size=2>
<asp:Label id=lblAdRemark runat="server" Text='<%# GetContField(DataBinder.Eval(Container.DataItem, "cont_contno"), "cont_adremark") %>'></asp:Label></FONT></FONT></FONT></TD></TR></TABLE><FONT size=2></FONT><FONT size=2><FONT face=�s�ө���></FONT></FONT><FONT size=2></FONT><FONT size=2><FONT size=2></FONT></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT></TD></TR>
<TR>
<TD style="WIDTH: 59px"><FONT size=2></FONT></TD>
<TD style="WIDTH: 122px" colSpan=9><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2><FONT size=2></FONT></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2><FONT face=�s�ө���>�o���t�Ӧ���H</FONT> 
<asp:DataGrid id=dgdInvMfr runat="server" Width="720px" BackColor="#E7EBFF" AutoGenerateColumns="False" Font-Size="X-Small">
<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="�o�����O">
<ItemTemplate>
<asp:Label id="lblInvNm" runat="server" Font-Size="X-Small" Text='<%# GetInvNm(DataBinder.Eval(Container.DataItem, "im_invcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="�o���ҵ|�O">
<ItemTemplate>
<asp:Label id="lblTaxNm" runat="server" Font-Size="X-Small" Text='<%# GetTaxNm(DataBinder.Eval(Container.DataItem, "im_taxtp")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></TD></TR>
<TR>
<TD style="WIDTH: 59px"><FONT size=2></FONT></TD>
<TD style="WIDTH: 122px" colSpan=9><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2><FONT size=2><FONT face=�s�ө���></FONT></FONT></FONT><FONT size=2><FONT face=�s�ө���></FONT></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2></FONT><FONT size=2><FONT face=�s�ө���>�خѸ��</FONT> 
<asp:DataGrid id=dgdFreeBk runat="server" Width="720px" BackColor="#e7ebff" AutoGenerateColumns="False" Font-Size="X-Small">
<HeaderStyle ForeColor="Black" BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="���y���O">
<ItemTemplate>
<asp:Label id="lblBkNm" runat="server" Font-Size="X-Small" Text='<%# GetBkNm(DataBinder.Eval(Container.DataItem, "fbk_bkcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="�l�H���O">
<ItemTemplate>
<asp:Label id=lblMtpNm runat="server" Font-Size="X-Small" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
</asp:DataGrid></FONT></TD></TR>
<TR>
<TD style="WIDTH: 59px"></TD>
<TD style="WIDTH: 122px" colSpan=9><FONT face=�s�ө��� size=2>�����s�i���<BR>
<asp:DataGrid id=dgdAdr runat="server" Width="720px" BackColor="LightCyan" AutoGenerateColumns="False" Font-Size="X-Small">
<HeaderStyle ForeColor="White" BackColor="CornflowerBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="adr_seq" HeaderText="�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="���X�_��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="���X����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="���v"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="�s�i�s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_fgfixad" HeaderText="���X�覡"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_adamt" HeaderText="�s�i����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_desamt" HeaderText="�]�p����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_chgamt" HeaderText="���Z�O��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_invamt" HeaderText="�o�����B"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_drafttp" HeaderText="�ϽZ�s�k"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_urltp" HeaderText="�����Z�s�k"></asp:BoundColumn>
</Columns>
</asp:DataGrid></FONT></TD></TR></TABLE></FONT>
</ItemTemplate>

<SeparatorTemplate>
<HR width="100%" color=coral SIZE=1>
</SeparatorTemplate>
</asp:datalist></form></FONT>
				<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>	
  </body>
</HTML>
