<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubFm_chklist.aspx.cs" Inherits="mclpub.Layout.PubFm_chklist" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">


    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 落版檢核表</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">落版年月區間：</td>
    <td>
        <asp:TextBox ID="tbxDate1" runat="server" MaxLength="7" Width="70px"></asp:TextBox>

<span class="stripeMe">
        <font color="maroon" size="2">
        <asp:RegularExpressionValidator ID="revPubDate0" runat="server" ControlToValidate="tbxDate1" ErrorMessage="刊登年月 請依格式填入" Font-Size="Small"  Display="Dynamic" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        </font>

</span>

        ~<asp:TextBox ID="tbxDate2" runat="server" MaxLength="7" Width="70px"></asp:TextBox>
        <font color="maroon" size="2">

<span class="stripeMe">
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" ControlToValidate="tbxDate2" ErrorMessage="刊登年月 請依格式填入" Font-Size="Small" Display="Dynamic" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
</span>

        (如 
				2002/08, 預設值: 當月)</font>
        
        </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">合約書編號<span class="stripeMe">：</span></td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server"  MaxLength="6" 
            Width="74px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">
<span class="stripeMe">
        廠商名稱：</span></td>
    <td>
        <asp:TextBox ID="tbxMfrIName" runat="server" MaxLength="50"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnOK" runat="server" Text="查詢" onclick="btnOK_Click" />
        <input id="btn_clear" type="button" value="清除" name="btn_clear"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" onclick="clearValue()"/>
        <asp:Button ID="ReturnDefault" runat="server" Text="回首頁" 
            onclick="ReturnDefault_Click" />
    </td>
  </tr>
</table>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>
<span class="stripeMe">
<asp:Label ID="lbNoCount" runat="server" ForeColor="Maroon" Text="查無資料, 請重新輸入查詢條件!"></asp:Label>
<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt">
				<ItemTemplate>
					<table width="100%" align="center">
						<!-- 標題 -->
						<!-- 合約編號 & 其相關資料 -->
						<tr align="center" valign="top">
							<th>
								合約書
								<br />
								編號
							</th>
							<th valign="middle">
								合約書/落版/發票廠商收件人資料
							</th>
						</tr>
						<tr valign="top">
							<td width="7%">
								&nbsp;
								<asp:Label id="lblContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_contno").ToString().Trim() %>'>
								</asp:Label>
							</td>
							<td style="background-color:#5980d9">
								&nbsp;合約書資料：
							</td>
						</tr>
						<tr vAlign="top">
							<td Rowspan="5">
								&nbsp;
							</td>
							<td>
								<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="true">
									<Columns>
										<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
										<asp:BoundColumn DataField="cust_nm" HeaderText="客戶名稱"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付款"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_totjtm" HeaderText="總製稿"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_tottm" HeaderText="總刊登"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_chgjtm" HeaderText="換稿次數"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_freetm" HeaderText="贈送次數"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_clrtm" HeaderText="彩色"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_getclrtm" HeaderText="套色"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_menotm" HeaderText="黑白"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_totamt" HeaderText="總金額"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_adamt" HeaderText="廣告費單價"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_aunm" HeaderText="聯絡人姓名"></asp:BoundColumn>
										<asp:BoundColumn DataField="cont_autel" HeaderText="連絡電話"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</td>
						</tr>
						<!-- 合約書資料 -->
						<!-- 落版細節 -->
						<tr>
							<td style="background-color:#5980d9">
								&nbsp;落版細節：
								<br />
							</td>
						</tr>
						<tr>
							<td>
								<asp:DataList id="DataList2" runat="server" border="1">
									<ItemTemplate>
										<tr>
											<th>
												刊登年月
											</th>
											<th>
												落版序號
											</th>
											<th>
												廣告版面
											</th>
											<th>
												廣告色彩
											</th>
											<th>
												廣告篇幅
											</th>
											<th>
												固定頁次
											</th>
											<th>
												發廠
												<br />
												序號
											</th>
											<th>
												發廠
												<br />
												姓名
											</th>
											<th>
												修改業務員
											</th>
											<th>
												修改日期
											</th>
											<th>
												&nbsp;
											</th>
										</tr>
										<!-- 輸出內容2 -->
										<tr vAlign="top">
											<td width="10%" style="FONT-WEIGHT: bold">
												<asp:Label id="lblYYYYMM" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_yyyymm").ToString() %>'>
												</asp:Label>
											</td>
											<td width="10%" style="FONT-WEIGHT: bold">
												<asp:Label id="lblPubSeq" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_pubseq").ToString() %>'>
												</asp:Label>
											</td>
											<td width="10%">
												<asp:Label id="lblLtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ltp_nm").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="10%">
												<asp:Label id="lblClrcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "clr_nm").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="12%">
												<asp:Label id="lblPgscd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pgs_nm").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="5%">
												<asp:Label id="lblfgFixPg" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fgfixpg").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="8%">
												<asp:Label id="lblIMSeq" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_imseq").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="8%">
												<asp:Label id="lblIMName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "im_nm").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="11%">
												<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "srspn_cname").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="10%">
												<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_moddate").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td width="*">
												&nbsp;
											</td>
										</tr>
										<tr>
											<td>
												&nbsp;
											</td>
											<td style="background-color:#4CC9FF">
												廣告金額
											</td>
											<td style="background-color:#4CC9FF">
												換稿金額
											</td>
											<td style="background-color:#4CC9FF">
												已開立
												<br />
												發票單
											</td>
											<td style="background-color:#4CC9FF">
												發票開立單
												<br />
												人工處理
											</td>
											<td style="background-color:#4CC9FF">
												計劃代號
											</td>
											<td style="background-color:#4CC9FF">
												成本中心
											</td>
											<td colSpan="4" style="background-color:#4CC9FF">
												備註
											</td>
										</tr>
										<tr vAlign="top">
											<td>
												&nbsp;
											</td>
											<td>
												$
												<asp:Label id="lblAdamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_adamt").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												$
												<asp:Label id="lblChgAmt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgamt").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblfgInved" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fginved").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblfgInvSelf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fginvself").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblProjNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_projno").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblCostCtr" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_costctr").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td colSpan="4">
												<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_remark").ToString().Trim() %>'>
												</asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												&nbsp;
											</td>
											<td style="background-color:#4CC9FF">
												稿件類別
											</td>
											<td style="background-color:#4CC9FF">
												到稿
											</td>
											<td style="background-color:#4CC9FF">
												新稿製法
											</td>
											<td style="background-color:#4CC9FF">
												改稿書類
											</td>
											<td style="background-color:#4CC9FF">
												改稿期別
											</td>
											<td style="background-color:#4CC9FF">
												改稿頁碼
											</td>
											<td style="background-color:#4CC9FF">
												改稿重出片
											</td>
											<td style="background-color:#4CC9FF">
												舊稿書類
											</td>
											<td style="background-color:#4CC9FF">
												舊稿期別
											</td>
											<td style="background-color:#4CC9FF">
												舊稿頁碼
											</td>
										</tr>
										<tr vAlign="top">
											<td>
												&nbsp;
											</td>
											<td>
												<asp:Label id="lblDrafttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_drafttp").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblfgGot" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fggot").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblfgNjtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "njtp_nm").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblChgbkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgbkcd").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblChgJNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgjno").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblChgJbkno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_chgjbkno").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblfgReChg" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_fgrechg").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblOrigBkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bk_nm").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblOrigJNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_origjno").ToString().Trim() %>'>
												</asp:Label>
											</td>
											<td>
												<asp:Label id="lblOrigJbkno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "pub_origjbkno").ToString().Trim() %>'>
												</asp:Label>
											</td>
										</tr>
									</ItemTemplate>
								</asp:DataList>
							</td>
						</tr>
						<!-- 發票廠商收件人 -->
						<tr>
							<td style="background-color:#5980d9">
								&nbsp;發票廠商收件人：
								<br />
							</td>
						</tr>
						<tr>
							<td>
								<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="true" Width="100%">
									<Columns>
										<asp:BoundColumn DataField="im_imseq" HeaderText="序號"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_nm" HeaderText="收件人姓名"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_jbti" HeaderText="職稱"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_addr" HeaderText="發票地址"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_fax" HeaderText="傳真"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_cell" HeaderText="手機"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
										<asp:BoundColumn DataField="im_fgitri" HeaderText="院所內註記"></asp:BoundColumn>
									</Columns>
								</asp:DataGrid>
							</td>
						</tr>
					</table>
				</ItemTemplate>
				<SeparatorTemplate>
					<font color='DarkRed'><B>＊除金額等重要值要注意外，也請確認”計劃代號”及”成本中心”的值！</B></font>
					<HR id="hr" width="100%" SIZE="2" color="#AAAAAA">
					<br />
				</SeparatorTemplate>
			</asp:datalist>

</span>



<script>
    function clearValue() {
        document.getElementById("<% =tbxDate1.ClientID%>").value = "";
        document.getElementById("<% =tbxDate2.ClientID%>").value = "";
        document.getElementById("<% =tbxContNo.ClientID%>").value = "";
        document.getElementById("<% =tbxMfrIName.ClientID%>").value = "";     
    }
</script>
 </asp:Content>
