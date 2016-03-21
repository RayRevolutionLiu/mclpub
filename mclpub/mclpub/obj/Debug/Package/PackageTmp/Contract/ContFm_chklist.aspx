<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContFm_chklist.aspx.cs" Inherits="mclpub.Contract.ContFm_chklist"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script>
    $(function() {
    $("#<% =tbxSignDate1.ClientID%>").datepicker(
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
    $("#<% =tbxSignDate2.ClientID%>").datepicker(
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
    function cleanAll() {
        window.document.getElementById("<% =tbxSignDate1.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSignDate2.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSDate.ClientID%>").value = "";
        window.document.getElementById("<% =tbxEDate.ClientID%>").value = "";
        window.document.getElementById("<% =ddlfgclosed.ClientID%>").value = "99";
        window.document.getElementById("<% =ddlEmpNo.ClientID%>").value = "000000";
        window.document.getElementById("<% =tbxContNo.ClientID%>").value = "";
        window.document.getElementById("<% =tbxMfrIName.ClientID%>").value = "";
    }

</script>
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;廣告合約管理 / 平面廣告合約書 / 合約書檢核表</span>
<span class="stripeMe"> 
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        <asp:Label ID="lblSignDate" runat="server">簽約日期區間：</asp:Label>
      </td>
    <td>
        <asp:TextBox ID="tbxSignDate1" runat="server" MaxLength="10"></asp:TextBox>
        ~<asp:TextBox ID="tbxSignDate2" runat="server" MaxLength="10"></asp:TextBox>
<span class="stripeMe">
        <asp:Label id="lblSEDateMemo0" runat="server"  ForeColor="Maroon">(yyyy/mm/dd)</asp:Label>
</span>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        <asp:Label ID="lblSEDate" runat="server">合約起迄區間：</asp:Label>
      </td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server" Width="50px" ></asp:TextBox>
        ~<asp:TextBox ID="tbxEDate" runat="server" Width="50px"></asp:TextBox>
        <asp:Label id="lblSEDateMemo" runat="server"  ForeColor="Maroon">(如 200206  ～ 200212)</asp:Label></td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        <asp:Label ID="lblfgclosed" runat="server">已結案：</asp:Label>
      </td>
    <td>
        <asp:DropDownList ID="ddlfgclosed" runat="server">
        <asp:ListItem Value="99" Selected="True">請選擇</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        <asp:Label ID="lblEmpNo" runat="server">承辦業務員：</asp:Label>
      </td>
    <td>
        <asp:DropDownList ID="ddlEmpNo" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        <asp:Label ID="lblContNo" runat="server">合約書編號：</asp:Label>
      </td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server" MaxLength="6" ></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        <asp:Label ID="lblMfrIName" runat="server">廠商名稱：</asp:Label>
      </td>
    <td>
        <asp:TextBox ID="tbxMfrIName" runat="server"></asp:TextBox>
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
<asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="新細明體" border="1" OnItemDataBound="DataList1OnItemDataBound">
                <HeaderTemplate>
                    <asp:Label ID="LbCount" runat="server" ForeColor="Maroon"></asp:Label>
                </HeaderTemplate>
				<ItemTemplate>
					<table width="100%"  cellSpacing="1" cellPadding="0" align="center" style="FONT-SIZE:smaller" border="1">
						<!-- 標題 -->
						<TR>
							<th>
								合約書編號
							</th>
							<th colSpan="3">
								廠商名稱
								<BR>
								(廠商統編)
							</th>
							<th>
								客戶名稱
								<BR>
								(編號)
							</th>
							<th>
								簽約日期
							</th>
							<th>
								合約類別
							</th>
							<th>
								書籍類別
							</th>
							<th>
								合約起迄
							</th>
							<th>
								建檔
								<BR>
								業務員 /
								<BR>
								修改者
							</th>
							<th>
								一次
								<BR>
								付清
							</th>
							<th>
								結案
							</th>
							<th>
								參考
								<BR>
								合約
								<BR>
								編號
							</th>
							<th>
								建檔日期 /
								<BR>
								修改日期
							</th>
						</TR>
						<!-- 輸出內容 -->
						<TR vAlign="top">
							<TD width="6%" style="FONT-WEIGHT: bold">
								<asp:Label id="lblContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_contno") %>'></asp:Label>
							</TD>
							<TD width="*" colSpan="3">
								<asp:Label id="lblMfrIName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm").ToString().Trim() %>'></asp:Label>
								(
								<asp:Label id="lblMfrNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_mfrno").ToString().Trim() %>'></asp:Label>
								)&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblCustName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_nm").ToString().Trim() %>'></asp:Label>
								&nbsp;
								<BR>
								(
								<asp:Label id="lblCustNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_custno").ToString().Trim() %>'></asp:Label>
								)&nbsp;
							</TD>
							<TD width="6%">
								<asp:Label id="lblSignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_signdate").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblConttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_conttp").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblBkcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bk_nm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_sdate").ToString().Trim() %>'></asp:Label>
								&nbsp;~
								<BR>
								<asp:Label id="lblEndDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_edate").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="9%">
								<asp:Label id="lblEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "srspn_cname").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_modempno").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD width="3%">
								<asp:Label id="lblfgPayonce" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgpayonce").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="6%">
								<asp:Label id="lblfgClosed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgclosed").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="8%">
								<asp:Label id="lblOldContNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_oldcontno").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD width="10%">
								<asp:Label id="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_credate").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_moddate").ToString().Trim() %>'></asp:Label>
							</TD>
						</TR>
						<tr>
							<TD>
								&nbsp;
							</TD>
							<th style="background-color:#4CC9FF">
								總製稿
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								已製稿
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								剩餘
								<BR>
								製稿
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								總刊登
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								已刊登
								<BR>
								次數</th>
							<th style="background-color:#4CC9FF">
								剩餘
								<BR>
								刊登
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								合約
								<BR>
								總金額
							</th>
							<th style="background-color:#4CC9FF">
								已繳
								<BR>
								金額
							</th>
							<th style="background-color:#4CC9FF">
								剩餘
								<BR>
								金額
							</th>
							<th style="background-color:#4CC9FF">
								換稿
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								贈送
								<BR>
								次數 /
								<BR>
								本數
							</th>
							<th style="background-color:#4CC9FF">
								廣告費
								<BR>
								單價
							</th>
							<th style="background-color:#4CC9FF">
								優惠折扣
							</th>
						</tr>
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblTotjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblMadejtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_madejtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblRestjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblTottm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_tottm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblPubtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblResttm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_resttm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblTotamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPaidamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_paidamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblRestamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblChgjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_chgjtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblFreetm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freetm").ToString().Trim() %>'></asp:Label>
								&nbsp; / &nbsp;
								<asp:Label id="lblFreebkcnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freebkcnt").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD>
								$
								<asp:Label id="lblAdamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_adamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblDiscount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_disc").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
						</TR>
						<tr>
							<TD>
								&nbsp;
							</TD>
							<th style="background-color:#4CC9FF">
								彩色
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								套色
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								黑白
								<BR>
								次數
							</th>
							<th style="background-color:#4CC9FF">
								落版
								<BR>
								總廣告
								<BR>
								金額
							</th>
							<th style="background-color:#4CC9FF">
								落版
								<BR>
								總換稿
								<BR>
								金額
							</th>
							<TD>
								&nbsp;
							</TD>
							<th style="background-color:#4CC9FF">
								聯絡人
								<BR>
								姓名
							</th>
							<th style="background-color:#4CC9FF">
								電話
							</th>
							<th style="background-color:#4CC9FF">
								傳真
							</th>
							<th style="background-color:#4CC9FF">
								手機
								<BR>
								/ Email
							</th>
							<th colSpan="3" style="background-color:#4CC9FF">
								備註
							</th>
						</tr>
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblClrtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_clrtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblGetclrtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_getclrtm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblMenotm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_menotm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPubamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								$
								<asp:Label id="lblPubchgamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_chgamt").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aunm").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_autel").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aufax").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
							<TD>
								<asp:Label id="lblAuCell" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aucell").ToString().Trim() %>'></asp:Label>
								&nbsp; /
								<BR>
								<asp:Label id="lblAuEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_auemail").ToString().Trim() %>'></asp:Label>
							</TD>
							<TD colSpan="3">
								<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_remark").ToString().Trim() %>'></asp:Label>
								&nbsp;
							</TD>
						</TR>
						<!-- 發票廠商收件人 -->
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD colSpan="14">
								&nbsp;發票廠商收件人：<span class="stripeMe"><asp:GridView ID="GridView1" 
                                    runat="server" AutoGenerateColumns="false" 
                                    CssClass="font_blacklink font_size13" onrowdatabound="GridView1_RowDataBound" 
                                    Width="99%" Font-Size="7pt">
                                    <Columns>
                                        <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                                        <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                                        <asp:BoundField DataField="im_nm" HeaderText="合約編號" />
                                        <asp:BoundField DataField="im_jbti" HeaderText="收件人姓名" />
                                        <asp:BoundField DataField="im_zip" HeaderText="職稱" />
                                        <asp:BoundField DataField="im_addr" HeaderText="郵遞區號" />
                                        <asp:BoundField DataField="im_tel" HeaderText="電話" />
                                        <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                                        <asp:BoundField DataField="im_cell" HeaderText="手機" />
                                        <asp:BoundField DataField="im_email" HeaderText="Email" />
                                        <asp:BoundField DataField="im_invcd" HeaderText="發票類別" />
                                        <asp:BoundField DataField="im_taxtp" HeaderText="發票課稅別" />
                                        <asp:BoundField DataField="im_fgitri" HeaderText="院所內註記" />
                                    </Columns>
                                </asp:GridView>
                                </span><br />
							</TD>
						</TR>
						<!-- 雜誌收件人 -->
						<TR vAlign="top">
							<TD>
								&nbsp;
							</TD>
							<TD colSpan="14">
								&nbsp;雜誌收件人：<br />
                            <asp:GridView ID="GridView2" runat="server" Width="99%" AutoGenerateColumns="false" 
                                    CssClass="font_blacklink font_size13" onrowdatabound="GridView2_RowDataBound" Font-Size="7pt">
                            <Columns>
                            <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                            <asp:BoundField DataField="or_inm" HeaderText="廠商名稱" />
                            <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
                            <asp:BoundField DataField="or_jbti" HeaderText="職稱" />
                            <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
                            <asp:BoundField DataField="or_addr" HeaderText="郵寄地址" />
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
							</TD>
						</TR>
					</table>
				</ItemTemplate>
				<SeparatorTemplate>
					<HR id="hr" width="100%" SIZE="2" color="Orange">
					<br />
				</SeparatorTemplate>
			</asp:datalist>

</span>
</asp:Content>