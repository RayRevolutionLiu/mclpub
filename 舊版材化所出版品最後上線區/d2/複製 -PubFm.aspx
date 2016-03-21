<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="PubFm.aspx.cs" Src="PubFm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>落版 - 新增/維護/刪除 落版內容</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<CENTER><kw:header id="Header" runat="server"></kw:header></CENTER>
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						落版 - 新增/維護/刪除落版 步驟二: 新增/維護/刪除 落版內容</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="PubFm" method="post" runat="server">
			<!-- 已新增 落版資料 區 --><FONT color="#ff0066" size="2">[已新增 落版資料 區]</FONT>
			<asp:label id="lblPubCounts" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><asp:textbox id="tbxSysCode" runat="server" Font-Size="x-Small" DESIGNTIMEDRAGDROP="1502" Enabled="False" WIDTH="30px" MaxLength="2" Visible="False" BorderWidth="0px">C2</asp:textbox><asp:label id="lblContNo" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxContNo" runat="server" Font-Size="x-Small" Enabled="False" WIDTH="50px" MaxLength="6" BorderWidth="0px"></asp:textbox><asp:textbox id="tbxMfrNo" runat="server" Font-Size="X-Small" Enabled="False" MaxLength="10" BorderWidth="0px" Width="150px"></asp:textbox><asp:textbox id="tbxCustNo" runat="server" Font-Size="X-Small" Enabled="False" MaxLength="7" BorderWidth="0px" Width="100px"></asp:textbox><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="修改" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="刪除" HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="書籍期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="頁碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="ltp_nm" HeaderText="廣告版面"></asp:BoundColumn>
					<asp:BoundColumn DataField="clr_nm" HeaderText="廣告色彩"></asp:BoundColumn>
					<asp:BoundColumn DataField="pgs_nm" HeaderText="廣告篇幅"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="固定頁次"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_drafttp" HeaderText="稿類"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_origjno" HeaderText="舊稿期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgjno" HeaderText="改稿期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_adamt" HeaderText="廣告金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgamt" HeaderText="換稿金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fginved" HeaderText="已開發票開立單"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fginvself" HeaderText="發票人工處理"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="pub_fginved" HeaderText="已開發票開立單註記"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="pub_fginvself" HeaderText="發票人工處理註記"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_projno" HeaderText="計劃代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_costctr" HeaderText="成本中心"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="im_fgitri" HeaderText="院所內註記代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="fgitri_name" HeaderText="院所內註記"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:label id="lblDraftCounts" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><FONT color="#ff0066" size="2">&nbsp;
				<asp:label id="lblAmtCounts" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><INPUT id="hiddenMfrNo" type="hidden" size="3" name="hiddenMfrNo" runat="server">&nbsp;
				<INPUT id="hiddenCustNo" type="hidden" size="3" name="hiddenCustNo" runat="server">
			</FONT>
			<br>
			<asp:label id="lblAddMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><br>
			<!-- 落版資料 新增/修改 區 --><font color="#ff0066" size="2">[落版資料 新增/修改 區]</font>&nbsp;&nbsp;
			<asp:textbox id="tbxBookName" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="55px"></asp:textbox><asp:textbox id="tbxBkcd" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;
			<asp:label id="lblYYYMMMessage" runat="server" ForeColor="Gray" Font-Size="X-Small">刊登年月合理範圍：</asp:label><asp:textbox id="tbxStartDate" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="40px"></asp:textbox><font color="gray" size="2">～</font>
			<asp:textbox id="tbxEndDate" runat="server" Font-Size="x-Small" Enabled="False" BorderWidth="0px" Width="40px"></asp:textbox><br>
			<asp:label id="lblContMessage" runat="server" ForeColor="Blue" Font-Size="X-Small" Enabled="False" BorderWidth="0px"></asp:label><asp:label id="lblTotjtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxTotjtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;
			<asp:label id="lblTottm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxTottm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;
			<asp:label id="lblChgjtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxChgjtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox>&nbsp;&nbsp;&nbsp;
			<asp:label id="lblFreetm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxFreetm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="20px"></asp:textbox><font color="gray" size="2">(<IMG class=ico id=imgContDetail onclick="javascript:window.open('ContFm_show.aspx?custno=<% Response.Write(hiddenCustNo.Value); %>&amp;old_contno=<% Response.Write(tbxContNo.Text); %>', '_new', 'Height=470, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt=顯示合約書資料 src="../images/edit.gif" width=18 border=0 >顯示合約書資料)</font>
			<br>
			<asp:label id="lblClrtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label>&nbsp;
			<asp:textbox id="tbxClrtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" MaxLength="3" BorderWidth="0px" Width="30px"></asp:textbox>&nbsp;
			<asp:label id="lblGetClrtm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label>&nbsp;
			<asp:textbox id="tbxGetClrtm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" MaxLength="3" BorderWidth="0px" Width="30px"></asp:textbox>&nbsp;
			<asp:label id="lblMenotm" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxMenotm" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" MaxLength="3" BorderWidth="0px" Width="30px"></asp:textbox><asp:label id="lblTotamt" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxTotamt" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="60px"></asp:textbox><asp:label id="lblContAdamt" runat="server" ForeColor="Gray" Font-Size="X-Small"></asp:label><asp:textbox id="tbxContAdamt" runat="server" ForeColor="Red" Font-Size="X-Small" Enabled="False" BorderWidth="0px" Width="60px"></asp:textbox>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" width="100%" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							序號
						</TH>
						<TH>
							<FONT color="#c00000">*</FONT>刊登年月
							<br>
							<font color="#c00000" size="2">(請填範圍內,
								<br>
								如 200207)</font>
						</TH>
						<TH>
							<FONT color="#c00000">*</FONT>書籍期別
						</TH>
						<TH>
							刊登頁碼
						</TH>
						<TH>
							廣告版面 <IMG class="ico" id="imgLPrior" title="顯示版面優先次序資料" onclick="doGetLPrior(this)" src="../images/edit.gif" border="0">
						</TH>
						<TH>
							廣告色彩
						</TH>
						<TH>
							廣告篇幅
						</TH>
						<TH>
							<FONT color="#c00000">*</FONT> 固定頁次
						</TH>
						<TH align="left" colSpan="3">
							發票廠商收件人 姓名
							<br>
							<font color="gray">(詳細資料 <IMG class=ico title="新增/修改/刪除 發票廠商收件人" onclick="javascript:window.open('InvMfrForm.aspx?contno=<% Response.Write(tbxContNo.Text); %>&amp;custno=<% Response.Write(hiddenCustNo.Value); %>&amp;old_contno=0&amp;fgnew=1', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" height=18 src="../images/new.gif" border=0 >)</font>
						</TH>
					</TR>
				</THEAD>
				<TR bgColor="#e2eafc">
					<TD><asp:label id="lblPubSeq" runat="server"></asp:label></TD>
					<TD><INPUT id="tbxYYYYMM" onblur="Javascript:CheckYYYYMM(this);" type="text" maxLength="6" onchange="Javascript:CheckYYYYMM2(this);" size="6" name="tbxPubDate" runat="server">
					</TD>
					<TD><INPUT id="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);" type="text" maxLength="4" size="3" name="tbxBkpPno" runat="server">&nbsp;
						<IMG class="ico" id="imgBookpno" title="書籍期別參考資料" onclick="Javascript:doGetBookp(this);" src="../images/edit.gif" border="0">
					</TD>
					<TD align="middle"><asp:textbox id="tbxPageNo" runat="server" MaxLength="3" Width="30px"></asp:textbox></TD>
					<TD><asp:dropdownlist id="ddlLTypeCode" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlColorCode" runat="server"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="ddlPageSizeCode" runat="server"></asp:dropdownlist></TD>
					<TD><asp:radiobuttonlist id="rblfgfixpage" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">是</asp:ListItem>
							<asp:ListItem Value="0">否</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlIMSeq" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:imagebutton id="imbIMRefresh" runat="server" AlternateText="重新整理 發票廠商收件人資料" ImageUrl="../images/refresh.gif"></asp:imagebutton>&nbsp;
						<asp:label id="lblIMCount" runat="server" ForeColor="Maroon" Font-Size="XX-Small"></asp:label><INPUT id="hiddenIMfgitri" type="hidden" size="3" name="hiddenIMfgitri" runat="server">
					</TD>
				</TR>
				<!-- 第二行 -->
				<TR>
					<TH>
						&nbsp;
					</TH>
					<TH align="left" colSpan="2">
						廣告金額
						<br>
						<font color="#c00000" size="2">(預設同 廣告費單價)</font>
					</TH>
					<TH align="left" colSpan="2">
						換稿金額
					</TH>
					<TH align="left" colSpan="6">
						&nbsp;&nbsp;備註
						<br>
						<FONT color="#c00000" size="2">(最多輸入25個中文字)</FONT>
					</TH>
				</TR>
				<TR bgColor="#e2eafc">
					<TD>&nbsp;
					</TD>
					<TD colSpan="2"><FONT face="新細明體">$</FONT>
						<asp:textbox id="tbxAdAmt" runat="server" MaxLength="10" Width="50px"></asp:textbox></TD>
					<TD align="left" colSpan="2"><FONT face="新細明體">$</FONT>
						<asp:textbox id="tbxChgAmt" runat="server" MaxLength="10" Width="50px"></asp:textbox></TD>
					<TD colSpan="6"><asp:textbox id="tbxRemark" runat="server" MaxLength="25" Width="350px"></asp:textbox></TD>
				</TR>
				<!-- 第三行 -->
				<TR>
					<TH>
						&nbsp;
					</TH>
					<TH>
						<FONT color="#c00000" size="2">*</FONT>稿件類別
					</TH>
					<TH>
						<FONT color="#c00000" size="2">*</FONT>到稿
					</TH>
					<TH>
						新稿製法
					</TH>
					<TH>
						改稿書類
					</TH>
					<TH>
						改稿期別
					</TH>
					<TH>
						改稿頁碼
					</TH>
					<TH>
						改稿重出片
					</TH>
					<TH>
						舊稿書類
					</TH>
					<TH>
						舊稿期別
					</TH>
					<TH>
						舊稿頁碼
					</TH>
				</TR>
				<TR bgColor="#e2eafc">
					<TD>&nbsp;
					</TD>
					<TD><asp:dropdownlist id="ddlDraftType" runat="server" AutoPostBack="True">
							<asp:ListItem Value="1">舊稿</asp:ListItem>
							<asp:ListItem Value="2">新稿</asp:ListItem>
							<asp:ListItem Value="3">改稿</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:radiobuttonlist id="rblfggot" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">是</asp:ListItem>
							<asp:ListItem Value="0">否</asp:ListItem>
						</asp:radiobuttonlist>&nbsp;
					</TD>
					<TD><asp:panel id="pnlNjtp" runat="server">
							<asp:DropDownList id="ddlNJTypeCode" runat="server"></asp:DropDownList>
						</asp:panel>&nbsp;
					</TD>
					<TD colSpan="3"><asp:panel id="pnlChg" runat="server">
							<asp:DropDownList id="ddlChgBookCode" runat="server" AutoPostBack="True"></asp:DropDownList>
							<asp:textbox id="tbxChgjno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
							<IMG class="ico" title="改稿頁碼參考資料" onclick="doGetPgNo2(this)" src="../images/edit.gif" border="0">
							<asp:textbox id="tbxChgbkno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
						</asp:panel>&nbsp;
					</TD>
					<TD style="BORDER-LEFT-WIDTH: 0px; BORDER-LEFT-COLOR: #e2eafc">&nbsp;
						<asp:radiobuttonlist id="rblfgrechg" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">是</asp:ListItem>
							<asp:ListItem Value="0">否</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD colSpan="3"><asp:panel id="pnlOrig" runat="server">
							<asp:DropDownList id="ddlOrigBookCode" runat="server" AutoPostBack="True"></asp:DropDownList>
							<asp:textbox id="tbxOrigjno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
							<IMG class="ico" title="舊稿頁碼參考資料" onclick="doGetPgNo1(this)" src="../images/edit.gif" border="0">
							<asp:textbox id="tbxOrigbkno" runat="server" MaxLength="3" Width="30px"></asp:textbox>
						</asp:panel>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<FONT color="#c00000" size="2">* 為必填欄位!&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:label id="lblProjCostMessage" runat="server" ForeColor="Navy" Font-Size="X-Small"></asp:label><IMG class="ico" id="imgProjNoCostctr" onclick="javascript:window.open('../d5/proj.aspx', '_new', 'Height=470, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="顯示計劃代號資料" src="../images/edit.gif" width="18" border="0"><asp:label id="lblProjNo" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:label>&nbsp;
				<asp:label id="lblCostCtr" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:label><asp:label id="lblfgITRI" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label></FONT><br>
			<asp:button id="btnSave" runat="server" Text="儲存新增"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="儲存修改"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="載入預設資料"></asp:button>&nbsp;
			<asp:button id="btnGoChkList" runat="server" Text="前往落版檢核表"></asp:button><asp:regularexpressionvalidator id="revPgNo" runat="server" Font-Size="X-Small" ControlToValidate="tbxPageNo" ValidationExpression="\d{0,3}" ErrorMessage="刊登頁碼必須為數字型態, 請更正, 否則資料無法新增!"></asp:regularexpressionvalidator><asp:literal id="litWinOpen1" runat="server"></asp:literal><asp:literal id="litWinAlert1" runat="server"></asp:literal></form>
		<br>
		<!-- 頁尾 Footer -->
		<CENTER><kw:footer id="Footer" runat="server"></kw:footer></CENTER>
		<SCRIPT language="javascript">
		<!--
		//檢查落版輸入之 "刊登年月" 的值是否正確
		function CheckYYYYMM(obj)
		{	
			// 判斷刊登年月的長度是否為 6碼
			var yyyymm = window.document.all("tbxYYYYMM").value;
			if(yyyymm.length!=6)
			{
				alert("'刊登年月' 的長度必須為 6碼(西元), 請修正!");
				return;
			}
			// 若刊登年月的長度為 6碼 (合理)
			else
			{
				// 檢查是否輸入為 數字型態
				if(isNaN(yyyymm)==true)
					alert("'刊登年月' 必須輸入數字型態!");
				
				// 判斷刊登年月是否在 合約起迄日 範圍內
				var ContStartDate = window.document.all("tbxStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("tbxEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				if(yyyymm<ContStartDate || yyyymm>ContEndDate)
				{
					alert("'刊登年月' 必須在合約起迄範圍內, 請修正! \n否則無法新增此筆錯誤資料!!!");
					return;
				}
				
				// 並判斷西元刊登年月是否合理化 : 年(4碼, 1990~2200), 月(01~12)
				var yyyy = yyyymm.substring(0, 4);
				var mm = yyyymm.substring(4, 6);
				
				// 判斷西元刊登年度是否合理化
				if(yyyy<=1990 || yyyy>=2200)
				{
					alert("注意: 刊登年月之年度 '" + yyyy + "' 不合理, 範圍 1990~2200, 請更正!");
					return;
				}
				else
					yyyymm = yyyymm;
				
				// 判斷西元刊登月份是否合理化
				if(mm>12 || mm<=0)
				{
					alert("注意: 刊登年月之月份 '" + mm + "' 不合理, 請更正!");
					return;
				}
				else
					yyyymm = yyyymm;			
			// 結束 - 若刊登年月的長度為 6碼 (合理)
			}
			
		}
		//-->
		</SCRIPT>
		<script language="javascript">
		<!--
		// 提示因 '刊登年月' 變更, 必須更新 '書籍期別' 的值 (再按一下)
		function CheckYYYYMM2(obj)
		{
			var yyyymm = window.document.all("tbxYYYYMM").value;
			if(yyyymm != "")
				alert("您更新了 '刊登年月' !\n 請再按一下 '書籍期別' 旁的按鈕來更新資料!!!");
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// 檢查 "書籍期別" 一欄是否有輸入
		function CheckBookPNo(obj)
		{	
			var BookPNo = window.document.all("tbxBkpPno").value;
			// 若書籍期別沒有輸入
			if(BookPNo == null)
			{
				//alert("'書籍期別' 為必填!\n 請按下右方按鈕來挑選!");
				return;
			}
			else
			{
				// 檢查是否輸入為 數字型態
				if(isNaN(BookPNo)==true)
					alert("'書籍期別' 必須輸入數字型態!");
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetBookp(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// 指定傳過去的變數 - 抓出 書籍類別代碼 & 刊登年月, 來找出 書籍期別
			var bkcd = document.all("tbxBkcd").value;
			var ym = document.all("tbxYYYYMM").value;
			myObject.bkcd = document.all("tbxBkcd").value;
			myObject.ym = document.all("tbxYYYYMM").value;
			//alert("myObject.bkcd= " + myObject.bkcd);
			//alert("myObject.ym= " + myObject.ym);
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			//alert("PageName= " + PageName);
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				document.all("tbxBkpPno").value = myObject.result;
				// 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				document.all("tbxYYYYMM").value = myObject.yyyymm;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetLPrior(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// 指定傳過去的變數 - 抓出 書籍類別代碼 & 刊登年月, 來找出 書籍期別
			var bkcd = document.all("tbxBkcd").value;
			myObject.bkcd = document.all("tbxBkcd").value;
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			var PageName = "adlprior_get.aspx?bkcd=" + bkcd;
			vreturn=window.open(PageName,  '_new', 'Height=320, Width=280, Top=120, Left=490, toolbar=no, scrollbars=yes, status=no, resizable=no'); 
		}
		//-->
		</script>
		<!-- 網頁重新整理 功能 (當 收件人視窗關閉時, 會呼叫此 function) -->
		<script language="javascript">
		function RefreshMe()
		{
			window.PubFm.submit();
		}
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="舊稿頁碼參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別, 再抓出其刊登頁碼
		function doGetPgNo1(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// 傳入 廠商統編 & 舊稿期別, 來參考列出該廠商 曾刊登(並寫回)之所有落版資料
			// 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
			var mfrno = document.all("hiddenMfrNo").value;
			var bkpno = document.all("tbxOrigjno").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// 開啟視窗對話框, 最後將值傳入 oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:170px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				document.all("tbxOrigbkno").value = myObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="改稿頁碼參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別, 再抓出其刊登頁碼
		// 此段與上段同, 只是 window.showModalDialog 裡的顯示位置 & vreturn 不同而已
		function doGetPgNo2(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// 傳入 廠商統編 & 舊稿期別, 來參考列出該廠商 曾刊登(並寫回)之所有落版資料
			// 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
			var mfrno = document.all("hiddenMfrNo").value;
			var bkpno = document.all("tbxChgjno").value;
			//alert("mfrno= " + mfrno);
			//alert("bkpno= " + bkpno);
			
			// 開啟視窗對話框, 最後將值傳入 oMyObject
			var PageName = "pubpgno_get.aspx?mfrno=" + mfrno + "&bkpno=" + bkpno;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:380px;dialogWidth:420px;dialogLeft:170px;dialogTop:100px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			if(vreturn)  {
				document.all("tbxChgbkno").value = myObject.pgno;
				return true;
			}
		
		}
		//-->
		</script>
	</body>
</HTML>
