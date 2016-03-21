<%@ Page language="c#" Codebehind="AdrFileUp.aspx.cs" Src="AdrFileUp.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrFileUp" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="AdrFileUp" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="95%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										廣告落版處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;美編上稿</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11">合約基本資料</TD>
							</TR>
							<tr>
								<td>
									<TABLE class="TableColor" id="Table14" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>合約編號</TD>
											<TD>合約類別</TD>
											<TD>簽約日期</TD>
											<TD>合約起迄</TD>
											<TD>刊登次數</TD>
											<TD>贈送次數</TD>
											<TD>合約金額</TD>
											<TD>優惠折數</TD>
											<TD>總製圖檔稿次數</TD>
											<TD>總製網頁稿次數</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>～<asp:label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" colspan="2">美編上稿</TD>
							</TR>
							<TR>
								<TD width="60%">
									<TABLE class="TableColor" id="Table31" cellSpacing="0" cellPadding="2" width="100%" border="0">
										<tr>
											<td colspan="2">
												<A class="HylerLinkStyle" href="AdrImages.aspx" target="_blank">現有廣告圖檔</A>&nbsp;&nbsp;&nbsp;<A class="HylerLinkStyle" href="AdrUpload.aspx" target="_blank">上傳廣告圖檔</A>
												<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
											</td>
										</tr>
										<TR>
											<TD align="right">
												<asp:CheckBox id="cbxImage" runat="server" Text="圖檔："></asp:CheckBox>
											</TD>
											<td>
												<asp:DropDownList id="ddlImages" runat="server"></asp:DropDownList>
												<asp:Button id="btnRefresh" runat="server" Text="更新圖檔資料"></asp:Button>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:CheckBox id="cbxLink" runat="server" Text="網頁連結："></asp:CheckBox>
											</TD>
											<td><asp:TextBox id="tbxNavUrl" runat="server"></asp:TextBox>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:CheckBox id="cbxAltText" runat="server" Text="廣告標語："></asp:CheckBox>
											</TD>
											<td><asp:TextBox id="tbxAltText" runat="server"></asp:TextBox>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:Label id="lblType1" runat="server">上稿方式 1：</asp:Label>
											</TD>
											<td><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">～
												<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
												<asp:Button id="btnDateSetImage" runat="server" Text="日期區間上稿"></asp:Button>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:Label id="Label1" runat="server">上稿方式 2：</asp:Label>
											</TD>
											<td><asp:Button id="btnSetImage" runat="server" Text="勾選項目上稿"></asp:Button>
											</td>
										</TR>
									</TABLE>
								</TD>
								<td>
									<asp:Label id="lblInfo" runat="server" ForeColor="#C00000" Font-Size="X-Small">
									使用說明：<br>1.利用【現有廣告圖檔】先查詢所需圖檔是否已存在<br>
									2.如為新圖檔, 請利用【上傳廣告圖檔】將圖檔上傳<br>
									3.利用【更新圖檔資料】將上傳圖檔載入下拉式選單中<br>
									4.選擇圖檔及輸入網頁連結資料<br>
									5.利用【日期區間上稿】方式可一次將此區間的所有資料上稿<br>
									6.利用【勾選項目上稿】方式可隨意挑選欲上稿的日期
									</asp:Label>
								</td>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader">廣告落版資料</TD>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlAdr" runat="server" Width="100%">
										<asp:button id="btnSelAll" runat="server" Text="全選"></asp:button>
										<asp:button id="btnDeSelAll" runat="server" Text="清選"></asp:button>
										<asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
											<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
											<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="挑選">
													<ItemTemplate>
														<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
												<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="序號">
													<HeaderStyle Width="25px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="播出日期">
													<HeaderStyle Width="60px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_alttext" HeaderText="廣告標語">
													<HeaderStyle Width="100px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="廣告頁面"></asp:BoundColumn>
												<asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="廣告位置"></asp:BoundColumn>
												<asp:BoundColumn DataField="adr_navurl" HeaderText="廣告連結">
													<HeaderStyle Width="100px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="播放機率">
													<HeaderStyle Width="25px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_remark" HeaderText="備註">
													<HeaderStyle Width="100px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="廣告圖檔">
													<ItemTemplate>
														<asp:Label id=lblImgUrl runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "adr_imgurl") %>'>
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:DropDownList id="ddlImgUrl" runat="server"></asp:DropDownList>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="圖檔稿類別">
													<ItemTemplate>
														<asp:Label id=lblDraftTp runat="server" Text='<%# GetDraftTpNm(DataBinder.Eval(Container.DataItem, "adr_drafttp")) %>'>
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:DropDownList id="ddlDraftTp" runat="server">
															<asp:ListItem Value="1">舊稿</asp:ListItem>
															<asp:ListItem Value="2">新稿</asp:ListItem>
															<asp:ListItem Value="3">改稿</asp:ListItem>
														</asp:DropDownList>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="網頁稿類別">
													<ItemTemplate>
														<asp:Label id=lblUrlTp runat="server" Text='<%# GetUrlTpNm(DataBinder.Eval(Container.DataItem, "adr_urltp")) %>'>
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:DropDownList id="ddlUrlTp" runat="server">
															<asp:ListItem Value="1">舊稿</asp:ListItem>
															<asp:ListItem Value="2">新稿</asp:ListItem>
															<asp:ListItem Value="3">改稿</asp:ListItem>
														</asp:DropDownList>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="adr_adcate" ReadOnly="True" HeaderText="adr_adcate">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="adr_keyword" ReadOnly="True" HeaderText="adr_keyword">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid>
									</asp:panel>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
