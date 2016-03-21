<%@ Page language="c#" Codebehind="PubFm_chklist.aspx.cs" Src="PubFm_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm_chklist" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�����ˮ֪�</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
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
	</HEAD>
	<body>
		<center>
			<!-- ���Y: �D�\���� -->
			<kw:Header runat="server" />
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�����ˮ֪�</font>
					</td>
				</tr>
			</table>
		</center>
		<!-- Run at Server Form-->
		<form id="PubFm_chklist" method="post" runat="server">
			<asp:checkbox id="cbx0" runat="server"></asp:checkbox><asp:label id="lblQuery" runat="server">�����~��϶��G</asp:label>
			<asp:textbox id="tbxDate1" runat="server" Width="50px" MaxLength="7"></asp:textbox>
			��
			<asp:textbox id="tbxDate2" runat="server" Width="50px" MaxLength="7"></asp:textbox>
			&nbsp;
			<asp:Label id="lblSEDateMemo" runat="server" Font-Size="X-Small" ForeColor="Maroon">(�p 2002/07  �� 2002/07)</asp:Label>
			<br>
			<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
			<asp:Label id="lblContNo" runat="server">�X���ѽs���G</asp:Label>
			<asp:TextBox id="tbxContNo" runat="server" MaxLength="6" Width="50px" Font-Size="X-Small"></asp:TextBox>
			<br>
			<asp:CheckBox id="cbx5" runat="server"></asp:CheckBox>
			<asp:Label id="lblMfrIName" runat="server">�t�ӦW�١G</asp:Label>
			<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small" MaxLength="50"></asp:TextBox>
			<br>
			<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>
			&nbsp;
			<asp:Button id="btnClear" runat="server" Text="�M�����d"></asp:Button>
			&nbsp;
			<asp:button id="btnBack" runat="server" Text="��^����"></asp:button>
			&nbsp; <INPUT id="btnClose" onclick="doClose()" type="button" value="��������" name="btnClose">
			<br>
			&nbsp;<font color="red" size="2"><b>�Ы��U '�d��' ���s���ˬd���!</b></font>
			<br>
			<asp:label id="lblRecordCount" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="�s�ө���">
				<ItemStyle BorderColor="Black"></ItemStyle>
				<ItemTemplate>
					<TABLE width="100%" border="1" bgColor="#e6ebf9" borderColor="#000000" cellSpacing="1" cellPadding="0" align="center" style="FONT-SIZE: x-small">
						<!-- ���D -->
						<!-- �X���s�� & �������� -->
						<TR style="COLOR: white" bgColor="#21418c" align="center" valign="top">
							<TD>
								�X����
								<BR>
								�s��
							</TD>
							<TD style="LETTER-SPACING: 10px" valign="middle">
								�X����/����/�o���t�Ӧ���H���
							</TD>
						</TR>
						<TR vAlign="top">
							<TD bgColor="#e6ebf9" width="7%" style="FONT-WEIGHT: bold">
								&nbsp;
								<asp:Label id="lblContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_contno").ToString().Trim() %>'>
								</asp:Label>
							</TD>
							<TD width="*" style="COLOR: #ffffff" bgColor="#5980d9">
								&nbsp;�X���Ѹ�ơG
							</TD>
						</TR>
						<TR vAlign="top">
							<TD Rowspan="5">
								&nbsp;
							</TD>
							<TD>
								<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff" BorderColor="#000000"></ItemStyle>
									<Columns>
										<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
										<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�W��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="�@���I��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_totjtm" HeaderText="�`�s�Z"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_tottm" HeaderText="�`�Z�n"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_chgjtm" HeaderText="���Z����"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_freetm" HeaderText="�ذe����"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_clrtm" HeaderText="�m��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_getclrtm" HeaderText="�M��"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_menotm" HeaderText="�¥�"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_totamt" HeaderText="�`���B"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_adamt" HeaderText="�s�i�O���"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_aunm" HeaderText="�p���H�m�W"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_autel" HeaderText="�s���q��"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
						<!-- �X���Ѹ�� -->
						<!-- �����Ӹ` -->
						<TR style="COLOR: #ffffff" bgColor="#5980d9">
							<TD>
								&nbsp;�����Ӹ`�G
								<BR>
							</TD>
						</TR>
						<TR>
							<TD>
								<asp:DataList id="DataList2" runat="server" border="1">
									<ItemStyle BorderColor="#00000" BorderWidth="1px"></ItemStyle>
									<ItemTemplate>
										<TR style="COLOR: #000000" bgColor="#BFCFF0">
											<TD>
												�Z�n�~��
											</TD>
											<TD>
												�����Ǹ�
											</TD>
											<TD>
												�s�i����
											</TD>
											<TD>
												�s�i��m
											</TD>
											<TD>
												�s�i�g�T
											</TD>
											<TD>
												�T�w����
											</TD>
											<TD>
												�o�t
												<BR>
												�Ǹ�
											</TD>
											<TD>
												�o�t
												<BR>
												�m�W
											</TD>
											<TD>
												�ק�~�ȭ�
											</TD>
											<TD>
												�ק���
											</TD>
											<TD>
												&nbsp;
											</TD>
										</TR>
										<!-- ��X���e2 -->
										<TR vAlign="top">
											<TD width="10%" style="FONT-WEIGHT: bold">
												<asp:Label id="lblYYYYMM" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_yyyymm").ToString() %>'>
												</asp:Label>
											</TD>
											<TD width="10%" style="FONT-WEIGHT: bold">
												<asp:Label id="lblPubSeq" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_pubseq").ToString() %>'>
												</asp:Label>
											</TD>
											<TD width="10%">
												<asp:Label id="lblLtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ltp_nm").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="10%">
												<asp:Label id="lblClrcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clr_nm").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="12%">
												<asp:Label id="lblPgscd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pgs_nm").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="5%">
												<asp:Label id="lblfgFixPg" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fgfixpg").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="8%">
												<asp:Label id="lblIMSeq" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_imseq").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="8%">
												<asp:Label id="lblIMName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "im_nm").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="11%">
												<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "srspn_cname").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="10%">
												<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_moddate").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD width="*">
												&nbsp;
											</TD>
										</TR>
										<TR style="COLOR: #000000" bgColor="#BFCFF0">
											<TD bgColor="#e6ebf9">
												&nbsp;
											</TD>
											<TD>
												�s�i���B
											</TD>
											<TD>
												���Z���B
											</TD>
											<TD>
												�w�}��
												<BR>
												�o����
											</TD>
											<TD>
												�o���}�߳�
												<BR>
												�H�u�B�z
											</TD>
											<TD>
												�p���N��
											</TD>
											<TD>
												��������
											</TD>
											<TD colSpan="4">
												�Ƶ�
											</TD>
										</TR>
										<TR vAlign="top">
											<TD>
												&nbsp;
											</TD>
											<TD>
												$
												<asp:Label id="lblAdamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_adamt").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												$
												<asp:Label id="lblChgAmt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgamt").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblfgInved" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fginved").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblfgInvSelf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fginvself").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblProjNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_projno").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblCostCtr" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_costctr").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD colSpan="4">
												<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_remark").ToString().Trim() %>'>
												</asp:Label>
											</TD>
										</TR>
										<TR style="COLOR: #000000" bgColor="#BFCFF0">
											<TD bgColor="#e6ebf9">
												&nbsp;
											</TD>
											<TD>
												�Z�����O
											</TD>
											<TD>
												��Z
											</TD>
											<TD>
												�s�Z�s�k
											</TD>
											<TD>
												��Z����
											</TD>
											<TD>
												��Z���O
											</TD>
											<TD>
												��Z���X
											</TD>
											<TD>
												��Z���X��
											</TD>
											<TD>
												�½Z����
											</TD>
											<TD>
												�½Z���O
											</TD>
											<TD>
												�½Z���X
											</TD>
										</TR>
										<TR vAlign="top">
											<TD>
												&nbsp;
											</TD>
											<TD>
												<asp:Label id="lblDrafttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_drafttp").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblfgGot" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fggot").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblfgNjtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "njtp_nm").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblChgbkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgbkcd").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblChgJNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgjno").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblChgJbkno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgjbkno").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblfgReChg" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fgrechg").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblOrigBkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bk_nm").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblOrigJNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_origjno").ToString().Trim() %>'>
												</asp:Label>
											</TD>
											<TD>
												<asp:Label id="lblOrigJbkno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_origjbkno").ToString().Trim() %>'>
												</asp:Label>
											</TD>
										</TR>
									</ItemTemplate>
								</asp:DataList>
							</TD>
						</TR>
						<!-- �o���t�Ӧ���H -->
						<TR style="COLOR: #ffffff" bgColor="#5980d9">
							<TD>
								&nbsp;�o���t�Ӧ���H�G
								<BR>
							</TD>
						</TR>
						<TR>
							<TD>
								<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff" BorderColor="#000000"></ItemStyle>
									<Columns>
										<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_addr" HeaderText="�o���a�}"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<SeparatorTemplate>
					<font color='DarkRed'><B>�������B�����n�ȭn�`�N�~�A�]�нT�{���p���N�����Ρ��������ߡ����ȡI</B></font>
					<HR id="hr" width="100%" SIZE="2" color="#AAAAAA">
					<br>
				</SeparatorTemplate>
			</asp:datalist></form>
			<!-- ���: ���v�� -->
			<kw:Footer runat="server" />	
	</body>
</HTML>
