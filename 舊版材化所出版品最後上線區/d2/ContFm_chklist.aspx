<%@ Page language="c#" Codebehind="ContFm_chklist.aspx.cs" src="ContFm_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_chklist" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�X�����ˮ֪�</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
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
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�X�����ˮ֪�</font>
					</td>
				</tr>
			</table>
		</center>
		<!-- Run at Server Form-->
		<form id="ContFm_chklist" method="post" runat="server">
			<asp:CheckBox id="cbx0" runat="server"></asp:CheckBox>
			<asp:label id="lblSignDate" runat="server">ñ������϶��G</asp:label>
			<asp:textbox id="tbxSignDate1" runat="server" MaxLength="10" Width="70px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxSignDate1.name)" src="../images/calendar01.gif">
			��
			<asp:textbox id="tbxSignDate2" runat="server" MaxLength="10" Width="70px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxSignDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
			<asp:Label id="lblSEDate" runat="server">�X���_���϶��G</asp:Label>
			<asp:TextBox id="tbxSDate" runat="server" Width="50px"></asp:TextBox>
			��
			<asp:TextBox id="tbxEDate" runat="server" Width="50px"></asp:TextBox>
			&nbsp;
			<asp:Label id="lblSEDateMemo" runat="server" Font-Size="X-Small" ForeColor="Maroon">(�p 200206  �� 200212)</asp:Label>
			<br>
			<asp:CheckBox id="cbx2" runat="server"></asp:CheckBox>
			<asp:Label id="lblfgclosed" runat="server">�w���סG</asp:Label>
			<asp:DropDownList id="ddlfgclosed" runat="server">
				<asp:ListItem Value="1">�O</asp:ListItem>
				<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:CheckBox id="cbx3" runat="server"></asp:CheckBox>
			<asp:Label id="lblEmpNo" runat="server">�ӿ�~�ȭ��G</asp:Label>
			<asp:DropDownList id="ddlEmpNo" runat="server"></asp:DropDownList>
			<br>
			<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
			<asp:Label id="lblContNo" runat="server">�X���ѽs���G</asp:Label>
			<asp:TextBox id="tbxContNo" runat="server" Width="50px" MaxLength="6" Font-Size="X-Small"></asp:TextBox>
			<br>
			<asp:CheckBox id="cbx5" runat="server"></asp:CheckBox>
			<asp:Label id="lblMfrIName" runat="server">�t�ӦW�١G</asp:Label>
			<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small"></asp:TextBox>
			<br>
			<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>
			&nbsp;
			<asp:Button id="btnClear" runat="server" Text="�M�����d"></asp:Button>
			&nbsp;
			<asp:Button id="btnBack" runat="server" Text="��^����"></asp:Button>
			&nbsp; <INPUT id="btnClose" name="btnClose" type="button" value="��������" onclick="doClose()">&nbsp;&nbsp;
			<br>
			&nbsp;<font size="2" color="red"><b>�Ы��U '�d��' ���s���ˬd���!</b></font>
			<br>
			<asp:label id="lblRecordCount" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="�s�ө���" border="1">
				<ItemTemplate>
					<TABLE width="100%" bgColor="#e6ebf9" borderColor="#666666" cellSpacing="1" cellPadding="0" align="center" style="FONT-SIZE: x-small" border="1">
						<!-- ���D -->
						<TR style="COLOR: white" bgColor="#21418c">
							<TD>
								�X���ѽs��
							</TD>
							<TD colSpan="3">
								�t�ӦW��
								<BR>
								(�t�Ӳνs)
							</TD>
							<TD>
								�Ȥ�W��
								<BR>
								(�s��)
							</TD>
							<TD>
								ñ�����
							</TD>
							<TD>
								�X�����O
							</TD>
							<TD>
								���y���O
							</TD>
							<TD>
								�X���_��
							</TD>
							<TD>
								����
								<BR>
								�~�ȭ� /
								<BR>
								�ק��
							</TD>
							<TD>
								�@��
								<BR>
								�I�M
							</TD>
							<TD>
								����
							</TD>
							<TD>
								�Ѧ�
								<BR>
								�X��
								<BR>
								�s��
							</TD>
							<TD>
								���ɤ�� /
								<BR>
								�ק���
							</TD>
						</TR>
						<!-- ��X���e -->
						<TR vAlign="top">
							<TD width="6%" style="FONT-WEIGHT: bold">
								<asp:Label id="lblContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_contno") %>'></asp:Label>
							</TD>
							<TD width="*" colSpan="3">
								<asp:Label id="lblMfrIName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm").ToString().Trim() %>'></asp:Label>
								(
								<asp:Label id="lblMfrNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_mfrno").ToString().Trim() %>'></asp:Label>
								)&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblCustName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_nm").ToString().Trim() %>'></asp:Label>
								&nbsp;
								<BR>
								(
								<asp:Label id="lblCustNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_custno").ToString().Trim() %>'></asp:Label>
								)&nbsp;
							</TD>
							<TD width="6%">
								<asp:Label id="lblSignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_signdate").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblConttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_conttp").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblBkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bk_nm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_sdate").ToString().Trim() %>'></asp:Label>
								&nbsp;~
								<BR>
								<asp:Label id="lblEndDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_edate").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="9%">
								<asp:Label id="lblEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "srspn_cname").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_modempno").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD width="3%">
								<asp:Label id="lblfgPayonce" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgpayonce").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="6%">
								<asp:Label id="lblfgClosed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgclosed").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblOldContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_oldcontno").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_credate").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_moddate").ToString().Trim() %>'></asp:Label>
							</TD>
						</TR>
						<TR style="COLOR: #000000" bgColor="#BFCFF0">
							<TD bgColor="#e6ebf9">
								&nbsp;
							</TD>
							<TD>
								�`�s�Z
								<BR>
								����
							</TD>
							<TD>
								�w�s�Z
								<BR>
								����
							</TD>
							<TD>
								�Ѿl
								<BR>
								�s�Z
								<BR>
								����
							</TD>
							<TD>
								�`�Z�n
								<BR>
								����
							</TD>
							<TD>
								�w�Z�n
								<BR>
								����
							</TD>
							<TD>
								�Ѿl
								<BR>
								�Z�n
								<BR>
								����
							</TD>
							<TD>
								�X��
								<BR>
								�`���B
							</TD>
							<TD>
								�wú
								<BR>
								���B
							</TD>
							<TD>
								�Ѿl
								<BR>
								���B
							</TD>
							<TD>
								���Z
								<BR>
								����
							</TD>
							<TD>
								�ذe
								<BR>
								���� /
								<BR>
								����
							</TD>
							<TD>
								�s�i�O
								<BR>
								���
							</TD>
							<TD>
								�u�f�馩
							</TD>
						</TR>
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblTotjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblMadejtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_madejtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblRestjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblTottm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_tottm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblPubtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblResttm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_resttm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblTotamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPaidamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_paidamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblRestamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblChgjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_chgjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblFreetm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freetm").ToString().Trim() %>'></asp:Label>
								&nbsp; / &nbsp;
								<asp:Label id="lblFreebkcnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freebkcnt").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD>
								$
								<asp:Label id="lblAdamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_adamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblDiscount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_disc").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
						</TR>
						<TR style="COLOR: #000000" bgColor="#BFCFF0">
							<TD bgColor="#e6ebf9">
								&nbsp;
							</TD>
							<TD>
								�m��
								<BR>
								����
							</TD>
							<TD>
								�M��
								<BR>
								����
							</TD>
							<TD>
								�¥�
								<BR>
								����
							</TD>
							<TD>
								����
								<BR>
								�`�s�i
								<BR>
								���B
							</TD>
							<TD>
								����
								<BR>
								�`���Z
								<BR>
								���B
							</TD>
							<TD>
								&nbsp;
							</TD>
							<TD>
								�p���H
								<BR>
								�m�W
							</TD>
							<TD>
								�q��
							</TD>
							<TD>
								�ǯu
							</TD>
							<TD>
								���
								<BR>
								/ Email
							</TD>
							<TD colSpan="3">
								�Ƶ�
							</TD>
						</TR>
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblClrtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_clrtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblGetclrtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_getclrtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblMenotm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_menotm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPubamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPubchgamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_chgamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aunm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_autel").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aufax").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuCell" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aucell").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblAuEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_auemail").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD colSpan="3">
								<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_remark").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
						</TR>
						<!-- �o���t�Ӧ���H -->
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
								&nbsp;�o���t�Ӧ���H�G
								<BR>
								<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff"></ItemStyle>
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
						<!-- ���x����H -->
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
								&nbsp;���x����H�G
								<BR>
								<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff"></ItemStyle>
									<Columns>
										<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_jbti" HeaderText="¾��"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_addr" HeaderText="�l�H�a�}"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_unpubcnt" HeaderText="���n����"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_mtpcd" HeaderText="�l�H���O"></asp:BoundColumn>
										<asp:BoundColumn DataField="or_fgmosea" HeaderText="���~�l�H"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<SeparatorTemplate>
					<HR id="hr" width="100%" SIZE="2" color="Orange">
					<br>
				</SeparatorTemplate>
			</asp:datalist>
			<br>
			<br>
			<asp:label id="lblMemo1" runat="server" ForeColor="#C04000" Font-Size="X-Small">�����G<br>���ˮ֪�C�ܤ��X���ѬO�|�����͵o���}�߳椧���, <br>�w���͵o���}�߳椧�X���Ѹ�Ƥ��|�b���C��.<br></asp:label>
			<br>
		</form>
			<!-- ���: ���v�� -->
			<kw:Footer runat="server" />		
	</body>
</HTML>
