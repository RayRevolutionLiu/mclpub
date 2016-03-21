<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ModifyCust.aspx.cs" src="ModifyCust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.ModifyCust" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="ModifyCust" method="post" runat="server">
			<CENTER>
				<table>
					<tr>
						<td style="WIDTH: 600px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂戶資料 <IMG height="10" src="images/header/right02.gif" width="10" border="0"> 修改訂戶資料
							</font>
						</td>
					</tr>
				</table>
				<TABLE style="WIDTH: 600px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td style="WIDTH: 600px">
								<font color="white">廠商資料</font>
							</td>
						</tr>
						<TR>
							<TD style="WIDTH: 600px">
								公司名稱：
								<asp:textbox id="tbxCompanyname" runat="server" Width="195px"></asp:textbox>
								<IMG class="ico" title="查詢" onclick="doSelectMfr( tbxMfrnoSearch.name,tbxMfrnoSearch.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">
								<INPUT id="hiddenId" type="hidden" runat="server">
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 600px">
								統一編號：
								<asp:textbox id="tbxMfrnoSearch" runat="server" Width="124px" MaxLength="10"></asp:textbox>
								<IMG class="ico" title="查詢" onclick="doSelectMfr( tbxMfrnoSearch.name,tbxMfrnoSearch.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">
								<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
								<br>
								<asp:label id="Label1" runat="server" ForeColor="DarkRed">[請輸入關鍵值然後按"查詢", 或輸入完整統一編號後按"顯示訂戶資料"] </asp:label>
								<asp:LinkButton id="lnbNewCust" runat="server" ForeColor="Blue">新增訂戶</asp:LinkButton>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 600px">
								訂戶編號：
								<asp:textbox id="tbxCustNo" runat="server" Width="94px"></asp:textbox>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 600px">
								訂戶姓名：
								<asp:textbox id="tbxCustName" runat="server" Width="94px"></asp:textbox>
								&nbsp;
								<asp:linkbutton id="lnbShow" runat="server">顯示訂戶資料</asp:linkbutton>
							</TD>
						</TR>
						<TR>
							<td style="WIDTH: 600px">
								<asp:datalist id="DataList1" runat="server" BorderColor="#4A3C8C" BorderWidth="1px">
									<HeaderTemplate>
										<TABLE>
											<TR>
												<TD width="60">
													<FONT color="white">訂戶編號</FONT>
												</TD>
												<TD width="60">
													<FONT color="white">舊工材編號</FONT>
												</TD>
												<TD width="60">
													<FONT color="white">舊電材編號</FONT>
												</TD>
												<TD width="90">
													<FONT color="white">訂戶姓名</FONT>
												</TD>
												<TD width="90">
													<FONT color="white">訂戶職稱</FONT>
												</TD>
												<TD width="90">
													<FONT color="white">聯絡電話</FONT>
												</TD>
												<TD width="60">
													<FONT color="white">註冊日期</FONT>
												</TD>
												<TD width="60">
													<FONT color="white"></FONT>
												</TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<EditItemStyle BackColor="Info"></EditItemStyle>
									<SelectedItemTemplate>
										<FONT face="新細明體"></FONT>
									</SelectedItemTemplate>
									<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
									<ItemStyle BorderWidth="1px" BackColor="#E7E7FF"></ItemStyle>
									<ItemTemplate>
										<TABLE>
											<TR>
												<TD>
													<asp:Label id="lblNo" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "cust_custno")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblOldNo1" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "cust_oldcustno1")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblOldNo2" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "cust_oldcustno2")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblName" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblJob" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "cust_jbti")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblTel" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "cust_tel")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblRegdate" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "cust_regdate")%>' Runat="server"></asp:Label>
												</TD>
												<TD>
													<asp:LinkButton id="lnbDetail" Width="60" ForeColor="Blue" Runat="server" CommandName="edit">修改資料</asp:LinkButton>
												</TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<HeaderStyle BorderWidth="1px" ForeColor="White" BackColor="#4A3C8C"></HeaderStyle>
									<EditItemTemplate>
										<TABLE>
											<TR>
												<TD>
													訂戶編號：
												</TD>
												<TD>
													<asp:Label id="lblCustNo" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_custno")%>'></asp:Label>
												</TD>
												<TD align="right">
													註冊日期：
												</TD>
												<TD>
													<asp:Label id="tbxRegdate" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_regdate")%>'></asp:Label>
												</TD>
											</TR>
											<TR>
												<TD>
													統一編號：
												</TD>
												<TD>
													<asp:TextBox id="tbxMfrno" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container.DataItem, "cust_mfrno")%>'>
													</asp:TextBox>
													<asp:Label id="lblError" ForeColor="#C00000" Runat="server"></asp:Label>
												</TD>
												<TD align="right">
													上次修改日期：
												</TD>
												<TD>
													<asp:Label id="lblModifyDate" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_moddate")%>'></asp:Label>
												</TD>
											</TR>
											<TR>
												<TD>
													訂戶姓名：
												</TD>
												<TD>
													<asp:TextBox id="tbxName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>'>
													</asp:TextBox>
												</TD>
												<TD align="right">
													訂戶職稱：
												</TD>
												<TD>
													<asp:TextBox id="tbxJob" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_jbti")%>'>
													</asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD>
													聯絡電話：
												</TD>
												<TD>
													<asp:TextBox id="tbxTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_tel")%>'>
													</asp:TextBox>
												</TD>
												<TD align="right">
													傳真號碼：
												</TD>
												<TD>
													<asp:TextBox id="tbxFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_fax")%>'>
													</asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD>
													手機號碼：
												</TD>
												<TD>
													<asp:TextBox id="tbxCell" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_cell")%>'>
													</asp:TextBox>
												</TD>
												<TD align="right">
													Email：
												</TD>
												<TD>
													<asp:TextBox id="tbxEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_email")%>'>
													</asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD>
													營業項目：
												</TD>
												<TD colSpan="3">
													<asp:checkboxlist id="cblbtp" runat="server" Width="440px" BorderWidth="1px" BackColor="#E2EAFC" BorderStyle="Inset" RepeatDirection="Horizontal" RepeatColumns="4"></asp:checkboxlist>
													<asp:TextBox id="tbxBtpcd" runat="server" Width="27px" Text='<%# DataBinder.Eval(Container.DataItem, "cust_btpcd")%>' Height="24px" Visible="False"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD>
													專業領域：
												</TD>
												<TD colSpan="3">
													<asp:CheckBoxList id="cblitp" runat="server" Width="440px" BorderWidth="1px" BackColor="#E2EAFC" BorderStyle="Inset" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
													<asp:TextBox id="tbxItpcd" runat="server" Width="27px" Text='<%# DataBinder.Eval(Container.DataItem, "cust_itpcd")%>' Height="24px" Visible="False"></asp:TextBox>
												</TD>
											</TR>
										</TABLE>
										<asp:LinkButton id="lnbSave" ForeColor="Blue" Runat="server" CommandName="update" ToolTip="確定儲存並資料更新">儲存資料</asp:LinkButton>
										<asp:LinkButton id="lnbClose" ForeColor="Blue" Runat="server" CommandName="cancel" ToolTip="不儲存資料並關閉視窗">放棄儲存</asp:LinkButton>
										<asp:TextBox id="tbxId" runat="server" Width="16px" Text='<%# DataBinder.Eval(Container.DataItem, "cust_custid")%>' Height="26px" Visible="False"></asp:TextBox>
									</EditItemTemplate>
								</asp:datalist>
							</td>
						</TR>
					</TBODY>
				</TABLE>
			</CENTER>
		</form>
		<!-- 頁尾 Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
function doSelectMfr(name1, value1, name2, value2)
{
	var vReturn = window.open("MfrSearch.aspx?Field1="+name1+"&mfrno="+value1+"&Field2="+name2+"&company="+value2, "Poping"); 
}
		</script>
	</body>
</HTML>
