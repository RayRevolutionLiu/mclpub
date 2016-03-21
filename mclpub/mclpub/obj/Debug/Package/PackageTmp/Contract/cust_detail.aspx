<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cust_detail.aspx.cs" Inherits="mclpub.Contract.cust_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
	<body>
		<form id="form1" runat="server">
		<span class="stripeMe">
			<!-- Table 開始: 細節資訊 -->
			<TABLE class="font_blacklink font_size13" width="100%">
				<!-- Table Title -->
			  <tr>
			    <th colspan="4">廠商之細節資訊</th>
			  </tr>	
				<tr >
					<td colSpan="4">
						<font>廠商資料</font> (ID=
							<asp:label id="lblMfrID" runat="server"></asp:label>)
					</td>
				</tr>
				<!-- 細節資訊開始 -->
				<TR vAlign="center">
					<TD noWrap align="right" width="25%">
						公司名稱：
						<br>
						(發票抬頭)
					</TD>
					<TD colSpan="3">
						<asp:label id="lblMfrIName" runat="server" ForeColor="Red"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right">
						統一編號：
					</TD>
					<TD>
						<asp:label id="lblMfrNo" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD noWrap align="right" width="20%">
						廠商連絡電話：</TD>
					<TD width="25%">
						<asp:label id="lblMfrTel" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD noWrap align="right">
						地址：
					</TD>
					<TD colSpan="3">
						<asp:label id="lblMfrIZipcode" runat="server"></asp:label>
						&nbsp;
						<asp:label id="lblMfrIAddr" runat="server"></asp:label>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="font_blacklink font_size13" width="100%">
			<tr>
			    <th colspan="4">客戶資料(ID：<asp:label id="lblCustID" runat="server" Font-Size="X-Small"></asp:label>／舊客戶編號：
			    <asp:Label id="lblOldCustNo" runat="server" Font-Size="X-Small"></asp:Label>
			        )</th>
			</tr>
				<TR vAlign="center">
					<TD  noWrap align="right" width="25%">
						姓名及編號：
					</TD>
					<TD>
						<asp:label id="lblCustName" runat="server" ForeColor="Red"></asp:label>
						&nbsp;(
						<asp:Label id="lblCustNo" runat="server" ForeColor="Red"></asp:Label>
						)
					</TD>
					<TD noWrap align="right" width="20%">
						職稱：
					</TD>
					<TD width="25%">
						<asp:label id="lblCustJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right" >
						註冊日期：
					</TD>
					<TD >
						<asp:label id="lblCustRegDate" runat="server"></asp:label>
					</TD>
					<TD  noWrap align="right">
						修改日期：
					</TD>
					<TD >
						<asp:label id="lblCustModDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right" >
						電話：
					</TD>
					<TD >
						<asp:label id="lblCustTel" runat="server"></asp:label>
					</TD>
					<TD  noWrap align="right">
						傳真：
					</TD>
					<TD >
						<asp:label id="lblCustFax" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right" >
						手機：
					</TD>
					<TD >
						<asp:label id="lblCustCell" runat="server"></asp:label>
					</TD>
					<TD  noWrap align="right">
						Email：
					</TD>
					<TD >
						<asp:label id="lblCustEmail" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right" >
						客戶領域：
					</TD>
					<TD colspan="3">
						<asp:Label id="lblCustItpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right" >
						客戶營業：
					</TD>
					<TD colspan="3">
						<asp:Label id="lblCustBtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
			</TABLE>
			<br />
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="關閉視窗" name="btn_close" Class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
		</span>
		</form>
	</body>
</html>
