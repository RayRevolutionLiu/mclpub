<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContChkList.aspx.cs" Inherits="mclpub.Contract.ContChkList"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<script language="javascript">
    function cleanAll() {
        window.document.getElementById("<% =tbxContNo.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSDate.ClientID%>").value = "";
        window.document.getElementById("<% =tbxEDate.ClientID%>").value = "";
        window.document.getElementById("<% =ddlEmpData.ClientID%>").value = "000000";
        window.document.getElementById("<% =ddlClosed.ClientID%>").value = "99";
    }

</script>

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;廣告合約管理 / 網路廣告合約書 / 合約書檢核表</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        合約書編號：</td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server" Width="100px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        簽約日期區間：</td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
        ~<asp:TextBox ID="tbxEDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
        <asp:Label id="lblSEDateMemo" runat="server"  ForeColor="Maroon">(yyyy/mm/dd)</asp:Label></td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        承辦業務員：</td>
    <td>
        <asp:DropDownList ID="ddlEmpData" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        已結案：</td>
    <td>
        <asp:DropDownList ID="ddlClosed" runat="server">
            <asp:ListItem Selected="true" Value="99">請選擇</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
        <input id="btnClose" name="btnClose" onclick="cleanAll();" type="button" value="清除重查" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"/>
        <asp:Button ID="btnBack" runat="server" Text="返回首頁" onclick="btnBack_Click" />
        </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>請按下<span class="font_darkblue">查詢</span>按鈕來檢查資料!</li>
	<li><span class="font_red">避免造成查詢緩慢 請先下搜尋條件後再行查詢</span></li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right"></td>
</tr>
</table>

<span class="stripeMe">
<asp:Label ID="lbNoCount" runat="server" ForeColor="Maroon" Text="查無資料, 請重新輸入查詢條件!"></asp:Label>
<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="新細明體">
										<ItemTemplate>
											<table width="99%" cellSpacing="0" cellPadding="0" align="center" border="0">
												<!-- 標題 -->
												<tr>
													<th>
														合約書編號
													</th>
													<th colSpan="3">
														廠商名稱(廠商統編)
													</th>
													<th>
														客戶名稱(編號)
													</th>
													<th>
														簽約日期
													</th>
													<th>
														合約類別
													</th>
													<th>
														合約起迄
													</th>
													<th>
														業務人員
													</th>
													<th>
														修改人員
													</th>
													<th>
														一次付清
													</th>
													<th>
														結案
													</th>
													<th>
														建檔日期
													</th>
													<th>
														修改日期
													</th>
												</tr>
												<!-- 輸出內容 -->
												<tr vAlign="top">
													<td width="7%" rowspan="8">
														<asp:Label id="lblContno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_contno") %>'>
														</asp:Label>
													</td>
													<td colSpan="3" width="*">
														<asp:Label id="lblMfrIName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm").ToString().Trim() %>'>
														</asp:Label>
														(
														<asp:Label id="lblMfrNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_mfrno").ToString().Trim() %>'>
														</asp:Label>
														)
													</td>
													<td width="9%">
														<asp:Label id="lblCustName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_nm").ToString().Trim() %>'>
														</asp:Label>
														(
														<asp:Label id="lblCustNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_custno").ToString().Trim() %>'>
														</asp:Label>
														)
													</td>
													<td width="6%">
														<asp:Label id="lblSignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_signdate").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="6%">
														<asp:Label id="lblConttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_conttp").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="6%">
														<asp:Label id="lblStartdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_sdate").ToString().Trim() %>'>
														</asp:Label>~
														<asp:Label id="lblEndDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_edate").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="6%">
														<asp:Label id="lblEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inputuser").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="8%">
														<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "moduser").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="8%">
														<asp:Label id="lblfgPayonce" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgpayonce").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="8%">
														<asp:Label id="lblfgClosed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgclosed").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="8%">
														<asp:Label id="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_credate").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td width="8%">
														<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_moddate").ToString().Trim() %>'>
														</asp:Label>
													</td>
												</tr>
												<tr>
													<th style="background-color:#4CC9FF">
														總製圖檔稿次數
													</th>
													<th style="background-color:#4CC9FF">
														總製網頁稿次數
													</th>
													<th style="background-color:#4CC9FF">刊登次數</th>
													<th style="background-color:#4CC9FF">贈送次數</th>
													<th style="background-color:#4CC9FF">
														總刊登次數
													</th>
													<th style="background-color:#4CC9FF">
														已刊登次數
													</th>
													<th style="background-color:#4CC9FF">
														剩餘刊登次數
													</th>
													<th style="background-color:#4CC9FF">
														合約總金額
													</th>
													<th style="background-color:#4CC9FF">
														已繳金額
													</th>
													<th style="background-color:#4CC9FF">
														剩餘金額
													</th>
													<th style="background-color:#4CC9FF">
														優惠折扣
													</th>
													<th colspan="2" style="background-color:#4CC9FF">合約備註</th>
												</tr>
												<tr vAlign="top" align="right">
													<td>
														<asp:Label id="lblTotimgtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totimgtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblToturltm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_toturltm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblRestjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblTottm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freetm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblPubtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblResttm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "enpubtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblTotamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_resttm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														$
														<asp:Label id="lblPaidamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totamt").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														$
														<asp:Label id="lblRestamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_paidamt").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>$
														<asp:Label id="lblChgjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restamt").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblFreetm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_disc").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td colspan="2">
														<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_remark").ToString().Trim() %>'>
														</asp:Label>
													</td>
												</tr>
												<tr>
													<th style="background-color:#4CC9FF">
														聯絡人姓名
													</th>
													<th style="background-color:#4CC9FF">
														電話
													</th>
													<th style="background-color:#4CC9FF">
														傳真
													</th>
													<th colspan="2" style="background-color:#4CC9FF">
														手機 / Email
													</th>
													<th colspan="2" style="background-color:#4CC9FF">
														廣告推廣內文
													</th>
													<th style="background-color:#4CC9FF">搜尋期限</th>
													<th colspan="5" style="background-color:#4CC9FF">產品設備內文</th>
												</tr>
												<tr vAlign="top">
													<td>
														<asp:Label id="lblAunm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aunm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblAuTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_autel").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td>
														<asp:Label id="lblAuFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aufax").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</td>
													<td colspan="2">
														<asp:Label id="lblAuCell" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aucell").ToString().Trim() %>'>
														</asp:Label>/
														<asp:Label id="lblAuEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_auemail").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td colspan="2">
														<asp:Label id="lblCcont" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_ccont").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td>
														<asp:Label id="lblCsdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_csdate").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td colspan="5">
														<asp:Label id="lblPdcont" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pdcont").ToString().Trim() %>'>
														</asp:Label>
													</td>
												</tr>
												<!-- 材料特性及應用產業相關資料 -->
												<tr vAlign="top">
													<td colSpan="14">
														<table cellSpacing="0" cellPadding="1" width="100%" border="0">
															<tr>
																<td vAlign="top" width="50%">材料特性：
																	<asp:datagrid id="dgdAtpMatp1" runat="server" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2" UseAccessibleHeader="True">
																		<Columns>
																			<asp:BoundColumn DataField="cls2_cname" ReadOnly="true">
																				<ItemStyle Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="cls3_cname" ReadOnly="true"></asp:BoundColumn>
																		</Columns>
																	</asp:datagrid></td>
																<td vAlign="top">應用產業：
																	<asp:datagrid id="dgdAtpMatp2" runat="server" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2" UseAccessibleHeader="True">
																		<Columns>
																			<asp:BoundColumn DataField="cls2_cname" ReadOnly="true">
																				<ItemStyle Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="cls3_cname" ReadOnly="true"></asp:BoundColumn>
																		</Columns>
																	</asp:datagrid></td>
															</tr>
														</table>
													</td>
												</tr>
												<!-- 發票廠商收件人 -->
												<tr vAlign="top">
													<td colSpan="14">
														&nbsp;發票廠商基本資料：
														<BR>
														<asp:datagrid id="dgdNewInvMfr" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="True">
															<Columns>
																<asp:BoundColumn ItemStyle-Width="25" DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_jbti" HeaderText="稱謂"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_addr" HeaderText="地址"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
																<asp:BoundColumn DataField="invcd" HeaderText="發票類別"></asp:BoundColumn>
																<asp:BoundColumn DataField="taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
															</Columns>
														</asp:datagrid>
													</td>
												</tr>
												<!-- 雜誌收件人及贈書資料 -->
												<tr vAlign="top">
													<td colSpan="14">
														&nbsp;雜誌收件人及贈書資料：
														<BR>
														<asp:datagrid id="dgdNewOr" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="True">
															<Columns>
																<asp:BoundColumn ItemStyle-Width="25" DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_nm" HeaderText="雜誌收件人姓名"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_addr" HeaderText="地址"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_fgmosea" HeaderText="國外"></asp:BoundColumn>
															</Columns>
														</asp:datagrid>
														<asp:DataGrid id="dgdNewFreeBk" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="True">
															<Columns>
																<asp:BoundColumn ItemStyle-Width="25" DataField="fbk_fbkitem" HeaderText="項次"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="str_ma_sdate" HeaderText="贈書起月"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="str_ma_edate" HeaderText="贈書迄月"></asp:BoundColumn>
																<asp:BoundColumn DataField="fc_nm" HeaderText="書籍"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="or_nm" HeaderText="收件人"></asp:BoundColumn>
																<asp:BoundColumn DataField="ma_pubmnt" HeaderText="當月刊登份數"></asp:BoundColumn>
																<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="未刊登份數"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
															</Columns>
															<PagerStyle CssClass="PagerStyle"></PagerStyle>
														</asp:DataGrid>
													</td>
												</tr>
											</table>
										</ItemTemplate>
				                        <SeparatorTemplate>
					                    <HR id="hr" width="100%" SIZE="2" color="Orange">
					                    <br />
				                        </SeparatorTemplate>
									</asp:datalist>
</span>

</asp:Content>


