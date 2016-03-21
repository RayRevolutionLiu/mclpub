<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mfr_detail.aspx.cs" Inherits="mclpub.Contract.mfr_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>廠商之細節資料</title>
</head>
	<body>
		<!-- Run at Server Form -->
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
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIName" runat="server" ForeColor="Red"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD  noWrap align="right">
						統一編號：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrNo" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD noWrap align="right" width="25%">
						註冊日期：
					</TD>
					<TD>
						<asp:label id="lblMfrRegDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD noWrap align="right">
						負責人姓名：
					</TD>
					<TD>
						<asp:label id="lblMfrRespName" runat="server"></asp:label>
					</TD>
					<TD noWrap align="right">
						負責人職稱：
					</TD>
					<TD>
						<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD noWrap align="right">
						電話：
					</TD>
					<TD>
						<asp:label id="lblMfrTel" runat="server"></asp:label>
					</TD>
					<TD noWrap align="right">
						傳真：
					</TD>
					<TD>
						<asp:label id="lblMfrFax" runat="server"></asp:label>
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
			<br />
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="關閉視窗" name="btn_close" Class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
			</span>
		</form>
	</body>
</html>
