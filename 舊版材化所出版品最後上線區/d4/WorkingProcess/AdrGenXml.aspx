<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="AdrGenXml.aspx.cs" Src="AdrGenXml.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrGenXml" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="AdrGenXml" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										落版處理<IMG height="10" src="../../images/header/right02.gif" width="10" border="0">產生播出檔
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
								<td>點選右方日曆上的日期<BR>
									或直接輸入日期：<BR>
									<asp:TextBox id="tbxAdDate" runat="server" Width="80px"></asp:TextBox>
									<asp:RegularExpressionValidator id="rdvAdDate" runat="server" CssClass="ValidatorStyle" ErrorMessage="格式應為yyyy/mm/dd" Display="Dynamic" ControlToValidate="tbxAdDate" ValidationExpression="[1-9]\d{3}\/[0-1][0-9]\/[0-3][0-9]"></asp:RegularExpressionValidator><BR>
									<asp:Button id="btnQueryPublish" runat="server" Text="查詢該日落版狀況"></asp:Button></td>
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
						<!-- 頁尾 Footer -->
						<asp:Panel id="pnlAdr" runat="server" Width="100%" Visible="False">
							<asp:Button id="btnGenXml" Text="產生yyyy/MM/dd的播出檔" Runat="server" CausesValidation="False"></asp:Button>
							<asp:TextBox id="tbxSelDate" runat="server" Width="10px" Visible="False"></asp:TextBox>
							<asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="adr_contno" ReadOnly="True" HeaderText="合約書編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="序號">
										<HeaderStyle Width="25px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="播出日期">
										<HeaderStyle Width="60px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="廣告標語">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="廣告頁面"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="廣告位置"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="廣告連結">
										<HeaderStyle Width="100px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="播放機率">
										<HeaderStyle Width="25px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="adr_fgfixad" ReadOnly="True" HeaderText="播放方式"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_imgurl" ReadOnly="True" HeaderText="廣告圖檔"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_drafttp" ReadOnly="True" HeaderText="圖檔稿類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_urltp" ReadOnly="True" HeaderText="網頁稿類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_empno" ReadOnly="True" HeaderText="負責業務員"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="客戶姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="廠商名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_aunm" ReadOnly="True" HeaderText="聯絡人"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_nm" ReadOnly="True" HeaderText="發票廠商收件人"></asp:BoundColumn>
									<asp:BoundColumn DataField="adr_remark" ReadOnly="True" HeaderText="備註">
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
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
