<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RemailMaintain.aspx.cs" Src="RemailMaintain.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RemailMaintain" %>
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
		<form id="RemailMaintain" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<table id="tblX" border="0" width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										補書處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										補書修改</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE style="WIDTH: 604px" cellSpacing="0" cellPadding="2" class="TableColor">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">客戶資料
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">合約編號：
								</TD>
								<td colSpan="3"><asp:textbox id="tbxContNo" runat="server" MaxLength="6" Width="100px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">公司名稱：
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxMfrNm" runat="server" Width="204px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">統一編號：
								</TD>
								<td><asp:textbox id="tbxMfrNo" runat="server" MaxLength="10" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">客戶編號：
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxCustNo" runat="server" MaxLength="6" Width="52px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">客戶姓名：
								</TD>
								<td><asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">簽約日期：
								</TD>
								<td colSpan="3"><asp:textbox id="tbxSSDate" runat="server" MaxLength="10" Width="82px"></asp:textbox><IMG class="ico" title="日曆" onclick='javascript:pick_date_single(tbxSSDate.name)' src="../../images/calendar01.gif">
									～<asp:textbox id="tbxSEDate" runat="server" MaxLength="10" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick='javascript:pick_date_single(tbxSEDate.name)' src="../../images/calendar01.gif">
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
							<TR>
								<TD style="WIDTH: 104px" align="right">寄書狀態：
								</TD>
								<td colSpan="3"><asp:radiobuttonlist id="rblSent" runat="server" RepeatDirection="Horizontal">
										<asp:ListItem Value="0" Selected="True">未寄出</asp:ListItem>
										<asp:ListItem Value="1">已寄出</asp:ListItem>
									</asp:radiobuttonlist></td>
							</TR>
						</TABLE>
						<asp:linkbutton id="lnbSearch" runat="server">查詢</asp:linkbutton>
						<DIV align="center"><asp:datagrid id="dgdRemail" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
								<AlternatingItemStyle CssClass="AlteringItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<FooterStyle CssClass="FooterStyle"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" ReadOnly="True" HeaderText="合約類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="訂戶姓名">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rm_oritem" ReadOnly="True" HeaderText="收件人序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" ReadOnly="True" HeaderText="收件人"></asp:BoundColumn>
									<asp:BoundColumn DataField="rm_seq" ReadOnly="True" HeaderText="補書序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="rm_cont" HeaderText="補書內容"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="補書註記">
										<ItemTemplate>
											<asp:Label id=lblFgSent runat="server" Text='<%# GetFgSentName(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:DropDownList id=ddlFgSent runat="server" SelectedIndex='<%# GetSelectedIndex(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'>
												<asp:ListItem Value="Y" Selected="True">可寄出</asp:ListItem>
												<asp:ListItem Value="N">目前不寄出</asp:ListItem>
												<asp:ListItem Value="C">已寄出</asp:ListItem>
												<asp:ListItem Value="D">*不處理*</asp:ListItem>
											</asp:DropDownList>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="PushButton" UpdateText="儲存" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><FONT face="新細明體"><BR>
							</FONT>
							<asp:label id="lblMessage" runat="server" Visible="False" CssClass="ImportantLabel"></asp:label></DIV>
					</td>
				</tr>
			</table>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></FORM>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
				event.returnValue=confirm("確定要刪除此筆補書資料?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
