<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvMfrForm.aspx.cs" Inherits="mclpub.Contract.InvMfrForm"  MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新增/修改/刪除 發票廠商收件人資料</title>
    <script language="javascript">
        function CloseAndPstBack() {
            if (window.opener) {
                window.opener.PushBtn();
            }
            window.close();
        }
    </script>
</head>
	<body>
		<form id="form1" runat="server">
		<span class="stripeMe">
			<!-- 發票廠商收件人 歷史資料 區 --><FONT color="#ff0066" size="2">[發票廠商收件人 歷史資料 區]&nbsp;&nbsp; </FONT>
			<asp:label id="lblMfrInfo" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:label>
			<br />
            <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="false" OnRowDataBound="GridView1OnRowDataBound" CssClass="font_blacklink font_size13" OnRowCommand="GridView1OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" Text="載入資料" CommandName="LKload" CommandArgument='<%# Eval("im_imseq")%>' ></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                <asp:BoundField DataField="im_nm" HeaderText="收件人姓名" />
                <asp:BoundField DataField="im_jbti" HeaderText="職稱" />
                <asp:BoundField DataField="im_zip" HeaderText="郵遞區號" />
                <asp:BoundField DataField="im_addr" HeaderText="發票地址" />
                <asp:BoundField DataField="im_tel" HeaderText="電話" />
                <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                <asp:BoundField DataField="im_cell" HeaderText="手機" />
                <asp:BoundField DataField="im_email" HeaderText="Email" />
                <asp:BoundField DataField="im_invcd" HeaderText="發票類別" />
                <asp:BoundField DataField="im_taxtp" HeaderText="發票課稅別" />
                <asp:BoundField DataField="im_fgitri" HeaderText="院所內註記" />
            </Columns>
            </asp:GridView>
            <span class="font_size12 font_darkblue font_bold">
			<asp:label id="lblHistoryMessage" runat="server"></asp:label>
			</span>
			<br>
			<!-- 發票廠商收件人 新增/修改資料 區 --><font color="#ff0066" size="2">[發票廠商收件人 新增/修改資料 區]</font>
			<asp:textbox id="tbxIMSysCode" runat="server" Visible="False" MaxLength="2" WIDTH="30px" Enabled="False">C2</asp:textbox><FONT color="#ff0066" size="2">&nbsp;
				<asp:textbox id="tbxIMContNo" runat="server" Visible="False" MaxLength="6" WIDTH="50px" Enabled="False"></asp:textbox>&nbsp;&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label>&nbsp;
				<asp:label id="lblCustNo" runat="server" Visible="False"></asp:label></FONT>
			<TABLE id="tblAdd" cellSpacing="0" cellPadding="0"  class="font_blacklink font_size13" width="99%" border="0">
				<THEAD>
					<TR>
						<th>
							序號
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>廠商
							<br>
							統編
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>姓名
						</th>
						<th>
							職稱
						</th>
						<th>
							電話
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>發票
							<br>
							類別
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>發票
							<br>
							課稅別
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>院所內
							<br>
							註記
						</th>
					</TR>
				</THEAD>
				<TBODY>
					<TR>
						<TD><asp:label id="lblImSeq" runat="server" Font-Size="X-Small"></asp:label></TD>
						<TD><asp:textbox id="tbxIMMfrNo" runat="server" MaxLength="10" WIDTH="70px"></asp:textbox><asp:RequiredFieldValidator id="rfvIMMfrNo" runat="server" ControlToValidate="tbxIMMfrNo" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator></TD>
						<TD><asp:textbox id="tbxIMName" runat="server" MaxLength="30" WIDTH="70px"></asp:textbox><asp:RequiredFieldValidator id="rfvIMName" runat="server" ControlToValidate="tbxIMName" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator></TD>
						<TD><asp:textbox id="tbxIMJobTitle" runat="server" MaxLength="12" WIDTH="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMTel" runat="server" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD><asp:dropdownlist id="ddlIMInvtp" runat="server">
								<asp:ListItem Value="2">二聯</asp:ListItem>
								<asp:ListItem Value="3" Selected="True">三聯</asp:ListItem>
								<asp:ListItem Value="4">其他</asp:ListItem>
								<asp:ListItem Value="9">不清楚</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlIMTaxtp" runat="server">
								<asp:ListItem Value="1" Selected="True">應稅5%</asp:ListItem>
								<asp:ListItem Value="2">零稅</asp:ListItem>
								<asp:ListItem Value="3">免稅</asp:ListItem>
								<asp:ListItem Value="9">不清楚</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlIMfgITRI" runat="server"></asp:dropdownlist></TD>
					</TR>
					<!-- 第二行 -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH colSpan="3">
							郵遞區號&nbsp;&amp;&nbsp;&nbsp;發票地址
						</TH>
						<TH>
							傳真
						</TH>
						<TH>
							手機
						</TH>
						<TH colSpan="2">
							Email
						</TH>
					</TR>
					<TR >
						<TD>&nbsp;
						</TD>
						<TD colSpan="3"><asp:textbox id="tbxIMZipcode" runat="server" MaxLength="5" WIDTH="40px"></asp:textbox>&nbsp;
							<asp:textbox id="tbxIMAddr" runat="server" MaxLength="120" WIDTH="230px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMFax" runat="server" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxIMCell" runat="server" MaxLength="30" WIDTH="80px"></asp:textbox></TD>
						<TD colSpan="2"><asp:textbox id="tbxIMEmail" runat="server" MaxLength="80" WIDTH="160px"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* 為必填欄位!&nbsp;&nbsp;(院所內註記資料是依據 '計劃代號' 檔; 若無 '院內往來' 
				選項, 請先至 '共用檔案/計劃代號' 來新增其計劃代號.)<br>
				註：若發票廠商收件人為個人戶(英文字開頭), 則其發票類別將自動更正為 '二聯', 若原資料有誤將提示您已做此修正！</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="儲存新增" onclick="btnSave_Click"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="儲存修改" 
            onclick="btnModify_Click"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="載入預設資料" 
            onclick="btnLoadData_Click"></asp:button>&nbsp;
			<asp:button id="btnClearAll" runat="server" Text="清除資料" 
            onclick="btnClearAll_Click"></asp:button>&nbsp;&nbsp;
			<INPUT id="btnClose" onclick="CloseAndPstBack();" type="button" value="關閉視窗" name="btnClose" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
			<br />
			<br />
			<font color="#ff0066" size="2">[已新增 發票廠商收件人資料 區]</font>
			<br />
            <asp:GridView ID="GridView2" runat="server" Width="99%" AutoGenerateColumns="false" OnRowDataBound="GridView2OnRowDataBound" CssClass="font_blacklink font_size13" OnRowCommand="GridView2OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="LKedit" CommandArgument='<%# Eval("im_imseq")%>' Text="修改"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="LKdel" CommandArgument='<%# Eval("im_imseq")%>' Text="刪除"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                <asp:BoundField DataField="im_nm" HeaderText="收件人姓名" />
                <asp:BoundField DataField="im_jbti" HeaderText="職稱" />
                <asp:BoundField DataField="im_zip" HeaderText="郵遞區號" />
                <asp:BoundField DataField="im_addr" HeaderText="發票地址" />
                <asp:BoundField DataField="im_tel" HeaderText="電話" />
                <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                <asp:BoundField DataField="im_cell" HeaderText="手機" />
                <asp:BoundField DataField="im_email" HeaderText="Email" />
                <asp:BoundField DataField="im_invcd" HeaderText="發票類別" />
                <asp:BoundField DataField="im_taxtp" HeaderText="發票課稅別" />
                <asp:BoundField DataField="im_fgitri" HeaderText="院所內註記" />
            </Columns>
            </asp:GridView>
		<span class="font_size13 font_bold font_gray">
        <ol>
	        <li>新增資料-於歷史區, 按 <span class="font_darkblue">載入資料</span>, 或按 <span class="font_darkblue">載入預設資料</span> 按鈕, 資料確認後, 按 <span class="font_darkblue">儲存新增</span> 按鈕</li>
            <li>修改資料-於已新增區的該資料行, 按下 <span class="font_darkblue">修改</span>, 資料確認後, 按 "儲存修改" 按鈕</li>
            <li>刪除資料-於已新增區的該資料行, 按下 <span class="font_darkblue">刪除</span> 即可</li>
            <li><font color="blue" size="2">全部操作完畢, 按 "關閉視窗" 來回到上一頁</font></li>

        </ol>
        </span>
        </span>
		</form>
	</body>
</html>
