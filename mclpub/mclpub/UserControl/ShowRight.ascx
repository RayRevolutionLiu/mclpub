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
					<li><a href="<%=ResolveUrl("~/Subscriber/Customer.aspx")%>" target="_self">廣告客戶資料維護</a></li>
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
                            <li><a href="<%=ResolveUrl("~/Contract/RptCustQuery.aspx")%>" target="_self">客戶基本資料清單</a></li>
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
                            <li>
                                <a href="#" target="_self">補書處理</a>
                                    <ul>
                                        <li><a href="<%=ResolveUrl("~/Order/RemailSearch.aspx?function1=new")%>" target="_self">補書登錄</a></li>
                                        <li><a href="<%=ResolveUrl("~/Order/RemailSearch.aspx?function1=mod")%>" target="_self">補書單修改/查詢</a></li>
                                        <li><a href="<%=ResolveUrl("~/Order/RmListFilter.aspx")%>" target="_self">補書清單</a></li>
                                    </ul>  
                            </li>
					    </ul>
					</li>
				</ul>
			</li>
            <li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn04_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn04_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn04_out.gif")%>'"></a>	
				<ul>
					<li>
					    <a href="#" target="_self">雜誌叢書標籤處理</a>
					    <ul>      
					        <li><a href="<%=ResolveUrl("~/LabelArea/search_label.aspx")%>" target="_self">大宗標籤</a></li>
					        <li><a href="<%=ResolveUrl("~/LabelArea/RmLabelFilter.aspx")%>" target="_self">補書標籤</a></li>
<%--					        <li><a href="<%=ResolveUrl("~/LabelArea/LstLabelFilter.aspx")%>" target="_self">缺書標籤</a></li>--%>
					        <li><a href="<%=ResolveUrl("~/LabelArea/appriseFilter.aspx")%>" target="_self">續訂通知標籤</a></li>
					    </ul>
					</li>
                    <li>
					    <a href="#" target="_self">平面廣告標籤處理</a>
					    <ul>      
					        <li><a href="<%=ResolveUrl("~/LabelArea/PubFm_label_search.aspx")%>" target="_self">合約內有刊登標籤</a></li>
					        <li><a href="<%=ResolveUrl("~/LabelArea/PubFm_label_search2.aspx")%>" target="_self">合約內未刊登標籤</a></li>
                            <li><a href="<%=ResolveUrl("~/LabelArea/PubFm_label_search3.aspx")%>" target="_self">合約外標籤</a></li>
                            <li><a href="<%=ResolveUrl("~/LabelArea/PubFm_label_search3Print.aspx")%>" target="_self">合約外標籤列印</a></li>
					    </ul>
                    </li>
                    <li>
					    <a href="#" target="_self">網路廣告標籤處理</a>
					    <ul>      
					        <li><a href="<%=ResolveUrl("~/LabelArea/Pub_LabelFilter.aspx")%>" target="_self">大宗標籤(當月刊登)</a></li>
					        <li><a href="<%=ResolveUrl("~/LabelArea/UnPub_LabelFilter.aspx")%>" target="_self">大宗標籤(當月未刊登)</a></li>
<%--					        <li><a href="<%=ResolveUrl("~/LabelArea/RmLabelFilterInternet.aspx")%>" target="_self">補書標籤</a></li>
					        <li><a href="<%=ResolveUrl("~/LabelArea/LostLabelFilter.aspx")%>" target="_self">缺書標籤</a></li>--%>
					    </ul>
                    </li>
				</ul>
			</li>
            <li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn05_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn05_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn05_out.gif")%>'"></a>	
				<ul>
                    <li>
                    <a href="#" target="_self">平面廣告落版處理</a>
                    <ul>
                        <li>
                            <a href="#" target="_self">新增/維護/顯示 落版</a>
                            <ul>
                                <li><a href="<%=ResolveUrl("~/Layout/pub_new1.aspx")%>" target="_self">由合約書進入</a></li>
                                <li><a href="<%=ResolveUrl("~/Layout/pub_new2.aspx")%>" target="_self">由年月落版進入</a></li>      
                            </ul>
                        </li>
                        <li><a href="<%=ResolveUrl("~/Layout/PubFm_chklist.aspx")%>" target="_self">落版檢核表</a></li>
                        <li><a href="<%=ResolveUrl("~/Layout/contpubfm_search.aspx")%>" target="_self">顯示合約及落版資料</a></li>
                        <li><a href="<%=ResolveUrl("~/Layout/adpub_act1.aspx?action=1")%>" target="_self">廣告排版動作</a></li>
                        <li><a href="<%=ResolveUrl("~/Layout/adpub_act1.aspx?action=2")%>" target="_self">美編樣後修正</a></li>
                        <li><a href="<%=ResolveUrl("~/Layout/adpub_form.aspx")%>" target="_self">廣告落版單</a></li>
                        <li><a href="<%=ResolveUrl("~/Layout/adpub_list.aspx")%>" target="_self">廣告落版清單</a></li>
                        <li><a href="<%=ResolveUrl("~/Layout/admade_stat.aspx")%>" target="_self">廣告製稿統計表</a></li>
                        <li>
                            <a href="#" target="_self">相關維護區</a>
                            <ul>
                                <li><a href="<%=ResolveUrl("~/Layout/adlprior.aspx")%>" target="_self">版面優先次序</a></li>
                                <li><a href="<%=ResolveUrl("~/Layout/pgno.aspx")%>" target="_self">內頁起始頁碼</a></li>
                                <li><a href="<%=ResolveUrl("~/Layout/adcolor.aspx")%>" target="_self">廣告色彩</a></li>
                                <li><a href="<%=ResolveUrl("~/Layout/adlayout.aspx")%>" target="_self">廣告版面</a></li>
                                <li><a href="<%=ResolveUrl("~/Layout/adpgsize.aspx")%>" target="_self">廣告篇幅</a></li>
                                <li><a href="<%=ResolveUrl("~/Layout/njtype.aspx")%>" target="_self">新稿製法</a></li>
                            </ul>
                            
                        </li>
                    </ul>
                    </li>
                    <li>
                        <a href="#" target="_self">網路廣告落版處理</a>
                        <ul>
                            <li>
                                <a href="<%=ResolveUrl("~/Layout/AdrQueryCont.aspx")%>" target="_self">
                                    廣告落版處理
                                </a>
                             </li>

                            <li><a href="<%=ResolveUrl("~/Layout/RptAdrBillQuery.aspx")%>" target="_self">廣告落版單</a></li>
                            <%--<li><a href="<%=ResolveUrl("~/Layout/RptAdrQuery.aspx")%>" target="_self">廣告落版統計表</a></li>--%>
                            <li><a href="<%=ResolveUrl("~/Layout/AdrQueryPublished.aspx")%>" target="_self">美編上稿處理</a></li>
                            <li><a href="<%=ResolveUrl("~/Layout/RptFileUpQuery.aspx")%>" target="_self">美編上稿清單</a></li>
                            <li><a href="<%=ResolveUrl("~/Layout/AdrGenXml.aspx")%>" target="_self">產生播出檔</a></li>
<%--                            <li><a href="<%=ResolveUrl("~/Layout/AdrXmlManage.aspx")%>" target="_self">刪除播出檔</a></li>--%>
                        </ul>
                    </li>
				</ul>
			</li>

            <li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn06_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn06_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn06_out.gif")%>'"></a>	              	
				<ul>
                    <li><a href="#" target="_self">雜誌叢書發票處理</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/SetAccount/CreateIa.aspx")%>" target="_self">發票開立單產生</a></li>
                            <li><a href="<%=ResolveUrl("~/SetAccount/CheckList3.aspx")%>" target="_self">發票開立單檢核表</a></li>
                            <li><a href="<%=ResolveUrl("~/SetAccount/RecoveryIa.aspx")%>" target="_self">發票開立單回復(Recovery)</a></li>
                            <li><a href="<%=ResolveUrl("~/SetAccount/DeleteIa.aspx")%>" target="_self">註銷發票(未繳款之發票)</a></li>
                            <li><a href="<%=ResolveUrl("~/SetAccount/SpecialFM.aspx")%>" target="_self">已繳款之發票退回處理</a></li>
                        </ul>
                    </li>
                    <li><a href="#" target="_self">平面廣告發票處理</a>
                        <ul>
                            <li><a href="#" target="_self">發票開立單產生</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm1_Add.aspx")%>" target="_self">一次付款</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm2_Addia.aspx")%>" target="_self">大批月結</a></li>
                                </ul>
                            </li>
                            <li><a href="#" target="_self">發票開立單檢核表</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm1_Chklist_query.aspx")%>" target="_self">一次付款</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm1_chklist2.aspx")%>" target="_self">一次付款(當月刊登清單)</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm2_Chklist_ia.aspx?bkcd=&yyyymm=&sort=&iabseq=")%>" target="_self">大批月結</a></li>
                                </ul>
                            </li>
                            <li><a href="#" target="_self">發票開立單回復(Recovery)</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm1_Rec.aspx")%>" target="_self">一次付款</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/iaFm2_RecAll.aspx")%>" target="_self">大批月結</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li><a href="#" target="_self">網路廣告發票處理</a>
                        <ul>
                            <li><a href="#" target="_self">發票開立單產生</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/IA1Query.aspx")%>" target="_self">單一廠商</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/IAQuery.aspx")%>" target="_self">大批月結</a></li>
                                </ul>
                            </li>
                            <li><a href="#" target="_self">發票開立檢核表</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/RptIA1_ChkFilter.aspx")%>" target="_self">單一廠商</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/RptIA_ChkFilter.aspx")%>" target="_self">大批月結</a></li>
                                </ul>
                            </li>
                            <li><a href="#" target="_self">發票開立單回復</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/IA1RecoveryQuery.aspx")%>" target="_self">單一廠商</a></li>
                                    <li><a href="<%=ResolveUrl("~/SetAccount/IARecoveryQuery.aspx")%>" target="_self">大批月結</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li><a href="#" target="_self">繳款處理</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/Pay/PayFilter.aspx")%>" target="_self">新增繳款單</a></li>
                            <li><a href="<%=ResolveUrl("~/Pay/PayFMFilter.aspx")%>" target="_self">修改繳款單</a></li>
                            <li><a href="<%=ResolveUrl("~/Pay/PayDelete.aspx")%>" target="_self">刪除繳款單</a></li>
                            <li><a href="<%=ResolveUrl("~/Pay/CheckList7.aspx")%>" target="_self">繳款單檢核表</a></li>
                            <li><a href="<%=ResolveUrl("~/Pay/PayListFilter.aspx")%>" target="_self">產生繳款清單</a></li>
                            <li><a href="<%=ResolveUrl("~/Pay/RecoveryPayList.aspx")%>" target="_self">繳款清單回復(Recovery)</a></li>
                            <li><a href="<%=ResolveUrl("~/Pay/PayListPrint.aspx")%>" target="_self">列印繳款清單</a></li>
                        </ul>
                    </li>
					<li><a href="<%=ResolveUrl("~/SetAccount/SetSAPManage.aspx")%>" target="_self">發票轉檔</a></li>
                    <li><a href="<%=ResolveUrl("~/SetAccount/InvoiceListPrintCancle.aspx")%>" target="_self">發票列印與回覆</a></li>
                    <li><a href="<%=ResolveUrl("~/SetAccount/SAPListEdit.aspx")%>" target="_self">發票開立清單查詢</a></li>
                    <li><a href="<%=ResolveUrl("~/Pay/UnpaidListFilter.aspx")%>" target="_self">催款處理</a></li>
                    <li><a href="<%=ResolveUrl("~/SetAccount/SAP.aspx")%>" target="_self">發票開立單轉SAP<br />(會計中心)</a>
                    <li><a href="<%=ResolveUrl("~/SetAccount/GetInvno.aspx")%>" target="_self">發票號碼取回</a>
				</ul>
			</li>

            <li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn07_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn07_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn07_out.gif")%>'"></a>	
				<ul>
					<li><a href="#" target="_self">雜誌叢書報表</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/Statistics/IncomeFilter.aspx")%>" target="_self">收入統計表</a></li>
                            <li><a href="<%=ResolveUrl("~/Statistics/BookMntFilter.aspx")%>" target="_self">印製份數統計表</a></li>
                            <li><a href="<%=ResolveUrl("~/Statistics/CustMntFilter.aspx")%>" target="_self">客戶份數表</a></li>
                        </ul>
                    </li>
                    <li><a href="#" target="_self">平面廣告報表</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/Statistics/adincome_stat.aspx")%>" target="_self">廣告收入統計表</a></li>
                            <li><a href="#" target="_self">郵寄本數統計表</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/Statistics/orcounts_stat_search1.aspx")%>" target="_self">當月刊登</a></li>
                                    <li><a href="<%=ResolveUrl("~/Statistics/orcounts_stat_search2.aspx")%>" target="_self">當月未刊登</a></li>
<%--                                    <li><a href="<%=ResolveUrl("~/Statistics/orcounts_stat_search3.aspx")%>" target="_self">合約外寄送</a></li>--%>
                                </ul>
                            </li>
                            <li><a href="#" target="_self">印製份數統計表</a>
                                <ul>
                                    <li><a href="<%=ResolveUrl("~/Statistics/ormtpcounts_stat_search1.aspx")%>" target="_self">當月刊登</a></li>
                                    <li><a href="<%=ResolveUrl("~/Statistics/ormtpcounts_stat_search2.aspx")%>" target="_self">當月未刊登</a></li>
<%--                                    <li><a href="<%=ResolveUrl("~/Statistics/ormtpcounts_stat_search3.aspx")%>" target="_self">合約外寄送</a></li>--%>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li><a href="#" target="_self">網路廣告報表</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/Statistics/RptIncomeQuery.aspx")%>" target="_self">廣告收入統計表</a></li>
                        </ul>
                    </li>
				</ul>
			</li>
            <li class="current">
				<a href="#" target="_self"><img src="<%=ResolveUrl("~/Art/images/btn08_out.gif")%>" border="0" onMouseOver="this.src='<%=ResolveUrl("~/Art/images/btn08_over.gif")%>'" onMouseOut="this.src='<%=ResolveUrl("~/Art/images/btn08_out.gif")%>'"></a>	
				<ul>
<%--                    <li>
                        <a href="<%=ResolveUrl("~/Sys/proj.aspx")%>" target="_self">雜誌叢書缺書</a>
                        <ul>
                            <li><a href="<%=ResolveUrl("~/Sys/LostSearch.aspx?function1=new")%>" target="_self">
                                缺書登錄</a></li>
                            <li><a href="<%=ResolveUrl("~/Sys/LostSearch.aspx?function1=mod")%>" target="_self">
                                缺書單修改/查詢</a></li>
                            <li><a href="<%=ResolveUrl("~/Sys/LostListFilter.aspx")%>" target="_self">缺書清單</a></li>
                        </ul>d
                    </li>--%>
                    <li><a href="<%=ResolveUrl("~/Sys/proj.aspx")%>" target="_self">計劃代號維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/book.aspx")%>" target="_self">書籍資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/bookp.aspx")%>" target="_self">書籍期別資料</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/itp.aspx")%>" target="_self">領域代碼資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/btp.aspx")%>" target="_self">營業代碼資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/syscd.aspx")%>" target="_self">系統代碼資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/mtp.aspx")%>" target="_self">郵寄類別資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/ores.aspx")%>" target="_self">訂單來源檔資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/otp.aspx")%>" target="_self">訂購類別檔資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/pytp.aspx")%>" target="_self">付款方式資料維護</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/srspn.aspx")%>" target="_self">管理業務人員</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/S_FixCostCenter.aspx")%>" target="_self">成本中心異動修正</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/refm.aspx")%>" target="_self">轉 SAP 發票摘要檔</a></li>
                    <li><a href="<%=ResolveUrl("~/Sys/refd.aspx")%>" target="_self">轉 SAP 傳票摘要檔</a></li>
                     <li><a href="<%=ResolveUrl("~/Sys/S_SearchCust1.aspx")%>" target="_self">新增舊訂單(不新增ia及py)</a></li>
				</ul>
			</li>
</ul>
</div>	</div><!--{* main *}-->
