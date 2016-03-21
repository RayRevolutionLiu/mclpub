<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ORForm.aspx.cs" Inherits="mclpub.Contract.ORForm"  MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>新增/修改/刪除 雜誌收件人資料</title>
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
			<!-- 發票廠商收件人 歷史資料 區 --><FONT color="#ff0066" size="2">[雜誌收件人 歷史資料 區]&nbsp;&nbsp; </FONT>
			<asp:label id="lblMfrInfo" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:label>
			<br />
            <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="false" OnRowDataBound="GridView1OnRowDataBound" CssClass="font_blacklink font_size13" OnRowCommand="GridView1OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" Text="載入資料" CommandName="LKload" CommandArgument='<%# Eval("or_oritem")%>' ></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                <asp:BoundField DataField="or_inm" HeaderText="廠商名稱" />
                <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
                <asp:BoundField DataField="or_jbti" HeaderText="職稱" />
                <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
                <asp:BoundField DataField="or_addr" HeaderText="發票地址" />
                <asp:BoundField DataField="or_tel" HeaderText="電話" />
                <asp:BoundField DataField="or_fax" HeaderText="傳真" />
                <asp:BoundField DataField="or_cell" HeaderText="手機" />
                <asp:BoundField DataField="or_email" HeaderText="Email" />           
                <asp:BoundField DataField="or_pubcnt" HeaderText="有登本數" />
                <asp:BoundField DataField="or_unpubcnt" HeaderText="未登本數" />
                <asp:BoundField DataField="or_mtpcd" HeaderText="郵寄類別" />
                <asp:BoundField DataField="or_fgmosea" HeaderText="海外郵寄" />
            </Columns>
            </asp:GridView>
            <span class="font_size12 font_darkblue font_bold">
			<asp:label id="lblHistoryMessage" runat="server"></asp:label>
			</span>
			<br>
			<!-- 發票廠商收件人 新增/修改資料 區 --><font color="#ff0066" size="2">[雜誌收件人 新增/修改資料 區]</font>
			<asp:TextBox ID="tbxORSysCode" runat="server" Enabled="False" 
            Font-Size="X-Small" MaxLength="2" Visible="False" WIDTH="30px">C2</asp:TextBox>
        <FONT color="#ff0066" size="2">&nbsp;
				<asp:TextBox ID="tbxORContNo" runat="server" Enabled="False" 
            Font-Size="X-Small" MaxLength="6" Visible="False" WIDTH="50px"></asp:TextBox>
        &nbsp;&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label>&nbsp;
				<asp:label id="lblCustNo" runat="server" Visible="False"></asp:label></FONT>&nbsp;<br />
			<TABLE id="tblAdd" cellSpacing="0" cellPadding="0"  class="font_blacklink font_size13" width="99%" border="0">
				<THEAD>
					<TR>
						<th>
							序號
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>公司
							<br>
							名稱
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
							有登<br />
                            本數</th>
						<th>
							未登<br />
                            本數</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>郵寄類別
						</th>
						<th>
							<FONT color="#c00000" size="2">*</FONT>海外郵寄
						</th>
					</TR>
				</THEAD>
				<TBODY>
					<TR>
						<TD>
                            <asp:Label ID="lblORItem" runat="server"></asp:Label>
                        </TD>
						<TD>
                            <asp:TextBox ID="tbxORMfrIName" runat="server"
                                MaxLength="50" Width="80px"></asp:TextBox>
                        </TD>
						<TD>
                            <asp:TextBox ID="tbxORName" runat="server" MaxLength="30" 
                                Width="70px"></asp:TextBox>
                        </TD>
						<TD>
                            <asp:TextBox ID="tbxORJobTitle" runat="server" 
                                MaxLength="12" Width="70px"></asp:TextBox>
                        </TD>
						<TD>
                            <asp:TextBox ID="tbxORTel" runat="server" MaxLength="30" 
                                WIDTH="90px"></asp:TextBox>
                        </TD>
						<TD><asp:textbox id="tbxORPubCount" runat="server" MaxLength="3" WIDTH="30px"></asp:textbox></TD>
						<TD>
                            <asp:TextBox ID="tbxORUnPubCount" runat="server" 
                                MaxLength="3" WIDTH="30px"></asp:TextBox>
                        </TD>
						<TD>
                            <asp:DropDownList ID="ddlORmtpcd" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </TD>
						<TD><asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
								<asp:ListItem Value="1">國外</asp:ListItem>
							</asp:dropdownlist></TD>
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
						<TH colspan="2">
							手機
						</TH>
						<TH colSpan="2">
							Email
						</TH>
					</TR>
					<TR >
						<TD>&nbsp;
						</TD>
						<TD colSpan="3">
                            <asp:TextBox ID="tbxORZipcode" runat="server" MaxLength="5" 
                                Width="40px"></asp:TextBox>
                            &nbsp;
							<asp:TextBox ID="tbxORAddr" runat="server" MaxLength="120" 
                                WIDTH="230px"></asp:TextBox>
                        </TD>
						<TD>
                            <asp:TextBox ID="tbxORFax" runat="server" MaxLength="30" 
                                WIDTH="90px"></asp:TextBox>
                        </TD>
						<TD colspan="2">
                            <asp:TextBox ID="tbxORCell" runat="server" MaxLength="30" 
                                WIDTH="80px"></asp:TextBox>
                        </TD>
						<TD colSpan="2">
                            <asp:TextBox ID="tbxOREmail" runat="server" MaxLength="80" 
                                WIDTH="160px"></asp:TextBox>
                        </TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* 為必填欄位!&nbsp;</FONT>
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
			<font color="#ff0066" size="2">[已新增 雜誌收件人資料 區]</font>
			<br />
            <asp:GridView ID="GridView2" runat="server" Width="99%" AutoGenerateColumns="false" OnRowDataBound="GridView2OnRowDataBound" CssClass="font_blacklink font_size13" OnRowCommand="GridView2OnRowCommand">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="LKedit" CommandArgument='<%# Eval("or_oritem")%>' Text="修改"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="LKdel" CommandArgument='<%# Eval("or_oritem")%>' Text="刪除"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                <asp:BoundField DataField="or_inm" HeaderText="廠商名稱" />
                <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
                <asp:BoundField DataField="or_jbti" HeaderText="職稱" />
                <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
                <asp:BoundField DataField="or_addr" HeaderText="發票地址" />
                <asp:BoundField DataField="or_tel" HeaderText="電話" />
                <asp:BoundField DataField="or_fax" HeaderText="傳真" />
                <asp:BoundField DataField="or_cell" HeaderText="手機" />
                <asp:BoundField DataField="or_email" HeaderText="Email" />         
                <asp:BoundField DataField="or_pubcnt" HeaderText="有登本數" />
                <asp:BoundField DataField="or_unpubcnt" HeaderText="未登本數" />
                <asp:BoundField DataField="or_mtpcd" HeaderText="郵寄類別" />
                <asp:BoundField DataField="or_fgmosea" HeaderText="海外郵寄" />
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
