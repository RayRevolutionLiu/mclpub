<%@ Page language="c#" Codebehind="LostAdd.aspx.cs" Src="LostAdd.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.LostAdd" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
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
		<form id="LostAdd" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<table id="tblX" width="100%">
				<tr>
					<td align="middle"><table>
							<tr>
								<td align="left"><font color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;材料世界網廣告次系統<IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										缺書處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">&nbsp;缺書登錄
									</font>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" style="WIDTH: 604px" cellSpacing="0" cellPadding="2">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">客戶資料
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">合約編號：
								</TD>
								<td colSpan="3"><asp:textbox id="tbxContNo" runat="server" Width="100px" MaxLength="6"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">公司名稱：
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxMfrNm" runat="server" Width="204px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">統一編號：
								</TD>
								<td><asp:textbox id="tbxMfrNo" runat="server" Width="99px" MaxLength="10"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">客戶編號：
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxCustNo" runat="server" Width="52px" MaxLength="6"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">客戶姓名：
								</TD>
								<td><asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">簽約日期：
								</TD>
								<td colSpan="3"><asp:textbox id="tbxSSDate" runat="server" Width="82px" MaxLength="10"></asp:textbox><IMG class="ico" title="日曆" onclick="javascript:pick_date_single(tbxSSDate.name)" src="../../images/calendar01.gif">
									∼<asp:textbox id="tbxSEDate" runat="server" Width="84px" MaxLength="10"></asp:textbox><IMG class="ico" title="日曆" onclick="javascript:pick_date_single(tbxSEDate.name)" src="../../images/calendar01.gif">
								</td>
							</TR>
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">雜誌收件人資料
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">收件人姓名：
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxOrName" runat="server" Width="99px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">收件人電話：
								</TD>
								<td><asp:textbox id="tbxOrTel" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">收件人地址：
								</TD>
								<td colSpan="3"><asp:textbox id="tbxOrAddr" runat="server" Width="431px"></asp:textbox></td>
							</TR>
						</TABLE>
						<asp:linkbutton id="lnbSearch" runat="server">查詢</asp:linkbutton>
						<DIV align="center"><asp:datagrid id="dgdContOr" runat="server" AllowPaging="True" CellPadding="2" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
								<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<FooterStyle CssClass="FooterStyle"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
										<HeaderStyle Width="40px"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別">
										<HeaderStyle Width="33px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
									<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="贈書項次">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fc_nm" HeaderText="贈書類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="fbkmnt" HeaderText="份數(有/未)">
										<HeaderStyle Width="30px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_oritem" HeaderText="收件人序號">
										<HeaderStyle Width="10px"></HeaderStyle>
										<ItemStyle Width="10px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="收件人">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_addr" HeaderText="收件人地址"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="收件人電話"></asp:BoundColumn>
									<asp:ButtonColumn Text="缺書登錄" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" Position="Top" CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:label id="lblInfo" Runat="server"></asp:label><asp:datagrid id="dgdLost" runat="server" CellPadding="2" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
								<SelectedItemStyle Font-Bold="True" CssClass="SelectedItemStyle"></SelectedItemStyle>
								<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
								<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<FooterStyle CssClass="FooterStyle"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號">
										<HeaderStyle Width="40px"></HeaderStyle>
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" ReadOnly="True" HeaderText="合約類別">
										<HeaderStyle Width="33px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="訂戶姓名">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="lst_fbkitem" ReadOnly="True" HeaderText="贈書項次">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fc_nm" ReadOnly="True" HeaderText="原贈書內容"></asp:BoundColumn>
									<asp:BoundColumn DataField="fbkmnt" ReadOnly="True" HeaderText="份數(有/未)">
										<HeaderStyle Width="28px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="lst_oritem" ReadOnly="True" HeaderText="收件人序號">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" ReadOnly="True" HeaderText="收件人"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_seq" ReadOnly="True" HeaderText="缺書序號">
										<HeaderStyle Width="10px"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="lst_cont" HeaderText="缺書內容"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_rea" HeaderText="缺書原因"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="缺書註記">
										<ItemTemplate>
											<asp:Label id=lblFgSent runat="server" Text='<%# GetFgSentName(DataBinder.Eval(Container.DataItem, "lst_fgsent")) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:DropDownList id=ddlFgSent runat="server" SelectedIndex='<%# GetSelectedIndex(DataBinder.Eval(Container.DataItem,"lst_fgsent")) %>'>
												<asp:ListItem Value="Y" Selected="True">可寄出</asp:ListItem>
												<asp:ListItem Value="N">目前不寄出</asp:ListItem>
												<asp:ListItem Value="d">*不處理*</asp:ListItem>
											</asp:DropDownList>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="PushButton" UpdateText="儲存" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><br>
							<asp:label id="lblMessage" runat="server" Visible="False" CssClass="ImportantLabel"></asp:label></DIV>
					</td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
				event.returnValue=confirm("確定要刪除此筆缺書資料?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
