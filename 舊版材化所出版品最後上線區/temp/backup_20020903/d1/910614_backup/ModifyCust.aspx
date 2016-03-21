<%@ Page language="c#" Codebehind="ModifyCust.aspx.cs" src="ModifyCust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.ModifyCust" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
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
						<td style="WIDTH: 534px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								訂戶資料 <IMG height="10" src="images/header/right02.gif" width="10" border="0"> 修改訂戶資料
							</font>
						</td>
					</tr>
				</table>
			</CENTER>
			<CENTER>
				<TABLE style="WIDTH: 541px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td style="WIDTH: 602px">
								<font color="white">廠商資料</font>
							</td>
						</tr>
						<TR>
							<TD style="WIDTH: 602px">
								公司名稱：
								<asp:textbox id="tbxCompanyname" runat="server" Width="195px"></asp:textbox>
								<IMG class="ico" title="查詢" onclick="doSelectMfr( tbxMfrnoSearch.name,tbxMfrnoSearch.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">
								<INPUT id="hiddenId" type="hidden" runat="server">
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 602px">
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
							<TD style="WIDTH: 602px">
								訂戶編號：
								<asp:textbox id="tbxCustNo" runat="server" Width="94px"></asp:textbox>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 602px">
								訂戶姓名：
								<asp:textbox id="tbxCustName" runat="server" Width="94px"></asp:textbox>
								&nbsp;
								<asp:linkbutton id="lnbShow" runat="server">顯示訂戶資料</asp:linkbutton>
							</TD>
						</TR>
						<TR>
							<td style="WIDTH: 602px">
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
													<asp:Label id="lblNo" Width="60" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_custno")%>'></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblOldNo1" Width="60" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_oldcustno1")%>'></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblOldNo2" Width="60" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_oldcustno2")%>'></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblName" Width="90" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>'></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblJob" Width="90" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_jbti")%>'></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblTel" Width="90" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_tel")%>'></asp:Label>
												</TD>
												<TD>
													<asp:Label id="lblRegdate" Width="60" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "cust_regdate")%>'></asp:Label>
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
												<TD style="HEIGHT: 18px">
													訂戶編號：
												</TD>
												<TD style="HEIGHT: 18px">
													<asp:Label id="lblCustNo" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_custno")%>'></asp:Label>
												</TD>
												<TD style="HEIGHT: 18px">
													註冊日期：
												</TD>
												<TD style="HEIGHT: 18px">
													<asp:Label id="tbxRegdate" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_regdate")%>'></asp:Label>
												</TD>
											</TR>
											<TR>
												<TD>
													統一編號：
												</TD>
												<TD colSpan="3">
													<asp:TextBox id="tbxMfrno" runat="server" MaxLength="10" Text='<%# DataBinder.Eval(Container.DataItem, "cust_mfrno")%>'>
													</asp:TextBox>
													<asp:Label id="lblError" ForeColor="#C00000" Runat="server"></asp:Label>
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
												<TD>
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
												<TD>
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
												<TD>
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
													<asp:checkboxlist id="cblbtp" runat="server" Width="440px" BorderWidth="1px" RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="Inset" BackColor="#E2EAFC"></asp:checkboxlist>
													<asp:TextBox id="tbxBtpcd" runat="server" Width="27px" Text='<%# DataBinder.Eval(Container.DataItem, "cust_btpcd")%>' Visible="False" Height="24px"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD>
													專業領域：
												</TD>
												<TD colSpan="3">
													<asp:CheckBoxList id="cblitp" runat="server" Width="440px" BorderWidth="1px" RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="Inset" BackColor="#E2EAFC"></asp:CheckBoxList>
													<asp:TextBox id="tbxItpcd" runat="server" Width="27px" Text='<%# DataBinder.Eval(Container.DataItem, "cust_itpcd")%>' Visible="False" Height="24px"></asp:TextBox>
												</TD>
											</TR>
										</TABLE>
										<asp:LinkButton id="lnbSave" ForeColor="Blue" Runat="server" CommandName="update" ToolTip="確定儲存並資料更新">儲存資料</asp:LinkButton>
										<asp:LinkButton id="lnbClose" ForeColor="Blue" Runat="server" CommandName="cancel" ToolTip="不儲存資料並關閉視窗">放棄儲存</asp:LinkButton>
										<asp:TextBox id="tbxId" runat="server" Width="16px" Text='<%# DataBinder.Eval(Container.DataItem, "cust_custid")%>' Visible="False" Height="26px"></asp:TextBox>
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
