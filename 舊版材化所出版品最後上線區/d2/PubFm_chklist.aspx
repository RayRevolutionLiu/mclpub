<%@ Page language="c#" Codebehind="PubFm_chklist.aspx.cs" Src="PubFm_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm_chklist" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>落版檢核表</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
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
					<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							落版檢核表</font>
					</td>
				</tr>
			</table>
		</center>
		<!-- Run at Server Form-->
		<form id="PubFm_chklist" method="post" runat="server">
			<asp:checkbox id="cbx0" runat="server"></asp:checkbox><asp:label id="lblQuery" runat="server">落版年月區間：</asp:label>
			<asp:textbox id="tbxDate1" runat="server" Width="50px" MaxLength="7"></asp:textbox>
			～
			<asp:textbox id="tbxDate2" runat="server" Width="50px" MaxLength="7"></asp:textbox>
			&nbsp;
			<asp:Label id="lblSEDateMemo" runat="server" Font-Size="X-Small" ForeColor="Maroon">(如 2002/07  ～ 2002/07)</asp:Label>
			<br>
			<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
			<asp:Label id="lblContNo" runat="server">合約書編號：</asp:Label>
			<asp:TextBox id="tbxContNo" runat="server" MaxLength="6" Width="50px" Font-Size="X-Small"></asp:TextBox>
			<br>
			<asp:CheckBox id="cbx5" runat="server"></asp:CheckBox>
			<asp:Label id="lblMfrIName" runat="server">廠商名稱：</asp:Label>
			<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small" MaxLength="50"></asp:TextBox>
			<br>
			<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>
			&nbsp;
			<asp:Button id="btnClear" runat="server" Text="清除重查"></asp:Button>
			&nbsp;
			<asp:button id="btnBack" runat="server" Text="返回首頁"></asp:button>
			&nbsp; <INPUT id="btnClose" onclick="doClose()" type="button" value="關閉視窗" name="btnClose">
			<br>
			&nbsp;<font color="red" size="2"><b>請按下 '查詢' 按鈕來檢查資料!</b></font>
			<br>
			<asp:label id="lblRecordCount" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="新細明體">
				<ItemStyle BorderColor="Black"></ItemStyle>
				<ItemTemplate>
					<TABLE width="100%" border="1" bgColor="#e6ebf9" borderColor="#000000" cellSpacing="1" cellPadding="0" align="center" style="FONT-SIZE: x-small">
						<!-- 標題 -->
						<!-- 合約編號 & 其相關資料 -->
						<TR style="COLOR: white" bgColor="#21418c" align="center" valign="top">
							<TD>
								合約書
								<BR>
								編號
							</TD>
							<TD style="LETTER-SPACING: 10px" valign="middle">
								合約書/落版/發票廠商收件人資料
							</TD>
						</TR>
						<TR vAlign="top">
							<TD bgColor="#e6ebf9" width="7%" style="FONT-WEIGHT: bold">
								&nbsp;
								<asp:Label id="lblContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_contno").ToString().Trim() %>'>
								</asp:Label>
							</TD>
							<TD width="*" style="COLOR: #ffffff" bgColor="#5980d9">
								&nbsp;合約書資料：
							</TD>
						</TR>
						<TR vAlign="top">
							<TD Rowspan="5">
								&nbsp;
							</TD>
							<TD>
								<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff" BorderColor="#000000"></ItemStyle>
									<Columns>
										<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
										<asp:BoundColumn DataField="cust_nm" HeaderText="客戶名稱"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付款"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_totjtm" HeaderText="總製稿"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_tottm" HeaderText="總刊登"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_chgjtm" HeaderText="換稿次數"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_freetm" HeaderText="贈送次數"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_clrtm" HeaderText="彩色"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_getclrtm" HeaderText="套色"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_menotm" HeaderText="黑白"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_totamt" HeaderText="總金額"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_adamt" HeaderText="廣告費單價"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_aunm" HeaderText="聯絡人姓名"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_autel" HeaderText="連絡電話"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
						<!-- 合約書資料 -->
						<!-- 落版細節 -->
						<TR style="COLOR: #ffffff" bgColor="#5980d9">
							<TD>
								&nbsp;落版細節：
								<BR>
							</TD>
						</TR>
						<TR>
							<TD>
								<asp:DataList id="DataList2" runat="server" border="1">
									<ItemStyle BorderColor="#00000" BorderWidth="1px"></ItemStyle>
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
												</asp:Label>
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
											<TD bgColor="#e6ebf9">
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
											<TD bgColor="#e6ebf9">
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
							</TD>
						</TR>
						<!-- 發票廠商收件人 -->
						<TR style="COLOR: #ffffff" bgColor="#5980d9">
							<TD>
								&nbsp;發票廠商收件人：
								<BR>
							</TD>
						</TR>
						<TR>
							<TD>
								<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
									<HeaderStyle BackColor="#BFCFF0" HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle BackColor="#e7ebff" BorderColor="#000000"></ItemStyle>
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
					</TABLE>
				</ItemTemplate>
				<SeparatorTemplate>
					<font color='DarkRed'><B>＊除金額等重要值要注意外，也請確認”計劃代號”及”成本中心”的值！</B></font>
					<HR id="hr" width="100%" SIZE="2" color="#AAAAAA">
					<br>
				</SeparatorTemplate>
			</asp:datalist></form>
			<!-- 表尾: 版權區 -->
			<kw:Footer runat="server" />	
	</body>
</HTML>
