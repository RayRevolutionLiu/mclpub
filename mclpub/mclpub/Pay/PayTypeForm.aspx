<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayTypeForm.aspx.cs" Inherits="mclpub.Pay.PayTypeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 繳款處理 / 新增繳款資料</span>
    <span class="stripeMe">
			<table cellSpacing="0" cellPadding="0" border="0" width="98%">
				<tr>
					<th colSpan="2">繳款單資料</th>
				</tr>
				<tr>
					<td align="right" width="120px" class="font_bold">
						繳款單編號：
					</td>
					<td>
						<asp:label id="lblPayNo" runat="server" ForeColor="#C04000"></asp:label>
					</td>
				</tr>
				<tr>
					<td align="right" class="font_bold">
						金額：
					</td>
					<td>
						<asp:label id="lblAmt" runat="server" ForeColor="#C04000"></asp:label>
						<asp:textbox id="tbxAmt" runat="server" Visible="False" Width="60px"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td align="right" class="font_bold">付款方式：</td>
					<td>
						<asp:dropdownlist id="ddlPayType" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlPayType_SelectedIndexChanged"></asp:dropdownlist>
					</td>
				</tr>
			</table>
			<asp:panel id="Panel1" runat="server" Visible="False">
            <br />
				<table cellSpacing="0" cellPadding="0" border="0" width="98%">
					<tr>
						<th colSpan="2">票據資料
						</th>
					</tr>
					<tr>
						<td align="right" class="font_bold" width="120px">
							號碼：
						</td>
						<td>
							<INPUT id="tbxChkno" style="WIDTH: 114px" type="text" maxLength="16" size="13" name="tbxChkno" runat="server">
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							付款行：
						</td>
						<td>
							<INPUT id="tbxChkbnm" style="WIDTH: 185px" type="text" maxLength="20" size="25" name="tbxChkbnm" runat="server">
							<FONT color="#990033">輸入字數請勿超過15個中文字</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							到期日：
						</td>
						<td>
							<INPUT id="tbxChkdate" type="text" size="7" name="tbxChkdate" runat="server" class="UniqueDate">
                            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="到期日請勿空白" ControlToValidate="tbxChkdate"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							郵資：
						</td>
						<td>
							<INPUT id="tbxPost" style="WIDTH: 78px" type="text" size="7" name="tbxChkdate" runat="server">
						</td>
					</tr>
				</table>
			</asp:panel>
			<asp:panel id="Panel2" runat="server" Visible="False">
            <br />
				<table width="98%" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<th colSpan="2">
							劃撥單資料
						</th>
					</tr>
					<tr>
						<td align="right" class="font_bold" width="120px">
							批號：
						</td>
						<td>
							<INPUT id="tbxMoseq" style="WIDTH: 53px" type="text" maxLength="5" size="3" name="tbxMoseq" runat="server">
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							項次：
						</td>
						<td>
							<INPUT id="tbxMoitem" style="WIDTH: 53px" type="text" maxLength="3" size="3" name="tbxMoitem" runat="server">
						</td>
					</tr>
				</table>
			</asp:panel>
			<asp:panel id="Panel3" runat="server" Visible="False">
            <br />
				<table width="98%" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<th colSpan="2">電匯資料
						</th>
					</tr>
					<tr>
						<td align="right" class="font_bold" width="120px">
							帳號：
						</td>
						<td>
							<INPUT id="tbxWaccno" style="WIDTH: 114px" type="text" maxLength="16" size="13" name="tbxWaccno" runat="server">
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							匯入日期：
						</td>
						<td>
							<INPUT id="tbxWdate" type="text" maxLength="10" size="10" name="tbxWdate" runat="server" class="UniqueDate">
                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="匯入日期請勿空白" ControlToValidate="tbxWdate"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							金融代碼：
						</td>
						<td>
							<INPUT id="tbxWbcd" style="WIDTH: 38px" type="text" maxLength="3" size="1" name="tbxWbcb" runat="server">
						</td>
					</tr>
				</table>
			</asp:panel>
			<asp:panel id="Panel4" runat="server" Visible="False">
            <br />
				<table cellSpacing="0" cellPadding="0" border="0" width="98%">
					<tr>
						<th colSpan="4">
							信用卡資料
						</th>
					</tr>
					<tr>
						<td style="width:120px" align="right" class="font_bold">
							卡別：
						</td>
						<td colspan="3">
							<asp:RadioButtonList id="rblCctp" runat="server" Repeatdirection="Horizontal">
								<asp:ListItem Value="1" Selected="true">聯合信用卡</asp:ListItem>
								<asp:ListItem Value="2">VISA</asp:ListItem>
								<asp:ListItem Value="3">Master</asp:ListItem>
								<asp:ListItem Value="4">JCB</asp:ListItem>
							</asp:RadioButtonList>
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							卡號：
						</td>
						<td colSpan="3">
							<INPUT id="tbxCcno1" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno1" runat="server">
							- <INPUT id="tbxCcno2" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno2" runat="server">
							- <INPUT id="tbxCcno3" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno3" runat="server">
							- <INPUT id="tbxCcno4" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno4" runat="server">
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							授權碼：
						</td>
						<td colSpan="3">
							<INPUT id="tbxCcauthcd" style="WIDTH: 78px" type="text" maxLength="6" size="7" name="tbxCcauthcd" runat="server">
						</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							有效年月：
						</td>
						<td colSpan="3">
							<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
							年
							<asp:dropdownlist id="ddlMonth" runat="server">
								<asp:ListItem Value="01">1</asp:ListItem>
								<asp:ListItem Value="02">2</asp:ListItem>
								<asp:ListItem Value="03">3</asp:ListItem>
								<asp:ListItem Value="04">4</asp:ListItem>
								<asp:ListItem Value="05">5</asp:ListItem>
								<asp:ListItem Value="06">6</asp:ListItem>
								<asp:ListItem Value="07">7</asp:ListItem>
								<asp:ListItem Value="08">8</asp:ListItem>
								<asp:ListItem Value="09">9</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
							</asp:dropdownlist>
							月</td>
					</tr>
					<tr>
						<td align="right" class="font_bold">
							交易日期：
						</td>
						<td>
							<INPUT id="tbxCcDate" type="text" maxLength="10" size="10" name="tbxWdate" runat="server" class="UniqueDate">
						</td>
					</tr>
				</table>
			</asp:panel>
            </span>
            <br />
            <asp:Button ID="btnCancel" runat="server" Text="取消回首頁" 
        onclick="btnCancel_Click" CausesValidation="false"/>
            <asp:Button ID="btnBefore" runat="server" Text="上一步" 
        onclick="btnBefore_Click"  CausesValidation="false"/>
            <asp:Button ID="btnSubmit" runat="server" Text="確定儲存繳款資料" 
        onclick="btnSubmit_Click" />
</asp:Content>
