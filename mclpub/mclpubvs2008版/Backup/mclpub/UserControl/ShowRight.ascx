<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowRight.ascx.cs" Inherits="mclpub.UserControl.ShowRight" %>
    <div id="main">
    <div class="home"><a href="<%=ResolveUrl("~/Default.aspx")%>" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn_home.gif")%>" border="0" /></a></div>
    <div id="headerinfo" class="font_black font_size13">

<table border="0" width="510" cellspacing="0" cellpadding="0" summary="header info">
  <tr>
    <td height="40">
    <span class="font_size18 font_bold">
        <asp:Label ID="Name" runat="server" Text="Label"></asp:Label></span>&nbsp;
    您好&nbsp;
<%--    您的管理等級為:<span class="font_size18 font_bold font_red"><asp:Label ID="Level" runat="server"
        Text="Label"></asp:Label></span>級，--%>
        請從以下主選單開始操作管理功能。
    </td>
  </tr>
</table>

    </div><!--{* headerinfo *}-->
	<div id="menu">
<ul class="sf-menu">
			<li class="current">
            <a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn01_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn01_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn01_out.gif")%>'"></a>
            	<ul>
					<li><a href="<%=ResolveUrl("~/Subscriber/Customer.aspx")%>" target="_self">客戶資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Subscriber/PubSearchCust.aspx")%>" target="_self">雜誌叢書訂戶資料</a></li>
                    <li><a href="<%=ResolveUrl("~/Subscriber/Printadvert.aspx")%>" target="_self">平面廣告推廣戶</a></li>
                    <li><a href="#" target="_self">材料世界網訂戶</a></li>
                    <li><a href="<%=ResolveUrl("~/Subscriber/Company.aspx")%>" target="_self">廠商資料維護</a></li>
				</ul>

            </li>
<!--{* 單一選項兩層次選單 start *}-->
    		<li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn02_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn02_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn02_out.gif")%>'"></a>	
				<ul>
					<li>
                    <a href="#" target="_self">平面廣告合約書</a>
                        <ul>
                    	    <li><a href="<%=ResolveUrl("~/Contract/PlaneCont.aspx")%>" target="_self">合約書</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/ContFm_chklist.aspx")%>" target="_self">合約書檢核表</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/CancelAndColseShow.aspx")%>" target="_self">(註銷/結案)合約書</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/cont_list.aspx")%>" target="_self">合約書清單</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/contfm_chk.aspx")%>" target="_self">合約書錯誤資料清單</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" target="_self">網路廣告合約書</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/Contract/InterPlaneCont.aspx")%>" target="_self">合約書</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/ContChkList.aspx")%>" target="_self">合約書檢核表</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/RptCont.aspx")%>" target="_self">合約書清單</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/RptAdAmtQuery.aspx")%>" target="_self">廣告費用檢查清單</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/ContCanceled.aspx")%>" target="_self">已註銷合約處理</a></li>
                            <li><a href="<%=ResolveUrl("~/Contract/RptCustQuery.aspx")%>" target="_self">網路廣告客戶</a></li>
                        </ul>
                    </li>
                    <!--{* 第三層次選單 start *}
                    <ul>
                    	<li><a href="#" target="_self">submenu</a></li>
                        <li><a href="#" target="_self">submenu</a></li>
                        <li><a href="#" target="_self">submenu</a></li>
                    </ul>
					{* 第三層次選單 end *}
                    </li>

                    <li><a href="#" target="_self">工材廣告</a></li>-->
				</ul>
			</li>
<!--{* 單一選項兩層次選單 over *}-->            
            <li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn03_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn03_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn03_out.gif")%>'"></a>	
				<ul>
					<li>
					    <a href="#" target="_self">雜誌叢書訂單處理</a>
					    <ul>      
					        <li><a href="<%=ResolveUrl("~/Order/SearchCustOrder.aspx?type=01")%>" target="_self">訂閱訂單</a></li>
					        <li><a href="<%=ResolveUrl("~/Order/SearchCustOrder.aspx?type=03")%>" target="_self">推廣戶訂單</a></li>
					        <li><a href="<%=ResolveUrl("~/Order/SearchCustOrder.aspx?type=02")%>" target="_self">贈戶訂單</a></li>
					        <li><a href="<%=ResolveUrl("~/Order/BulkOrder.aspx")%>" target="_self">贈戶訂單整批作業</a></li>
					        <li><a href="<%=ResolveUrl("~/Order/SearchCustOrder.aspx?type=09")%>" target="_self">零售訂單</a></li>
					        <li><a href="<%=ResolveUrl("~/Order/CheckList.aspx")%>" target="_self">訂單檢核表</a></li>
					        <li><a href="<%=ResolveUrl("~/Order/OrderListFilter.aspx")%>" target="_self">訂單明細表</a></li>
					    </ul>
					</li>
				</ul>
			</li>
            <li class="current">
				<a href="page04.html" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn04_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn04_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn04_out.gif")%>'"></a>	
				
			</li>
            <li class="current">
				<a href="page05.html" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn05_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn05_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn05_out.gif")%>'"></a>	
				<ul>

					<li><a href="#" target="_self">版面管理</a></li>
                    <li><a href="<%=ResolveUrl("~/Art/DownPage.aspx")%>" target="_self">落版管理</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page06.html" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn06_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn06_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn06_out.gif")%>'"></a>	
				<ul>
					<li><a href="#" target="_self">發票管理</a></li>

                    <li><a href="#" target="_self">繳款</a></li>
                    <li><a href="#" target="_self">付款</a></li>
                    <li><a href="#" target="_self">SAP功能</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page07.html" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn07_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn07_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn07_out.gif")%>'"></a>	
				<ul>

					<li><a href="#" target="_self">統計報表</a></li>
                    <li><a href="#" target="_self">統計匯出</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page08.html" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn08_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn08_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn08_out.gif")%>'"></a>	
				<ul>
					<li><a href="#" target="_self">權限設定</a></li>

                    <li><a href="#" target="_self">參數設定</a></li>
                    <li><a href="#" target="_self">角色管理</a></li>
				</ul>
			</li>
</ul>
</div>	</div><!--{* main *}-->
