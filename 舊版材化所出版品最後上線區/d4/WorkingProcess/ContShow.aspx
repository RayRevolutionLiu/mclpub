<%@ Page language="c#" Codebehind="ContShow.aspx.cs" Src="ContShow.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContShow" %>
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
		<form id="ContShow" method="post" runat="server">
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD width="100%" align="middle" class="NormalLabel">合約資料
								</TD>
							</TR>
						</TABLE>
						<br>
					</td>
				</tr>
				<TR>
					<TD align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader">廠商及客戶資料</TD>
							</TR>
							<TR>
								<TD>
									<!--廠商及客戶資料 -->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">公司名稱(統編)：</TD>
											<TD width="30%"><asp:label id="lblMfrNm" runat="server">公司名稱</asp:label>(
												<asp:label id="lblMfrNo" runat="server">00000000</asp:label>&nbsp; )</TD>
											<TD align="right" width="15%">詳細資料：</TD>
											<TD width="30%"><IMG onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" alt=廠商詳細資料 src="../../images/edit.gif" name=imgMfrDetail ></TD>
										</TR>
										<TR>
											<TD align="right">公司負責人姓名(職稱)：</TD>
											<TD><asp:label id="lblRespData" runat="server">負責人(職稱)</asp:label></TD>
											<TD align="right">公司電話(傳真)：</TD>
											<TD><asp:label id="lblMfrTelFax" runat="server">00-00000000(Fax: 00-00000000)</asp:label></TD>
										<TR>
											<TD align="right">客戶姓名(編號)：</TD>
											<TD><asp:label id="lblCustNm" runat="server">客戶姓名</asp:label>(
												<asp:label id="lblCustNo" runat="server">000000</asp:label>&nbsp; )</TD>
											<TD align="right">詳細資料：</TD>
											<TD><IMG onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" alt=客戶詳細資料 src="../../images/edit.gif" name=imgCustDetail ></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">合約書基本資料</TD>
							</TR>
							<TR>
								<TD>
									<!--合約書基本資料-->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">簽約日期：</TD>
											<TD width="30%">
												<asp:Label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right" width="15%">合約編號：</TD>
											<TD width="30%"><asp:label id="lblContNo" runat="server">000000</asp:label></TD>
										</TR>
										<TR>
											<TD align="right">合約類別：</TD>
											<TD>
												<asp:Label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">合約起迄日：</TD>
											<TD>
												<asp:Label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:Label>&nbsp;～
												<asp:Label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblDayCount" runat="server"></asp:label></TD>
											<TD align="right">承辦業務員：</TD>
											<TD>
												<asp:Label id="lblEmpDate" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="right">一次付清註記：</TD>
											<TD>
												<asp:Label id="lblPayOnce" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">合約備註：</TD>
											<TD colSpan="3">
												<asp:Label id="lblRemark" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">合約書細節</TD>
							</TR>
							<TR>
								<TD>
									<!--合約書細節-->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">刊登次數：</TD>
											<TD width="30%">
												<asp:Label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblUnPubTm" runat="server" Visible="False"></asp:label></TD>
											<TD align="right" width="15%">合約總金額：</TD>
											<TD width="30%">
												<asp:Label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="right">贈送次數：</TD>
											<TD>
												<asp:Label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right">優惠折數：</TD>
											<TD>
												<asp:Label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:Label>(例: 
												0.8表示八折)</TD>
										</TR>
										<TR>
											<TD align="right">總製圖檔稿次數：</TD>
											<TD>
												<asp:Label id="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblUnImgTm" runat="server" Visible="False"></asp:label></TD>
											<TD align="right">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">總製網頁稿次數：</TD>
											<TD>
												<asp:Label id="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblUnUrlTm" runat="server" Visible="False"></asp:label></TD>
											<TD align="right">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">廣告聯絡人資料</TD>
							</TR>
							<TR>
								<TD>
									<!--廣告聯絡人資料-->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">廣告聯絡人姓名：</TD>
											<TD width="30%">
												<asp:Label id="lblAuNm" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right" width="15%">&nbsp;</TD>
											<TD width="30%">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">電話：</TD>
											<TD>
												<asp:Label id="lblAuTel" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right">傳真：</TD>
											<TD>
												<asp:Label id="lblAuFax" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="right">手機：</TD>
											<TD>
												<asp:Label id="lblAuCell" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right">Email：</TD>
											<TD>
												<asp:Label id="lblAuEmail" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<!--
							<TR>
								<TD class="TableColorHeader">廣告推廣內文、期限、產品設備內文、材料特性、應用產業等相關資料</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">發票廠商收件人資料</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">雜誌收件人及贈書資料</TD>
							</TR>
							<TR>
								<TD><asp:datagrid id="dgdFreeBk" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="DataGridStyle">
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="贈書項次"></asp:BoundColumn>
											<asp:BoundColumn DataField="fbk_sdate" HeaderText="贈書起月"></asp:BoundColumn>
											<asp:BoundColumn DataField="fbk_edate" HeaderText="贈書迄月"></asp:BoundColumn>
											<asp:BoundColumn DataField="bk_nm" HeaderText="書籍"></asp:BoundColumn>
											<asp:BoundColumn DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
											<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
											<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
											<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="郵寄類別">
												<ItemTemplate>
													<asp:Label id=lblMtpNm runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							-->
							<TR>
								<TD align=center><INPUT onclick="javascript:window.close();" type="button" value="關閉" name="btnClose"></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="tbxHidMfrNo" runat="server" Visible="False" Width="10px"></asp:textbox><asp:textbox id="tbxHidCustNo" runat="server" Visible="False" Width="10px"></asp:textbox>
									<asp:TextBox id="tbxOldContNo" runat="server" Visible="False" Width="10px"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
