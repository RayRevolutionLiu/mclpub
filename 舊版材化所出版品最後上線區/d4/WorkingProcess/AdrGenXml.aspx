<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="AdrGenXml.aspx.cs" Src="AdrGenXml.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrGenXml" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="AdrGenXml" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�����B�z<IMG height="10" src="../../images/header/right02.gif" width="10" border="0">���ͼ��X��
									</FONT>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<table border="0" cellpadding="1" cellspacing="1">
							<tr>
								<td>�I��k����W�����<BR>
									�Ϊ�����J����G<BR>
									<asp:TextBox id="tbxAdDate" runat="server" Width="80px"></asp:TextBox>
									<asp:RegularExpressionValidator id="rdvAdDate" runat="server" CssClass="ValidatorStyle" ErrorMessage="�榡����yyyy/mm/dd" Display="Dynamic" ControlToValidate="tbxAdDate" ValidationExpression="[1-9]\d{3}\/[0-1][0-9]\/[0-3][0-9]"></asp:RegularExpressionValidator><BR>
									<asp:Button id="btnQueryPublish" runat="server" Text="�d�߸Ӥ鸨�����p"></asp:Button></td>
								<td>
									<asp:calendar id="calDates" runat="server" CssClass="CalendarStyle">
										<DayStyle CssClass="DayStyle"></DayStyle>
										<NextPrevStyle CssClass="CalNextPrevStyle"></NextPrevStyle>
										<DayHeaderStyle CssClass="DayHeaderStyle"></DayHeaderStyle>
										<TitleStyle CssClass="CalTitleStyle" BackColor="PaleGreen"></TitleStyle>
										<WeekendDayStyle CssClass="WeekendDayStyle"></WeekendDayStyle>
										<OtherMonthDayStyle CssClass="OtherMonthDayStyle"></OtherMonthDayStyle>
									</asp:calendar></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
						</table>
						<!-- ���� Footer -->
						<asp:Panel id="pnlAdr" runat="server" Width="100%" Visible="False">
							<asp:Button id="btnGenXml" Text="����yyyy/MM/dd�����X��" Runat="server" CausesValidation="False"></asp:Button>
							<asp:TextBox id="tbxSelDate" runat="server" Width="10px" Visible="False"></asp:TextBox>
							<asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="adr_contno" ReadOnly="True" HeaderText="�X���ѽs��"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�Ǹ�">
										<HeaderStyle Width="25px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="���X���">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="�s�i�лy">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="�s�i����"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="�s�i��m"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="�s�i�s��">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="������v">
										<HeaderStyle Width="25px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_fgfixad" ReadOnly="True" HeaderText="����覡"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_imgurl" ReadOnly="True" HeaderText="�s�i����"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_drafttp" ReadOnly="True" HeaderText="���ɽZ���O"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_urltp" ReadOnly="True" HeaderText="�����Z���O"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_empno" ReadOnly="True" HeaderText="�t�d�~�ȭ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="�t�ӦW��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_aunm" ReadOnly="True" HeaderText="�p���H"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_nm" ReadOnly="True" HeaderText="�o���t�Ӧ���H"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_remark" ReadOnly="True" HeaderText="�Ƶ�">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="sort_adcate" HeaderText="sort_adcate"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="sort_keyword" HeaderText="sort_keyword"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</asp:Panel>
						<asp:TextBox id="TextBox1" runat="server" Width="90%" TextMode="MultiLine" Rows="20"></asp:TextBox><kw:footer id="Footer1" runat="server"></kw:footer>
					</td>
				</tr>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
