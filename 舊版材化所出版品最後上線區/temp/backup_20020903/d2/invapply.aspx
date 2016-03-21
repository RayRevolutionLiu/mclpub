<%@ Page language="c#" Codebehind="invapply.aspx.cs" Src="invapply.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.invapply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立申請單</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!-- 頁首 Header -->
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							發票開立申請單</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- 標題 -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">發票開立申請單</FONT></B>
			</DIV>
			<!-- Run at Server Form -->
			<form ID="invapply" name="invapply" method="post" runat="server">
				<TABLE style="WIDTH: 90%" border="0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<tr bgcolor="white" align="right">
						<td colspan="6">
							頁次： 1 / 1
						</td>
					</tr>
					<TR bgcolor="#214389" style="COLOR: #ffffff">
						<TD nowrap>
							<FONT face="新細明體">開立日期：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">90/11/29</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">&nbsp;</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">&nbsp;</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體"><B>發票開立申請單編號：</B></FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_iano" runat="server" Height="18px">00000001</asp:Label>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="新細明體">公司名稱 (統一編號)：</FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_imn" runat="server" Height="18px">工研院</asp:Label>
							<FONT face="新細明體">&nbsp;&nbsp;(</FONT>
							<asp:Label id="lbl_mfrno" runat="server" Height="18px">02750963</asp:Label>
							<FONT face="新細明體">)</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體">部門代號：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">
								<asp:Label id="lbl_deptnm" runat="server" Height="18px">資服組</asp:Label>
								&nbsp;(</FONT>
							<asp:Label id="lbl_deptcd" runat="server" Height="18px">SB100</asp:Label>
							<FONT face="新細明體">)</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體">業務承辦人姓名：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">
								<asp:Label id="lbl_cname" runat="server" Height="18px">游惠茹</asp:Label>
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="新細明體">寄發票地址：</FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_rzip" runat="server" Height="18px">300</asp:Label>
							<FONT face="新細明體">&nbsp;
								<asp:Label id="lbl_raddr" runat="server" Height="18px">新竹市...</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體" color="#ff0000">營運別：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">
								<asp:Label id="lbl_orgcd" runat="server" Height="18px">17</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體"><FONT face="新細明體">業務承辦人聯絡電話：</FONT></FONT>
						</TD>
						<TD>
							<FONT face="新細明體">
								<asp:Label id="lbl_tel" runat="server" Height="18px">03-5916837</asp:Label>
							</FONT>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="新細明體">發票收件人姓名/稱謂：</FONT>
						</TD>
						<TD>
							<asp:Label id="lbl_rnm" runat="server" Height="18px">陳俐靜</asp:Label>
							&nbsp;&nbsp;
							<asp:Label id="lbl_rjbti" runat="server" Height="18px">小姐</asp:Label>
						</TD>
						<TD nowrap>
							合約編號：
						</TD>
						<TD>
							<asp:Label id="lbl_contno" runat="server" Height="18px">000001</asp:Label>
						</TD>
						<TD nowrap>
							&nbsp;申請人主管姓名 / 簽章：
						</TD>
						<TD>
							<FONT face="新細明體">&nbsp;</FONT>
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							<FONT face="新細明體">發票收件人電話：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">
								<asp:Label id="lbl_rtel" runat="server" Height="18px">03-5732073</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體" color="#ff0000">計劃代號(?)：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">
								<asp:Label id="lbl_projyr" runat="server" Height="18px">90</asp:Label>
								&nbsp;
								<asp:Label id="lbl_projno" runat="server" Height="18px">F59C740</asp:Label>
							</FONT>
						</TD>
						<TD nowrap>
							<FONT face="新細明體">會計姓名 / 簽章：</FONT>
						</TD>
						<TD>
							<FONT face="新細明體">&nbsp;</FONT>
						</TD>
					</TR>
				</TABLE>
				<br>
				<TABLE dataFld="item" id="iad_detail" style="WIDTH: 90%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="1">
					<thead>
						<tr bgColor="#214389">
							<td colSpan="7">
								<font color="white">申請單明細資料</font>
							</td>
						</tr>
						<tr borderColor="#bfcff0" bgColor="#bfcff0" align="middle">
							<td nowrap>
								<span dataFld="item"></span>功能
							</td>
							<td nowrap>
								項次
							</td>
							<td nowrap>
								計劃代號
							</td>
							<td nowrap>
								品名
							</td>
							<td nowrap>
								數量
							</td>
							<td nowrap>
								單價
							</td>
							<td nowrap>
								總價
							</td>
						</tr>
					</thead>
					<tbody>
						<tr borderColor="#bfcff0" bgColor="#e2eafc" align="middle">
							<td>
								<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
							</td>
							<td>
								<asp:Label dataFld="項次" id="lbl_item1" runat="server">1</asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_projno1" runat="server" Height="18px">90F59C730</asp:Label>
							</td>
							<td align="left">
								<asp:Label id="lbl_desc1" runat="server" Height="18px">工材  訂閱 2001/06~2002/05 </asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_unit1" runat="server" Height="18px">1</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_uprice1" runat="server" Height="18px">1800</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_amt1" runat="server" Height="18px">$ 2000</asp:Label>
							</td>
						</tr>
						<tr borderColor="#bfcff0" bgColor="#e2eafc" align="middle">
							<td>
								<IMG class="ico" title="新增資料" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" height="15" src="images/new.gif" width="16" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" height="14" src="images/cut.gif" width="9" border="0">&nbsp;
							</td>
							<td>
								<asp:Label dataFld="項次" id="lbl_item2" runat="server">2</asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_projno2" runat="server" Height="18px">90F59C710</asp:Label>
							</td>
							<td align="left">
								<asp:Label id="lbl_desc2" runat="server" Height="18px">工材  月廣告費</asp:Label>
							</td>
							<td>
								<asp:Label id="lbl_unit2" runat="server" Height="18px">2</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_uprice2" runat="server" Height="18px">5000</asp:Label>
							</td>
							<td align="right">
								<asp:Label id="lbl_amt2" runat="server" Height="18px">$ 1400</asp:Label>
							</td>
						</tr>
						<tr align="middle" valign="top">
							<td nowrap>
								備註：
							</td>
							<td nowrap align="left" colspan="6">
								<asp:Label id="lbl_remark" runat="server">*廣告客戶... </asp:Label>
							</td>
						<tr align="middle">
							<td nowrap>
								發票類別：
							</td>
							<td colspan="2" align="left" nowrap>
								<asp:RadioButtonList id="rab_invtpcd" runat="server" Height="18px" RepeatDirection="Horizontal">
									<asp:ListItem Value="1">二聯</asp:ListItem>
									<asp:ListItem Value="2" Selected="True">三聯</asp:ListItem>
									<asp:ListItem Value="3">其他</asp:ListItem>
								</asp:RadioButtonList>
							</td>
							<td nowrap>
								小計：
							</td>
							<td colspan="2">
								&nbsp;
							</td>
							<td colspan="3" nowrap align="right">
								<FONT face="新細明體">$ </FONT>
								<asp:Label id="lbl_pyat" runat="server" Height="18px">3400</asp:Label>
							</td>
						</tr>
						<tr align="middle">
							<td nowrap>
								發票日期：
							</td>
							<td colspan="2" align="left">
								<asp:Label id="lbl_iasdate" runat="server" Height="18px">90/12/25</asp:Label>
							</td>
							<td nowrap>
								發票課稅別：
							</td>
							<td colspan="2" align="left" nowrap>
								<asp:RadioButtonList id="Radiobuttonlist1" runat="server" Height="18px">
									<asp:ListItem Value="1" Selected="True">應稅 5%</asp:ListItem>
									<asp:ListItem Value="2">零稅</asp:ListItem>
									<asp:ListItem Value="3">免稅</asp:ListItem>
								</asp:RadioButtonList>
							</td>
							<td nowrap align="right">
								<FONT face="新細明體">$</FONT>
								<asp:Label id="lbl_txat" runat="server" Height="18px">170</asp:Label>
							</td>
						</tr>
						<tr align="middle">
							<td nowrap>
								發票號碼：
							</td>
							<td colspan="2" align="left">
								<asp:Label id="lbl_invno" runat="server" Height="18px">FK18733396</asp:Label>
							</td>
							<td nowrap align="middle">
								銷售額 (總計)：
							</td>
							<td colspan="2">
								&nbsp;
							</td>
							<td nowrap align="right">
								<FONT face="新細明體">$</FONT>
								<asp:Label id="lbl_ivat" runat="server" Height="18px" Font-Bold="True">3570</asp:Label>
							</td>
						</tr>
					</tbody>
					<TFOOT>
						<TR align="left">
							<TD colSpan="8">
								<font color="blue">您好, 為了便於沖轉本公司之應收帳款的款項, 煩請貴公司在<B>郵寄帳款</B>時, 隨<B>支票</B>附上
									<br>
									<b>&nbsp; (1)</STRONG>&nbsp;發票開立申請單 (本單） 或
										<br>
										&nbsp; (2) 貴公司所要沖銷的發票號碼, 月份</b>
									<br>
									<br>
									支票抬頭： 工業材料研究所
									<br>
									聯絡地址： 新竹縣竹東鎮中興路四段１９５之５號 (７７館）
									<br>
									聯絡電話： (03)591-8205&nbsp;&nbsp;&nbsp; 工業材料雜誌&nbsp;&nbsp; 葉瑞鳳 小姐 啟
									<br>
								</font>
							</TD>
						</TR>
					</TFOOT>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</BODY>
</HTML>
