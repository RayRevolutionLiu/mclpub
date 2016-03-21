<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContMaintain.aspx.cs" Inherits="mclpub.Contract.ContMaintain"  MasterPageFile="~/MasterPage.Master" MaintainScrollPositionOnPostback="true"%>

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

$(function() {
$("#<% =tbxSDate.ClientID%>").datepicker(
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

$(function() {
$("#<% =tbxEDate.ClientID%>").datepicker(
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

$(function() {
$("#<% =tbxCsDate.ClientID%>").datepicker(
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
        document.getElementById('<% =postbackBtn.ClientID%>').click();
    }  
</script>

    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 網路廣告合約書 步驟三:維護合約書內容</span>  
    <span class="stripeMe">
    <center>
    <TABLE class="font_blacklink font_size13" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<th colspan="4">廠商及客戶資料</th>
								</TR>
								<TR>
												<TD align="right" width="20%">公司名稱(統編)：</TD>
												<TD width="30%">
													<asp:label id="lblMfrNm" runat="server" ForeColor="Maroon">公司名稱</asp:label>(
													<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon">00000000</asp:label>&nbsp; 
													)</TD>
												<TD align="right" width="15%">詳細資料：</TD>
												<TD width="35%"><IMG class="ico" id="imgMfrDetail" onclick="doDetail('450','300','mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>');" alt="廠商詳細資料" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0"></TD>
											</TR>
											<TR>
												<TD align="right">公司負責人姓名(職稱)：</TD>
												<TD>
													<asp:label id="lblRespData" runat="server" ForeColor="Maroon">負責人(職稱)</asp:label></TD>
												<TD align="right">公司電話(傳真)：</TD>
												<TD>
													<asp:label id="lblMfrTelFax" runat="server" ForeColor="Maroon">00-00000000(Fax: 00-00000000)</asp:label></TD>
											</TR>
											<TR>
												<TD align="right">客戶姓名(編號)：</TD>
												<TD>
													<asp:label id="lblCustNm" runat="server" ForeColor="Maroon">客戶姓名</asp:label>(
													<asp:label id="lblCustNo" runat="server" ForeColor="Maroon">000000</asp:label>&nbsp; 
													)</TD>
												<TD align="right">詳細資料：</TD>
												<TD><IMG class="ico" id="imgCustDetail" onclick="doDetail('450','450','cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>');" alt="客戶詳細資料" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0"></TD>
											</TR>
								<TR>
									<th colspan="4">合約書基本資料</th>
								</TR>
											<TR>
												<TD align="right" width="20%">合約編號：</TD>
												<TD width="30%">
													<asp:label id="lblContNo" runat="server" ForeColor="Maroon">000000</asp:label></TD>
												<TD align="right" width="15%">簽約日期：</TD>
												<TD width="35%">
													<asp:textbox id="tbxSignDate" runat="server" Width="80px" MaxLength="10"></asp:textbox>  
    <span class="stripeMe">
                                                    <asp:regularexpressionvalidator id="revCsDate0" runat="server" 
                                                        ErrorMessage="格式錯誤，請輸入正確格式" Display="Dynamic" ControlToValidate="tbxSignDate" 
                                                         ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:regularexpressionvalidator>
    </span>
                                                </TD>
											</TR>
											<TR>
												<TD align="right">合約類別：</TD>
												<TD>
													<asp:dropdownlist id="ddlContTp" runat="server">
														<asp:ListItem Value="01" Selected="True">一般合約</asp:ListItem>
														<asp:ListItem Value="09">推廣合約</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD align="right">合約起迄日：</TD>
												<TD>
													<asp:textbox id="tbxSDate" runat="server" Width="80px" MaxLength="10"></asp:textbox>&nbsp;<span class="stripeMe"><asp:regularexpressionvalidator 
                                                        id="revCsDate1" runat="server" 
                                                        ErrorMessage="格式錯誤，請輸入正確格式" Display="Dynamic" ControlToValidate="tbxSDate" 
                                                         ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:regularexpressionvalidator>
    </span>
                                                    ～
													<asp:textbox id="tbxEDate" runat="server" Width="80px" MaxLength="10" AutoPostBack="True"></asp:textbox>  
    <span class="stripeMe">
                                                    <asp:regularexpressionvalidator id="revCsDate2" runat="server" 
                                                        ErrorMessage="格式錯誤，請輸入正確格式" Display="Dynamic" ControlToValidate="tbxEDate" 
                                                        ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:regularexpressionvalidator>
    </span>
                                                    &nbsp;<asp:label id="lblDayCount" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="right">已開過發票：</TD>
												<TD>
													<asp:radiobuttonlist id="rblPayOnce" runat="server" RepeatDirection="Horizontal" Enabled="False">
														<asp:ListItem Value="1">是</asp:ListItem>
														<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD align="right">承辦業務員：</TD>
												<TD>
													<asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD align="right">合約備註：</TD>
												<TD colSpan="3">
													<asp:textbox id="tbxRemark" runat="server" Width="273px" MaxLength="50"></asp:textbox></TD>
											</TR>
								<TR>
									<th colspan="4">合約書細節</th>
								</TR>
											<TR>
												<TD align="right" width="20%">刊登次數：</TD>
												<TD width="30%">
												<asp:textbox id="tbxPubTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnPubTm" runat="server"></asp:label>
													<asp:Button id="btnCount" runat="server" Text="計算次數" onclick="btnCount_Click"></asp:Button>										
													</TD>
												<TD width="15%">合約總金額：</TD>
												<TD width="35%">
													<asp:textbox id="tbxTotAmt" runat="server" Width="80px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">贈送次數：</TD>
												<TD>
													<asp:textbox id="tbxFreeTm" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">優惠折數：</TD>
												<TD>
													<asp:textbox id="tbxDisc" runat="server" Width="80px"></asp:textbox>(例: 
													0.8表示八折)</TD>
											</TR>
											<TR>
												<TD align="right">總製圖檔稿次數：</TD>
												<TD>
													<asp:textbox id="tbxTotImgTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnImgTm" runat="server"></asp:label></TD>
												<TD align="right">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD align="right">總製網頁稿次數：</TD>
												<TD>
													<asp:textbox id="tbxTotUrlTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnUrlTm" runat="server"></asp:label></TD>
												<TD align="right">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
								<TR>
									<th colspan="4">廣告聯絡人資料</th>
								</TR>
											<TR>
												<TD align="right" width="20%">廣告聯絡人姓名：</TD>
												<TD width="30%">
													<asp:textbox id="tbxAuNm" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right" width="15%">&nbsp;</TD>
												<TD width="35%">&nbsp;</TD>
											</TR>
											<TR>
												<TD align="right">電話：</TD>
												<TD>
													<asp:textbox id="tbxAuTel" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">傳真：</TD>
												<TD>
													<asp:textbox id="tbxAuFax" runat="server" Width="80px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">手機：</TD>
												<TD>
													<asp:textbox id="tbxAuCell" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">Email：</TD>
												<TD>
													<asp:textbox id="tbxAuEmail" runat="server" Width="150px"></asp:textbox></TD>
											</TR>
								<TR>
									<th colspan="4">廣告推廣內文、期限、產品設備內文</th>
								</TR>
											<TR>
												<TD align="right" width="20%">廣告推廣內文：</TD>
												<TD colspan="3">
													<asp:textbox id="tbxCCont" runat="server" Width="407px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">搜尋期限：</TD>
												<TD colspan="3">
													<asp:textbox id="tbxCsDate" runat="server" Width="80px"></asp:textbox>&nbsp;<asp:regularexpressionvalidator id="revCsDate" runat="server" ErrorMessage="格式錯誤，請輸入正確格式" Display="Dynamic" ControlToValidate="tbxCsDate" ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:regularexpressionvalidator>(如：2002/12/31)</TD>
											</TR>
											<TR>
												<TD align="right">產品設備內文：</TD>
												<TD colspan="3">
													<asp:textbox id="tbxPdCont" runat="server" Width="500px" MaxLength="250" TextMode="MultiLine" Rows="3" Height="94px"></asp:textbox></TD>
											</TR>
								<TR>
									<th colspan="4">材料特性及應用產業相關資料</th>
								</TR>
											<TR>
												<TD vAlign="top" width="50%" colspan="2">材料特性：<IMG class="ico" alt="ATP_MATP" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0" onclick="doDetail('900','600','AtpMatp.aspx?NewContNo=<% Response.Write(lblContNo.Text.Trim().Trim()); %>&ClassId=1');">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
													<asp:datagrid id="dgdAtpMatp1" runat="server" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2">
														<SelectedItemStyle ></SelectedItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle></ItemStyle>
														<HeaderStyle></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="cls2_cname" ReadOnly="True">
																<ItemStyle Wrap="False"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cls3_cname" ReadOnly="True"></asp:BoundColumn>
														</Columns>
													</asp:datagrid>
													</ContentTemplate>
													</asp:UpdatePanel>	
													</TD>
												<TD vAlign="top" colspan="2">應用產業：<IMG class="ico" alt="ATP_MATP" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0" onclick="doDetail('900','600','AtpMatp.aspx?NewContNo=<% Response.Write(lblContNo.Text.Trim().Trim()); %>&ClassId=2');">
												<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
													<asp:datagrid id="dgdAtpMatp2" runat="server" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2">
														<SelectedItemStyle ></SelectedItemStyle>
														<AlternatingItemStyle ></AlternatingItemStyle>
														<ItemStyle></ItemStyle>
														<HeaderStyle></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="cls2_cname" ReadOnly="True">
																<ItemStyle Wrap="False"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cls3_cname" ReadOnly="True"></asp:BoundColumn>
														</Columns>
													</asp:datagrid>
													</ContentTemplate>
													</asp:UpdatePanel>	
													</TD>
											</TR>
								<TR>
									<th colspan="4">雜誌收件人及贈書資料</th>
								</TR>
					            <TR>
						            <TD colspan="4">
							        <font color="darkred">操作說明：</font>按  
		                            <span class="stripeMe">
                                        <IMG 
            onclick="doDetail('900','600','FreeBook.aspx?Act=New&CustNo=<% Response.Write(lblCustNo.Text.Trim()); %>&NewContNo=<% Response.Write(lblContNo.Text.Trim()); %>&OldContNo=<% Response.Write(tbxOldContNo.Text.Trim()); %>');" 
            alt="詳細" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0" name="imgAddFreeBk"></span>
							        來 新增 / 修改 / 刪除 雜誌收件人及贈書資料;
							        </TD>
					            </TR>
								<TR>
									<TD colspan="4">
									<asp:UpdatePanel ID="UpdatePanel4" runat="server">
									<ContentTemplate>
                                        <asp:GridView ID="dgdNewOr" runat="server" AutoGenerateColumns="false" Width="99%" CssClass="font_blacklink font_size13" >
                                        <Columns>
                                        <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                                        <asp:BoundField DataField="or_inm" HeaderText="公司名稱" />
                                        <asp:BoundField DataField="or_nm" HeaderText="雜誌收件人姓名" />
                                        <asp:BoundField DataField="or_jbti" HeaderText="稱謂" />
                                        <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
                                        <asp:BoundField DataField="or_addr" HeaderText="地址" />
                                        <asp:BoundField DataField="or_tel" HeaderText="電話" />
                                        <asp:BoundField DataField="or_fax" HeaderText="傳真" />
                                        <asp:BoundField DataField="or_cell" HeaderText="手機" />
                                        <asp:BoundField DataField="or_email" HeaderText="Email" />
                                        </Columns>
                                        </asp:GridView>
                                        <br />
                                        
                                        <asp:GridView ID="dgdNewFreeBk" runat="server" AutoGenerateColumns="false" Width="99%" CssClass="font_blacklink font_size13" >
                                        <Columns>
                                        <asp:BoundField DataField="fbk_fbkitem" HeaderText="項次" />
                                        <asp:BoundField DataField="str_ma_sdate" HeaderText="贈書起月" />
                                        <asp:BoundField DataField="str_ma_edate" HeaderText="贈書迄月" />
                                        <asp:BoundField DataField="fc_nm" HeaderText="書籍" />
                                        <asp:BoundField DataField="or_nm" HeaderText="收件人" />
                                        <asp:BoundField DataField="ma_pubmnt" HeaderText="當月刊登份數" />
                                        <asp:BoundField DataField="ma_unpubmnt" HeaderText="未刊登份數" />
                                        </Columns>
                                        </asp:GridView>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>	
                                    </TD>
								</TR>
								<TR>
									<th colspan="4">發票廠商基本資料</th>
								</TR>
					            <TR>
						            <TD colspan="4">
							        <font color="darkred">操作說明：</font>按  
		                            <span class="stripeMe">
                                        <IMG onclick="doDetail('900','600','InvMfr.aspx?NewContNo=<% Response.Write(lblContNo.Text.Trim()); %>&OldContNo=<% Response.Write(tbxOldContNo.Text.Trim()); %>&mfrno=<% Response.Write(lblMfrNo.Text.Trim()); %>');" alt="詳細" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0" name="imgAddInvMfr"></span>
							        來 新增 / 修改 / 刪除 發票廠商基本資料;
							        </TD>
					            </TR>
								<TR>
									<TD colspan="4">
									<asp:UpdatePanel ID="UpdatePanel5" runat="server">
									<ContentTemplate>
                                        <asp:GridView ID="dgdNewInvMfr" runat="server" AutoGenerateColumns="false" 
                                            Width="99%" CssClass="font_blacklink font_size13" >
                                        <Columns>
                                        <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                                        <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                                        <asp:BoundField DataField="im_nm" HeaderText="收件人姓名" />
                                        <asp:BoundField DataField="im_jbti" HeaderText="稱謂" />
                                        <asp:BoundField DataField="im_zip" HeaderText="郵遞區號" />
                                        <asp:BoundField DataField="im_addr" HeaderText="地址" />
                                        <asp:BoundField DataField="im_tel" HeaderText="電話" />
                                        <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                                        <asp:BoundField DataField="im_cell" HeaderText="手機" />
                                        <asp:BoundField DataField="im_email" HeaderText="Email" />
                                        <asp:BoundField DataField="invcd" HeaderText="發票類別" />
                                        <asp:BoundField DataField="taxtp" HeaderText="發票課稅別" />
                                        <asp:BoundField DataField="imfgitri" HeaderText="院所內註記" />
                                        </Columns>
                                        </asp:GridView>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>	
                                    </TD>
								</TR>

											<TR>
												<TD>
													<asp:Label id="Label1" runat="server">合約現況</asp:Label></TD>
												<TD colspan="3" align="left">
													<asp:RadioButtonList id="rblClosed" runat="server" Width="158px" RepeatDirection="Horizontal" Height="14px" ForeColor="Red">
														<asp:ListItem Value="0">進行中</asp:ListItem>
														<asp:ListItem Value="1">已結案</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
								<TR>
									<TD colspan="4">
										<asp:Button id="btnSave" runat="server" Text="儲存合約" onclick="btnSave_Click"></asp:Button>
										<asp:Button id="btnNoSave" runat="server" Text="取消儲存" onclick="btnNoSave_Click"></asp:Button>
										<asp:Button id="btnFgCancel" runat="server" Text="註銷合約"  onclick="btnFgCancel_Click" BorderColor="Red" OnClientClick="return confirm('是否註銷')" /></asp:Button></TD>
								</TR>
								<TR>
									<TD colspan="4">
										<asp:textbox id="tbxHidMfrNo" runat="server" Width="10px" Visible="False"></asp:textbox>
										<asp:textbox id="tbxHidCustNo" runat="server" Width="10px" Visible="False"></asp:textbox>
										<asp:TextBox id="tbxOldContNo" runat="server" Width="10px" Visible="False"></asp:TextBox></TD>
								</TR>
								</TABLE>
								<asp:UpdatePanel ID="UpdatePanel3" runat="server">
								<ContentTemplate>
								<asp:Button ID="postbackBtn" runat="server" onclick="postbackBtn_Click" />
								</ContentTemplate>
								</asp:UpdatePanel>	
    </center>
    </span>
</asp:Content>
