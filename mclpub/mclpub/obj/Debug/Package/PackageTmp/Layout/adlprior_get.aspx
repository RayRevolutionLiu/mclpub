<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adlprior_get.aspx.cs" Inherits="mclpub.Layout.adlprior_get" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>顯示 版面優先次序 資料</title>
</head>
<body>
		<!-- Run at Server Form -->
		<form id="adlprior_get" method="post" runat="server">
			<table cellSpacing="0" cellPadding="4" class="font_blacklink font_size13" width="100%" border="0">
				<!-- DataGrid: 自資料庫抓最新資料 -->
				<tr>
					<td width="5%">
						&nbsp;
					</td>
					<td>
						<!-- 操作說明 -->
						<font color="blue" size="2">操作說明：預設帶入
							<asp:Label id="lblBookName" runat="server" ForeColor="Red"></asp:Label>
							<FONT color="#8b0000">&nbsp;</FONT>之資料.</font>
						<br>
						<font color="blue" size="2">請按下<span class="font_darkblue">關閉視窗</span>按鈕, 
							來關閉此視窗!</font>
						<br>
					</td>
				</tr>
				<tr>
					<td width="5%">
						&nbsp;
					</td>
					<td width="100%">
                        <span class="stripeMe">
						<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False" CssClass="font_blacklink font_size13" UseAccessibleHeader="true" Font-Size="X-Small">
							<Columns>
								<asp:BoundColumn DataField="lp_priorseq" HeaderText="排版優先次序">
									<ItemStyle HorizontalAlign="Center">
									</ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ltp_nm" HeaderText="廣告版面"></asp:BoundColumn>
								<asp:BoundColumn DataField="clr_nm" HeaderText="廣告色彩"></asp:BoundColumn>
								<asp:BoundColumn DataField="pgs_nm" HeaderText="廣告篇幅"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_bkcd" HeaderText="書籍代碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_ltpcd" HeaderText="廣告版面代碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_clrcd" HeaderText="廣告色彩代碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_pgscd" HeaderText="廣告篇幅代碼"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
                        </span>
						<!-- 資料筆數 -->
						<FONT color="#333333">
							<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
							(共有
							<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
							筆資料 )</FONT>
					</td>
				</tr>
				<!-- 關閉視窗按鈕 -->
				<tr>
					<td>
						&nbsp;
					</td>
					<td>
						<br>
						<INPUT id="btn_close" onclick="Javascript: window.close();" type="button" value="關閉視窗" name="btn_close"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
						&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
