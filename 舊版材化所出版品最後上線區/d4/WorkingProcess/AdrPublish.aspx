<%@ Page language="c#" Codebehind="AdrPublish.aspx.cs" Src="AdrPublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrPublish" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="AdrPublish" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="95%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�s�i�����B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										������ƺ��@</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11">�X���򥻸��</TD>
							</TR>
							<tr>
								<td>
									<TABLE class="TableColor" id="Table11" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>�X���s��</TD>
											<TD>�X�����O</TD>
											<TD>ñ�����</TD>
											<TD>�X���_��</TD>
											<TD>�t�ӦW��</TD>
											<TD>�Ȥ�W��</TD>
											<TD>�Z�n����</TD>
											<TD>�ذe����</TD>
											<TD>�X�����B</TD>
											<TD>�u�f���</TD>
											<TD>��ܦX��</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>��<asp:label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblMfrNm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblCustNm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><A href="ContShow.aspx?ContNo=<% Response.Write(lblContNo.Text); %>" target=_blank ><IMG alt="�Բ�" src="..\..\images\new.gif" border="0" name="imgShowCont"></A></TD>
										</TR>
									</TABLE>
									<TABLE class="TableColor" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>�`�Z�n����</TD>
											<TD>�w�Z�n����</TD>
											<TD>�Ѿl�Z�n����</TD>
											<TD>�`�s���ɽZ����</TD>
											<TD>�Ѿl�s���ɽZ����</TD>
											<TD>�`�s�����Z����</TD>
											<TD>�Ѿl�s�����Z����</TD>
											<TD>���������`����</TD>
											<TD>���������`����</TD>
											<TD>�`�̭������`����</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lbl_PubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lbl_PubedTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lbl_RestTm" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lbl_TotImgTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lbl_RestImgTm" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lbl_TotUrlTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lbl_RestUrlTm" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotMtm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotItm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotNtm" runat="server" CssClass="NormalLabel"></asp:label></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader">�o���t�Ӧ���H���<IMG onclick='doOpenInvMfr(<% Response.Write("\""+lblContNo.Text+"\""); %>, "", "")' alt=�s�W/�ק� src="..\..\images\new.gif" name=imgAddInvMfr ></TD>
							</TR>
							<tr>
								<td><asp:datagrid id="dgdNewInvMfr1" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�">
												<ItemStyle Width="25px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs">
												<ItemStyle Width="60px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W">
												<ItemStyle Width="60px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
											<asp:BoundColumn DataField="invcd" HeaderText="�o�����O"></asp:BoundColumn>
											<asp:BoundColumn DataField="taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</TABLE>
						<TABLE class="TableColor" id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TBODY>
								<TR>
									<TD class="TableColorHeader" colSpan="4">�s�i���</TD>
								</TR>
								<TR>
									<TD align="right">�s�i�_�W���</TD>
									<TD colspan="3"><asp:textbox id="tbxSDate" runat="server" Width="83px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">~
										<asp:textbox id="tbxEDate" runat="server" Width="88px" AutoPostBack="True"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
										�@<asp:textbox ID="tbxCountDay" Runat="server" Width="39px" ReadOnly="True" ForeColor="Red">0</asp:textbox>��<asp:Button id="btnCount" runat="server" Text="�p��Ѽ�"></asp:Button></TD>
								</TR>
								<TR>
									<TD align="right">�s�i�лy</TD>
									<TD><asp:textbox id="tbxAltText" runat="server"></asp:textbox></TD>
									<TD align="right">�o���t��</TD>
									<TD><asp:dropdownlist id="ddlInvMfr" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="right">�s�i����</TD>
									<TD><asp:dropdownlist id="ddlAdCate" runat="server">
											<asp:ListItem Value="M" Selected="True">����</asp:ListItem>
											<asp:ListItem Value="I">����</asp:ListItem>
											<asp:ListItem Value="N">�`��</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD align="right">�s�i��m</TD>
									<TD><asp:dropdownlist id="ddlKeyword" runat="server">
											<asp:ListItem Value="h0" Selected="True">����</asp:ListItem>
											<asp:ListItem Value="h1">�k�@</asp:ListItem>
											<asp:ListItem Value="h2">�k�G</asp:ListItem>
											<asp:ListItem Value="h3">�k�T</asp:ListItem>
											<asp:ListItem Value="h4">�k�|</asp:ListItem>
											<asp:ListItem Value="w1">�k��@</asp:ListItem>
											<asp:ListItem Value="w2">�k��G</asp:ListItem>
											<asp:ListItem Value="w3">�k��T</asp:ListItem>
											<asp:ListItem Value="w4">�k��|</asp:ListItem>
											<asp:ListItem Value="w5">�k�夭</asp:ListItem>
											<asp:ListItem Value="w6">�k�夻</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="right">����覡</TD>
									<TD><asp:radiobuttonlist id="rblFgFixAd" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">����</asp:ListItem>
											<asp:ListItem Value="1">�w��</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD align="right">������v</TD>
									<TD><asp:textbox id="tbxImpr" runat="server" MaxLength="2" Width="40px"></asp:textbox><A onclick='javascript:window.open("AdrFreeSlots.aspx", "SLOTS", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=600,height=600", false);return false;' href="#">�s�i�Ѿl�Ŷ���</A></TD>
								</TR>
								<TR>
									<TD align="right">�ϽZ���O?</TD>
									<TD><asp:radiobuttonlist id="rblImgTp" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">�½Z</asp:ListItem>
											<asp:ListItem Value="2">�s�Z</asp:ListItem>
											<asp:ListItem Value="3">��Z</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD align="right">URL���O?</TD>
									<TD><asp:radiobuttonlist id="rblUrlTp" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">�½Z</asp:ListItem>
											<asp:ListItem Value="2">�s�Z</asp:ListItem>
											<asp:ListItem Value="3">��Z</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="right">�s�i����</TD>
									<TD><asp:textbox id="tbxAdAmt" runat="server"></asp:textbox></TD>
									<TD align="right">�s�i�s��</TD>
									<TD><asp:textbox id="tbxNavUrl" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right">���Z�O��</TD>
									<TD><asp:textbox id="tbxChgAmt" runat="server"></asp:textbox></TD>
									<TD align="right">�Ƶ�</TD>
									<TD><asp:textbox id="tbxRemark" runat="server"></asp:textbox></TD>
								</TR>
								<tr>
									<TD align="right">�]�p����</TD>
									<TD><asp:textbox id="tbxDesAmt" runat="server"></asp:textbox></TD>
								</tr>
								<TR>
									<TD align="right">�������B</TD>
									<TD><asp:textbox id="tbxInvAmt" runat="server" CssClass="ReadOnlyTextBox" ReadOnly="True"></asp:textbox></TD>
									<TD colSpan="2"><asp:button id="bthAddAdr" runat="server" Text="�s�W�������"></asp:button></TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE class="TableColor" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="6">�w�������</TD>
							</TR>
							<tr>
								<td>
									<TABLE id="Table6" cellSpacing="1" cellPadding="1" border="1">
										<TR>
											<TD class="TableColor" width="100">�s�i�`���B</TD>
											<TD align="left" width="80" bgColor="#ecebff"><asp:label id="lblTotAdAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD class="TableColor" width="100">�]�p�`���B</TD>
											<TD align="left" width="80" bgColor="#ecebff"><asp:label id="lblTotDesAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD class="TableColor" width="100">���Z�`���B</TD>
											<TD align="left" width="80" bgColor="#ecebff"><asp:label id="lblTotChgAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TableColor">�w�����`���B</TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotPubedAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD class="TableColor" colSpan="4"><FONT face="�s�ө���"><asp:label id="lblHint" runat="server" CssClass="ImportantLabel">�w�����`���B=�s�i�`���B+�]�p�`���B+���Z�`���B�A�X�����B�ȥ]�t�s�i���B����</asp:label></FONT></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td><asp:button id="btnSelAll" runat="server" Text="����"></asp:button><asp:button id="btnDeSelAll" runat="server" Text="�M��"></asp:button><asp:button id="btnDelSeltedAdr" runat="server" Text="�R����ܶ���"></asp:button><asp:label id="lblAdrInfo" runat="server" CssClass="NormalLabel" ForeColor="Maroon"></asp:label><input id="hiddenAdrImpr" type="hidden" runat="server"></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="�R��">
												<ItemTemplate>
													<asp:CheckBox id="cbxDelAdr" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:EditCommandColumn ItemStyle-Wrap="False" ButtonType="LinkButton" UpdateText="��s" CancelText="����" EditText="�ק�"></asp:EditCommandColumn>
											<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�Ǹ�">
												<HeaderStyle Width="25px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="���X���">
												<HeaderStyle Width="60px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="�s�i����">
												<ItemTemplate>
													<asp:Label id=lblEAdCate runat="server" Text='<%# MatchAdCate(DataBinder.Eval(Container.DataItem, "adr_adcate")) %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="ddlEAdCate" runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="�s�i��m">
												<ItemTemplate>
													<asp:Label id=lblEKeyword runat="server" Text='<%# MatchKeyword(DataBinder.Eval(Container.DataItem, "adr_keyword")) %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="ddlEKeyword" runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="adr_navurl" HeaderText="�s�i�s��">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_impr" HeaderText="������v">
												<HeaderStyle Width="25px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_adamt" HeaderText="�s�i����">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_desamt" HeaderText="�]�p����">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_chgamt" HeaderText="���Z�O��">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_invamt" ReadOnly="True" HeaderText="�������B">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="�o���t��">
												<ItemTemplate>
													<asp:Label id=lblInvMfr runat="server" Text='<%# MatchImSeq(DataBinder.Eval(Container.DataItem, "adr_imseq")) %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="ddlEInvMfr" runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="adr_remark" HeaderText="�Ƶ�">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_adcate" ReadOnly="True" HeaderText="adr_adcate">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_keyword" ReadOnly="True" HeaderText="adr_keyword">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_imseq" ReadOnly="True" HeaderText="adr_imseq">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_fginved" ReadOnly="True" HeaderText="�o�����O">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn ReadOnly="True" HeaderText="�o�����O">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R����ܶ���")
				event.returnValue=confirm("�T�w�n�R���ҿ�ܪ����)?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
