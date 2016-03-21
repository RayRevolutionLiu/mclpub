<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adpub_act2.aspx.cs" Inherits="mclpub.Layout.adpub_act2" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
.connectedSortable { list-style-type: none; margin: 0; padding: 0; float: left; margin-right: 2px; }
.ui-state-default2 { margin: 0px 5px 5px 5px; padding: 2px; font-size:0.7em; width: 88px; height:200px; float: left;}

#fMenu
{
	width:100px;
	BACKGROUND-COLOR: #99cc99;
	BORDER-RIGHT:  #99cc99 thin solid;
	BORDER-TOP:  #99cc99 thin solid;
	BORDER-LEFT:  #99cc99 thin solid;
	BORDER-BOTTOM:  #99cc99 thin solid;
}
.srcData
{
    padding-left:1px;
    padding-right:1px;
    padding-bottom:0px;
    padding-top:0px;
    background-color:#99cc99;
	BORDER-RIGHT: darkseagreen thin outset;
	BORDER-TOP: darkseagreen thin outset;
	BORDER-LEFT: darkseagreen thin outset;
	BORDER-BOTTOM: darkseagreen thin outset;
	COLOR:#336633;
	font-size:10pt;
	vertical-align:middle;
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="tbxStartPageNo" type="hidden" runat="server" />&nbsp;
    <input id="hid_xxx" type="hidden" runat="server" />&nbsp;
    <input id="hidData_special" type="hidden" name="hidData_special" runat="server">
    <input id="hidData" type="hidden" name="hidData" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 廣告排版動作</span>
    <span class="stripeMe">
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1" class="noclass">檢視</a></li>
                <li><a href="#tabs-2" class="noclass">落版</a></li>
                <li><a href="#tabs-3" class="noclass">列印</a></li>
            </ul>
            <div id="tabs-1" style="font-size:11px">
                <table border="0" width="100%" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td colspan="22" align="center" style="background-color: #003399">
                                <strong><font size="4"><font color="#ffffff">廣告排版版面&nbsp; -</font>
                                    <asp:Label ID="lblSearchKeyword" runat="server" ForeColor="Gold" Font-Size="X-Small"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lblDBMessage" runat="server" ForeColor="Cyan" Font-Size="X-Small"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblTotalCounts" runat="server" ForeColor="Orange" Font-Size="X-Small"></asp:Label>&nbsp;
                                    <asp:Label ID="lblClrPgsGroupCount" runat="server" Font-Size="X-Small" ForeColor="Orange"></asp:Label>
                                </font></strong>
                            </td>
                        </tr>
                    <tr>
						<th>
							新頁次
						</th>
						<th>
							合約書
							<br />
							編號
						</th>
						<th>
							落版
							<br />
							序號
						</th>
						<th>
							刊登
							<br />
							年月
						</th>
						<th>
							刊登
							<br />
							頁碼
						</th>
						<th width="8%">
							版面
						</th>
						<th>
							色彩
						</th>
						<th>
							篇幅
						</th>
						<th>
							固定
							<br />
							頁次
						</th>
						<th>
							<font color="red">公司名稱</font>
						</th>
						<th>
							到稿
						</th>
						<th>
							新稿
							<br />
							製法
						</th>
						<th>
							改稿
							<br />
							書籍
						</th>
						<th>
							改稿
							<br />
							期別
						</th>
						<th>
							改稿
							<br />
							頁碼
						</th>
						<th>
							改稿
							<br />
							重出片
						</th>
						<th>
							舊稿
							<br />
							書籍
						</th>
						<th>
							舊稿
							<br />
							期別
						</th>
						<th>
							舊稿
							<br />
							頁碼
						</th>
						<th>
							落版
							<br />
							業務員
						</th>
						<th>
							備註
						</th>
					</tr>
                    <tr>
                        <td align="left" style="background-color: #ffff00" colspan="22">
                            <font color="green" size="2"><b>特殊版面</b></font>
                        </td>
                    </tr>
                    </thead>
                    <tbody id="dataTBODYSpecial">
                        <%--<tr valign="bottom" align="middle">
                            <td>
                                <span datafld="頁次" id="OrderS"><font face="新細明體"></font></span>
                            </td>
                            <td>
                                <span datafld="合約書編號" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="落版序號" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="刊登年月" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td align="right">
                                <span datafld="刊登頁碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td width="8%">
                                <span datafld="廣告版面" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="廣告色彩" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="廣告篇幅" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="固定頁次註記" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                border-left: #595959 0px solid; border-bottom: #595959 1px solid" align="left">
                                <!-- 當 load 自資料庫時: idCompanyName 的 onclick() 裡要變更為 DSOS -->
                                <span datafld="公司名稱" id="idCompanyName1"></span>
                            </td>
                            <td>
                                <span datafld="到稿註記" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="新稿製法" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿書籍代碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿期別" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿頁碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿重出片註記" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="舊稿書籍名稱" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="舊稿期別" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="舊稿頁碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="落版業務員姓名" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td align="left">
                                <span datafld="備註" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                        </tr>--%>
                    </tbody>
                </table>
                <%--<asp:GridView ID="specialGV" runat="server" Width="100%" AutoGenerateColumns="false"
                    Font-Size="7" OnRowDataBound="specialGV_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="頁次" HeaderText="新頁次" />
                        <asp:BoundField DataField="合約書編號" HeaderText="合約書<br />編號" />
                        <asp:BoundField DataField="落版序號" HeaderText="落版<br />序號" />
                        <asp:BoundField DataField="刊登年月" HeaderText="刊登<br />年月" />
                        <asp:BoundField DataField="刊登頁碼" HeaderText="刊登<br />頁碼" />
                        <asp:BoundField DataField="廣告版面" HeaderText="版面" />
                        <asp:BoundField DataField="廣告色彩" HeaderText="色彩" />
                        <asp:BoundField DataField="廣告篇幅" HeaderText="篇幅" />
                        <asp:BoundField DataField="固定頁次註記" HeaderText="固定<br />頁次" />
                        <asp:BoundField DataField="公司名稱" HeaderText="公司名稱" />
                        <asp:BoundField DataField="到稿註記" HeaderText="到稿" />
                        <asp:BoundField DataField="新稿製法" HeaderText="新稿<br />製法" />
                        <asp:BoundField DataField="改稿書籍代碼" HeaderText="改稿<br />書籍" />
                        <asp:BoundField DataField="改稿期別" HeaderText="改稿<br />期別" />
                        <asp:BoundField DataField="改稿頁碼" HeaderText="改稿<br />頁碼" />
                        <asp:BoundField DataField="改稿重出片註記" HeaderText="改稿<br />重出片" />
                        <asp:BoundField DataField="舊稿書籍名稱" HeaderText="舊稿<br />書籍 " />
                        <asp:BoundField DataField="舊稿期別" HeaderText="舊稿<br />期別" />
                        <asp:BoundField DataField="舊稿頁碼" HeaderText="舊稿<br />頁碼" />
                        <asp:BoundField DataField="落版業務員姓名" HeaderText="落版<br />業務員" />
                        <asp:BoundField DataField="備註" HeaderText="備註" />
                    </Columns>
                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        查詢無結果
                    </EmptyDataTemplate>
                </asp:GridView>--%>
                <table border="0" width="100%" cellspacing="0" cellpadding="0">
                    <thead>
                        <tr>
                            <td align="left" style="background-color: #ffff00" colspan="22">
                                <font color="green" size="2"><b>一般版面</b></font>
                            </td>
                        </tr>
                        <tr style="background-color: #bfcff0">
                            <th>
                                新頁次
                            </th>
                            <th>
                                合約書
                                <br />
                                編號
                            </th>
                            <th>
                                落版
                                <br />
                                序號
                            </th>
                            <th>
                                刊登
                                <br />
                                年月
                            </th>
                            <th>
                                刊登
                                <br />
                                頁碼
                            </th>
                            <th width="8%">
                                版面
                            </th>
                            <th>
                                色彩
                            </th>
                            <th>
                                篇幅
                            </th>
                            <th>
                                固定
                                <br />
                                頁次
                            </th>
                            <th>
                                <font color="red">公司名稱</font>
                            </th>
                            <th>
                                到稿
                            </th>
                            <th>
                                新稿
                                <br />
                                製法
                            </th>
                            <th>
                                改稿
                                <br />
                                書籍
                            </th>
                            <th>
                                改稿
                                <br />
                                期別
                            </th>
                            <th>
                                改稿
                                <br />
                                頁碼
                            </th>
                            <th>
                                改稿
                                <br />
                                重出片
                            </th>
                            <th>
                                舊稿
                                <br />
                                書籍
                            </th>
                            <th>
                                舊稿
                                <br />
                                期別
                            </th>
                            <th>
                                舊稿
                                <br />
                                頁碼
                            </th>
                            <th>
                                落版
                                <br />
                                業務員
                            </th>
                            <th>
                                備註
                            </th>
                        </tr>
                    </thead>
                    <tbody onmousemove="doMouseMove(event)" id="dataTBODYCommon">
<%--                        <tr valign="bottom" align="middle">
                            <td>
                                <span datafld="頁次" id="pageorder"><font face="新細明體"></font></span>
                            </td>
                            <td>
                                <span datafld="合約書編號" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="落版序號" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="刊登年月" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td align="right">
                                <span datafld="刊登頁碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td nowrap width="8%">
                                <span datafld="廣告版面" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="廣告色彩" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="廣告篇幅" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="固定頁次註記" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                border-left: #595959 0px solid; border-bottom: #595959 1px solid" align="left">
                                <!-- 當 load 自資料庫時: idCompanyName 的 onclick() 裡要變更為 DSO1 -->
                                <span datafld="公司名稱" id="idCompanyName" onclick="doClick(event)"></span>
                            </td>
                            <td>
                                <span datafld="到稿註記" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="新稿製法" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿書籍代碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿期別" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿頁碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="改稿重出片註記" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="舊稿書籍名稱" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="舊稿期別" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="舊稿頁碼" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td>
                                <span datafld="落版業務員姓名" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                            <td align="left">
                                <span datafld="備註" style="border-right: #595959 0px solid; border-top: #595959 0px solid;
                                    border-left: #595959 0px solid; border-bottom: #595959 1px solid"></span>
                            </td>
                        </tr>--%>
                    </tbody>
                </table>
                <%--<asp:GridView ID="CommonGV" runat="server" Width="100%" AutoGenerateColumns="false"
                    Font-Size="7" OnRowDataBound="CommonGV_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="頁次" HeaderText="新頁次" />
                        <asp:BoundField DataField="合約書編號" HeaderText="合約書<br />編號" />
                        <asp:BoundField DataField="落版序號" HeaderText="落版<br />序號" />
                        <asp:BoundField DataField="刊登年月" HeaderText="刊登<br />年月" />
                        <asp:BoundField DataField="刊登頁碼" HeaderText="刊登<br />頁碼" />
                        <asp:BoundField DataField="廣告版面" HeaderText="版面" />
                        <asp:BoundField DataField="廣告色彩" HeaderText="色彩" />
                        <asp:BoundField DataField="廣告篇幅" HeaderText="篇幅" />
                        <asp:BoundField DataField="固定頁次註記" HeaderText="固定<br />頁次" />
                        <asp:BoundField DataField="公司名稱" HeaderText="公司名稱" />
                        <asp:BoundField DataField="到稿註記" HeaderText="到稿" />
                        <asp:BoundField DataField="新稿製法" HeaderText="新稿<br />製法" />
                        <asp:BoundField DataField="改稿書籍代碼" HeaderText="改稿<br />書籍" />
                        <asp:BoundField DataField="改稿期別" HeaderText="改稿<br />期別" />
                        <asp:BoundField DataField="改稿頁碼" HeaderText="改稿<br />頁碼" />
                        <asp:BoundField DataField="改稿重出片註記" HeaderText="改稿<br />重出片" />
                        <asp:BoundField DataField="舊稿書籍名稱" HeaderText="舊稿<br />書籍 " />
                        <asp:BoundField DataField="舊稿期別" HeaderText="舊稿<br />期別" />
                        <asp:BoundField DataField="舊稿頁碼" HeaderText="舊稿<br />頁碼" />
                        <asp:BoundField DataField="落版業務員姓名" HeaderText="落版<br />業務員" />
                        <asp:BoundField DataField="備註" HeaderText="備註" />
                    </Columns>
                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        查詢無結果
                    </EmptyDataTemplate>
                </asp:GridView>--%>
                <table border="0" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="background-color:#bfcff0">
                            <span class="font_size13">
                            欲修改落版資料, 請至請至 <a href="../Contract/PlaneCont.aspx" target="_self">合約管理 / 平面廣告合約書</a>或
                            <a href="pub_new2.aspx" target="_self">落版管理 / 平面廣告落版處理 / 新增/維護/顯示 落版 / 由年月落版進入</a> 來修改!
                            <br />
                            列印說明: 如需列印本頁資料做為書面參考紙本, 列印時請選擇 <span class="font_darkblue">橫印</span>, 以得完整資料畫面!
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <input id="btnReOrder" onclick="Javascript: doReOrder();" type="button" value="重排頁次"
                             class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" name="btnReOrder">&nbsp;&nbsp;
                <input id="btnWritetoDB" onclick="doWriteToDB()" type="button" value="確認寫回" name="btnBack" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
                            <br>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="tabs-2">
                <span class="font_size13 font_bold font_gray">

                        <%--<li>請輸入任一關鍵詞然後按下<span class="font_darkblue">「查詢」</span></li>--%>廣告色彩<br />
                        <span style="color:Green">綠色外框表示彩色</span>，
                        <span style="color: #fe7800">橙色外框表示套色</span>，
                        <span style="color: Red">紅色外框表示拉頁</span>，
                        黑框為黑白全頁，無框為黑白半頁
                </span>
                <asp:Panel ID="PanelLayoutAll" runat="server">
                </asp:Panel>
                <div align="right">
                <asp:Button ID="submitBtn" runat="server" Text="確認寫回" OnClick="submitBtn_Click" OnClientClick="if(!checkLayout()){return false;}" /></div>
            </div>
            <div id="tabs-3">
                <span style="color: Red">註:請確認寫回之後再產生Excel</span><br />
                <asp:Button ID="exportExcelBtn" runat="server" Text="產生Excel" OnClick="exportExcelBtn_Click" />
            </div>
        </div>      
    </span>
    <center>
        <div id="ico" class="srcData" style="display: none; z-index: 999; position:absolute;">
        </div>
    </center>
    <script language="javascript" type="text/javascript">
        function allid() {
            //alert("111");
            var liObjs = document.getElementsByTagName('li');
            //            alert(element[70].value);
            //            alert(element.length);
            var val = "";
            for (var i = 0; i < liObjs.length; i++) {
                if (liObjs[i].getAttribute("name") != "" && liObjs[i].getAttribute("name") != null) {
                    if (i == liObjs.length - 1) {
                        val += liObjs[i].getAttribute("name");
                    }
                    else {
                        val += liObjs[i].getAttribute("name") + "-";
                    }
                }
            }
            //alert(val);
            window.document.getElementById("<% =hidData_special.ClientID%>").value = val;
        }
        window.onload = allid;

        //判斷每一個UL底下只能有8個LI 不然表示排版錯誤
        function checkLayout() {
            var liObjs = document.getElementsByTagName('ul');
            for (var i = 0; i < liObjs.length; i++) {
                if (liObjs[i].getAttribute("id") != "" && liObjs[i].getAttribute("id") != null) {
                    if (liObjs[i].childNodes.length != 8) {
                        alert("落版錯誤 請檢查");
                        return false;
                    }
                }
            }
            return true;
        }
    </script>
    <!-- xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").只有IE能用 但是22個欄位會把程式寫太長 所以寫個FUNCTION處裡-->
    <script>
        function ReturnThinSelectNode(i, e, tagName) {
            var cot_text = "";
            if (e.getElementsByTagName(tagName)[i] != null) {
                cot_text = (e.getElementsByTagName(tagName)[i].firstChild == null) ? "" : e.getElementsByTagName(tagName)[i].firstChild.data.toString();
            }
            return cot_text;
        }
    
    </script>
    <script language="javascript">
        var xmlDoc = null;
        if (window.ActiveXObject) {
            //for IE
            xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
            xmlDoc.async = "false";
            xmlDoc.loadXML(document.getElementById("<% =hidData_special.ClientID%>").value);

        } else if (document.implementation.createDocument) {
            try {//FireFox  
                xmlDoc = document.implementation.createDocument("", "", null);
                xmlDoc.async = false;
                xmlDoc = (new DOMParser()).parseFromString(document.getElementById("<% =hidData_special.ClientID%>").value, "text/xml");
            } catch (e) {//Chrome,Safari  
                var xmlhttpChrome = new window.XMLHttpRequest();
                xmlhttpChrome.open("GET", document.getElementById("<% =hidData_special.ClientID%>").value, false);
                xmlhttpChrome.send(null);
                xmlDoc = xmlhttpChrome.responseXML.documentElement;
            }
        } 
        var i=0;
        for (i = 0; i < xmlDoc.getElementsByTagName("Table").length; i++) {
            $("#dataTBODYSpecial").append("<tr valign='bottom' align='middle'>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"頁次") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"合約書編號") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"落版序號") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"刊登年月") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"刊登頁碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"廣告版面") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"廣告色彩") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"廣告篇幅") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"固定頁次註記") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"公司名稱")+ "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"改稿期別")+ "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"到稿註記")+ "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"新稿製法")+ "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"改稿書籍代碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"改稿頁碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"改稿重出片註記") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"舊稿書籍名稱") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"舊稿期別") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"舊稿頁碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"落版業務員姓名") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(i,xmlDoc,"備註") + "</span></td>" +
            "</tr>"
            );
        }

//        var xmldocts = DSO0.XMLDocument;
//        xmldocts.async = false;
//        xmldocts.loadXML(document.getElementById("<% =hidData_special.ClientID%>").value);
    </script>
    <script language="javascript">
        var xmlDocCom = null;
        //alert(document.getElementById("<% =hidData.ClientID%>").value);
        if (window.ActiveXObject) {
            //for IE
            xmlDocCom = new ActiveXObject("Microsoft.XMLDOM");
            xmlDocCom.async = "false";
            xmlDocCom.loadXML(document.getElementById("<% =hidData.ClientID%>").value);

        } else if (document.implementation.createDocument) {
            try {//FireFox  
                xmlDocCom = document.implementation.createDocument("", "", null);
                xmlDocCom.async = false;
                xmlDocCom = (new DOMParser()).parseFromString(document.getElementById("<% =hidData.ClientID%>").value, "text/xml");
            } catch (e) {//Chrome,Safari  
                var xmlhttpChrome = new window.XMLHttpRequest();
                xmlhttpChrome.open("GET", document.getElementById("<% =hidData.ClientID%>").value, false);
                xmlhttpChrome.send(null);
                xmlDocCom = xmlhttpChrome.responseXML.documentElement;
            }
        }
        //alert(xmlDocCom.xml);
        //插入頭尾空白node
        var xmlDocEmpty = null;
        if (window.ActiveXObject) {
            //for IE
            xmlDocEmpty = new ActiveXObject("Microsoft.XMLDOM");
            xmlDocEmpty.async = "false";
            xmlDocEmpty.loadXML(document.getElementById("<% =hid_xxx.ClientID%>").value);

        } else if (document.implementation && document.implementation.createDocument) {
            try {//FireFox  
                xmlDocEmpty = document.implementation.createDocument("", "", null);
                xmlDocEmpty.async = false;
                //                alert(document.getElementById("<% =hid_xxx.ClientID%>").value);
                xmlDocEmpty = (new DOMParser()).parseFromString(document.getElementById("<% =hid_xxx.ClientID%>").value, "text/xml");
            } catch (e) {//Chrome,Safari  
                var xmlhttpChrome = new window.XMLHttpRequest();
                xmlhttpChrome.open("GET", document.getElementById("<% =hid_xxx.ClientID%>").value, false);
                xmlhttpChrome.send(null);
                xmlDocEmpty = xmlhttpChrome.responseXML.documentElement;
            }
        }
        //        var xmldoct = DSO1.XMLDocument;
        //        xmldoct.async = false;
        //        xmldoct.loadXML(document.getElementById("<% =hidData.ClientID%>").value);


        //插入頭尾空白node
        //        var xmlDocEmpty = DSOX.XMLDocument;
        //        xmlDocEmpty.async = false;
        //        xmlDocEmpty.load("adpub_data_empty.xml");
        var newHeadNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
        var newTailNode = xmlDocEmpty.documentElement.firstChild.cloneNode(true);
        //alert(xmlDocEmpty.xml);
        // 下幾行是 for - 自 資料庫 載入時
        xmlDocCom.documentElement.insertBefore(newHeadNode, xmlDocCom.documentElement.childNodes.item(0));
        xmlDocCom.documentElement.appendChild(newTailNode);
        LoadCommonXml();
        // 下幾行是給 doReOrder() 裡用的 Global Variable

        function LoadCommonXml() {
            $("#dataTBODYCommon tr").remove();
            var j = 0;
            //alert(xmlDocCom.getElementsByTagName("頁次").length);
            for (j = 0; j < xmlDocCom.getElementsByTagName("頁次").length; j++) {//舊系統是判斷xmlDocCom.getElementsByTagName("item") 但是因為item在XML是保留字 所以用頁次 因為頁次一定會有
                $("#dataTBODYCommon").append("<tr valign='bottom' align='middle'>" +
            "<td><span name='pageorder' pageorder='" + ReturnThinSelectNode(j, xmlDocCom, "頁次") + "'>" + ReturnThinSelectNode(j, xmlDocCom, "頁次") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "合約書編號") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "落版序號") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "刊登年月") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "刊登頁碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "廣告版面") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "廣告色彩") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "廣告篇幅") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "固定頁次註記") + "</span></td>" +
            "<td><span id='idCompanyName' onclick='doClick(event)' style='border-right: #595959 0px solid; border-top: #595959 0px solid; border-left: #595959 0px solid; border-bottom: #595959 1px solid;cursor: pointer;'>" + ReturnThinSelectNode(j, xmlDocCom, "公司名稱") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "改稿期別") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "到稿註記") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "新稿製法") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "改稿書籍代碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "改稿頁碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "改稿重出片註記") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "舊稿書籍名稱") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "舊稿期別") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "舊稿頁碼") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "落版業務員姓名") + "</span></td>" +
            "<td><span>" + ReturnThinSelectNode(j, xmlDocCom, "備註") + "</span></td>" +
            "</tr>"
            );
            }
        }

        var Arr = new Array();
    </script>
    		<!-- 抓出目前排版的新頁次, 寫入 hiddata 裡, 最後再將新頁次寫回資料庫 -->
    <script language="javascript">
        function doWriteToDB() {
            //下幾行是 for - 自 資料庫 載入時
            //先抓出目前畫面中的頁次
            if (SortNeedPressFirst == false) {
                alert("請先按下重排頁次方能寫回");
                return;
            }
            //var xmlDoc = DSO1.XMLDocument;
            //alert(xmlDoc.documentElement.xml);
            //alert(xmlDoc.getElementsByTagName("頁次").length);

            //for(var i=0; i< document.all.pageorder.length; i++)
//            for (var i = 1; i < (xmlDocCom.getElementsByTagName("頁次").length - 1); i++) {
//                //alert(document.all.pageorder[i].innerText);
//                // 抓出非空白 node 之所有畫面上的新頁次
//                //if(document.all.pageorder[i].innerText != "--")
//                if (xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue != "") {
//                    // 檢查輸出 畫面上的新頁次
//                    //alert(document.all.pageorder[i].innerText);

//                    // 改寫 DSOT.XMLDocument - 將畫面上的新頁次 存入 xmlDoc (注意: 未寫入前 xmlDoc的頁次為 0(初始值); 寫入後為 畫面上的新頁次)
//                    //alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);

//                    // 若為固定頁次的資料, 其頁次不予以修改, 為原指定之頁次
//                    if (xmlDocCom.getElementsByTagName("固定頁次註記")[i].childNodes[0].nodeValue == "是") {
//                        //alert("第 " + i + " 筆為固定頁次");
//                        //alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text);
//                        //xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text;

//                        // 檢查該固定頁次之頁碼長度, 一律輸出轉為 2位數之數字! 
//                        var FixPgno = xmlDocCom.getElementsByTagName("刊登頁碼")[i].childNodes[0].nodeValue;
//                        if (FixPgno.length == 1) {
//                            FixPgno = "0" + FixPgno;
//                        }
//                        else {
//                            FixPgno = FixPgno;
//                        }
//                        //alert("FixPgno= " + FixPgno);

//                        // 輸出結果於 "頁次" 處
//                        xmlDocCom.getElementsByTagName("刊登頁碼")[i].childNodes[0].nodeValue = FixPgno;
//                        xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue = FixPgno;

//                    }
//                    // 反之, 則給予新頁次
//                    else {
//                        //alert(document.all.pageorder[i].innerText);
//                        //alert(document.getElementById("pageorder")[i].innerText);
//                        xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue = document.getElementsByName("pageorder")[i].getAttribute("pageorder");
//                        xmlDocCom.getElementsByTagName("刊登頁碼")[i].childNodes[0].nodeValue = document.getElementsByName("pageorder")[i].getAttribute("pageorder");
//                        //alert(xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);					
//                    }
//                }
//            }
            //檢查寫 新頁次 入 xmlDoc 是否成功
            //alert(xmlDoc.documentElement.xml);
            var Xml_head = xmlDocCom.createProcessingInstruction('xml', "version=\"1.0\" encoding='utf-8'");
            xmlDocCom.insertBefore(Xml_head, xmlDocCom.childNodes[0]);
            var XmlString = xmlDocCom.xml ? xmlDocCom.xml : (new XMLSerializer()).serializeToString(xmlDocCom);
            //var XmlStringAdd = "<version='1.0' encoding='utf-8'>" + XmlString;
            // 更新 hidData 值 - 將新的 xmlDoc 寫入 document.form1("hidData").value 值
                var option = {
                    url: 'adpub_act3.aspx',   //呼叫哪個 ashx
                    call: RequestXML, //拿到值以後 呼叫哪個 function
                    Variable: 'transValueXml=' + XmlString, //傳遞變數
                    type: '', //回傳類型
                    show_alert: false //是不是要秀alert
                }
                comemyfamily_call_Ajax_post(option);

                function RequestXML(e) {
                    alert(e);
                    // 網頁 ReLoad
                    SortNeedPressFirst = false; //用來判斷是否有先把新排序號碼排完才寫回的flag
                    location.reload(true);
                }

//                $.ajax({
//                    type: "POST",
//                    url: "adpub_act3.aspx",
//                    data: { transValueXml: XmlStringAdd },
//                    success: function (response) {
//                        alert("新頁次更新成功!");
//                    },
//                    error: function (e) {
//                        alert(e);
//                    }
//                });
            // 執行 adpub_act3.aspx: 藉傳遞變數 ("hidData").value 值(即 xml資料) 抓出各行之新頁次, 再分別 update 寫入資料庫中			
            // 清除 xmlHTTP 資料為空
            //var xmlHTTP = null;
        }
    </script>
    <!-- 功能表結束 -->
    <script language="javascript">
        // page layout maintain
        function doClick(e) {
            if (btnPressed) {
                if (srcDSO == xmlDocCom) {
                    doPut(e);
                    btnPressed = false;
                    //var gg = false;
                    //for(var i=0; i<document.getElementsByTagName("tb1").length; i++)
                    //{
                    // if(event.srcElement.readyState=="complete")
                    //}
                    //doReOrder();
                }
            }
            else {
                srcDSO = xmlDocCom;
                doPick(e);
                btnPressed = true;
            }
        }


        function doMouseMove(event) {
            var mouseX = Math.round(event.clientX);
            var mouseY = Math.round(event.clientY);

            var bt = document.body.scrollTop;
            var bl = document.body.scrollLeft;

            var et = document.documentElement ?
			    document.documentElement.scrollTop :
				null;
            var el = document.documentElement ?
			    document.documentElement.scrollLeft :
				null;

            var flyingObj = document.getElementById("ico");

            var AddT = bt || et;
            var AddL = bl || el;
            
            jQuery(document).ready(function () {
                $(document).mousemove(function (e) {
                    if (e.pageY > $(window).height() + $(window).scrollTop() - 40) {//此行用來判斷是否點擊的那筆是在螢幕最下方 這樣的話 提示的那個框框就要往上拉30才會看的到
                        $("#ico").get(0).style.top = (parseInt(AddT, 10) + parseInt(mouseY, 10) - 20) + 'px';

                    }
                    else {
                        $("#ico").get(0).style.top = (parseInt(AddT, 10) + parseInt(mouseY, 10) + 20) + 'px';
                    }
                });
            })
            flyingObj.style.left = (parseInt(AddL, 10) + parseInt(mouseX, 10) + 20) + 'px';

            //flyingObj.innerHTML = "scrollTop:" + scrollTop + mouseX + "AddT:" + AddT + mouseX;
        }

        function doPick(e) {
            var ide = e || window.event;
            srcObj = ide.target || ide.srcElement;
            srcObj.style.color = "red";
            srcObj.style.cursor = "hand";
            document.getElementById("ico").style.display = "";

            if (navigator.appName.indexOf("Explorer") > -1) {//firedox innerText 不能用
                document.getElementById("ico").innerText = srcObj.innerText;
            } else {
                document.getElementById("ico").textContent = srcObj.textContent;
            }

            document.getElementById("ico").innerText = srcObj.innerText;
            //alert(srcObj.innerText);
            //下幾行是 for - 自 xml檔案 載入時				
            //segOffset = srcObj.parentElement.parentElement.rowIndex-2;
            ////取出src的XmlDocument
            //var xmlDoc = srcDSO.XMLDocument; 
            //srcNode = xmlDoc.documentElement.childNodes.item(segOffset);
            //return !btnPressed;

            //下幾行是 for - 自 資料庫 載入時
            segOffset = srcObj.parentElement.parentElement.rowIndex - 2;
            //var xmlDoc = xmldoct.XMLDocument; 
        }


        function doPut(ide) {
            //obj為抓出put下去時，發出事件的cell？
            var ide = ide || window.event;
            var obj = ide.target || ide.srcElement;

            //cell->row，然後找出該row的index，-2是去掉兩格的非資料binding區
            var idx = obj.parentElement.parentElement.rowIndex - 2;
            //alert(xmlDocCom.getElementsByTagName("頁次").length);
            //不知道為什麼 xmlDocCom.documentElement.childNodes.length 抓到的是錯的 只好用頁次來抓
            if (idx == (xmlDocCom.getElementsByTagName("頁次").length - 1)) {
                alert("很抱歉, 禁止搬移到最後一個空位置上!");
                srcObj.style.color = "";
                srcObj.style.cursor = "";
                srcObj = null;
                document.getElementById("ico").style.display = "none";
                return;
                //return !btnPressed;
            }
            if (segOffset == (xmlDocCom.getElementsByTagName("頁次").length - 1)) {
                alert("很抱歉, 最後一個空位置禁止搬移!");
                srcObj.style.color = "";
                srcObj.style.cursor = "";
                srcObj = null;
                document.getElementById("ico").style.display = "none";
                return;
                //return !btnPressed;
            }
            if (segOffset == 0) {
                alert("很抱歉, 第一個空位置禁止搬移!");
                srcObj.style.color = "";
                srcObj.style.cursor = "";
                srcObj = null;
                document.getElementById("ico").style.display = "none";
                return;
                //return !btnPressed;
            }
            if (idx == segOffset)		//segOffset是pick起來時，那個row的index
            {
                //alert("the same node"); 
                srcObj.style.color = "";
                srcObj.style.cursor = "";
                srcObj = null;
                document.getElementById("ico").style.display = "none";
                return;
                //return !btnPressed;
            }
//            alert(ReturnThinSelectNode(0, srcNode, "固定頁次註記"));
            //            return;
            var holdPosition = ReturnThinSelectNode(idx, xmlDocCom, "固定頁次註記");
            //STEP2：如果挑選的點是不可移動的點，也不做
            if (holdPosition == "是") {
                //alert("這個node不可以移動"+!btnPressed);
                alert("很抱歉, 這個位置被要求 '固定', 故它不可被移動!");
                srcObj.style.color = "";
                srcObj.style.cursor = "";
                srcObj = null;
                document.getElementById("ico").style.display = "none";
                return;
                //return !btnPressed;
            }

            //下一行是 for - 自 xml檔案 載入時
            //if(xmlDoc.documentElement.childNodes.item(idx).selectSingleNode("固定頁次註記").text =="1")
            //下一行是 for - 自 資料庫 載入時
            //if (xmldoct.documentElement.childNodes.item(idx).selectSingleNode("固定頁次註記").text =="1")
            if (holdPosition == "是") {
                //alert("放下去的點是固定的");
                alert("很抱歉, 您想移到的位置被要求 '固定', 請重新安排新位置!");
                srcObj.style.color = "";
                srcObj.style.cursor = "";
                srcObj = null;
                document.getElementById("ico").style.display = "none";
                return;
                //return !btnPressed
            }
//            alert(segOffset + "&" + idx);
//            return;
            //Owen Add
            var OrgNode = null;
            var newNode = null;
            var idxAddOne = parseInt(idx, 10) + 1;       
            if (parseInt(segOffset,10) > parseInt(idx, 10)) {
                //Move Up
                for (var IndexItem = segOffset; IndexItem > idxAddOne; IndexItem--) {
                   //alert("IndexItem=" + IndexItem + "&idx + 1=" + idxAddOne);
                   //alert(xmlDocCom.documentElement.childNodes.item(IndexItem));
                   //var aaa = (new XMLSerializer()).serializeToString(xmlDocCom.documentElement.childNodes.item.length);
                    //alert(xmlDocCom.getElementsByTagName("公司名稱")[IndexItem].childNodes[0].nodeValue);
                    //alert("idx=" + idx + "segOffset=" + segOffset);
                    //OrgNode = xmlDocCom.documentElement.childNodes.item(IndexItem).cloneNode(true);
                    //newNode = xmlDocCom.documentElement.childNodes.item(IndexItem - 1).cloneNode(true);
                    OrgNode = xmlDocCom.getElementsByTagName("item")[IndexItem].cloneNode(true);
                    newNode = xmlDocCom.getElementsByTagName("item")[IndexItem - 1].cloneNode(true);
                    xmlDocCom.documentElement.replaceChild(newNode, xmlDocCom.getElementsByTagName("item")[IndexItem]);
                    xmlDocCom.documentElement.replaceChild(OrgNode, xmlDocCom.getElementsByTagName("item")[IndexItem - 1]);
                    OrgNode = null;
                    newNode = null;
                }
            }
            else if (parseInt(segOffset,10) < parseInt(idx, 10)) {
                //Move Down
                for (var IndexItem = segOffset; IndexItem < idx; IndexItem++) {
                    OrgNode = xmlDocCom.getElementsByTagName("item")[IndexItem].cloneNode(true);
                    newNode = xmlDocCom.getElementsByTagName("item")[IndexItem + 1].cloneNode(true);
                    xmlDocCom.documentElement.replaceChild(newNode, xmlDocCom.getElementsByTagName("item")[IndexItem]);
                    xmlDocCom.documentElement.replaceChild(OrgNode, xmlDocCom.getElementsByTagName("item")[IndexItem + 1]);
//                    OrgNode = xmlDocCom.documentElement.childNodes.item(IndexItem).cloneNode(true);
//                    newNode = xmlDocCom.documentElement.childNodes.item(IndexItem + 1).cloneNode(true);
//                    xmlDocCom.documentElement.replaceChild(newNode, xmlDocCom.documentElement.childNodes.item(IndexItem));
//                    xmlDocCom.documentElement.replaceChild(OrgNode, xmlDocCom.documentElement.childNodes.item(IndexItem + 1));
                    OrgNode = null;
                    newNode = null;
                }
            }

            //alert(xmlDocCom.getElementsByTagName("頁次")[0].childNodes[0].nodeValue);
            //下一行是 for - 自 xml檔案 載入時
            //var xmlRefList = srcDSO.XMLDocument.documentElement.cloneNode(true); 
            //xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);
					
            //下一行是 for - 自 資料庫 載入時
//            var xmlRefList = DSOT.XMLDocument.documentElement.cloneNode(true); 
//            xmlDoc.documentElement.insertBefore(srcNode, xmlDoc.documentElement.childNodes.item(idx).nextSibling);

            LoadCommonXml();
            srcObj.style.color = "";
            srcObj.style.cursor = "";
            srcObj = null;
            document.getElementById("ico").style.display = "none";
            //return !btnPressed;
        }

        function SortArr() {
            var Temp;

            for (var i = 0; i < (Arr.length - 1); i++)
                for (var j = i; j < Arr.length; j++)
                    if (Arr[j] > Arr[i]) {
                        Temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = Temp;
                    };
        }

        // 按下 重排頁次 的動作 function
        function doReOrder() {
            alert("重排頁次中...請稍後!");


            //取出src的XmlDocument
            //注意: 之前 function 有指定 srcDSO == theDSO (即DSO1); 所以下一行要變更直接load DSO1, 非 srcDSO; 否則若page一load時, 去按 "重排頁次" 會發生錯誤
            //var xmlDoc = srcDSO.XMLDocument; 

            //下一行是 for - 自 xml檔案 載入時
            //var xmlDoc = DSO1.XMLDocument; 
            //alert(xmlDoc.documentElement.xml); 

            //下一行是 for - 自 資料庫 載入時
            //var xmlDoc = DSO1.XMLDocument;
            //alert(xmlDoc.documentElement.xml); 
            //alert("xmlDoc.getElementsByTagName("頁次").length= " + xmlDoc.getElementsByTagName("頁次").length);


            // 測試 Arr 是否在此 function 可抓得到 (a Global Variable; 已定義在 Initial Client Side Script 裡, Line 61)
            //alert("Arr= " + Arr);

            // 指定 固定頁次=是, 則其 新頁次 = 刊登頁碼之DB值
            var FixPageNo = "";
            while (Arr.length != 0)
                Arr.pop();
            for (var j = 0; j < xmlDocCom.getElementsByTagName("頁次").length; j++) {
                //alert("公司名稱= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("公司名稱").text);
                if (xmlDocCom.getElementsByTagName("公司名稱")[j].childNodes[0].nodeValue != "xxx") {
                    // 若 固定頁次=是, 則其 新頁次 = 刊登頁碼之DB值
                    //alert("固定頁次註記(" + j + ")= " + xmlDoc.documentElement.childNodes.item(j).selectSingleNode("固定頁次註記").text);
                    if (xmlDocCom.getElementsByTagName("固定頁次註記")[j].childNodes[0].nodeValue == "是") {
                        // 抓出 其刊登頁碼之值
                        FixPageNo = xmlDocCom.getElementsByTagName("刊登頁碼")[j].childNodes[0].nodeValue;
                        //alert("FixPageNo= " + FixPageNo);
                        if (xmlDocCom.getElementsByTagName("廣告篇幅")[j].childNodes[0].nodeValue == "半頁")
                            FixPageNo = parseInt(FixPageNo) - 0.5;
                        // 將 刊登頁碼值 塞入 Arr 裡, 以供 doIsInArray() & doNewPageNo() 使用
                        Arr.push(FixPageNo);
                        //alert("Arr= " + Arr);
                        //alert("Arr.length=" + Arr.length);

                        // 指定 固定頁次=是, 則其 新頁次 = 刊登頁碼之DB值
                        //xmlDoc.documentElement.childNodes.item(j).selectSingleNode("刊登頁碼").text = xmlDoc.documentElement.childNodes.item(j).selectSingleNode("刊登頁碼").text;
                        //xmlDoc.documentElement.childNodes.item(j).selectSingleNode("頁次").text = FixPageNo;
                    }
                }
                // 若公司名稱的值為 "xxx" , 表示為空白的 nodes, 將不做計算頁次的處理, 做清除處理
                else {
                    //alert("null");
                    // 不做任何處理, 清除 頁次 & 刊登頁碼 為空
                    //xmlDocCom.getElementsByTagName("頁次")[j].childNodes[0].nodeValue = "";
                    //xmlDocCom.getElementsByTagName("刊登頁碼")[j].childNodes[0].nodeValue = "";
                }
            }
            Arr.reverse();
            SortArr();
            //alert("Arr= " + Arr);
            //alert("Arr.length=" + Arr.length);

            // pp 為新頁次, 長度由 0 ~ xmlDoc.getElementsByTagName("頁次").length
            //alert(xmlDoc.getElementsByTagName("頁次").length);
            //alert("pageorder.length=" + (document.all.pageorder.length-2) );
            var NewPageNo1 = "";
            var pp = parseInt(document.getElementById("<% =tbxStartPageNo.ClientID%>").value) - 1;
            var FixedPage = "";
            for (var i = 1; i < (xmlDocCom.getElementsByTagName("頁次").length - 1); i++) {
                // 抓出所有落版資料
                // 抓出 行數及其刊登頁碼 之值
                //alert("刊登頁碼(" + i + ")= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text);
                //pp = xmlDoc.documentElement.childNodes.item(i).selectSingleNode("刊登頁碼").text;

                // 檢查 新頁次 NewPageNo  是否與 固定頁次註記="是"之刊登頁碼值 相衝突
                // 若 固定頁次註記 為 "否" 時, doIsInArray()
                if (xmlDocCom.getElementsByTagName("固定頁次註記")[i].childNodes[0].nodeValue != "是") {
                    // 計算出 新頁次 pp = 1 ~ document.all.pageorder.length-1
                    if (xmlDocCom.getElementsByTagName("廣告篇幅")[i].childNodes[0].nodeValue == "半頁") {
                        if ((i > 2) && (xmlDocCom.getElementsByTagName("廣告篇幅")[i - 1].childNodes[0].nodeValue == "全頁") && ((pp % 1) != 0))
                            pp = pp + 0.5;
                        pp = pp + 0.5;
                    }
                    else if (xmlDocCom.getElementsByTagName("廣告篇幅")[i].childNodes[0].nodeValue == "全頁")
                        pp = pp + 1;
                    else //Error
                        pp = pp + 1;
                    //alert("計算出 新頁次 " + pp);

                    // 新頁次 pp  與 固定頁次之刊登頁碼 Arr[i] 有衝突時
                    if (doIsInArray(pp) == 1) {
                        NewPageNo1 = doNewPageNo(pp);
                        //alert("NewPageNo1: " +NewPageNo1);
                        xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue = Math.ceil(NewPageNo1);
                        pp = NewPageNo1;
                    }
                    // 新頁次 pp  與 固定頁次之刊登頁碼 Arr[i] 無衝突時
                    else {
                        xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue = Math.ceil(pp);
                    }

                }
                // 若 固定頁次註記 為 "是" 時, 指定其 新頁次 = 刊登頁碼 )
                else {
                    FixedPage = xmlDocCom.getElementsByTagName("刊登頁碼")[i].childNodes[0].nodeValue;
                    //alert("刊登頁碼= " + FixedPage);	
                    xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue = FixedPage;
                    //alert("頁次= " + xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text);

                }

                // 6/24/2003 bug: 因修訂了 doSortingXML(), 故移除下段, 否則會發生新頁次由 8, 9, 6, 7 開始排
                // 檢查該固定頁次之頁碼長度, 一律輸出轉為 2位數之數字!
                // 若 新頁次 為個位數, 做前面補零的動作
                //if(document.all.pageorder[i].innerText < 10)
                //{
                //document.all.pageorder[i].innerText = "0" + document.all.pageorder[i].innerText;
                //xmlDoc.documentElement.childNodes.item(i).selectSingleNode("頁次").text = document.all.pageorder[i].innerText;
                //};
                //alert("document.all.pageorder[i].innerText= " + document.all.pageorder[i].innerText);
            }
            //Sorting
            doSortingXML();
            SortNeedPressFirst = true;
            LoadCommonXml();
            alert("重排頁次完成...請檢視!");
        }

        function doSortingXML() {
            //var xmlDoc = DSO1.XMLDocument;
            var MinPageNo, SrcPageNo, DesPageNo, ItemtoMoved;

            for (var i = 1; i < (xmlDocCom.getElementsByTagName("頁次").length - 2); i++) {
                // 6/24/2003 bug: 當新頁次超過100時, 並沒有排在 99之後, 卻排在9之後, 如 10, 100~109, 11, 11x...; 解決: SrcPageNo & DesPageNo 加 parseInt()
                SrcPageNo = parseInt(xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue);
                //alert("Item to Compare " + i +" PageNo: " + SrcPageNo);
                MinPageNo = SrcPageNo;
                for (var j = (i + 1); j < (xmlDocCom.getElementsByTagName("頁次").length - 1); j++) {
                    DesPageNo = parseInt(xmlDocCom.getElementsByTagName("頁次")[i].childNodes[0].nodeValue);
                    //alert("Item to be Compared " + j +" PageNo: " + DesPageNo);
                    if (DesPageNo < MinPageNo) {
                        //alert("Find Smaller Page in Item " +j + " PageNo: " + DesPageNo);
                        MinPageNo = DesPageNo;
                        ItemtoMoved = j;
                    };
                };

                //Find Item to Move
                if (MinPageNo != SrcPageNo) {
                    //alert("Src Item " + i +" Des Item " + ItemtoMoved);
                    var OrgNode = xmlDocCom.getElementsByTagName("item")[ItemtoMoved].cloneNode(true);
                    var newNode = xmlDocCom.getElementsByTagName("item")[i].cloneNode(true);
                    xmlDocCom.documentElement.replaceChild(newNode, getElementsByTagName("item")[ItemtoMoved]);
                    xmlDocCom.documentElement.replaceChild(OrgNode, xmlDocCom.getElementsByTagName("item")[i]);
                    OrgNode = null;
                    newNode = null;
                };
            };
        }

        // for doReOrder() 裡使用
        function doIsInArray(pp1) {
            // 抓出 固定頁次註記='是' 之刊登頁碼值
            for (var i = 0; i < Arr.length; i++) {
                //alert("Arr[i]= " + Arr[i] + ", pp1=" + pp1);
                // 若 新頁次 = 固定頁次註記='是' 之刊登頁碼值 時
                if ((pp1 == Arr[i]) || (Math.ceil(pp1) == Arr[i]) || (pp1 == Math.ceil(Arr[i]))) {
                    return 1;
                }
            }
            return 0;
        }


        // for doReOrder() 裡使用
        function doNewPageNo(pp2) {
            var Offset;

            while ((Offset = doIsPageOccupied(pp2)) != 0) {
                pp2 = pp2 + Offset;
            }
            return pp2;
        }


        // for NewPageNo() 裡使用
        function doIsPageOccupied(pp1) {
            // 抓出 固定頁次註記='是' 之刊登頁碼值
            //alert("Arr= "+Arr);
            for (var i = 0; i < Arr.length; i++) {
                //alert("Arr[i]= " + Arr[i] + ", pp1=" + pp1);
                // 若 新頁次 = 固定頁次註記='是' 之刊登頁碼值 時
                if ((pp1 == Arr[i]) || (Math.ceil(pp1) == Arr[i]) || (pp1 == Math.ceil(Arr[i]))) {
                    //alert("Find");
                    if (((pp1 % 1) != 0) && ((Arr[i] % 1) != 0)) {
                        Arr.pop();
                        return 0.5;
                    }
                    else {
                        Arr.pop();
                        return 1;
                    };
                };
            }
            return 0;
        }

        // function doRePublish() 重新排版，已停用

        var srcDSO = new Object();
        var btnPressed = false;
        var srcObj = new Object();
        var segIdx = 0;
        var segOffset = 0;
        var SortNeedPressFirst = false;
    </script>
    <!-- idCompanyName 之 OnMouseOver 色塊顏色 -->
    <script language="javascript" event="onmouseover" for="idCompanyName">
					style.backgroundColor='Gold';
					style.cursor="hand";
    </script>
    <!-- idCompanyName 之 OnMouseOut 色塊顏色 -->
    <script language="javascript" event="onmouseout" for="idCompanyName">
					style.backgroundColor='';
					style.cursor="default";
    </script>
    <!-- fMenu 之 OnMouseOver 色塊顏色  -->
    <script language="javascript" event="onmouseover" for="fMenu">
					event.srcElement.style.backgroundColor='Gold';
					event.srcElement.style.cursor="hand";
    </script>
    <!-- fMenu 之 OnMouseOut 色塊顏色  -->
    <script language="javascript" event="onmouseout" for="fMenu">
					event.srcElement.style.backgroundColor='';
					event.srcElement.style.cursor="";
    </script>
</asp:Content>
