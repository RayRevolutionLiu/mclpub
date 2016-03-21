<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaneCont2Edit.aspx.cs" Inherits="mclpub.Contract.PlaneCont2Edit" MasterPageFile="~/MasterPage.Master"  MaintainScrollPositionOnPostback="true"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script>
$(function() {
$("#<% =tbxSignDate.ClientID%>").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
});
</script>

<script language="javascript">
    function PushBtn() {
        document.getElementById('<% =imbIMRefresh.ClientID%>').click();
        document.getElementById('<% =imbORRefresh.ClientID%>').click();
    }  
</script>

    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 平面廣告合約書 步驟三:修改合約書內容</span> 
    <span class="stripeMe">
		<center>
				<!--Table 開始-->
				<TABLE cellSpacing="0" cellPadding="4" width="92%" border="0" class="font_blacklink font_size13">
					<!-- 廠商及客戶資料 -->
					<TR>
						<th colSpan="4">
							廠商及客戶資料
						</th>
					</TR>
					<!-- 廠商資料 -->
					<TR vAlign="middle">
						<TD noWrap align="right">
							公司名稱 (廠商統編)：
						</TD>
						<TD>
							<asp:label id="lblMfrIName" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon"></asp:label>
							)
						</TD>
						<TD noWrap align="right">
							詳細資料：
						</TD>
						<TD>
							<IMG class="ico" id="imgMfrDetail" onclick="doDetail('450','300','mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>');" alt="廠商詳細資料" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
						</TD>
					</TR>
					<!-- 公司負責人資料 -->
					<TR vAlign="middle">
						<TD noWrap align="right">
							公司負責人 姓名(職稱)：
						</TD>
						<TD>
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;<FONT face="新細明體">(
								<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
								)</FONT>
						</TD>
						<TD noWrap align="right">
							公司電話 (傳真)：
						</TD>
						<TD>
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblMfrFax" runat="server"></asp:label>
								)</FONT>
						</TD>
					</TR>
					<!-- 客戶資料 -->
					<TR vAlign="middle">
						<TD noWrap align="right">
							客戶姓名 (客戶編號)：
						</TD>
						<TD>
							<asp:label id="lblCustName" runat="server" ForeColor="Maroon"></asp:label>
							<FONT face="新細明體">&nbsp;(
								<asp:label id="lblCustNo" runat="server" ForeColor="Maroon"></asp:label>
								)</FONT>
						</TD>
						<TD noWrap align="right">
							詳細資料：
						</TD>
						<TD>
							<IMG class="ico" id="imgCustDetail" onclick="doDetail('450','450','cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>');" alt="客戶詳細資料" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
						</TD>
					</TR>
					<!-- 合約書基本資料 -->
					<TR>
						<th colSpan="4">
							<font color="#ffffff">合約書基本資料&nbsp;&nbsp;</font>&nbsp;
							<asp:label id="lblfgClosedMessage" runat="server" ForeColor="Yellow"></asp:label>
						</th>
					</TR>
					<TR>
						<TD noWrap align="right">
							簽約日期：
						</TD>
						<TD>
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" MaxLength="10"></asp:textbox>
							&nbsp;<br>
							<FONT face="新細明體" color="#c00000">(預設值: 一年, 如 2002/06 ~ 2003/05)</FONT>
						</TD>
						<TD noWrap align="right">
							合約書編號：
						</TD>
						<TD>
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							合約類別：
						</TD>
						<TD>
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlContType" runat="server">
								<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
								<asp:ListItem Value="09">推廣合約</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD noWrap align="right">
							書籍類別：
						</TD>
						<TD>
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							合約起迄日：
						</TD>
						<TD noWrap>
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxStartDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp; <font size="3">~</font> <FONT color="red">*</FONT>
							<asp:textbox id="tbxEndDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp;
						</TD>
						<TD noWrap align="right">
							建檔業務員：
						</TD>
						<TD>
							<FONT color="red">*</FONT>
							<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							一次付清註記：
						</TD>
						<TD noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD noWrap align="right">
						</TD>
						<TD vAlign="top">
							<asp:RegularExpressionValidator id="revSDate" runat="server" ErrorMessage="合約起日格式不符合 'yyyy/mm'" ControlToValidate="tbxStartDate"
								ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>&nbsp;
							<asp:RegularExpressionValidator id="revEDate" runat="server" ErrorMessage="合約迄日格式不符合 'yyyy/mm'" DESIGNTIMEDRAGDROP="324"
								ControlToValidate="tbxEndDate" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							結案註記：
						</TD>
						<TD noWrap>
							<asp:RadioButtonList id="rblfgClosed" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD noWrap align="right">
							修改業務員：
						</TD>
						<TD vAlign="top">
							&nbsp;&nbsp;
							<asp:DropDownList id="ddlModEmpNo" runat="server"></asp:DropDownList>
							<br>
							<FONT face="新細明體" color="#c00000">(預設值: 登入者)</FONT>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							合約註銷註記：
						</TD>
						<TD noWrap>
							<asp:RadioButtonList id="rblfgCancel" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">是</asp:ListItem>
								<asp:ListItem Value="0">否</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD noWrap align="right">
							參考合約書編號：
						</TD>
						<TD vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblOldContNo" runat="server" ForeColor="Maroon"></asp:Label>
							&nbsp;&nbsp;
							<asp:Label id="lblOldContMessage" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							建檔日期：
						</TD>
						<TD noWrap>
							&nbsp;
							<asp:Label id="lblCreateDate" runat="server"></asp:Label>
						</TD>
						<TD noWrap align="right">
							最後修改日期：
						</TD>
						<TD vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblModifyDate" runat="server"></asp:Label>
						</TD>
					</TR>
					<!-- 合約書細節 資料 -->
					<TR>
						<th colSpan="4">
							<font color="white">合約書細節</font>
						</th>
					</TR>
					<TR>
						<TD vAlign="middle" align="center" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										總製稿次數：
									</TD>
									<TD>
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD noWrap align="right">
										總刊登次數：
									</TD>
									<TD>
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD noWrap align="right">
										合約總金額：
									</TD>
									<TD>
										<FONT color="red">* </FONT>$
										<asp:textbox id="tbxTotalAmt" runat="server" MaxLength="8" Width="60px"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										已製稿次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:TextBox id="tbxMadeJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD noWrap align="right">
										已刊登次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:TextBox id="tbxPubTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD noWrap align="right">
										已繳金額：
									</TD>
									<TD>
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:TextBox id="tbxPaidAmt" runat="server" MaxLength="8" Width="60px" ForeColor="Gray"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										剩餘製稿次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD noWrap align="right">
										剩餘刊登次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD noWrap align="right">
										剩餘金額：
									</TD>
									<TD>
										&nbsp;&nbsp;&nbsp;<FONT face="新細明體">$</FONT>
										<asp:TextBox id="tbxRestAmt" runat="server" MaxLength="8" Width="60px" ForeColor="Gray"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										換稿次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD noWrap align="right">
										贈送次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD align="right">
										廣告費單價：
									</TD>
									<TD>
										&nbsp;&nbsp;&nbsp;$
										<asp:TextBox id="tbxADAmt" runat="server" MaxLength="8" Width="50px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										優惠折數：
										<BR>
										<FONT face="新細明體" color="#c00000">(請填實數!)</FONT>
									</TD>
									<TD>
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" MaxLength="6" Width="40px"></asp:textbox>
										<FONT face="新細明體">折</FONT>&nbsp;
										<br>
										<FONT color="#c00000">七五折, 請填 0.75</FONT>
									</TD>
									<TD align="right">
										贈送本數：
									</TD>
									<TD>
										$
										<asp:textbox id="tbxFreeBookCount" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD align="right">
										&nbsp;
									</TD>
									<TD>
										&nbsp;&nbsp;
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										彩色次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:textbox id="tbxColorTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD noWrap align="right">
										套色次數：
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:textbox id="tbxGetColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD align="right">
										黑白次數：
									</TD>
									<TD>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="tbxMenoTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										&nbsp;
									</TD>
									<TD>
										&nbsp;&nbsp;
									</TD>
									<TD noWrap align="right">
										<font color="gray">已落版 總廣告金額：</font>
									</TD>
									<TD>
										$
										<asp:textbox id="tbxPubAdAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray" Enabled="False"></asp:textbox>
									</TD>
									<TD noWrap align="right">
										<font color="gray">已落版 總換稿金額：</font>
									</TD>
									<TD>
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxPubChangeAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray"
											Enabled="False"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="middle" align="left">
									<TD noWrap align="right">
										<font color="gray">已落版 剩餘彩色次數：</font>
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestClrtm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
									<TD noWrap align="right">
										<font color="gray">已落版 剩餘套色次數：</font>
									</TD>
									<TD>
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestGetClrtm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray"
											Enabled="False"></asp:TextBox>
									</TD>
									<TD noWrap align="right">
										<font color="gray">已落版 剩餘黑白次數：</font>
									</TD>
									<TD>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:TextBox id="tbxRestMenotm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR> <!-- 廣告聯絡人 資料 -->
					<TR>
						<th colSpan="4">
							<font color="white">廣告聯絡人資料</font>
						</th>
					</TR>
					<TR>
						<TD noWrap align="right">
							廣告聯絡人姓名：
						</TD>
						<TD>
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
						</TD>
						<TD noWrap align="right">
							&nbsp;
						</TD>
						<TD noWrap>
							<FONT face="新細明體" color="#c00000">(本區資料 預設同客戶資料!)</FONT>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							電話：
						</TD>
						<TD>
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuTel" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD noWrap align="right">
							傳真：
						</TD>
						<TD>
							<asp:textbox id="tbxAuFax" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD noWrap align="right">
							手機：
						</TD>
						<TD>
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuCell" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD noWrap align="right">
							Email：
						</TD>
						<TD>
							<asp:textbox id="tbxAuEmail" runat="server" MaxLength="80" Width="160px"></asp:textbox>
						</TD>
					</TR>
					<!-- 備註　資料 -->
					<TR>
						<Th colSpan="4">
							備註
						</Th>
					</TR>
					<TR>
						<TD align="right">
							額外備註：
						</TD>
						<TD colSpan="3">
							&nbsp;&nbsp;&nbsp;<TEXTAREA id="tarContRemark" name="tarContRemark" rows="5" cols="60" runat="server"></TEXTAREA>
						</TD>
					</TR>
					<!-- 發票廠商收件人 資料 -->
					<TR>
						<Th colSpan="4">
                            發票廠商收件人資料
                            <asp:Label id="lblfgNew" runat="server" ForeColor="Red" Visible="False"></asp:Label>   
						</Th>
					</TR>
					<tr>
					    <td colspan="4">
					    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
					    <ContentTemplate>
				            <span class="stripeMe">
                            <asp:Label ID="lblIMMessage" runat="server" ForeColor="Red"></asp:Label>
                            </span>
				            <asp:ImageButton id="imbIMRefresh" runat="server" 
				            ImageUrl="~/Art/images/refresh.gif" AlternateText="重新整理 發票廠商收件人資料" 
				            onclick="imbIMRefresh_Click"></asp:ImageButton>  
				        </ContentTemplate>
				        </asp:UpdatePanel> 
					    </td>
					</tr>
					<TR>
						<TD colspan="4">
							<font color="darkred">操作說明：</font>按  
    <span class="stripeMe">
                            <IMG class="ico" title="新增/修改/刪除 發票廠商收件人" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0" onclick="doDetail('900','600','InvMfrForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>');"></span>
							來 新增 / 修改 / 刪除 收件人資料;</TD>
					</TR>
					<TR>
						<TD colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
							<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="99%" OnRowDataBound="GridView1OnRowDataBound" CssClass="font_blacklink font_size13" >
							<Columns>
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
                            </ContentTemplate>
                            </asp:UpdatePanel>
						</TD>
					</TR>
					<!-- 雜誌收件人 資料 -->
					<TR>
						<Th colSpan="4">
						雜誌收件人資料&nbsp;
						</Th>
					</TR>
					<tr>
					    <td colspan="4">
					    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
				            <ContentTemplate>
				                <span class="stripeMe">
                                <asp:Label ID="lblORMessage" runat="server" ForeColor="Red"></asp:Label>
                                </span>
				                <asp:ImageButton id="imbORRefresh" runat="server" AlternateText="重新整理 雜誌收件人資料" 
				                ImageUrl="~/Art/images/refresh.gif" onclick="imbORRefresh_Click"></asp:ImageButton>
				            </ContentTemplate>
				        </asp:UpdatePanel>
					    </td>
					</tr>
					<TR>
						<TD colspan="4">
							<font color="darkred">操作說明：</font>按  
    <span class="stripeMe">
		                    <IMG class="ico" title="新增/修改/刪除 雜誌收件人" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0" onclick="doDetail('900','600','ORForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>');"></span>
							來 新增 / 修改 / 刪除 收件人資料;
							</TD>
					</TR>
					<TR>
						<TD colSpan="4">
						    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width="99%" OnRowDataBound="GridView2OnRowDataBound" CssClass="font_blacklink font_size13" >
							<Columns>
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
                            </ContentTemplate>
                            </asp:UpdatePanel>
							<div align="right">
								<font color="red">有登本數／未登本數 總計：
									<asp:Label id="lblORPunCnt" runat="server" ForeColor="Blue"></asp:Label>
									&nbsp;
									<asp:Label id="lblORUnPubCnt" runat="server" ForeColor="Blue"></asp:Label>
								</font>&nbsp;
							</div>
						</TD>
					</TR>
					<TR bgColor="#ffffff">
						<TD align="center" colSpan="4">
							<br>
							<asp:button id="btnSave" runat="server" Text="儲存修改" onclick="btnSave_Click"></asp:button>
							&nbsp;&nbsp;
							<asp:button id="btnCancel" runat="server" Text="取消回首頁" 
                                onclick="btnCancel_Click"></asp:button>
							&nbsp;
							<asp:Button id="btnGoPub" runat="server" Text="維護落版資料" onclick="btnGoPub_Click"></asp:Button>
							&nbsp;
							<asp:Label id="lblfgPubed" runat="server"></asp:Label>
							<asp:Label id="lblpubfgnew" runat="server"></asp:Label>
						</TD>
					</TR>
				</TABLE>
				</span>
</asp:Content>


