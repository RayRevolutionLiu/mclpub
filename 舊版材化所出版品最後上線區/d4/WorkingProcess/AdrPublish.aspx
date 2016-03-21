<%@ Page language="c#" Codebehind="AdrPublish.aspx.cs" Src="AdrPublish.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrPublish" %>
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
		<form id="AdrPublish" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="95%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										廣告落版處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										落版資料維護</FONT>
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
									<TABLE class="TableColor" id="Table11" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>合約編號</TD>
											<TD>合約類別</TD>
											<TD>簽約日期</TD>
											<TD>合約起迄</TD>
											<TD>廠商名稱</TD>
											<TD>客戶名稱</TD>
											<TD>刊登次數</TD>
											<TD>贈送次數</TD>
											<TD>合約金額</TD>
											<TD>優惠折數</TD>
											<TD>顯示合約</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>～<asp:label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblMfrNm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblCustNm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><A href="ContShow.aspx?ContNo=<% Response.Write(lblContNo.Text); %>" target=_blank ><IMG alt="詳細" src="..\..\images\new.gif" border="0" name="imgShowCont"></A></TD>
										</TR>
									</TABLE>
									<TABLE class="TableColor" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>總刊登次數</TD>
											<TD>已刊登次數</TD>
											<TD>剩餘刊登次數</TD>
											<TD>總製圖檔稿次數</TD>
											<TD>剩餘製圖檔稿次數</TD>
											<TD>總製網頁稿次數</TD>
											<TD>剩餘製網頁稿次數</TD>
											<TD>首頁落版總次數</TD>
											<TD>內頁落版總次數</TD>
											<TD>奈米頁落版總次數</TD>
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
								<TD class="TableColorHeader">發票廠商收件人資料<IMG onclick='doOpenInvMfr(<% Response.Write("\""+lblContNo.Text+"\""); %>, "", "")' alt=新增/修改 src="..\..\images\new.gif" name=imgAddInvMfr ></TD>
							</TR>
							<tr>
								<td><asp:datagrid id="dgdNewInvMfr1" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="im_imseq" HeaderText="序號">
												<ItemStyle Width="25px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編">
												<ItemStyle Width="60px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名">
												<ItemStyle Width="60px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_jbti" HeaderText="稱謂"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
											<asp:BoundColumn DataField="invcd" HeaderText="發票類別"></asp:BoundColumn>
											<asp:BoundColumn DataField="taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
											<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</TABLE>
						<TABLE class="TableColor" id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TBODY>
								<TR>
									<TD class="TableColorHeader" colSpan="4">廣告資料</TD>
								</TR>
								<TR>
									<TD align="right">廣告起訖日期</TD>
									<TD colspan="3"><asp:textbox id="tbxSDate" runat="server" Width="83px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">~
										<asp:textbox id="tbxEDate" runat="server" Width="88px" AutoPostBack="True"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
										共<asp:textbox ID="tbxCountDay" Runat="server" Width="39px" ReadOnly="True" ForeColor="Red">0</asp:textbox>天<asp:Button id="btnCount" runat="server" Text="計算天數"></asp:Button></TD>
								</TR>
								<TR>
									<TD align="right">廣告標語</TD>
									<TD><asp:textbox id="tbxAltText" runat="server"></asp:textbox></TD>
									<TD align="right">發票廠商</TD>
									<TD><asp:dropdownlist id="ddlInvMfr" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="right">廣告頁面</TD>
									<TD><asp:dropdownlist id="ddlAdCate" runat="server">
											<asp:ListItem Value="M" Selected="True">首頁</asp:ListItem>
											<asp:ListItem Value="I">內頁</asp:ListItem>
											<asp:ListItem Value="N">奈米</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD align="right">廣告位置</TD>
									<TD><asp:dropdownlist id="ddlKeyword" runat="server">
											<asp:ListItem Value="h0" Selected="True">正中</asp:ListItem>
											<asp:ListItem Value="h1">右一</asp:ListItem>
											<asp:ListItem Value="h2">右二</asp:ListItem>
											<asp:ListItem Value="h3">右三</asp:ListItem>
											<asp:ListItem Value="h4">右四</asp:ListItem>
											<asp:ListItem Value="w1">右文一</asp:ListItem>
											<asp:ListItem Value="w2">右文二</asp:ListItem>
											<asp:ListItem Value="w3">右文三</asp:ListItem>
											<asp:ListItem Value="w4">右文四</asp:ListItem>
											<asp:ListItem Value="w5">右文五</asp:ListItem>
											<asp:ListItem Value="w6">右文六</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="right">播放方式</TD>
									<TD><asp:radiobuttonlist id="rblFgFixAd" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">輪播</asp:ListItem>
											<asp:ListItem Value="1">定播</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD align="right">播放機率</TD>
									<TD><asp:textbox id="tbxImpr" runat="server" MaxLength="2" Width="40px"></asp:textbox><A onclick='javascript:window.open("AdrFreeSlots.aspx", "SLOTS", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=600,height=600", false);return false;' href="#">廣告剩餘空間表</A></TD>
								</TR>
								<TR>
									<TD align="right">圖稿類別?</TD>
									<TD><asp:radiobuttonlist id="rblImgTp" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
											<asp:ListItem Value="2">新稿</asp:ListItem>
											<asp:ListItem Value="3">改稿</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD align="right">URL類別?</TD>
									<TD><asp:radiobuttonlist id="rblUrlTp" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
											<asp:ListItem Value="2">新稿</asp:ListItem>
											<asp:ListItem Value="3">改稿</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="right">廣告價格</TD>
									<TD><asp:textbox id="tbxAdAmt" runat="server"></asp:textbox></TD>
									<TD align="right">廣告連結</TD>
									<TD><asp:textbox id="tbxNavUrl" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="right">換稿費用</TD>
									<TD><asp:textbox id="tbxChgAmt" runat="server"></asp:textbox></TD>
									<TD align="right">備註</TD>
									<TD><asp:textbox id="tbxRemark" runat="server"></asp:textbox></TD>
								</TR>
								<tr>
									<TD align="right">設計價格</TD>
									<TD><asp:textbox id="tbxDesAmt" runat="server"></asp:textbox></TD>
								</tr>
								<TR>
									<TD align="right">落版金額</TD>
									<TD><asp:textbox id="tbxInvAmt" runat="server" CssClass="ReadOnlyTextBox" ReadOnly="True"></asp:textbox></TD>
									<TD colSpan="2"><asp:button id="bthAddAdr" runat="server" Text="新增落版資料"></asp:button></TD>
								</TR>
							</TBODY>
						</TABLE>
						<TABLE class="TableColor" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="6">已落版資料</TD>
							</TR>
							<tr>
								<td>
									<TABLE id="Table6" cellSpacing="1" cellPadding="1" border="1">
										<TR>
											<TD class="TableColor" width="100">廣告總金額</TD>
											<TD align="left" width="80" bgColor="#ecebff"><asp:label id="lblTotAdAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD class="TableColor" width="100">設計總金額</TD>
											<TD align="left" width="80" bgColor="#ecebff"><asp:label id="lblTotDesAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD class="TableColor" width="100">換稿總金額</TD>
											<TD align="left" width="80" bgColor="#ecebff"><asp:label id="lblTotChgAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TableColor">已落版總金額</TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotPubedAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD class="TableColor" colSpan="4"><FONT face="新細明體"><asp:label id="lblHint" runat="server" CssClass="ImportantLabel">已落版總金額=廣告總金額+設計總金額+換稿總金額，合約金額僅包含廣告金額部分</asp:label></FONT></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td><asp:button id="btnSelAll" runat="server" Text="全選"></asp:button><asp:button id="btnDeSelAll" runat="server" Text="清選"></asp:button><asp:button id="btnDelSeltedAdr" runat="server" Text="刪除選擇項目"></asp:button><asp:label id="lblAdrInfo" runat="server" CssClass="NormalLabel" ForeColor="Maroon"></asp:label><input id="hiddenAdrImpr" type="hidden" runat="server"></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="刪除">
												<ItemTemplate>
													<asp:CheckBox id="cbxDelAdr" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:EditCommandColumn ItemStyle-Wrap="False" ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
											<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="序號">
												<HeaderStyle Width="25px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="播出日期">
												<HeaderStyle Width="60px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_alttext" HeaderText="廣告標語">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="廣告頁面">
												<ItemTemplate>
													<asp:Label id=lblEAdCate runat="server" Text='<%# MatchAdCate(DataBinder.Eval(Container.DataItem, "adr_adcate")) %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="ddlEAdCate" runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="廣告位置">
												<ItemTemplate>
													<asp:Label id=lblEKeyword runat="server" Text='<%# MatchKeyword(DataBinder.Eval(Container.DataItem, "adr_keyword")) %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="ddlEKeyword" runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="adr_navurl" HeaderText="廣告連結">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_impr" HeaderText="播放機率">
												<HeaderStyle Width="25px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_adamt" HeaderText="廣告價格">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_desamt" HeaderText="設計價格">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_chgamt" HeaderText="換稿費用">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_invamt" ReadOnly="True" HeaderText="落版金額">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="發票廠商">
												<ItemTemplate>
													<asp:Label id=lblInvMfr runat="server" Text='<%# MatchImSeq(DataBinder.Eval(Container.DataItem, "adr_imseq")) %>'>
													</asp:Label>
												</ItemTemplate>
												<EditItemTemplate>
													<asp:DropDownList id="ddlEInvMfr" runat="server"></asp:DropDownList>
												</EditItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="adr_remark" HeaderText="備註">
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
											<asp:BoundColumn Visible="False" DataField="adr_fginved" ReadOnly="True" HeaderText="發票註記">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn ReadOnly="True" HeaderText="發票註記">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除選擇項目")
				event.returnValue=confirm("確定要刪除所選擇的資料)?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
