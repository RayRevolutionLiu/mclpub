<%@ Page language="c#" Codebehind="ContPubFm_show.aspx.cs" Src="ContPubFm_show.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContPubFm_show" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>顯示合約及落版資料</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- 視窗按鈕 -->
			<INPUT id="btnCloseWin" onclick="javascript:window.close();" type="button" value="關閉視窗">
			<INPUT id="btnPrintWin" onclick="javascript:window.print();" type="button" value="列印本頁">
			<br>
			<!-- Run at Server Form -->
			<form id="ContPubFm_show" method="post" runat="server">
				<!--Table 開始-->
				<TABLE cellSpacing="0" cellPadding="4" width="96%" bgColor="#bfcff0" border="0">
					<!-- 廠商及客戶資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">廠商及客戶資料</font>
						</td>
					</TR>
					<!-- 廠商資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							公司名稱 (廠商統編)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrIName" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon"></asp:label>
							)
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=450, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="廠商詳細資料" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- 公司負責人資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							公司負責人 姓名(職稱)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;<FONT face="新細明體">(
								<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							公司電話 (傳真)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblMfrFax" runat="server"></asp:label>
								)</FONT>
						</TD>
					</TR>
					<!-- 客戶資料 -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							客戶姓名 (客戶編號)：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server" ForeColor="Maroon"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblCustNo" runat="server" ForeColor="Maroon"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							詳細資料：
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="客戶詳細資料" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- 合約書基本資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">合約書基本資料&nbsp;&nbsp;</font>&nbsp;
							<asp:label id="lblfgClosedMessage" runat="server" ForeColor="Yellow"></asp:label>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							簽約日期：
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" Width="65px" MaxLength="10"></asp:textbox>
							&nbsp; <FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">為必填欄位]</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							合約書編號：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約類別：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlContType" runat="server">
								<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
								<asp:ListItem Value="09">推廣合約</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							書籍類別：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約起迄日：
						</TD>
						<TD class="cssData" noWrap>
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxStartDate" runat="server" Width="55px" MaxLength="7"></asp:textbox>
							&nbsp; <font size="3">~</font> <FONT color="red">*</FONT>
							<asp:textbox id="tbxEndDate" runat="server" Width="55px" MaxLength="7"></asp:textbox>
							&nbsp;
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							建檔業務員：
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							一次付清註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							結案註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgClosed" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							修改業務員：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlModEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							合約註銷註記：
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgCancel" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							參考合約書編號：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:label id="lblOldContNo" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;&nbsp;&nbsp;
							<asp:label id="lblOldContMessage" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							建檔日期：
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
							<asp:label id="lblCreateDate" runat="server"></asp:label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							最後修改日期：
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:label id="lblModifyDate" runat="server"></asp:label>
						</TD>
					</TR>
					<!-- 合約書細節 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">合約書細節</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										總製稿次數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										總刊登次數：
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										合約總金額：
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>$
										<asp:textbox id="tbxTotalAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										已製稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxMadeJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										已刊登次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxPubTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										已繳金額：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:textbox id="tbxPaidAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										剩餘製稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxRestJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										剩餘刊登次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxRestTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										剩餘金額：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:textbox id="tbxRestAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										換稿次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										贈送次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										廣告費單價：&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxADAmt" runat="server" Width="50px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										優惠折數：&nbsp;
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" Width="40px" MaxLength="6"></asp:textbox>
										<FONT face="新細明體">折</FONT>
									</TD>
									<TD class="cssTitle" align="right">
										贈送本數：&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeBookCount" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										彩色次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										套色次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxGetColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										黑白次數：
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="tbxMenoTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 總廣告金額：</font>
									</TD>
									<TD class="cssData">
										$
										<asp:textbox id="tbxPubAdAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 總換稿金額：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxPubChangeAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 剩餘彩色次數：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestClrtm" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 剩餘套色次數：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestGetClrtm" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">已落版 剩餘黑白次數：</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:TextBox id="tbxRestMenotm" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR> <!-- 廣告聯絡人 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">廣告聯絡人資料</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							廣告聯絡人姓名：
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" Width="65px" MaxLength="30"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							電話：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuTel" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							傳真：
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuFax" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							手機：
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuCell" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							Email：
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuEmail" runat="server" Width="160px" MaxLength="80"></asp:textbox>
						</TD>
					</TR>
					<!-- 備註　資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">備註</font>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" align="right">
							額外備註：
						</TD>
						<TD class="cssData" colSpan="3">
							&nbsp;&nbsp;&nbsp;<TEXTAREA id="tarContRemark" name="tarContRemark" rows="5" cols="60" runat="server" disabled></TEXTAREA>
						</TD>
					</TR>
					<!-- 發票廠商收件人 資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">發票廠商收件人資料</font>&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="DataGrid1" runat="server" Font-Size="XX-Small" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_addr" HeaderText="發票地址"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<br>
						</TD>
					</TR>
					<!-- 雜誌收件人 資料 -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">雜誌收件人資料</font>&nbsp;&nbsp;
						</td>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_inm" HeaderText="廠商名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_jbti" HeaderText="職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_addr" HeaderText="郵寄地址"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_mtpcd" HeaderText="郵寄類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_fgmosea" HeaderText="海外郵寄"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<br>
							<div align="right">
								<font color="red">有登本數／未登本數 總計：
									<asp:label id="lblORPunCnt" runat="server" ForeColor="Blue"></asp:label>
									&nbsp;
									<asp:label id="lblORUnPubCnt" runat="server" ForeColor="Blue"></asp:label>
								</font>&nbsp;
							</div>
						</TD>
					</TR>
					<!-- 落版 資料 -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">落版資料</font>&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:DataList id="DataList2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC">
								<ItemTemplate>
									<TR style="COLOR: #000000" bgColor="#BFCFF0">
										<TD>
											刊登年月
										</TD>
										<TD>
											落版序號
										</TD>
										<TD>
											廣告版面
										</TD>
										<TD>
											廣告色彩
										</TD>
										<TD>
											廣告篇幅
										</TD>
										<TD>
											固定頁次
										</TD>
										<TD>
											發廠
											<BR>
											序號
										</TD>
										<TD>
											發廠
											<BR>
											姓名
										</TD>
										<TD>
											修改業務員
										</TD>
										<TD>
											修改日期
										</TD>
										<TD>
											&nbsp;
										</TD>
									</TR>
									<!-- 輸出內容2 -->
									<TR vAlign="top">
										<TD width="10%" style="FONT-WEIGHT: bold">
											<asp:Label id="lblYYYYMM" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_yyyymm").ToString() %>'>
											</asp:Label><br>
											<font size="2">第
												<asp:Label id="lblBkPno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_pno").ToString().Trim() %>'>
												</asp:Label>
												期</font>
										</TD>
										<TD width="10%" style="FONT-WEIGHT: bold">
											<asp:Label id="lblPubSeq" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_pubseq").ToString() %>'>
											</asp:Label>
										</TD>
										<TD width="10%">
											<asp:Label id="lblLtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ltp_nm").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="10%">
											<asp:Label id="lblClrcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clr_nm").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="12%">
											<asp:Label id="lblPgscd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pgs_nm").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="5%">
											<asp:Label id="lblfgFixPg" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fgfixpg").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="8%">
											<asp:Label id="lblIMSeq" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_imseq").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="8%">
											<asp:Label id="lblIMName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "im_nm").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="11%">
											<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "srspn_cname").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="10%">
											<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_moddate").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD width="*">
											&nbsp;
										</TD>
									</TR>
									<TR style="COLOR: #000000" bgColor="#BFCFF0">
										<TD>
											&nbsp;
										</TD>
										<TD>
											廣告金額
										</TD>
										<TD>
											換稿金額
										</TD>
										<TD>
											已開立
											<BR>
											發票單
										</TD>
										<TD>
											發票開立單
											<BR>
											人工處理
										</TD>
										<TD>
											計劃代號
										</TD>
										<TD>
											成本中心
										</TD>
										<TD colSpan="4">
											備註
										</TD>
									</TR>
									<TR vAlign="top">
										<TD>
											&nbsp;
										</TD>
										<TD>
											$
											<asp:Label id="lblAdamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_adamt").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											$
											<asp:Label id="lblChgAmt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgamt").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblfgInved" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fginved").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblfgInvSelf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fginvself").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblProjNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_projno").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblCostCtr" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_costctr").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD colSpan="4">
											<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_remark").ToString().Trim() %>'>
											</asp:Label>
										</TD>
									</TR>
									<TR style="COLOR: #000000" bgColor="#BFCFF0">
										<TD>
											&nbsp;
										</TD>
										<TD>
											稿件類別
										</TD>
										<TD>
											到稿
										</TD>
										<TD>
											新稿製法
										</TD>
										<TD>
											改稿書類
										</TD>
										<TD>
											改稿期別
										</TD>
										<TD>
											改稿頁碼
										</TD>
										<TD>
											改稿重出片
										</TD>
										<TD>
											舊稿書類
										</TD>
										<TD>
											舊稿期別
										</TD>
										<TD>
											舊稿頁碼
										</TD>
									</TR>
									<TR vAlign="top">
										<TD>
											&nbsp;
										</TD>
										<TD>
											<asp:Label id="lblDrafttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_drafttp").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblfgGot" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fggot").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblfgNjtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "njtp_nm").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblChgbkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgbkcd").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblChgJNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgjno").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblChgJbkno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgjbkno").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblfgReChg" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fgrechg").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblOrigBkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bk_nm").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblOrigJNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_origjno").ToString().Trim() %>'>
											</asp:Label>
										</TD>
										<TD>
											<asp:Label id="lblOrigJbkno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_origjbkno").ToString().Trim() %>'>
											</asp:Label>
										</TD>
									</TR>
								</ItemTemplate>
							</asp:DataList>
							<br>
							<asp:Label id="lblPubMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:Label>
						</TD>
					</TR>
					<!-- 視窗按鈕 -->
					<TR bgColor="#ffffff">
						<TD align="middle" colSpan="4">
							<br>
							<INPUT id="btnCloseWin2" onclick="javascript:window.close();" type="button" value="關閉視窗">
							<INPUT id="btnPrintWin2" onclick="javascript:window.print();" type="button" value="列印本頁">
						</TD>
					</TR>
				</TABLE>
			</form>
		</center>
	</body>
</HTML>
