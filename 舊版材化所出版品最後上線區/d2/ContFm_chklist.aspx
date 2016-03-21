<%@ Page language="c#" Codebehind="ContFm_chklist.aspx.cs" src="ContFm_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_chklist" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>合約書檢核表</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		function pick_date(theField){
		var oParam = new Object();
		strFeature = "";
		strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
		var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
		if(vreturn)
			window.document.all(theField).value=vreturn;
		return true;
		}
		
		function doClose()
		{
			window.close();
		}
	</script>
	</HEAD>
	<body>
		<center>
			<!-- 表頭: 主功能選單 -->
			<kw:Header runat="server" />
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							合約書檢核表</font>
					</td>
				</tr>
			</table>
		</center>
		<!-- Run at Server Form-->
		<form id="ContFm_chklist" method="post" runat="server">
			<asp:CheckBox id="cbx0" runat="server"></asp:CheckBox>
			<asp:label id="lblSignDate" runat="server">簽約日期區間：</asp:label>
			<asp:textbox id="tbxSignDate1" runat="server" MaxLength="10" Width="70px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxSignDate1.name)" src="../images/calendar01.gif">
			～
			<asp:textbox id="tbxSignDate2" runat="server" MaxLength="10" Width="70px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxSignDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
			<asp:Label id="lblSEDate" runat="server">合約起迄區間：</asp:Label>
			<asp:TextBox id="tbxSDate" runat="server" Width="50px"></asp:TextBox>
			～
			<asp:TextBox id="tbxEDate" runat="server" Width="50px"></asp:TextBox>
			&nbsp;
			<asp:Label id="lblSEDateMemo" runat="server" Font-Size="X-Small" ForeColor="Maroon">(如 200206  ～ 200212)</asp:Label>
			<br>
			<asp:CheckBox id="cbx2" runat="server"></asp:CheckBox>
			<asp:Label id="lblfgclosed" runat="server">已結案：</asp:Label>
			<asp:DropDownList id="ddlfgclosed" runat="server">
				<asp:ListItem Value="1">是</asp:ListItem>
				<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:CheckBox id="cbx3" runat="server"></asp:CheckBox>
			<asp:Label id="lblEmpNo" runat="server">承辦業務員：</asp:Label>
			<asp:DropDownList id="ddlEmpNo" runat="server"></asp:DropDownList>
			<br>
			<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
			<asp:Label id="lblContNo" runat="server">合約書編號：</asp:Label>
			<asp:TextBox id="tbxContNo" runat="server" Width="50px" MaxLength="6" Font-Size="X-Small"></asp:TextBox>
			<br>
			<asp:CheckBox id="cbx5" runat="server"></asp:CheckBox>
			<asp:Label id="lblMfrIName" runat="server">廠商名稱：</asp:Label>
			<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small"></asp:TextBox>
			<br>
			<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>
			&nbsp;
			<asp:Button id="btnClear" runat="server" Text="清除重查"></asp:Button>
			&nbsp;
			<asp:Button id="btnBack" runat="server" Text="返回首頁"></asp:Button>
			&nbsp; <INPUT id="btnClose" name="btnClose" type="button" value="關閉視窗" onclick="doClose()">&nbsp;&nbsp;
			<br>
			&nbsp;<font size="2" color="red"><b>請按下 '查詢' 按鈕來檢查資料!</b></font>
			<br>
			<asp:label id="lblRecordCount" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="新細明體" border="1">
				<ItemTemplate>
					<TABLE width="100%" bgColor="#e6ebf9" borderColor="#666666" cellSpacing="1" cellPadding="0" align="center" style="FONT-SIZE: x-small" border="1">
						<!-- 標題 -->
						<TR style="COLOR: white" bgColor="#21418c">
							<TD>
								合約書編號
							</TD>
							<TD colSpan="3">
								廠商名稱
								<BR>
								(廠商統編)
							</TD>
							<TD>
								客戶名稱
								<BR>
								(編號)
							</TD>
							<TD>
								簽約日期
							</TD>
							<TD>
								合約類別
							</TD>
							<TD>
								書籍類別
							</TD>
							<TD>
								合約起迄
							</TD>
							<TD>
								建檔
								<BR>
								業務員 /
								<BR>
								修改者
							</TD>
							<TD>
								一次
								<BR>
								付清
							</TD>
							<TD>
								結案
							</TD>
							<TD>
								參考
								<BR>
								合約
								<BR>
								編號
							</TD>
							<TD>
								建檔日期 /
								<BR>
								修改日期
							</TD>
						</TR>
						<!-- 輸出內容 -->
						<TR vAlign="top">
							<TD width="6%" style="FONT-WEIGHT: bold">
								<asp:Label id="lblContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_contno") %>'></asp:Label>
							</TD>
							<TD width="*" colSpan="3">
								<asp:Label id="lblMfrIName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm").ToString().Trim() %>'></asp:Label>
								(
								<asp:Label id="lblMfrNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_mfrno").ToString().Trim() %>'></asp:Label>
								)&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblCustName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_nm").ToString().Trim() %>'></asp:Label>
								&nbsp;
								<BR>
								(
								<asp:Label id="lblCustNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_custno").ToString().Trim() %>'></asp:Label>
								)&nbsp;
							</TD>
							<TD width="6%">
								<asp:Label id="lblSignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_signdate").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblConttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_conttp").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblBkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bk_nm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_sdate").ToString().Trim() %>'></asp:Label>
								&nbsp;~
								<BR>
								<asp:Label id="lblEndDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_edate").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="9%">
								<asp:Label id="lblEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "srspn_cname").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_modempno").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD width="3%">
								<asp:Label id="lblfgPayonce" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgpayonce").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="6%">
								<asp:Label id="lblfgClosed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgclosed").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblOldContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_oldcontno").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_credate").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_moddate").ToString().Trim() %>'></asp:Label>
							</TD>
						</TR>
						<TR style="COLOR: #000000" bgColor="#BFCFF0">
							<TD bgColor="#e6ebf9">
								&nbsp;
							</TD>
							<TD>
								總製稿
								<BR>
								次數
							</TD>
							<TD>
								已製稿
								<BR>
								次數
							</TD>
							<TD>
								剩餘
								<BR>
								製稿
								<BR>
								次數
							</TD>
							<TD>
								總刊登
								<BR>
								次數
							</TD>
							<TD>
								已刊登
								<BR>
								次數
							</TD>
							<TD>
								剩餘
								<BR>
								刊登
								<BR>
								次數
							</TD>
							<TD>
								合約
								<BR>
								總金額
							</TD>
							<TD>
								已繳
								<BR>
								金額
							</TD>
							<TD>
								剩餘
								<BR>
								金額
							</TD>
							<TD>
								換稿
								<BR>
								次數
							</TD>
							<TD>
								贈送
								<BR>
								次數 /
								<BR>
								本數
							</TD>
							<TD>
								廣告費
								<BR>
								單價
							</TD>
							<TD>
								優惠折扣
							</TD>
						</TR>
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblTotjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblMadejtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_madejtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblRestjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblTottm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_tottm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblPubtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblResttm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_resttm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblTotamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPaidamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_paidamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblRestamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblChgjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_chgjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblFreetm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freetm").ToString().Trim() %>'></asp:Label>
								&nbsp; / &nbsp;
								<asp:Label id="lblFreebkcnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freebkcnt").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD>
								$
								<asp:Label id="lblAdamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_adamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblDiscount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_disc").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
						</TR>
						<TR style="COLOR: #000000" bgColor="#BFCFF0">
							<TD bgColor="#e6ebf9">
								&nbsp;
							</TD>
							<TD>
								彩色
								<BR>
								次數
							</TD>
							<TD>
								套色
								<BR>
								次數
							</TD>
							<TD>
								黑白
								<BR>
								次數
							</TD>
							<TD>
								落版
								<BR>
								總廣告
								<BR>
								金額
							</TD>
							<TD>
								落版
								<BR>
								總換稿
								<BR>
								金額
							</TD>
							<TD>
								&nbsp;
							</TD>
							<TD>
								聯絡人
								<BR>
								姓名
							</TD>
							<TD>
								電話
							</TD>
							<TD>
								傳真
							</TD>
							<TD>
								手機
								<BR>
								/ Email
							</TD>
							<TD colSpan="3">
								備註
							</TD>
						</TR>
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblClrtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_clrtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblGetclrtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_getclrtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblMenotm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_menotm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPubamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPubchgamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_chgamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aunm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_autel").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aufax").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuCell" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aucell").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblAuEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_auemail").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD colSpan="3">
								<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_remark").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
						</TR>
						<!-- 發票廠商收件人 -->
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
								&nbsp;發票廠商收件人：
								<BR>
								<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff"></ItemStyle>
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
								</asp:DataGrid>
							</TD>
						</TR>
						<!-- 雜誌收件人 -->
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
								&nbsp;雜誌收件人：
								<BR>
								<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff"></ItemStyle>
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
								</asp:DataGrid>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<SeparatorTemplate>
					<HR id="hr" width="100%" SIZE="2" color="Orange">
					<br>
				</SeparatorTemplate>
			</asp:datalist>
			<br>
			<br>
			<asp:label id="lblMemo1" runat="server" ForeColor="#C04000" Font-Size="X-Small">說明：<br>此檢核表列示之合約書是尚未產生發票開立單之資料, <br>已產生發票開立單之合約書資料不會在此列示.<br></asp:label>
			<br>
		</form>
			<!-- 表尾: 版權區 -->
			<kw:Footer runat="server" />		
	</body>
</HTML>
