<%@ Page language="c#" Codebehind="PubFm_Add.aspx.cs" Src="PubFm_Add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm_Add" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增落版內容</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left">
					<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						新增落版 步驟二: 新增落版內容</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="PubFm_Add" method="post" runat="server">
			<!--Table 開始-->
			<TABLE id="tblPubMain" style="WIDTH: 98%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
				<!-- 廠商及客戶資料 -->
				<TR bgColor="#214389">
					<TD>
						<font color="white">落版資料</font>
					</TD>
				</TR>
			</TABLE>
			<!-- 已新增 落版資料 區 --><font color="#ff0066" size="2">[已新增 落版資料 區]</font>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" HeaderText="編輯" CancelText="取消" EditText="編輯"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="刪除" HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="書籍期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="刊登頁碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_clrcd" HeaderText="廣告色彩"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgscd" HeaderText="廣告篇幅"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_ltpcd" HeaderText="廣告版面"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="固定頁次註記"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿註記"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="發票收件人姓名"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:label id="lblAddMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<br>
			<!-- 落版資料 新增/修改 區 --><font color="#ff0066" size="2">[落版資料 新增/修改 區]</font>
			<asp:textbox id="tbxSysCode" runat="server" Visible="False" MaxLength="2" WIDTH="30px" Enabled="False">C2</asp:textbox>
			<FONT color="#ff0066" size="2"></FONT>&nbsp;
			<asp:textbox id="tbxContNo" runat="server" Visible="False" MaxLength="6" WIDTH="50px" Enabled="False"></asp:textbox>
			&nbsp;
			<asp:label id="lblBkcd" runat="server" Visible="False" Font-Size="x-Small"></asp:label>
			&nbsp;
			<br>
			<font size="2">刊登年月合理範圍：</font>
			<asp:label id="lblStartDate" runat="server" Font-Size="x-Small"></asp:label>
			&nbsp;~&nbsp;
			<asp:label id="lblEndDate" runat="server" Font-Size="x-Small"></asp:label>
			&nbsp;
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							序號
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>刊登年月
							<br>
							<font color="#c00000" size="2">(請填範圍內)</font>
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>書籍期別
						</TH>
						<TH>
							刊登頁碼
						</TH>
						<TH>
							廣告色彩
						</TH>
						<TH>
							廣告篇幅
						</TH>
						<TH>
							廣告版面
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>固定頁次
							<BR>
							註記
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>發票廠商
							<br>
							收件人序號
						</TH>
						<TH>
							發票廠商
							<br>
							收件人姓名
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
							<asp:label id="lblPubSeq" runat="server"></asp:label>
						</TD>
						<TD>
							&nbsp; <INPUT dataFld="刊登年月" id="tbxYYYYMM" onblur="Javascript:CheckPubDate(this);" type="text" maxLength="6" onchange="Javascript:CheckPubDate2(this);" size="6" name="tbxPubDate">
						</TD>
						<TD>
							&nbsp; <INPUT dataFld="書籍期別" id="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);" type="text" maxLength="4" size="3" name="tbxBkpPno">&nbsp;
							<IMG class="ico" title="書籍期別參考資料" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
						</TD>
						<TD>
							&nbsp;
							<asp:textbox id="tbxPageNo" runat="server" MaxLength="3" Width="30px"></asp:textbox>
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
					<!-- 第二行 -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							廣告金額
						</TH>
						<TH>
							換稿金額
						</TH>
						<TH>
							已開立
							<br>
							發票單註記
						</TH>
						<TH>
							發票開立單
							<br>
							人工處理註記
						</TH>
						<TH colSpan="5">
							備註
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD colSpan="5">
							&nbsp;
						</TD>
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
							新稿製法
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>到稿註記
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
							<br>
							註記
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
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* 為必填欄位!</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="儲存新增"></asp:button>
			&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="儲存修改"></asp:button>
			&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="載入預設資料"></asp:button>
			<br>
			<br>
		</form>
		<!-- Javascript -->
		<script language="javascript">
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
				var ContStartDate = window.document.all("lblStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("lblEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				//alert("ContStartDate= " + ContStartDate);
				//alert("ContEndDate= " + ContEndDate);
				if(yyyymm<ContStartDate || yyyymm>ContEndDate)
				{
					alert("'刊登年月' 必須在合約起迄範圍內, 請修正!");
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
		</script>
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
			if(BookPNo.length==0)
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
			var bkcd = document.all("lblbkcd").value;
			var ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			//alert("ym= " + ym);
			myObject.bkcd = document.all("ddlBookCode").value.substring(0, 2);
			myObject.ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text;
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				xmlAdpubData.childNodes.item(idx).selectSingleNode("書籍期別").text = myObject.result;
				// 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text = myObject.yyyymm;
				
				// 同上之方法二 - 解決若沒輸入 刊登年月時, 直接按 '書籍期別', 而刊登年月為空 的情況
				//if(xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text=="")  {
					//var CurrentDate = new Date();
					//var Currentyyyy = CurrentDate.getFullYear();
					//var Currentmm = CurrentDate.getMonth()+1;
					//if(Currentmm.length!=2)
						//Currentmm = "0" + Currentmm;
					//var Currentym = Currentyyyy + Currentmm;
					//xmlAdpubData.childNodes.item(idx).selectSingleNode("刊登年月").text=Currentym;
				//}
				return true;
			}
			
		}
		//-->
		</script>
	</body>
</HTML>
